namespace Magnetosphere
{
    public interface IBotObserver
    {
        void UpdateBotState();
        Bot AddBot(BotConfig config);
        void RemoveBot(int index);
    }
}