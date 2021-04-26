 namespace P01_HarvestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            var harvestFieldsType = typeof(HarvestingFields);

            var allFields = harvestFieldsType.GetFields((BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public));
            var privateAndProtectedFields = harvestFieldsType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            var publicFields = harvestFieldsType.GetFields(BindingFlags.Instance | BindingFlags.Public);

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "HARVEST")
                {
                    break;
                }

                if (command == "private")
                {
                    foreach (var privateField in privateAndProtectedFields.Where(f => f.IsPrivate))
                    {
                        Console.WriteLine($"private {privateField.FieldType.Name} {privateField.Name}");
                    }
                }
                else if (command == "protected")
                {
                    foreach (var protectedField in privateAndProtectedFields.Where(f => f.IsFamily))
                    {
                        Console.WriteLine($"protected {protectedField.FieldType.Name} {protectedField.Name}");
                    }
                }
                else if (command == "public")
                {
                    foreach (var publicField in publicFields)
                    {
                        Console.WriteLine($"public {publicField.FieldType.Name} {publicField.Name}");
                    }
                }
                else if (command == "all")
                {
                    foreach (var field in allFields)
                    {
                        string accessModifier = field.IsPublic ? "public" : field.IsPrivate ? "private" : "protected";
                        Console.WriteLine($"{accessModifier} {field.FieldType.Name} {field.Name}");
                    }
                }
            }
        }
    }
}
