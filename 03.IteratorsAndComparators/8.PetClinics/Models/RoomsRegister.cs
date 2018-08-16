using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RoomsRegister 
{
    public RoomsRegister()
    {
        this.RegisterPet = new List<Pet>();
        this.Clinics = new Dictionary<Clinic, Pet[]>();
    }

    public List<Pet> RegisterPet { get; private set; }

    public Dictionary<Clinic, Pet[]> Clinics { get; private set; }

    public void CreatePet(string name, int age, string kind)
    {
        this.RegisterPet.Add(new Pet(name, age, kind));
    }

    public void CreateClinics(string name, int countRooms)
    {
        this.Clinics.Add(new Clinic(name, countRooms), new Pet[countRooms]);
    }

    public bool Add(string petName, string clinicName)
    {
        int current = this.Clinics.First(x => x.Key.Name == clinicName).Value.Length / 2;

        Pet pet = this.RegisterPet.FirstOrDefault(x => x.Name == petName);

        for (int i = 0; i < this.Clinics.First(x => x.Key.Name == clinicName).Value.Length; i++)
        {
            if (i % 2 != 0)
            {
                current -= i;
            }
            else
            {
                current += i;
            }

            bool isHasPet = this.Clinics.First(x => x.Key.Name == clinicName).Value[current] == null 
                ? true : false;
            if (isHasPet)
            {
                this.Clinics.First(x => x.Key.Name == clinicName).Value[current] = pet;
                return true;
            }
        }
        return false;
    }

    public bool HasEmptyRooms(string clinicName)
    {
        if(this.Clinics.First(x => x.Key.Name == clinicName)
            .Value.Count(x => x == null) > 0)
        {
            return true;
        }
        return false;
    }

    public string Print(string clinicName)
    {
        StringBuilder sb = new StringBuilder();
        foreach (var petInRoom in this.Clinics.First(x => x.Key.Name == clinicName).Value)
        {
            sb.AppendLine(GetInfoForRoom(petInRoom));
        }
        return sb.ToString().TrimEnd();
    }

    public bool Realese(string clinicName)
    {
        int countRoom = this.Clinics.First(x => x.Key.Name == clinicName).Key.CountRooms;
        bool result;

        int startIndex = countRoom / 2;
        int endIndex = countRoom;
        result = RemovePet(clinicName, startIndex, endIndex);

        return result;
    }

    private bool RemovePet(string clinicName, int startIndex, int endIndex)
    {
        for (int i = startIndex; i < endIndex; i++)
        {
            bool isHasPet = this.Clinics.First(x => x.Key.Name == clinicName).Value[i] != null 
                ? true : false;
            if (isHasPet)
            {
                this.Clinics.First(x => x.Key.Name == clinicName).Value[i] = null;
                return true;
            }
        }
        return false;
    }

    public string Print(string clinicName, int numberRoom)
    {
        Pet petInRoom = this.Clinics.First(x => x.Key.Name == clinicName).Value[numberRoom - 1];

        return GetInfoForRoom(petInRoom);
    }

    private static string GetInfoForRoom(Pet petInRoom)
    {
        string result = string.Empty;
        if (petInRoom == null)
        {
            result = "Room empty";
        }
        else
        {
            result = $"{petInRoom.Name} {petInRoom.Age} {petInRoom.Kind}";
        }
        return result;
    }
}

