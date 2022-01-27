using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            var context = new ProductShopContext();

            using (context)
            {
                Console.WriteLine(GetUsersWithProducts(context));
            }
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var sb = new StringBuilder();

            List<User> usersFromJSON = JsonConvert.DeserializeObject<List<User>>(inputJson);

            foreach (var user in usersFromJSON)
            {
                context.Users.Add(user);
            }

            context.SaveChanges();

            sb.AppendLine($"Successfully imported {usersFromJSON.Count}");
            return sb.ToString().Trim();
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<List<Product>>(inputJson);

            context.Products.AddRange(products);

            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<List<Category>>(inputJson).Where(c => c.Name != null).ToArray();

            context.Categories.AddRange(categories);

            context.SaveChanges();

            return $"Successfully imported {categories.Length}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoriesProducts = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson);

            context.CategoryProducts.AddRange(categoriesProducts);

            context.SaveChanges();

            return $"Successfully imported {categoriesProducts.Count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price > 500 && p.Price <=1000)
                .Select(p => new
                {
                    p.Name, p.Price, Seller = p.Seller.FirstName + " " + p.Seller.LastName
                })
                .OrderBy(p => p.Price)
                .ToList();

            DefaultContractResolver contractResolver =
                new DefaultContractResolver()
                {
                NamingStrategy = new CamelCaseNamingStrategy()
                };
            var serialized = JsonConvert.SerializeObject(products,
                new JsonSerializerSettings()
                {
                    ContractResolver = contractResolver,
                    Formatting = Formatting.Indented
                });

            return serialized;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var sellers = context.Users
                .Include(x => x.ProductsSold)
                .ThenInclude(x => x.Buyer)
                .Where(x => x.ProductsSold.Count > 0 && x.ProductsSold.Any(b => b.Buyer != null))
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    SoldProducts = x.ProductsSold.Select(product => new
                    {
                        product.Name,
                        product.Price,
                        BuyerFirstName = product.Buyer.FirstName,
                        BuyerLastName = product.Buyer.LastName
                    })
                })
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName);

            var settings = new JsonSerializerSettings()
            {
                ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                },
                Formatting = Formatting.Indented
            };

            string json = JsonConvert.SerializeObject(sellers, settings);

            return json;
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var sellers = context.Users
                .Where(u => u.ProductsSold.Any(ps => ps.Buyer != null))
                .OrderByDescending(u => u.ProductsSold.Count(ps => ps.Buyer != null))
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    u.Age,
                    SoldProducts = new
                    {
                        Count = u.ProductsSold.Count(ps => ps.Buyer != null),
                        Products = u.ProductsSold
                            .Where(p => p.Buyer != null)
                            .Select(p => new
                            {
                                p.Name,
                                p.Price
                            })
                    }
                })
                .ToList();

            var output = new
            {
                UsersCount = sellers.Count,
                Users = sellers
            };

            var settings = new JsonSerializerSettings()
            {
                ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                },
                Formatting = Formatting.Indented
                , NullValueHandling = NullValueHandling.Ignore,
            };

            string json = JsonConvert.SerializeObject(output, settings);

            return json;
        }
    }
}