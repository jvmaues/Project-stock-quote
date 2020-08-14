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
                double.TryParse(args[1], out num_max);
                double.TryParse(args[2], out num_min);

                //Print Result
                Console.WriteLine($"The stock {symbol} is being tracked.");
                Console.WriteLine($"The max price is {num_max} and the min price is {num_min}.");

                string server = "webfeeder.cedrotech.com";
                string login = "jvmaues@gmail.com";
                string password = "maues012";
                string urlParameter = "http://" + server + "/SignIn?login=" + login + "&password=" + password;

                

                
                while(true) {
                    double price;
                    bool condition = false;
                    do
                    {
                        string urlquote_base = "http://webfeeder.cedrotech.com/services/quotes/quote/";

                        string urlquote = urlquote_base + symbol;

                        //Getting stock response
                        Task<string> resp = Function.GetStock(urlParameter, urlquote);

                        string response = resp.Result;

                        Quote handledResponse = Function.HandleResponse(response);

                        price = handledResponse.lastTrade;

                        condition = !(num_max < price | num_min > price);

                        //time sleep
                        Thread.Sleep(120000);
                        Console.WriteLine($"The stock {symbol} is being tracking.");

                    } while (condition);

                    //handling alert message

                    string msgemail;

                    if (num_max < price)
                    {
                        msgemail = $"O papel {symbol} pode ser vendido no valor de {price}.";
                    }
                    else
                    {
                        msgemail = $"O papel {symbol} pode ser comprado no valor de {price}.";
                    }

                    //handle ConfigSmtp
                    ConfigSmtp config = Function.HandleConfigJson();

                    //Send email;
                    Function.SendEmail(msgemail, config);

                    
                }
                return 0;
            }

        }
    }
}