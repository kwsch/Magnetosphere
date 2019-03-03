namespace Magnetosphere
{
    public interface IDebuggable
    {
        void BreakpointAdd(uint type, ulong addr);
        void BreakpointDel(uint index);
        void BreakpointResume();

        void BreakpointEnable(uint index);
        void BreakpointDisable(uint index);
    }
}