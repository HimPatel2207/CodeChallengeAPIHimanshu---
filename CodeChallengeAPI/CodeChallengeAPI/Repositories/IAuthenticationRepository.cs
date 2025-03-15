

using CodeChallengeAPI.Models;

namespace CodeChallengeAPI.Repositories
{
    public interface IAuthenticationRepository
    {
        UserDetails AuthenticateUser(string userName, string password);
    }
}
