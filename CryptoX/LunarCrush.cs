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
        public HttpClient client { get; set; }

        public LunarCrush()
        {
            client = new HttpClient();
        }

        public async Task<string> Connect()
        {

            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader(await client.GetStringAsync(
                       "https://api.lunarcrush.com/v2?data=coinoftheday_info&key=0yhms1bivd391vg0g7klyb1")))
                {
                    string line;
                    // Read and display lines from the file until the end of
                    // the file is reached.
                    while ((line = sr.ReadLine()) != null)
                    {
                        return line;
                    }
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }

            //string res =
            //        await client.GetStringAsync(
            //            "https://api.lunarcrush.com/v2?data=coinoftheday_info&key=0yhms1bivd391vg0g7klyb1");
            //return res;
        }
    }      
}   

