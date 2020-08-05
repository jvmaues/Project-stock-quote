using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Linq;
using System.Text;
using System.Web;
using System.Net;
using System.IO;




public class CallApi
{
    private const string URL = "https://api.hgbrasil.com/finance";
    private string urlParameters = "?key=9f40c222";
    private string stockParameters = "symbol=";
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

        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri(URL);

        // Add an Accept header for JSON format.
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        HttpResponseMessage response = client.GetAsync().Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.

        Console.WriteLine(response);

        //Make any other calls using HttpClient here.

        //Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
        client.Dispose();

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