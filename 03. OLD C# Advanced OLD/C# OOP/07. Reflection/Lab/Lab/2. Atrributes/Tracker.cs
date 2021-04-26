using System.Linq;

namespace _2._Attributes
{
    public class Tracker
    {
        public Tracker()
        {
        }

        public void PrintMethodsByAuthor()
        {
            var programType = typeof(Program);

            var methods = programType.GetMethods();

            foreach (var method in methods)
            {
                if (method.CustomAttributes.Any(m => m.AttributeType == typeof(AuthorAttribute)))
                {
                    var attributes = method.GetCustomAttributes(false);

                    foreach (AuthorAttribute attr in attributes)
                    {
                        System.Console.WriteLine($"{method.Name} is written by {attr.Name}");
                    }
                }
            }
        }
    }
}