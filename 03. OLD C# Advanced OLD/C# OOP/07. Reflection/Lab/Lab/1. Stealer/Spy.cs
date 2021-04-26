namespace _1._Stealer
{
    using System.Reflection;
    using System.Linq;
    using System.Text;
    using System;

    public class Spy
    {
        private Type hackerType = typeof(Spy).Assembly.GetTypes().FirstOrDefault(x => x.Name == "Hacker");

        public string StealFieldInfo(string nameClass, params string[] requiredFields)
        {
            StringBuilder stringBuilder = new StringBuilder();

            var allFields = hackerType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

            stringBuilder.AppendLine($"Class under investigation: {nameClass}");

            var instance = Activator.CreateInstance(hackerType, new object[0]);

            foreach (var field in allFields.Where(f => requiredFields.Contains(f.Name)))
            {
                stringBuilder.AppendLine($"{field.Name} = {field.GetValue(instance)}");
            }

            return stringBuilder.ToString().Trim();
        }

        public string AnalyzeAcessModifiers(string className)
        {
            StringBuilder stringBuilder = new StringBuilder();

            var allFields = hackerType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);
            var allPublicMethod = hackerType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            var allNonPublicMethod = hackerType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (var field in allFields)
            {
                stringBuilder.AppendLine($"{field.Name} must be private");
            }

            foreach (var method in allNonPublicMethod.Where(m => m.Name.StartsWith("get")))
            {
                stringBuilder.AppendLine($"{method.Name} have to be public ");
            }

            foreach (var method in allPublicMethod.Where(m => m.Name.StartsWith("set")))
            {
                stringBuilder.AppendLine($"{method.Name} have to be private ");
            }

            return stringBuilder.ToString().Trim();
        }

        public string RevealPrivateMethods(string className)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"All Private Methods of Class: {className}");

            var baseClassName = hackerType.BaseType;
            stringBuilder.AppendLine($"Base Class: {baseClassName.Name}");

            var privateMethods = hackerType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (var method in privateMethods)
            {
                stringBuilder.AppendLine(method.Name);
            }

            return stringBuilder.ToString().Trim();
        }

        public string CollectGettersAndSetters(string className)
        {
            StringBuilder stringBuilder = new StringBuilder();

            var allMethods = hackerType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public).OrderBy(x => x.Name);

            foreach (var method in allMethods.Where(x => x.Name.StartsWith("get")))
            {
                stringBuilder.AppendLine($"{method.Name} will return {method.ReturnType}");
            }
            foreach (var method in allMethods.Where(x => x.Name.StartsWith("set")))
            {
                stringBuilder.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
            }
            return stringBuilder.ToString().Trim();
        }
    }
}
