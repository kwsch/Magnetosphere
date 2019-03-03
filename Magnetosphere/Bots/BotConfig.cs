using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Magnetosphere
{
    /// <summary>
    /// Configuration data for a <see cref="Bot"/> that can be saved for later reuse.
    /// </summary>
    [Serializable]
    public class BotConfig
    {
        [NonSerialized]
        public const string Config = "Configuration";

        [NonSerialized]
        public const string Inputs = "Inputs";

        [NonSerialized]
        public const string Separator = ",";

        // Configuration

        [Category(Config), Description("Communication method to the device.")]
        public ConnectionType ConnectionType { get; set; }

        [Category(Config), Description("Communication protocol when conversing with the device.")]
        public Protocol Protocol { get; set; }

        [Category(Config), Description("Type of the device to be communicated with.")]
        public DeviceType DeviceType { get; set; }

        // Inputs

        [Category(Inputs), Description("Name of the device to differentiate between multiple devices.")]
        public string Name { get => _name; set => _name = Default ? _name : value; }

        private string _name;

        [Category(Inputs), Description("Inputs that are required to connect to the device.")]
        public string Arguments { get; set; }

        // Misc

        [NonSerialized]
        private bool Default;

        [NonSerialized]
        public bool IsFunctional = true;

        /// <summary>
        /// Creates a copy of the data for later mutation.
        /// </summary>
        /// <returns></returns>
        public BotConfig Clone()
        {
            var bot = (BotConfig)MemberwiseClone();
            bot.Default = false;
            return bot;
        }

        /// <summary>
        /// Default <see cref="Bot"/> setup parameters, which can be configured prior to creating a new <see cref="Bot"/>.
        /// </summary>
        /// <returns></returns>
        public static BotConfig[] GetFunctionalDefaultBots()
        {
            var defaults = typeof(BotConfig).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);
            var configs = defaults.Select(z => z.GetValue(typeof(BotCreator))).OfType<BotConfig>();
            #if !DEBUG
            configs = configs.Where(c => c.IsFunctional);
            #endif
            return configs.ToArray();
        }

        /// <summary>
        /// Default <see cref="Atmosphere"/> based <see cref="Bot"/>.
        /// </summary>
        public static BotConfig Atmosphere = new BotConfig
        {
            _name = "My Switch",
            Default = true,
            Protocol = Protocol.Atmosphere,
            DeviceType = DeviceType.NintendoSwitch,
            ConnectionType = ConnectionType.Tcp,
            Arguments = "192.168.0.1,8000",
            IsFunctional = false,
        };

        /// <summary>
        /// Default <see cref="NTR"/> based <see cref="Bot"/>.
        /// </summary>
        public static BotConfig NTR = new BotConfig
        {
            _name = "My 3DS",
            Default = true,
            Protocol = Protocol.NTR,
            DeviceType = DeviceType.Nintendo3DS,
            ConnectionType = ConnectionType.Tcp,
            Arguments = "192.168.0.1,8000",
            IsFunctional = false,
        };

        private const int CITRA_PORT = 45987;

        /// <summary>
        /// Default <see cref="Citra"/> based <see cref="Bot"/>.
        /// </summary>
        public static BotConfig Citra = new BotConfig
        {
            _name = "Citra Emulator",
            Default = true,
            Protocol = Protocol.Citra,
            DeviceType = DeviceType.Nintendo3DS,
            ConnectionType = ConnectionType.Udp,
            Arguments = $"127.0.0.1,{CITRA_PORT}",
        };
    }
}
