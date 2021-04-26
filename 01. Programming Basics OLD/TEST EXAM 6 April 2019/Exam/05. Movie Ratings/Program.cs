namespace _05._Movie_Ratings
{
    using System;

    public class Program
    {
        public static void Main()
        {
            int films = int.Parse(Console.ReadLine());

            double maxRating = 0;
            string maxRatingfilmName = string.Empty;

            double minRating = double.MaxValue;
            string minRatingFilmName = string.Empty;

            double avarageRating = 0;

            for (int i = 0; i < films; i++)
            {
                var filmName = Console.ReadLine();
                var rating = double.Parse(Console.ReadLine());

                avarageRating += rating;

                if (rating > maxRating)
                {
                    maxRating = rating;
                    maxRatingfilmName = filmName;
                }
                if (rating < minRating)
                {
                    minRating = rating;
                    minRatingFilmName = filmName;
                }
            }

            Console.WriteLine($"{maxRatingfilmName} is with highest rating: {maxRating:F1}");
            Console.WriteLine($"{minRatingFilmName} is with lowest rating: {minRating:F1}");
            Console.WriteLine($"Average rating: {avarageRating / films:F1}");
        }
    }
}
