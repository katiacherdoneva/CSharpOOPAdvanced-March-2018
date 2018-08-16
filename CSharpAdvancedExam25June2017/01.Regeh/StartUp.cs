﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class StartUp
{
    static void Main()
    {
        var input = Console.ReadLine();
        var pattern = @"\[[A-Z&a-z]+<([0-9]+)REGEH([0-9]+)>[A-Z&a-z]+\]";
        var regex = Regex.Matches(input, pattern);
        var nums = new List<int>();

        foreach (Match match in regex)
        {
            nums.Add(int.Parse(match.Groups[1].Value));
            nums.Add(int.Parse(match.Groups[2].Value));
        }

        int numSum = 0;
        string result = string.Empty;
        for (int i = 0; i < nums.Count; i++)
        {
            numSum += nums[i];
            numSum %= input.Length;
            result += input[numSum];
        }

        Console.WriteLine(result);
    }
}