namespace JoyTop.Application.Abstractions
{
    public interface IStateManager
    {
        Task SetUserStateAsync(long userId, IState state, CancellationToken cancellationToken = default);

        Task<IState> GetUserStateAsync(long userId, CancellationToken cancellationToken = default);
    }
}
