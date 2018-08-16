using System;
using System.Collections.Generic;
using System.Linq;

public class Clinic
{
    private int countRooms;

    public Clinic(string name, int countRooms)
    {
        this.Name = name;
        this.CountRooms = countRooms;
    }

    public string Name { get; private set; }

    public int CountRooms
    {
        get { return countRooms; }
        set
        {
            if (value % 2 == 0)
                throw new ArgumentException("Invalid Operation!");
            countRooms = value;
        }
    }
}
