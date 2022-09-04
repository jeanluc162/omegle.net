using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

#if (NETSTANDARD2_0_OR_GREATER || NET461_OR_GREATER)
using Microsoft.Extensions.Logging;
#endif

namespace omegle.net
{
    public partial class Client
    {
        protected readonly TaskScheduler _eventLoopCallbackScheduler = TaskScheduler.FromCurrentSynchronizationContext();
        private Thread _eventLoopThread;
        private CancellationTokenSource _cts;
        private void StartEventLoop()
        {
            if(_eventLoopThread != null && _eventLoopThread.IsAlive)
            {
                //TODO: Throw Exception
            }
            _cts?.Dispose();
            _cts = new CancellationTokenSource();
            _eventLoopThread = new Thread(async () => await EventLoop("", _cts.Token)); //TODO: tatsächliche Id mitgeben
            _eventLoopThread.Start();
        }
        private void StopEventLoop()
        {
            if(_eventLoopThread == null || !_eventLoopThread.IsAlive)
            {
                //TODO: Throw Exception
            }
            _cts.Cancel();
            
        }
        private async Task EventLoop(String id, CancellationToken cancellationToken)
        {
            while(!cancellationToken.IsCancellationRequested)
            {
                ICollection<ICollection<String>> Events;
                try
                {
                    Events = await EventsCoreAsync(
                        new Id_params
                        {
                            Id = id
                        },
                        cancellationToken
                    );
                }
                catch(OperationCanceledException)
                {
                    break;
                }
                catch(Exception ex)
                {
                    //TODO: Logging, Errorhandling
                    continue;
                }
                #if (NETSTANDARD2_0_OR_GREATER || NET461_OR_GREATER)
                _logger?.LogDebug("Events abgerufen:\r\n\t{Events}", String.Join("\r\n\t", Events.Select(strings => String.Join(": ", strings))));
                #endif
            }
        }
    }
}