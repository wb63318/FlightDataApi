using FlightDataApi.Models;

namespace FlightDataApi.Repos
{
    public interface IFlightRepository
    {
        public Task<IEnumerable<Flight>> GetAllAsync();
        public Task<Flight> GetAsync(int id);
        public Task<Flight> AddAsync(Flight flight);
        public Task<Flight> UpdateAsync(int id, Flight flight);
        public Task<Flight> DeleteAsync(int id);
    }
}
