using JoyTop.Application.Abstractions;
using Telegram.Bot.Types;

namespace JoyTop.Application.Models
{
    public class UserContext
    {
        public Domain.User User { get; set; }

        public IState CurrentState { get; set; }
    }
}
