namespace P02_BlackBoxInteger
{
    using System;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            Type blackBoxType = typeof(BlackBoxInteger);
            BlackBoxInteger blackBoxInstance = (BlackBoxInteger)Activator.CreateInstance(blackBoxType, true);

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] commandOfArgs = input
                    .Split('_', StringSplitOptions.RemoveEmptyEntries);
                string command = commandOfArgs[0];
                int n = int.Parse(commandOfArgs[1]);

                blackBoxType.GetMethod(command, BindingFlags.Instance | BindingFlags.NonPublic)
                    .Invoke(blackBoxInstance, new object[] {n});

                var innerValue = blackBoxType
               .GetField("innerValue", BindingFlags.NonPublic | BindingFlags.Instance)
               .GetValue(blackBoxInstance);

                Console.WriteLine(innerValue);
            }        
        }
    }
}
