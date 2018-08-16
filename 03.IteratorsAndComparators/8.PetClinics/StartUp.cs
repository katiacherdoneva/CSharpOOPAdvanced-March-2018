using System;

public class StartUp
{
    static void Main()
    {
        RoomsRegister roomsRegister = new RoomsRegister();

        int number = int.Parse(Console.ReadLine());
        for (int i = 0; i < number; i++)
        {
            string[] commandOfArgs = Console.ReadLine()
                .Split(' ');
            try
            {
                string clinicName;
                string result = string.Empty;
                string command = commandOfArgs[0];
                switch (command)
                {
                    case "Create":
                        string petOrClinic = commandOfArgs[1];
                        string name = commandOfArgs[2];
                        int roomsOrAge = int.Parse(commandOfArgs[3]);

                        if (petOrClinic == "Pet")
                        {
                            string kind = commandOfArgs[4];
                            roomsRegister.CreatePet(name, roomsOrAge, kind);
                        }
                        else
                        {
                            roomsRegister.CreateClinics(name, roomsOrAge);
                        }
                        break;
                    case "Add":
                        string petName = commandOfArgs[1];
                        clinicName = commandOfArgs[2];
                        result = roomsRegister.Add(petName, clinicName).ToString();
                        break;
                    case "Release":
                        clinicName = commandOfArgs[1];
                        result = roomsRegister.Realese(clinicName).ToString();
                        break;
                    case "HasEmptyRooms":
                        clinicName = commandOfArgs[1];
                        result = roomsRegister.HasEmptyRooms(clinicName).ToString();
                        break;
                    case "Print":
                        clinicName = commandOfArgs[1];

                        if (commandOfArgs.Length == 2)
                        {
                            result = roomsRegister.Print(clinicName);
                        }
                        else
                        {
                            int numberRoom = int.Parse(commandOfArgs[2]);
                            result = roomsRegister.Print(clinicName, numberRoom);
                        }
                        break;
                }

                if(result != string.Empty)
                {
                    Console.WriteLine(result);
                }
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine(argEx.Message);
            }
        }
    }
}

