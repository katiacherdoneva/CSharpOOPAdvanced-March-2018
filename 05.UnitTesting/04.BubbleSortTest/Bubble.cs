using System;
using System.Collections.Generic;
using System.Text;

public class Bubble
{
    private int[] numbers;

    public Bubble(int[] numbers)
    {
        this.numbers = numbers;
    }

    public void BubbleSort()
    {
        int temp = 0;

        for (int write = 0; write < this.numbers.Length; write++)
        {
            for (int sort = 0; sort < this.numbers.Length - 1; sort++)
            {
                if (this.numbers[sort] > this.numbers[sort + 1])
                {
                    temp = this.numbers[sort + 1];
                    this.numbers[sort + 1] = this.numbers[sort];
                    this.numbers[sort] = temp;
                }
            }
        }
    }
}

