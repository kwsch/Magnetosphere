using System;

namespace Magnetosphere
{
    public static class MessengerUtil
    {
        public static DeviceMessenger GetMessenger(DeviceConnection connection, Protocol protocol)
        {
            switch (protocol)
            {
                case Protocol.Atmosphere:
                    return new AMSMessenger(connection);
                case Protocol.NTR:
                    return new NTRMessenger(connection);
                case Protocol.Citra:
                    return new CitraMessenger(connection);
                default:
                    return null;
            }
        }

        public static object GetTranslator(DeviceMessenger msg)
        {
            switch (msg)
            {
                case NTRMessenger n:
                    return new NTRTranslator(n);

                case AMSMessenger a:
                    return new AMSTranslator(a);

                case CitraMessenger c:
                    return new CitraTranslator(c);

                default:
                    throw new ArgumentException($"{nameof(msg.GetType)} does not have a C# communication API.");
            }
        }
    }
}
