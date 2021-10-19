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
using System.Web;

namespace CryptoX
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private static Task<LunarCrush.Root> AllData;
        private static List<DataToDisplay> AllDataToDisplay = new List<DataToDisplay>() { };

        public Window1()
        {
            InitializeComponent();
            Window1.AllData = Initialize();
        }

        private async Task<LunarCrush.Root> Initialize()
        {
            LunarCrush Lune = new LunarCrush();
            val.Text = await Lune.Connect();
            List<string> AllName = new List<string>() { } ;
            LunarCrush.Root tmp = Lune.transfert(val.Text);

            try
            {
                for (int i=0; i<20; i++)
                {
                    AllName.Add(tmp.data[i].name);
                }
                choix.ItemsSource = AllName;
                
            }
            catch (Exception e)
            {
                textbox2.Text = e.ToString();
                textbox4.Text = e.ToString();
                textbox6.Text = e.ToString();
                textbox8.Text = e.ToString();
                textbox10.Text = e.ToString();
            }
            return tmp;
        }

        private void GetCheckBox(Task<LunarCrush.Root> AllData)
        {
            var queryAllDataName = from Data in AllData.Result.data
                                   where Data.name == choix.Text
                                   select new { Name = Data.name, Price = Data.price, Symbol = Data.symbol, Price_btc = Data.price_btc, Market_cap = Data.market_cap};


            foreach (var item in queryAllDataName)
            {
                textbox2.Text = item.Name;
                textbox4.Text = item.Symbol;
                textbox6.Text = "" + item.Price;
                textbox8.Text = "" + item.Price_btc;
                textbox10.Text = "" + item.Market_cap;
            }

            /*Graph p = new Graph(textbox4.Text);
            p.Show();*/
        }


        //Boutons
        private void Button_Clicked(object sender, RoutedEventArgs e)
        {
            GetCheckBox(Window1.AllData);
        }
        
        private void Button_Clicked_Get(object sender, RoutedEventArgs e)
        {
            Window1.AllDataToDisplay = GetTheTop(Window1.AllData);
        }

        //////////Graphiques
        private List<DataToDisplay> GetTheTop (Task<LunarCrush.Root> AllData)
        {
            List<DataToDisplay> AllDataToDisplay = new List<DataToDisplay>() { };

            var queryTop = (from Data in AllData.Result.data
                              orderby Data.price.HasValue descending
                            select new DataToDisplay { name = Data.name, price = Data.price }).Take(5);

             foreach (DataToDisplay item in queryTop)
             {
                 AllDataToDisplay.Add(item);
            }
            
            Graph.Source = new BitmapImage(new Uri(QChart.Build(@AllDataToDisplay))); //Ligne de code tres compliquée pour récuperer l'urlk sous forme de string et la remettre en url
            return AllDataToDisplay;
        }


        public class DataToDisplay
        {
            public string name { get; set; }
            public double? price { get; set; }
        }
    }

}
