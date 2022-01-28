using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using AutoMapper;
using CarDealer.DTO;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            CreateMap<CarDTO, Car>()
                    .ForMember(dest => dest.PartCars, opt => opt.MapFrom(c => c.PartsId.Distinct().Select(p => new PartCar { PartId = p })));

            CreateMap<Customer, OutputCustomerDTO>()
                .ForMember(dto => dto.BirthDate, opt => opt.MapFrom(src => src.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)));

            CreateMap<Car, ToyotaDTO>();

            CreateMap<Supplier, SupplierDTO>()
                .ForMember(dto => dto.PartsCount, opt => opt.MapFrom(src => src.Parts.Count));

            CreateMap<Customer, BuyerDTO>()
                .ForMember(dto => dto.FullName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dto => dto.BoughtCars, opt => opt.MapFrom(src => src.Sales.Count))
                .ForMember(dto => dto.SpentMoney, opt => opt.MapFrom(src => src.Sales.Sum(c => c.Car.PartCars.Sum(cp => cp.Part.Price))));

        }
    }
}
