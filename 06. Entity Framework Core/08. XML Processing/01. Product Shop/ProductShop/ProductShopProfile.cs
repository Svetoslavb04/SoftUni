using AutoMapper;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System.Linq;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            CreateMap<ImportUserDto, User>();
            CreateMap<ImportProductDto, Product>();
            CreateMap<ImportCategoryDto, Category>();
            CreateMap<ImportCategoryProductDto, CategoryProduct>();
            CreateMap<Product, ProductsInRangeDto>()
                .ForMember(dest => dest.Buyer, opt => opt.MapFrom(src => $"{src.Buyer.FirstName} {src.Buyer.LastName}"));
            CreateMap<Product, ExportProductDto>();
            CreateMap<User, ExportUserDto>();
            CreateMap<Category, ExportCategoryDto>()
                .ForMember(dest => dest.ProductsCount, opt => opt.MapFrom(src => src.CategoryProducts.Count))
                .ForMember(dest => dest.AverageProductsPrice, opt => opt.MapFrom(src => src.CategoryProducts.Average(ct => ct.Product.Price)))
                .ForMember(dest => dest.SumProductsPrice, opt => opt.MapFrom(src => src.CategoryProducts.Sum(ct => ct.Product.Price)));
            CreateMap<User, ExportSoldProductsDto>()
                .ForMember(dest => dest.Count, opt => opt.MapFrom(src => src.ProductsSold.Count))
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.ProductsSold.OrderByDescending(p => p.Price)));
            CreateMap<User, ExportUserDtoEXTENDED>()
                .ForMember(dest => dest.SoldProducts, opt => opt.MapFrom(src => src));
        }
    }
}
