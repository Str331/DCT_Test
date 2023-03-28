using DCT_Test.Model;
using DCT_Test.Properties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCT_Test.DCT.Services.Services
{
    public interface IGetReq
    {
        string Get(string URL, List<TryFind> ParamList = null);

        ObservableCollection<Resource> GetByResources(List<TryFind> ParamList = null);

        ObservableCollection<Trade> GetTradeData(string ResId, List<TryFind> ParamList = null);

        Prediction GetPred(string ResId);

        ObservableCollection<Points> GetPoints(string ResId, string span, List<TryFind> ParamList = null);
    }
}
