namespace Magnetosphere
{
    public interface IDeviceInfoFetch
    {
        void ListProcess();
        void ListThread();
        void AttachProcess(long pid, ulong offset);
        void MemLayout();
    }
}