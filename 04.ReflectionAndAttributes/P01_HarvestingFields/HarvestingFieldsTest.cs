namespace P01_HarvestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            Type type = typeof(HarvestingFields);
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "HARVEST")
            {
                FieldInfo[] fieldsInfo = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                switch (command)
                {
                    case "private":
                        fieldsInfo = fieldsInfo.Where(x => x.IsPrivate).ToArray();
                        break;
                    case "protected":
                        fieldsInfo = fieldsInfo.Where(x => x.IsFamily).ToArray();
                        break;
                    case "public":
                        fieldsInfo = fieldsInfo.Where(x => x.IsPublic).ToArray();
                        break;
                    case "all":
                        break;
                }

                foreach (var field in fieldsInfo)
                {
                    string fieldAttributes = field.Attributes.ToString().ToLower() == "family" ?
                        "protected" : field.Attributes.ToString().ToLower();

                    Console.WriteLine($"{fieldAttributes} {field.FieldType.Name} {field.Name}");
                }
            }
        }
    }
}

