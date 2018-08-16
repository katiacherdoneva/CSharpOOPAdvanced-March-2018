using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main()
    {
        Dictionary<string, Dictionary<string, List<string>>> infoForDoctor = new Dictionary<string, Dictionary<string, List<string>>>();
        Dictionary<string, Dictionary<int, List<string>>> infoForRoom = new Dictionary<string, Dictionary<int, List<string>>>();
        int indexForRoom = 1;

        string input = string.Empty;
        while ((input = Console.ReadLine()) != "Output")
        {
            string[] commandOfArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string department = commandOfArgs[0];
            string doctor = commandOfArgs[1] + " " + commandOfArgs[2];
            string patient = commandOfArgs[3];

            FullDoctors(ref infoForDoctor, department, doctor, patient);
            FullRooms(ref infoForRoom, department, patient, ref indexForRoom);
        }

        PrintResult(infoForDoctor, infoForRoom);
    }

    private static void PrintResult(Dictionary<string, Dictionary<string, List<string>>> infoForDoctor, 
        Dictionary<string, Dictionary<int, List<string>>> infoForRoom)
    {
        string output = string.Empty;
        while ((output = Console.ReadLine()) != "End")
        {
            string[] commandOfArgs = output.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int room = 0;

            if(commandOfArgs.Length == 1)
            {
                foreach (var r in infoForRoom[commandOfArgs[0]])
                {
                    foreach (var p in r.Value)
                    {
                        Console.WriteLine(p);
                    }
                }
            }
            else if (int.TryParse(commandOfArgs[1], out room))
            {
                string department = commandOfArgs[0];

                if (room <= infoForRoom[department].LastOrDefault().Key)
                {
                    foreach (var p in infoForRoom[department][room].OrderBy(x => x))
                    {
                        Console.WriteLine(p);
                    }
                }
            }
            else
            {
                string doctor = commandOfArgs[0] + " " + commandOfArgs[1];
                List<string> patients = new List<string>();

                foreach (var d in infoForDoctor.Where(x => x.Value.ContainsKey(doctor)))
                {
                    foreach (var doc in d.Value)
                    {
                        if(doc.Key == doctor)
                        {
                            foreach (var p in doc.Value)
                            {
                                patients.Add(p);
                            }
                        }         
                    }
                }

                foreach (var p in patients.OrderBy(x => x))
                {
                    Console.WriteLine(p);
                }
            }
           
            
        }
        
    }

    private static void FullRooms(ref Dictionary<string, Dictionary<int, List<string>>> infoForRoom, 
        string department, string patient, ref int index)
    {

        if (!infoForRoom.ContainsKey(department))
        {
            infoForRoom.Add(department, new Dictionary<int, List<string>>());
        }

        if(infoForRoom[department].ContainsKey(20) && infoForRoom[department][20].Count == 3)
        {
            return;
        }
        else if (infoForRoom[department].ContainsKey(20))
        {
            if (infoForRoom[department][20].Count < 3)
            {
                infoForRoom[department][20].Add(patient);
            }
        }
        else
        {
            if(!infoForRoom[department].ContainsKey(index))
            {
                infoForRoom[department].Add(index, new List<string>());
                infoForRoom[department][index].Add(patient);
            }
            else if (infoForRoom[department][index].Count < 3)
            {
                infoForRoom[department][index].Add(patient);
            }
            else
            {
                infoForRoom[department].Add(++index, new List<string>());
                infoForRoom[department][index].Add(patient);
            }
        }
    }

    private static void FullDoctors(ref Dictionary<string, Dictionary<string, List<string>>> infoForDoctor, string department, string doctor, string patient)
    {
        if (!infoForDoctor.ContainsKey(department))
        {
            infoForDoctor.Add(department, new Dictionary<string, List<string>>());
        }

        if (infoForDoctor.Any(x => !x.Value.Keys.Contains(doctor)))
        {
            infoForDoctor[department].Add(doctor, new List<string>());
        }
        infoForDoctor[department][doctor].Add(patient);
    }
}

