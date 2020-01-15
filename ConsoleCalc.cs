using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
					
public class Program
{
	public static string numbersBox = Console.ReadLine();
	
	public static void Main()
	{
		Regex regex = new Regex("^[a-zA-Z^$.|?*+(){}/`~_=';:><[]+$");
            bool hasOnlyAlpha = regex.IsMatch(numbersBox);
            if (string.IsNullOrWhiteSpace(numbersBox) || hasOnlyAlpha)
            {
                Console.WriteLine("I need numbers to do the math...");
                return;
            }

            string[] numbers = numbersBox.Split(',');
            List<int> ints = new List<int>() { };

            foreach (string number in numbers)
            {
                int x = Int32.Parse(number);
                ints.Add(x);
            }

            int sum = ints.Sum();
            int mean = sum / ints.Count;
			Console.WriteLine("\nMEAN: " + mean.ToString());

            List<int> mads = new List<int>() { };
            foreach (int number in ints)
            {
                int x = number - mean;
                if (x < 0) { x *= -1; }
                mads.Add(x);
            }

            float mad = (float)mads.Sum() / (float)mads.Count();
            Console.WriteLine("MAD: " + mad.ToString());
	}
}
