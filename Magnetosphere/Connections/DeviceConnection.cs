using System;
using System.Diagnostics;
using System.Threading;

namespace Magnetosphere
{
    public abstract class DeviceConnection : IDisposable
    {
        public abstract string Summary { get; }

        public abstract bool Connect();
        public abstract bool Disconnect();

        public abstract bool SendPacket(byte[] data);
        public abstract bool ReceivePacket(out byte[] data);
        public abstract bool HasPacketReady { get; }

        public Action HandlePendingMessage { protected get; set; }

        private Thread ReactThread;
        public int ReadLoopInterval { get; set; } = 10;

        protected bool Listening;

        public void StartPassiveRead()
        {
            Listening = true;
            ReactThread = new Thread(ListenerLoop)
            {
                IsBackground = true
            };
            ReactThread.Start();
        }

        public void StopPassiveRead() => Listening = false;

        private void ListenerLoop(object state)
        {
            while (Listening)
            {
                try
                {
                    if (HasPacketReady) // data available!
                        HandlePendingMessage?.Invoke();
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
                Thread.Sleep(ReadLoopInterval);
            }

            ReactThread.Join();
            ReactThread = null;
        }

        public virtual void Dispose()
        {
            Listening = false;
            GC.SuppressFinalize(this);
        }
    }
}