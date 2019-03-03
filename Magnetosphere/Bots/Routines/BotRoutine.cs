namespace Magnetosphere
{
    public abstract class BotRoutine
    {
        public Bot Parent { get; private set; }

        public DeviceState State
        {
            get => Parent.State;
            set => Parent.State = value;
        }

        public virtual string Status { get; set; }

        public virtual void Initialize(Bot parent) => Parent = parent;

        public virtual void Start()
        {
            State = DeviceState.Running;
        }

        public virtual void Pause()
        {
            State = DeviceState.Paused;
        }

        public virtual void Exit()
        {
            State = DeviceState.Idle;
            if (this != None)
                Parent.Execute(None);
        }

        public void UpdateStatus(string msg)
        {
            Status = msg;
            Parent.UpdateStatus(msg);
        }

        public static readonly BotRoutine None = new NoRoutine();
    }

    public class NoRoutine : BotRoutine
    {
        public override string Status { get; set; } = "Awaiting routine.";

        public override void Initialize(Bot parent)
        {
            base.Initialize(parent);
            base.Exit();
        }
    }
}