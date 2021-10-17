using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoX
{
    class ViewModel
    {
        private static List<Window1.DataToDisplay> AllDataToDisplay = new List<Window1.DataToDisplay>() { };

        public ViewModel(List<Window1.DataToDisplay> DataInList)
        {
            AllDataToDisplay = DataInList;
        }
    }
}
