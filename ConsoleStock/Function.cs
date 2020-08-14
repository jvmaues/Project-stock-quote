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
using Microsoft.SqlServer.Server;

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

        public static async Task<string> GetStock(string url, string urlquote)
        {
            var httpClient = new HttpClient();
            var request1 = new HttpRequestMessage(HttpMethod.Post, url);
            var response = await httpClient.SendAsync(request1);
            var contents = await response.Content.ReadAsStringAsync();

            var request2 = new HttpRequestMessage(HttpMethod.Get, urlquote);
            var response2 = await httpClient.SendAsync(request2);
            var contents2 = await response2.Content.ReadAsStringAsync();
            return contents2;
        }

        public static string PostLogin()
        {
            try
            {
                String server = "https://webfeeder.cedrotech.com";
                String login = "jvmaues@gmail.com";
                String password = "maues012";
                String urlParameter = "http://" + server + "/SignIn?login=" + login + "&password=" + password;

                return urlParameter;
            }
            catch (Exception e)
            {
                return e.ToString();
            }
           
        }

        public static string GetURL(string symbol)
        {
            //string url_standard = "https://api.hgbrasil.com/finance/stock_price?key=9f40c222&symbol=";
            //string url_standard = "/services/quotes/quote/"
            //string url = url_standard + symbol;

            String server = "https://webfeeder.cedrotech.com";
            String login = "jvmaues@gmail.com";
            String password = "maues012";
            String urlParameter = "http://" + server + "/SignIn?login=" + login + "&password=" + password;

            return urlParameter;
        }

        public static ConfigSmtp HandleConfigJson()
        {
            using (StreamReader r = new StreamReader("../../configSmtp.json"))
            {
                var json = r.ReadToEnd();
                ConfigSmtp config = JsonConvert.DeserializeObject<ConfigSmtp>(json);
                return config;
            }
            
        }
        

        public static Quote HandleResponse(string response)
        {
  
            Quote handledResponse = JsonConvert.DeserializeObject<Quote>(response);

            return handledResponse;
            
        }

        public static void SendEmail(string sendmessage, ConfigSmtp config)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                //message setting
                message.From = new MailAddress(config.emailcredencial);
                message.To.Add(new MailAddress(config.email));
                
                message.Subject = "Alert Quote";
                message.IsBodyHtml = false;
                message.Body = sendmessage;
                //smtp setting
                smtp.Port = config.port;
                smtp.Host = config.host;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(config.emailcredencial, config.password);
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