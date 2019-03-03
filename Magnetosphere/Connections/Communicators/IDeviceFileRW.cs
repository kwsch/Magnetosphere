namespace Magnetosphere
{
    public interface IDeviceFileRW
    {
        byte[] ReadFile(string fileName);
        void WriteFile(byte[] data, string fileName);

        void Reboot();
    }
}