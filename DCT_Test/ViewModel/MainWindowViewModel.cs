using DCT_Test.DCT.Domain.Infrastructure.Commands;
using DCT_Test.DCT.Services.Services;
using DCT_Test.Model;
using DCT_Test.Properties;
using DCT_Test.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DCT_Test.ViewModel
{
    class MainWindowViewModel : BaseViewModel
    {
        #region Variables

        GetReq requests = new GetReq();
        Converter convert = new Converter();


        private string _ConvertedCurrency = null;
        public string ConvertedCurrency
        {
            get => _ConvertedCurrency;
            set => Set(ref _ConvertedCurrency, value);
        }

        private Resource _ToConvert;
        public Resource ToConvert
        {
            get => _ToConvert;
            set => Set(ref _ToConvert, value);
        }
        private Resource _ConvertInto;
        public Resource ConvertInto
        {
            get => _ConvertInto;
            set => Set(ref _ConvertInto, value);
        }

        private double _ConvertAmount = 0;
        public double ConvertAmount
        {
            get => _ConvertAmount;
            set => Set(ref _ConvertAmount, value);
        }
        private Resource _PlotCurrency = null;
        public Resource PlotCurrency
        {
            get => _PlotCurrency;
            set => Set(ref _PlotCurrency, value);
        }
        private Resource _Details = null;
        public Resource Details
        {
            get => _Details;
            set
            {
                _Details = value;
                OnPropChanged(nameof(Details));
            }
        }

        private ObservableCollection<Resource> _Info;
        public ObservableCollection<Resource> Info
        {
            get => _Info;
            set
            {
                _Info = value;
                OnPropChanged(nameof(Info));
            }
        }

        private ObservableCollection<Trade> _Markets;
        public ObservableCollection<Trade> Markets
        {
            get => _Markets;
            set
            {
                _Markets = value;
                OnPropChanged(nameof(Markets));
            }
        }

        public ObservableCollection<Resource> BestAssets { get; }
        public ObservableCollection<Resource> Currencies { get; }
        public ObservableCollection<Periods> Points { get; private set; } = null;
        #endregion
        #region Commands
        public ICommand ConvertCurrencyCommand { get; }

        private bool CanConvertCurrencyCommandExecute(object p)
        {
            if (_ToConvert != null && _ConvertInto != null && _ConvertAmount != 0) return true;
            return false;
        }

        private void OnConvertCurrencyCommandExecuted(object p)
        {
            double result = convert.Convert(_ToConvert.Id, _ConvertInto.Id, _ConvertAmount);
            if (result != 0)
            {
                ConvertedCurrency = result.ToString();
            }
            else
            {
                ConvertedCurrency = "Converting impossible";
            }
        }

        public ICommand CloseApplicationCommand { get; }
        private bool CanCloseApplicationCommandExecute(object p) => true;
        private void OnCloseApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }
        public ICommand DrawChartCommand { get; }
        private bool CanDrawChartCommandExecute(object p)
        {
            if (PlotCurrency != null)
            {
                return true;
            }
            return false;
        }

        private void OnDrawChartCommandExecuted(object p)
        {
            ObservableCollection<Points> unixPoints = requests.GetPoints(PlotCurrency.Id, "d1");
            Points = new ObservableCollection<Periods>();
            foreach (var up in unixPoints)
            {
                DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                DateTime date = start.AddMilliseconds(up.Period).ToLocalTime();

                Points.Add(new Periods { Price = up.Price, Date = date });
            }
            OnPropChanged("Points");
        }
        public ICommand ShowInfoCommand { get; }
        private bool CanShowInfoCommandExecute(object p)
        {
            if (Details != null)
            {
                return true;
            }
            return false;
        }
        private void OnShowInfoCommandExecuted(object p)
        {
            Info = new ObservableCollection<Resource>()
            {
                Details
            };
            List<TryFind> parametersAllMarkets = new List<TryFind>()
            {
                new TryFind
                {
                    CoinName = "limit",
                    Value = 2000
                }
            };
            Markets = requests.GetTradeData(Details.Id, parametersAllMarkets);

        }
        #endregion

        public MainWindowViewModel()
        {
            ShowInfoCommand = new Command(OnShowInfoCommandExecuted, CanShowInfoCommandExecute);
            DrawChartCommand = new Command(OnDrawChartCommandExecuted, CanDrawChartCommandExecute);
            ConvertCurrencyCommand = new Command(OnConvertCurrencyCommandExecuted, CanConvertCurrencyCommandExecute);
            CloseApplicationCommand = new Command(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);

            List<TryFind> parametersAllAssets = new List<TryFind>()
            {
                new TryFind
                {
                    CoinName = "limit",
                    Value = 2000
                }
            };
            Currencies = requests.GetByResources(parametersAllAssets);
            BestAssets = new ObservableCollection<Resource>();
            for (int i = 0; i < 10; i++)
            {
                BestAssets.Add(Currencies[i]);
            }
        }
    }
}
