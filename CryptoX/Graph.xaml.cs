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
    /// Logique d'interaction pour Graph.xaml
    /// </summary>
    public partial class Graph : Window
    {
        public Graph(string name)
        {
            InitializeComponent();
            Initialize(name);
        }

        private async void Initialize (string name)
        {
            LunarCrush Lune = new LunarCrush();
            debug.Text = await Lune.Connect();
        }
    }
}
