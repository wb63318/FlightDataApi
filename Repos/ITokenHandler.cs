using FlightDataApi.Models;

namespace FlightDataApi.Repos
{
    public interface ITokenHandler
    {
        Task<string>CreateTokenAsync(User user);
    }
}
