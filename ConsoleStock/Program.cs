using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

            string[] symbols = { "ABEV3", "AZUL4", "BTOW3", "B3SA3", "BBSE3", "VRML3", "BBDC4", "BBDC3", "PETR4", "PETR3", "BRDT3", "QUAL3", "RADL3", "RAIL3", "SBSP3", "BIDI4" };

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

                // Convert values of max quote and min quote
                double num_max;
                double num_min;
                bool test_max = double.TryParse(args[1], out num_max);
                bool teste_min = double.TryParse(args[2], out num_min);

                bool condition = false;

                string response;

                string name;
                double price;
                string updated_at;

                //Print Result
                Console.WriteLine($"The stock {symbol} is being tracked.");
                Console.WriteLine($"The max price is {num_max} and the min price is {num_min}.");

                do
                {
                    Console.WriteLine($"The stock {symbol} is being tracking.");

                    //Get Stock data
                    Task<string> task = Function.GetStock(url);

                    response = task.Result;

                    //Handle response
                    Root handledResponse = Function.HandleResponse(response, symbol);

                    name = handledResponse.results.stock.name;
                    price = handledResponse.results.stock.price;
                    updated_at = handledResponse.results.stock.updated_at;

                    condition = !(num_max < price | num_min > price);
                    Console.WriteLine(condition);
                    Console.WriteLine(price);
                    Console.WriteLine(num_max);

                    //time sleep
                    Thread.Sleep(5000);

                } while (condition);

                //handling price

                string msgemail;

                if (num_max < price)
                {
                    msgemail = "Coe pedrin pode vender a ação trackada!";
                }
                else
                {
                    msgemail = "Coe pedrin pode comprar a ação trackada!";
                }

                //Send email;
                Function.SendEmail(msgemail);


                Console.ReadLine();
                return 0;
            }

        }
    }
}