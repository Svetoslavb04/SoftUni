using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
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
                string json = File.ReadAllText("../../../Datasets/categories.json");

                Console.WriteLine(ImportProducts(context, json));
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
    }
}