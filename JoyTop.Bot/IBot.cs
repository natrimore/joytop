namespace JoyTop.Bot
{
    public interface IBot
    {
        Task Execute(CancellationToken cancellationToken = default);
    }
}
