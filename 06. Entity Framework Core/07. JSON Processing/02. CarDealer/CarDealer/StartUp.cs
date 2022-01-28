using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();
            var json = File.ReadAllText("../../../Datasets/sales.json");

            var outputString = GetSalesWithAppliedDiscount(context);

            Console.WriteLine(outputString);
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<List<Supplier>>(inputJson);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var suppliers = context.Suppliers.Select(s => s.Id).ToList();

            var parts = JsonConvert.DeserializeObject<List<Part>>(inputJson).Where(p => suppliers.Contains(p.SupplierId)).ToList();

            context.Parts.AddRange(parts);

            context.SaveChanges();

            return $"Successfully imported {parts.Count}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carsDTO = JsonConvert.DeserializeObject<List<CarDTO>>(inputJson);

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });

            var mapper = mapperConfig.CreateMapper();



            foreach (var carDTO in carsDTO)
            {
                var car = mapper.Map<Car>(carDTO);

                context.Cars.Add(car);
            }


            context.SaveChanges();

            return $"Successfully imported {context.Cars.Count()}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<List<Customer>>(inputJson);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<List<Sale>>(inputJson);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}.";
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var config = new MapperConfiguration(cfg => { cfg.AddProfile<CarDealerProfile>(); });

            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .ProjectTo<OutputCustomerDTO>(config);

            string json = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return json;
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<CarDealerProfile>());

            var toyotas = context.Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ProjectTo<ToyotaDTO>(config);

            var json = JsonConvert.SerializeObject(toyotas, Formatting.Indented);

            return json;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<CarDealerProfile>());

            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .ProjectTo<SupplierDTO>(config);

            var json = JsonConvert.SerializeObject(suppliers, Formatting.Indented);
            return json;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new
                {
                    car = new
                    {
                        c.Make,
                        c.Model,
                        c.TravelledDistance
                    },
                    parts = c.PartCars.Select(p => new
                    {
                        p.Part.Name,
                        Price = string.Format("{0:F2}", p.Part.Price)
                    }).ToList()
                });

            var settings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented
            };


            var json = JsonConvert.SerializeObject(cars, settings);

            return json;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });

            var customersGroup = context.Customers
                .ProjectTo<BuyerDTO>(config)
                .OrderByDescending(c => c.SpentMoney)
                .ThenByDescending(c => c.BoughtCars)
                .ToList();

            var buyersDTO = new List<BuyerDTO>();

            foreach (var c in customersGroup.OrderByDescending(c => c.SpentMoney).ThenByDescending(c => c.BoughtCars))
            {
                var buyerDTO = new BuyerDTO()
                {
                    FullName = c.FullName,
                    BoughtCars = c.BoughtCars,
                    SpentMoney = c.SpentMoney

                };

                buyersDTO.Add(buyerDTO);
            }
            
            var json = JsonConvert.SerializeObject(buyersDTO, Formatting.Indented);

            return json;
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(s => new
                {
                    car = new
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    customerName = s.Customer.Name,
                    Discount = s.Discount.ToString("F2"),
                    price = s.Car.PartCars.Sum(p => p.Part.Price).ToString("F2"),
                    priceWithDiscount = (s.Car.PartCars.Sum(p => p.Part.Price) - (s.Car.PartCars.Sum(p => p.Part.Price) * s.Discount/100)).ToString("F2")
                })
                .Take(10);

            var settings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented
            };

            string json = JsonConvert.SerializeObject(sales, settings);

            return json;
        }
    }
}