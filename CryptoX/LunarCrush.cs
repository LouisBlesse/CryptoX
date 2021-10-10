using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http.Headers;
using System.Net.Http;

namespace CryptoX
{
    class LunarCrush
    {
        static HttpClient client = new HttpClient();
        public static async Task<string>  Connect()
        {
            string res =
                await client.GetStringAsync(
                    "https://api.lunarcrush.com/v2?data=coinoftheday_info&key=0yhms1bivd391vg0g7klyb1");
            return res;
        }

    }      
}   

