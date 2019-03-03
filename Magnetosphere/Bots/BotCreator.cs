using System;
using System.Linq;

namespace Magnetosphere
{
    /// <summary>
    /// Provides logic to instantiate a new <see cref="Bot"/> object.
    /// </summary>
    public static class BotCreator
    {
        private static Bot CreateBot(DeviceMessenger msg, DeviceType type)
        {
            switch (type)
            {
                case DeviceType.NintendoSwitch:
                    return new BotSwitch(msg);
                case DeviceType.Nintendo3DS:
                    return new Bot3DS(msg);
                default:
                    return null;
            }
        }

        private static Bot CreateBot(DeviceType b, Protocol p, ConnectionType t, params string[] args)
        {
            var c = ConnectionUtil.GetConnection(t, args);
            var messenger = MessengerUtil.GetMessenger(c, p);
            var bot = CreateBot(messenger, b);
            return bot;
        }

        /// <summary>
        /// Creates a new <see cref="Bot"/> from the configuration details.
        /// </summary>
        /// <param name="config">Bot configuration details</param>
        /// <returns>New Bot object</returns>
        public static Bot CreateBot(this BotConfig config)
        {
            var args = config.Arguments
                .Split(new[] {BotConfig.Separator}, StringSplitOptions.RemoveEmptyEntries)
                .Select(z => z.Trim()).ToArray();

            var bot = CreateBot(config.DeviceType, config.Protocol, config.ConnectionType, args);
            bot.Config = config;

            return bot;
        }
    }
}