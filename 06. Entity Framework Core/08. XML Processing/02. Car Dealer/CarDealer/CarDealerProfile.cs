using AutoMapper;
using CarDealer.Dtos.Export;
using CarDealer.Dtos.Import;
using CarDealer.Models;
using System.Linq;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            CreateMap<ImportSuppliersDto, Supplier>();
            CreateMap<ImportPartsDto, Part>();
            CreateMap<PartId, Part>();
            CreateMap<Car, ExportCarDto>();
            CreateMap<Car, ExportBMWDto>();
            CreateMap<Supplier, ExportSupplierDto>()
                .ForMember(dto => dto.partsCount, opt => opt.MapFrom(src => src.Parts.Count));
            CreateMap<Customer, ExportCustomerDto>()
                .ForMember(dto => dto.FullName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dto => dto.BoughtCars, opt => opt.MapFrom(src => src.Sales.Count))
                .ForMember(dto => dto.SpentMoney, opt => opt.MapFrom(src => src.Sales.Sum(c => c.Car.PartCars.Sum(cp => cp.Part.Price))));
            CreateMap<Sale, ExportSaleDto>()
                .ForMember(dto => dto.Car, opt => opt.MapFrom(src => src.Car))
                .ForMember(dto => dto.CustomerName, opt => opt.MapFrom(src => src.Customer.Name))
                .ForMember(dto => dto.Price, opt => opt.MapFrom(src => src.Car.PartCars.Sum(cp => cp.Part.Price)))
                .ForMember(dto => dto.PriceWithDiscount, opt => opt.MapFrom(src => src.Car.PartCars.Sum(cp => cp.Part.Price) - src.Car.PartCars.Sum(cp => cp.Part.Price) * src.Discount / 100));

        }
    }
}
