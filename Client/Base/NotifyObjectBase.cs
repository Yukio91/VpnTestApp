using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace vpn.Client.Base
{
    public abstract class NotifyObjectBase : INotifyPropertyChanged
    {
        protected NotifyObjectBase()
        {

        }

        #region INotifyPropertyChanged members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
