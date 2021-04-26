namespace P02_BlackBoxInteger
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            var type = typeof(BlackBoxInteger);
            var instance = Activator.CreateInstance(type, true);

            while (true)
            {
                var command = Console.ReadLine().Split("_");

                if (command[0] == "END")
                {
                    break;
                }
                else
                {
                    type.GetMethod(command[0], BindingFlags.Instance | BindingFlags.NonPublic).Invoke(instance, new object[] { int.Parse(command[1]) });

                    Console.WriteLine(type.GetField("innerValue",BindingFlags.Instance | BindingFlags.NonPublic).GetValue(instance));
                }
            }
        }
    }
}
