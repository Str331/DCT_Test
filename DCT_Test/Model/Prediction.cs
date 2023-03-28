using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCT_Test.Model
{
    public class Prediction
    {
        public string Id { get; set; }

        public string CoinType { get; set; }

        public double PredByPrice { get; set; }

        public string Symb { get; set; }

        public string CurrentSymb { get; set; }
    }
}
