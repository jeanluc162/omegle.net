using System.Collections.ObjectModel;

namespace omegle.net
{
    public partial class Client
    {
        private ObservableCollection<Message> _Messages;
        public ObservableCollection<Message> Messages
        {
            get => _Messages;
            set => SetWithNotify(value, out _Messages);
        }
    }
}