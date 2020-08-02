using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;


public class DataObject
{
    public string Name { get; set; }
}

public class Functions
{
    public static int Track(string name)
    {
        // Test for invalid input.
        if (name != "PETR4")
        {
            return -1;
        }
        return 0;
    }
}

class MainClass
{
    static int Main(string[] args)
    {
	    string stock = args[0];

	    if ((args.Length) != 3)
            {
                Console.WriteLine("Please enter a valid argument params");
                Console.WriteLine("Usagename: prototype <PETR4> <num_max> <num_min>");
                return 1;
            }

        // Convert values of max and min
        decimal num_max;
        decimal num_min;
        bool test_max = decimal.TryParse(args[1], out num_max);
        bool teste_min = decimal.TryParse(args[2], out num_min);
        
        // Tracking Stock.
        int result = Functions.Track(stock);

        // Print result.
        if (result == -1)
            Console.WriteLine("Invalid input");
        else
            Console.WriteLine($"The stock {stock} is being tracking.");
            Console.WriteLine($"The max price is {num_max} and the min price is {num_min}.");
        return 0;
    }
}