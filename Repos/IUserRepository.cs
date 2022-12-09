using FlightDataApi.Models;

namespace FlightDataApi.Repos
{
    public interface IUserRepository
    {
        Task<User> AuthenticateAsync(string username, string password);
    }
}
