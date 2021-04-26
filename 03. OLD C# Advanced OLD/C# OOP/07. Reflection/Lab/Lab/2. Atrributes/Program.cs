namespace _2._Attributes
{
    using System;

    [Author("Ventsi")]
    public class Program
    {
        [Author("Pesho")]
        [Author("Gosho")]
        public static void Main()
        {
            var tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }
    }
}
