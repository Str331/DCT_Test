using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCT_Test.Model
{
    public class Trade
    {
        public string MainId { get; set; }

        public string ConvertId { get; set; }

        public string QuoteId { get; set; }

        public string Symb { get; set; }

        public string QuoteSymb { get; set; }

        public double? Price { get; set; }

        public double? ChangePriceByDay { get; set; }

        public double? ChangePercentByDay { get; set; }
    }
}
