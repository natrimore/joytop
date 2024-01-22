using JoyTop.Application.Abstractions;
using JoyTop.Domain.Repositories;

namespace JoyTop.Application.States
{
    public class StateManager : IStateManager
    {
        private readonly IUserRepository _userRepository;

        public StateManager(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public Task<IState> GetUserStateAsync(long userId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task SetUserStateAsync(long userId, IState state, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
