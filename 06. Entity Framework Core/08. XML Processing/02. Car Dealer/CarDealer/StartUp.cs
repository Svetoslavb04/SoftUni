using AutoMapper;
using CarDealer.Data;
using CarDealer.Dtos.Import;
using CarDealer.Models;
using System.IO;
using System.Xml.Serialization;
using System;
using System.Linq;
using System.Collections.Generic;
using AutoMapper.QueryableExtensions;
using CarDealer.Dtos.Export;
using Microsoft.EntityFrameworkCore;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            var context = new CarDealerContext();

            using (context)
            {
                Console.WriteLine(GetSalesWithAppliedDiscount(context));
            }
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(ImportSuppliersDto[]), new XmlRootAttribute("Suppliers"));

            var suppliersDtos =
              (ImportSuppliersDto[])serializer.Deserialize(new StringReader(inputXml));

            var config = new MapperConfiguration(cfg => { cfg.AddProfile<CarDealerProfile>(); });
            var mapper = config.CreateMapper();

            Supplier[] suppliers = mapper.Map<Supplier[]>(suppliersDtos);

            context.Suppliers.AddRange(suppliers);

            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(ImportPartsDto[]), new XmlRootAttribute("Parts"));

            ImportPartsDto[] partsDto =
              (ImportPartsDto[])serializer.Deserialize(new StringReader(inputXml));

            var config = new MapperConfiguration(cfg => { cfg.AddProfile<CarDealerProfile>(); });
            var mapper = config.CreateMapper();

            var suppliersIds = context.Suppliers.Select(x => x.Id).ToArray();

            Part[] parts = mapper.Map<Part[]>(partsDto)
                .Where(p => suppliersIds.Contains(p.SupplierId))
                .ToArray();

            context.Parts.AddRange(parts);

            context.SaveChanges();

            return $"Successfully imported {parts.Length}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportCarDto[]), new XmlRootAttribute("Cars"));

            var reader = new StringReader(inputXml);

            var carDto = (ImportCarDto[])serializer.Deserialize(reader);

            foreach (var importCar in carDto)
            {
                Car car = new Car
                {
                    Make = importCar.Make,
                    Model = importCar.Model,
                    TravelledDistance = importCar.TraveledDistance
                };

                context.Cars.Add(car);

                var parts = importCar.PartsIds
                    .Distinct()
                    .Select(x => x.Id)
                    .ToArray();

                foreach (var part in parts)
                {
                    PartCar partCar = new PartCar
                    {
                        PartId = part,
                        Car = car
                    };

                    if (car.PartCars.FirstOrDefault(pc => pc.PartId == part) == null)
                    {
                        context.PartCars.Add(partCar);
                    }
                }
            }

            context.SaveChanges();

            return $"Successfully imported {carDto.Length}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<ImportCustomerDto>), new XmlRootAttribute("Customers"));

            var reader = new StringReader(inputXml);

            var customersDtos = (List<ImportCustomerDto>)serializer.Deserialize(reader);

            var customers = customersDtos.Select(x => new Customer
            {
                Name = x.Name,
                BirthDate = x.BirthDate,
                IsYoungDriver = x.IsYoungDriver
            }).ToList();

            context.Customers.AddRange(customers);

            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<ImportSalesDto>), new XmlRootAttribute("Sales"));

            var reader = new StringReader(inputXml);

            var salesDtos = (List<ImportSalesDto>)serializer.Deserialize(reader);

            var sales = new List<Sale>();

            var carIds = context.Cars.Select(x => x.Id).ToList();

            foreach (var saleDto in salesDtos)
            {
                if (carIds.Contains(saleDto.CarId))
                {
                    var sale = new Sale()
                    {
                        CarId = saleDto.CarId,
                        CustomerId = saleDto.CustomerId,
                        Discount = saleDto.Discount
                    };
                    sales.Add(sale);
                }   
            }

            context.Sales.AddRange(sales);

            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.TravelledDistance > 2000000)
                .ProjectTo<ExportCarDto>(new MapperConfiguration(cfg => { cfg.AddProfile<CarDealerProfile>(); }))
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ToList();

            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            XmlSerializer serializer = new XmlSerializer(typeof(List<ExportCarDto>), new XmlRootAttribute("cars"));

            var writer = new StringWriter();

            serializer.Serialize(writer, cars, ns);

            return writer.ToString();
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.Make == "BMW")
                .ProjectTo<ExportBMWDto>(new MapperConfiguration(cfg => { cfg.AddProfile<CarDealerProfile>(); }))
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ToList();

            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            XmlSerializer serializer = new XmlSerializer(typeof(List<ExportBMWDto>), new XmlRootAttribute("cars"));

            var writer = new StringWriter();

            serializer.Serialize(writer, cars, ns);

            return writer.ToString();
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .ProjectTo<ExportSupplierDto>(new MapperConfiguration(cfg => { cfg.AddProfile<CarDealerProfile>(); }))
                .ToList();

            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            XmlSerializer serializer = new XmlSerializer(typeof(List<ExportSupplierDto>), new XmlRootAttribute("suppliers"));

            var writer = new StringWriter();

            serializer.Serialize(writer, suppliers, ns);

            return writer.ToString().TrimEnd();
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new ExportFullCarDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    Parts = c.PartCars.Select(pc => new ExportPartDto
                    {
                        Name =pc.Part.Name,
                        Price = pc.Part.Price
                    }).OrderByDescending(p => p.Price).ToList()
                })
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ToList();

            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            XmlSerializer serializer = new XmlSerializer(typeof(List<ExportFullCarDto>), new XmlRootAttribute("cars"));

            var writer = new StringWriter();

            serializer.Serialize(writer, cars, ns);

            return writer.ToString().TrimEnd();
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Count > 0)
                .ProjectTo<ExportCustomerDto>(new MapperConfiguration(cfg => { cfg.AddProfile<CarDealerProfile>(); }))
                .OrderByDescending(c => c.SpentMoney)
                .ToList();

            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            XmlSerializer serializer = new XmlSerializer(typeof(List<ExportCustomerDto>), new XmlRootAttribute("customers"));

            var writer = new StringWriter();

            serializer.Serialize(writer, customers, ns);

            return writer.ToString().TrimEnd();

        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .ProjectTo<ExportSaleDto>(new MapperConfiguration(cfg => { cfg.AddProfile<CarDealerProfile>(); }))
                .ToList();

            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            XmlSerializer serializer = new XmlSerializer(typeof(List<ExportSaleDto>), new XmlRootAttribute("sales"));

            var writer = new StringWriter();

            serializer.Serialize(writer, sales, ns);

            return writer.ToString().TrimEnd();

        }
    }
}