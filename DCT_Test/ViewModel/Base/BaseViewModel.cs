using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DCT_Test.ViewModel.Base
{
    public class BaseViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual bool Set<T>(ref T feed, T value, [CallerMemberName] string Prop = null)
        {
            if (Equals(feed, value))
                return false;
            OnPropChanged(Prop);
            return true;
        }

        protected virtual void OnPropChanged([CallerMemberName] string Prop = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Prop));
    }
}
