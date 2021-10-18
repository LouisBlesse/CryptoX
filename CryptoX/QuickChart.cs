using QuickChart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoX
{
    public class QChart
    {
        public static string Build(List<Window1.DataToDisplay> AllDataToDisplay)
        {
            Chart qc = new Chart();

            qc.Width = 500;
            qc.Height = 300;
            qc.Config = @"{
              type: 'bar',
              data: {
                labels: ['" + AllDataToDisplay[0].name + "','" + AllDataToDisplay[1].name + "','" + AllDataToDisplay[2].name + "','" + AllDataToDisplay[3].name + "','" + AllDataToDisplay[4].name + @"'],
                datasets: [{
                  label: 'Cryptomonaies les plus chères',
                  data: [" + Convert.ToInt32(AllDataToDisplay[0].price) + "," + Convert.ToInt32(AllDataToDisplay[1].price) + "," + Convert.ToInt32(AllDataToDisplay[2].price) + "," + Convert.ToInt32(AllDataToDisplay[3].price) + "," + Convert.ToInt32(AllDataToDisplay[4].price) + @"]
                }]
              }
            }";

            return qc.GetUrl();
        }
    }
}
