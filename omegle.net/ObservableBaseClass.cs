using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace omegle.net
{
    public abstract class ObservableBaseClass : INotifyPropertyChanged, INotifyPropertyChanging
    {
        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;
        protected void SetWithNotify<T>(T value, out T field, [CallerMemberName] string propertyName = "")
        {
            NotifyChanging(propertyName);
            field = value;
            NotifyChanged(propertyName);
        }
        private void NotifyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private void NotifyChanging(string propertyName)
            => PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(propertyName));
    }
}