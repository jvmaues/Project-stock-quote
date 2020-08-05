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
    class Function
    {
        private static string handlededresponse;

        public static string Track(string name)
        {
            string msg = $"The {name} is being tracking.";
            return msg;
        }

        public static async Task<string> GetStock(string url)
        {
            string text = await new System.Net.WebClient().DownloadStringTaskAsync(url);

            return text;
        }

        public static string GetURL(string symbol)
        {
            string url_standard = "https://api.hgbrasil.com/finance/stock_price?key=9f40c222&symbol=";

            string url = url_standard + symbol;

            return url;
        }
        

        public static Root HandleResponse(string response, string symbol)
        {
            string temp = response.Replace(symbol, "stock");
            Root handledResponse = JsonConvert.DeserializeObject<Root>(temp);

            return handledResponse;
        }

        public static void SendEmail(string sendmessage)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                //message setting
                message.From = new MailAddress("mauesdevtest@gmail.com");
                message.To.Add(new MailAddress("jvmaues@gmail.com"));

                message.Subject = "Test";
                message.IsBodyHtml = false;
                message.Body = sendmessage;
                //smtp setting
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("mauesdevtest@gmail.com", "devtest318");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}