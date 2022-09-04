using System;

namespace omegle.net
{
    public partial class Client
    {
        protected enum States { Searching, Connected, Connecting, Disconnecting, Disconnected}
        private States _State = States.Disconnected;
        protected States State 
        {
            get => _State;
            set => SetWithNotify(value, out _State);
        }
        private String _Id;
        protected String Id
        {
            get => _Id;
            set => SetWithNotify(value, out _Id);
        }
        private String _RandId;
        protected String RandId
        {
            get => _RandId;
            set => SetWithNotify(value, out _RandId);
        }
    }
}