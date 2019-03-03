using System.Collections.Generic;

namespace Magnetosphere
{
    /// <summary>
    /// Collection of <see cref="Bot"/> objects.
    /// </summary>
    public class BotManager : IBotObserver
    {
        public readonly List<BotConfig> BotConfigs = new List<BotConfig>();
        private readonly List<Bot> Bots = new List<Bot>();
        public IBotObserver Parent { private get; set; }
        public int Count => Bots.Count;

        public IReadOnlyList<Bot> GetBotsWithState(DeviceState state) => Bots.FindAll(z => z.State == state);

        /// <summary>
        /// Creates and adds a new <see cref="Bot"/> from the provided details.
        /// </summary>
        /// <param name="config">Requested Bot configuration</param>
        /// <returns>New Bot object</returns>
        public Bot AddBot(BotConfig config)
        {
            BotConfigs.Add(config);

            var bot = config.CreateBot();
            Bots.Add(bot);
            bot.Updated += (_, __) => UpdateBotState();
            // don't connect to bot yet
            return bot;
        }

        /// <summary>
        /// Gets the Bot at the requested index.
        /// </summary>
        /// <param name="index">Bot index within <see cref="Bots"/></param>
        /// <returns>Existing bot</returns>
        public Bot this[int index] => Bots[index];

        public void RemoveBot(int index)
        {
            var bot = Bots[index];
            if (bot.State != DeviceState.Disconnected)
                bot.Disconnect();

            BotConfigs.RemoveAt(index);
            Bots.RemoveAt(index);
        }

        public void UpdateBotState() => Parent.UpdateBotState();
    }
}