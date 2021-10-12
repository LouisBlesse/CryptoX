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

namespace CryptoX
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            Initialize();
        }

        public async Task Initialize()
        {
            LunarCrush Lune = new LunarCrush();
            val.Text = await Lune.Connect();
            List<string> AllName = new List<string>() { } ;

            try
            {
                LunarCrush.Root tmp = Lune.transfert(val.Text);
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

        }
    }
}
