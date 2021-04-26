using System;
using System.Linq;
using System.Collections.Generic;
namespace _2._Articles
{
    public class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public Article() { }
        public Article(string title, string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }
        
        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }

    class Program
    {
        public static void Main()
        {
            var articles = new List<Article>();
            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {               
                var currentArticle = new Article()
                {
                    Title = string.Empty,
                    Content = string.Empty,
                    Author = string.Empty
                };
                var list = Console.ReadLine()
                .Split(", ");
                currentArticle.Title = list[0];
                currentArticle.Content = list[1];
                currentArticle.Author = list[2];
                articles.Add(currentArticle);
            }
            var command = Console.ReadLine();
            if (command == "title")
            {
                foreach (var article in articles.OrderBy(n => n.Title))
                {
                    Console.WriteLine(article);
                }
            }
            if (command == "content")
            {
                foreach (var article in articles.OrderBy(n => n.Content))
                {
                    Console.WriteLine(article);
                }
            }
            if (command == "author")
            {
                foreach (var article in articles.OrderBy(n => n.Author))
                {
                    Console.WriteLine(article);
                }
            }
        }
    }
}
