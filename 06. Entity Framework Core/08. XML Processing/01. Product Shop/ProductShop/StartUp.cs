using ProductShop.Data;
using System.Text;
using System;
using System.Xml.Linq;
using System.Xml.Serialization;
using ProductShop.Dtos.Import;
using System.IO;
using System.Collections.Generic;
using AutoMapper;
using ProductShop.Models;
using System.Linq;
using AutoMapper.QueryableExtensions;
using ProductShop.Dtos.Export;
using Microsoft.EntityFrameworkCore;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            var context = new ProductShopContext();

            using(context)
            {
                Console.WriteLine(GetUsersWithProducts(context));
            }
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(List<ImportUserDto>), new XmlRootAttribute("Users"));

            var importedUsersDtos = (List<ImportUserDto>)serializer.Deserialize(new StreamReader(inputXml));

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });

            var mapper = mapperConfig.CreateMapper();

            List<User> users = mapper.Map<List<User>>(importedUsersDtos);

            context.Users.AddRange(users);

            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(List<ImportProductDto>), new XmlRootAttribute("Products"));
            
            var importedProductsDtos = (List<ImportProductDto>)serializer.Deserialize(new StringReader(inputXml));

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });

            var mapper = mapperConfig.CreateMapper();

            List<Product> products = mapper.Map<List<Product>>(importedProductsDtos);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(List<ImportCategoryDto>), new XmlRootAttribute("Categories"));

            var importedCategoriesDtos = (List<ImportCategoryDto>)serializer.Deserialize(new StringReader(inputXml));

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });

            var mapper = mapperConfig.CreateMapper();

            List<Category> categories = mapper
                .Map<List<Category>>(importedCategoriesDtos
                .Where(c => c.Name != null));

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(List<ImportCategoryProductDto>), new XmlRootAttribute("CategoryProducts"));

            var importedCategoryProductsDtos = (List<ImportCategoryProductDto>)serializer.Deserialize(new StringReader(inputXml));

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });

            var mapper = mapperConfig.CreateMapper();

            var productsIds = context.Products.Select(p => p.Id).ToList();
            var categoriesIds = context.Categories.Select(c => c.Id).ToList();

            List<CategoryProduct> categoryProducts = mapper
                .Map<List<CategoryProduct>>(importedCategoryProductsDtos
                .Where(cp => productsIds.Contains(cp.ProductId) && categoriesIds.Contains(cp.CategoryId))
                .ToList());

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }
        public static string GetProductsInRange(ProductShopContext context)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });

            var products = context.Products
                .Where(p => p.Price > 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Take(10)
                .ProjectTo<ProductsInRangeDto>(mapperConfig)
                .ToList();

            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            XmlSerializer serializer = new XmlSerializer(typeof(List<ProductsInRangeDto>), new XmlRootAttribute("Products"));

            var writer = new StringWriter();

            serializer.Serialize(writer, products, ns);

            return writer.ToString();
        }
        public static string GetSoldProducts(ProductShopContext context)
        {
            var usersWithSoldProducts = context.Users
                .Where(u => u.ProductsSold.Count > 0)
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .ProjectTo<ExportUserDto>(new MapperConfiguration(cfg => { cfg.AddProfile<ProductShopProfile>(); }))
                .ToList();

            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            XmlSerializer serializer = new XmlSerializer(typeof(List<ExportUserDto>), new XmlRootAttribute("Users"));

            var writer = new StringWriter();

            serializer.Serialize(writer, usersWithSoldProducts, ns);

            return writer.ToString();
        }
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {   var categories = context.Categories
                .ProjectTo<ExportCategoryDto>(new MapperConfiguration(cfg => { cfg.AddProfile<ProductShopProfile>(); }))
                .OrderByDescending(c => c.ProductsCount)
                .ThenBy(c => c.SumProductsPrice)
                .ToList();

            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            XmlSerializer serializer = new XmlSerializer(typeof(List<ExportCategoryDto>), new XmlRootAttribute("Categories"));

            var writer = new StringWriter();

            serializer.Serialize(writer, categories, ns);

            return writer.ToString();
        }
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            // HAVE BETTER SOLUTION BUT IT DOES NOT RUN IN JUDGE
            var users = context.Users
                .Include(u => u.ProductsSold)
                .ToArray()
                .Where(u => u.ProductsSold.Count > 0)
                .ToList();

            var config = new MapperConfiguration(cfg => { cfg.AddProfile<ProductShopProfile>(); });
            var mapper = config.CreateMapper();

            List<ExportUserDtoEXTENDED> usersDtos = mapper.Map<List<ExportUserDtoEXTENDED>>(users);
            var writer = new StringWriter();

            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            var strangeDto = new StrangeXmlUserOutputDto()
            {
                Count = usersDtos.Count,
                Users = usersDtos.OrderByDescending(c => c.SoldProducts.Count).Take(10).ToList()
            };

            XmlSerializer serializer = new XmlSerializer(typeof(StrangeXmlUserOutputDto), new XmlRootAttribute("Users"));

            serializer.Serialize(writer, strangeDto, ns);

            return writer.GetStringBuilder().ToString();
        }
    }
}