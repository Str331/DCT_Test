using DCT_Test.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCT_Test.DCT.Services.Services
{
    public class Converter:IConverter
    {
        public double Convert(string FirstId, string LastId, double Quantity)
        {
            GetReq request = new GetReq();
            Prediction StartPrediction = request.GetPred(FirstId);
            Prediction EndPrediction = request.GetPred(LastId);
            if (StartPrediction != null && EndPrediction != null)
            {
                double USD = Quantity * StartPrediction.PredByPrice;
                return USD / EndPrediction.PredByPrice;
            }
            return 0;
        }
    }
}
