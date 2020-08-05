using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.IO;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;

namespace ConsoleStock
{
    class Program
    {
        static int Main(string[] args)
        {

            string[] symbols = { "ABEV3", "AZUL4", "BTOW3", "B3SA3", "BBSE3", "VRML3", "BBDC4", "BBDC3", "PETR4", "PETR3", "BRDT3", "QUAL3", "RADL3", "RAIL3", "SBSP3" };
            
            // Getting value of stock
            string symbol = args[0];

            if ((args.Length) != 3)
            {
                Console.WriteLine("Please enter a valid argument params");
                Console.WriteLine("Usagename: prototype <PETR4> <num_max> <num_min>");
                return 0;
            }
            if (!(symbols.Contains(symbol)))
            {
                Console.WriteLine("Invalid stock input");
                return 0;

            }
            else
            { 
                //Getting url
                string url = Function.GetURL(symbol);

                //Get Stock data
                Task<string> task = Function.GetStock(url);

                string response = task.Result;
            
                //Handle response
                Root handledResponse = Function.HandleResponse(response, symbol);

                string name = handledResponse.results.stock.name;
                double price = handledResponse.results.stock.price;
                string updated_at = handledResponse.results.stock.updated_at;

                // Convert values of max quote and min quote
                decimal num_max;
                decimal num_min;
                bool test_max = decimal.TryParse(args[1], out num_max);
                bool teste_min = decimal.TryParse(args[2], out num_min);

                // Tracking Stock.
                string result = Function.Track(symbol);

                //Send email;
                //Function.SendEmail(result);
           
                //Print Result
                Console.WriteLine($"The stock {symbol} is being tracking.");
                Console.WriteLine($"The max price is {num_max} and the min price is {num_min}.");
                Console.ReadLine();
            return 0;
        }
        
    }
}