using System;
using System.ComponentModel;
using System.Reflection;
using System.Linq;

public class StartUp
{
    static void Main()
    {
        string[] lights = Console.ReadLine()
            .Split(' ');
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            object[] enumLight = lights.Select(x => Enum.Parse(typeof(Light), x)).ToArray();

            FieldInfo[] fields = enumLight.Select(x => x.GetType().GetField(x.ToString())).ToArray();

            int index = 0;
            foreach (var fi in fields)
            {
                DescriptionAttribute[] attributes =
        (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

                Console.Write($"{attributes[0].Description} ");
                lights[index++] = attributes[0].Description;
            }
            Console.WriteLine();         
        }
    }
}

