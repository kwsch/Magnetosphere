using System;
using NLog;

namespace Magnetosphere
{
    public abstract class Bot
    {
        public readonly DeviceMessenger Messenger;

        public abstract IGameInfo CurrentGame { get; }

        public void Log(string message, LogLevel level) => Messenger.Logger.Log(level, message);
        public void Log(string message) => Log(message, LogLevel.Info);
        public void LogError(string message) => Log(message, LogLevel.Error);

        public BotRoutine Routine { get; private set; } = new NoRoutine();

        public DeviceState State { get; internal set; }
        public BotConfig Config { get; internal set; }
        public string Name => Config.Name;

        public event EventHandler<string> Updated;
        internal void UpdateStatus(string msg) => Updated?.Invoke(Routine, msg);
        public delegate void StatusUpdated(object sender, string msg);

        public void Execute(BotRoutine routine)
        {
            routine.Initialize(this);
            Routine = routine;
            routine.Start();
        }

        protected Bot(DeviceMessenger msg)
        {
            Messenger = msg;
            Translator = MessengerUtil.GetTranslator(msg);
        }

        public readonly object Translator;

        public bool Connect()
        {
            var result = Messenger.Connect();
            if (!result)
                return false;
            UpdateStatus("Connected.");
            Routine = BotRoutine.None;
            Execute(Routine);
            return true;
        }

        public bool Disconnect(bool joinThread = true)
        {
            Routine.Exit();
            var result = Messenger.Disconnect(joinThread);
            if (!result)
                return false;
            State = DeviceState.Disconnected;
            UpdateStatus(string.Empty);
            return true;
        }
    }

    public sealed class BotSwitch : Bot
    {
        public BotSwitch(DeviceMessenger msg) : base(msg)
        {
            Log($"Created new {nameof(BotSwitch)} from {msg.Summary}");
        }

        public override IGameInfo CurrentGame => null;
    }

    public sealed class Bot3DS: Bot
    {
        public Bot3DS(DeviceMessenger msg) : base(msg)
        {
            Log($"Created new {nameof(Bot3DS)} from {msg.Summary}");
        }

        public override IGameInfo CurrentGame => null;
    }
}