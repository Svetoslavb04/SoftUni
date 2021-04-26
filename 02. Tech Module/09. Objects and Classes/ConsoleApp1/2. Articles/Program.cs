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

        public string Edit(string newContent)
        {
            return Content = newContent;
        }

        public void ChangeAuthor(string newAuthor)
        {
            Author = newAuthor;
        }

        public void Rename(string newTitle)
        {
            Title = newTitle;
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
            var article = new Article()
            {
                Title = string.Empty,
                Content = string.Empty,
                Author = string.Empty
            };
            var list = Console.ReadLine()
                .Split(", ");
            article.Title = list[0];
            article.Content = list[1];
            article.Author = list[2];
            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                var input = Console.ReadLine()
                    .Split(": ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();
                if (input[0] == "Edit")
                {
                    article.Edit(input[1]);
                }
                if (input[0] == "ChangeAuthor")
                {
                    article.ChangeAuthor(input[1]);
                }
                if (input[0] == "Rename")
                {
                    article.Rename(input[1]);
                }
            }
            Console.WriteLine(article);
        }
    }
}
