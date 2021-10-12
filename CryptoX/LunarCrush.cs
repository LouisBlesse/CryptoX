using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http.Headers;
using System.Net.Http;
using Newtonsoft.Json;

namespace CryptoX
{
    class LunarCrush
    {
        public HttpClient client { get; set; }

        public LunarCrush()
        {
            client = new HttpClient();
        }

        public async Task<string> Connect()
        {
            string res =
                    await client.GetStringAsync(
                        "https://api.lunarcrush.com/v2?data=meta&key=0yhms1bivd391vg0g7klyb1&type=price");

            return res;
        }

        public Root transfert (string json){
            Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(json);
            return myDeserializedClass;
        }


        public class Config
        {
            public string data { get; set; }
            public string type { get; set; }
        }

        public class Usage
        {
            public int day { get; set; }
            public int month { get; set; }
        }

        public class Datum
        {
            public int id { get; set; }
            public string name { get; set; }
            public string symbol { get; set; }
            public double? price { get; set; }
            public double? price_btc { get; set; }
            public object market_cap { get; set; }
        }

        public class Root
        {
            public Config config { get; set; }
            public Usage usage { get; set; }
            public List<Datum> data { get; set; }
        }





    }    
    
    
}   

