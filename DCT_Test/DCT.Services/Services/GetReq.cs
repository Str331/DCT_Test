using DCT_Test.Properties;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DCT_Test.Model;

namespace DCT_Test.DCT.Services.Services
{
    public class GetReq:IGetReq
    {
        public string Get(string URL, List<TryFind> ParamList = null)
        {
            URL = "https://api.coincap.io/v2/";
            var client = new RestClient(URL);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            if (ParamList != null)
            {
                foreach (var parametres in ParamList)
                    request.AddParameter(parametres.CoinName, parametres.Value);
            }
            var response = client.Execute(request);
            JObject obj = JObject.Parse(response.Content);
            try
            {
                string data = obj["data"].ToString();
                return data;
            }
            catch (NullReferenceException) { }
            return null;
        }

        public ObservableCollection<Resource> GetByResources(List<TryFind> ParamList = null)
        {
            string URL = "assets";
            string response;
            if (ParamList == null)
                response = Get(URL);
            else
                response = Get(URL, ParamList);
            if (response != null)
            {
                ObservableCollection<Resource> assets = JsonConvert.DeserializeObject<ObservableCollection<Resource>>(response);
                return assets;
            }
            return null;
        }

        public ObservableCollection<Points> GetPoints(string ResId, string span, List<TryFind> ParamList = null)
        {
            string URL = $"assets/{ResId}/history?interval={span}";
            string responseData;
            if (ParamList == null)
                responseData = Get(URL);
            else
                responseData = Get(URL, ParamList);
            if (responseData != null)
            {
                ObservableCollection<Points> points = JsonConvert.DeserializeObject<ObservableCollection<Points>>(responseData);
                return points;
            }
            return null;
        }

        public Prediction GetPred(string ResId)
        {
            string URL = $"rates/{ResId}";
            string responseData;
            responseData = Get(URL);
            if (responseData != null)
            {
                Prediction prediction = JsonConvert.DeserializeObject<Prediction>(responseData);
                return prediction;
            }
            return null;
        }

        public ObservableCollection<Trade> GetTradeData(string ResId, List<TryFind> ParamList = null)
        {
            string URL = $"assets/{ResId}/markets";
            string responseData;
            if (ParamList == null)
            {
                responseData = Get(URL);
            }
            else
            {
                responseData = Get(URL, ParamList);
            }
            if (responseData != null)
            {
                ObservableCollection<Trade> trades = JsonConvert.DeserializeObject<ObservableCollection<Trade>>(responseData);
                return trades;
            }
            return null;
        }
    }
}
