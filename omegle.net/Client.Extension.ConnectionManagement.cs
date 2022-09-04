using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace omegle.net
{
    public partial class Client
    {
        private Random _random;
        private const String DefaultOmegleBaseUrl = "https://omegle.com";
        private const String RandomIdChars = "ABCDEFGHJKLMNPQRSTUVW23456789";
        public async Task ConnectAsync(CancellationToken cancellationToken)
        {
            EnsureConnectionPrerequisites();
            var Status = await StatusCoreAsync(
                _random.NextDouble(),
                RandId
            );
            var StartResponse = await StartCoreAsync(Rcs._1, Firstevents._0, RandId, null, null, null, null, null, null, null, cancellationToken);
            Id = StartResponse.ClientID;
            StartEventLoop();
        }
        public void Connect()
        {
            EnsureConnectionPrerequisites();
            var Status = StatusCore(
                _random.NextDouble(),
                RandId
            );
            var StartResponse = StartCore(Rcs._1, Firstevents._0, RandId, null, null, null, null, null, null, null);
            Id = StartResponse.ClientID;
            StartEventLoop();
        }
        private void EnsureConnectionPrerequisites()
        {
            if(State != States.Disconnected)
            {
                //TODO: Exception, Logging
            }
            RandId = new string(Enumerable.Repeat(RandomIdChars, 8).Select(s => s[_random.Next(s.Length)]).ToArray());
            BaseUrl = DefaultOmegleBaseUrl;
        }
        private void SelectRandomServerUrl(Status_response status)
        {
            BaseUrl = status.Servers.ElementAt(_random.Next(0, status.Servers.Count));
        }
        public async Task DisconnectAsync()
        {

        }
        public void Disconnect()
        {

        }
    }
}