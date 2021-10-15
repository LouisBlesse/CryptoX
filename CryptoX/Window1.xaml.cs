using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Threading;

namespace CryptoX
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private static Task<LunarCrush.Root> AllData;

        public Window1()
        {
            InitializeComponent();
            Window1.AllData = Initialize();
            List<DataToDisplay> ToDisplay = GetTheTop(AllData); ////Dont work
        }

        private async Task<LunarCrush.Root> Initialize()
        {
            LunarCrush Lune = new LunarCrush();
            val.Text = await Lune.Connect();
            List<string> AllName = new List<string>() { } ;
            LunarCrush.Root tmp = Lune.transfert(val.Text);

            try
            {
                for (int i=0; i<tmp.data.Count; i++)
                {
                    AllName.Add(tmp.data[i].name);
                }
                choix.ItemsSource = AllName;
                
            }
            catch (Exception e)
            {
                val2.Text = e.ToString();
            }
            return tmp;
        }

        private void GetCheckBox(Task<LunarCrush.Root> AllData)
        {
            var queryAllDataName = from Data in AllData.Result.data
                                   where Data.name == choix.Text
                                   select new { name = Data.name, price = Data.price};


            foreach (var item in queryAllDataName)
            {
                val2.Text = "La crypto monaie est le " + item.name + "sa valeure est de "+ item.price+".";
            }
        }

        private void Button_Clicked(object sender, RoutedEventArgs e)
        {
            val2.Text = "try Button_Clicked";
            GetCheckBox(Window1.AllData);
        }

        //////////Graphiques (dont work)
        ///
        private List<DataToDisplay> GetTheTop (Task<LunarCrush.Root> AllData)
        {
            List<DataToDisplay> AllDataToDisplay = new List<DataToDisplay>() { };

            /*var queryTop = (from Data in AllData.Result.data
                              orderby Data.price
                            select new DataToDisplay { name = Data.name, price = Data.price }).Take(5);*/

             /*foreach (var item in queryTop.Take(5))
             {
                 AllDataToDisplay.Add(item);
             }*/

            return AllDataToDisplay;
        }


        public class DataToDisplay
        {
            public string name { get; set; }
            public double? price { get; set; }
        }
    }
}
