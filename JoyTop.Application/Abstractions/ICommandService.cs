namespace JoyTop.Application.Abstractions
{
    public interface ICommandService
    {
        IReadOnlyCollection<BaseCommand> Get();
    }
}
