using System;
using System.Linq;

public class Database : IDatabase
{
    private int[] numbers;

    public Database(int[] numbers)
    {
        this.Numbers = numbers;
    }

    public int[] Numbers
    {
        get { return numbers; }
        set
        {
            if (value.Length > 16)
            {
                throw new InvalidOperationException("Full array.");
            }
            numbers = value;
        }
    }

    public void Add(int number)
    {
        int length = this.Numbers.Length;
        if (length >= 16)
        {
            throw new InvalidOperationException("Full array.");
        }

        for (int i = 0; i < length; i++)
        {
            if (this.Numbers[i] == 0)
            {
                this.Numbers[i] = number;
                break;
            }             
        }             
    }

    public void Remove()
    {
        int lenght = this.Numbers.Length;

        if (lenght == 0)
        {
            throw new InvalidOperationException("No numbers.");
        }
        this.Numbers[lenght - 1] = 0;
    }

    public int[] Fetch()
    {
        int[] cloneArray = this.numbers.Where(x => x != 0).ToArray();

        return cloneArray;
    }
}

