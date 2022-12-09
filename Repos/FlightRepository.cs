using FlightDataApi.Data;
using FlightDataApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightDataApi.Repos
{
    public class FlightRepository : IFlightRepository
    {
        private readonly FlightDataDbContext flightDataDb;

        public FlightRepository(FlightDataDbContext flightDataDb)
        {
            this.flightDataDb = flightDataDb;
        }
        public async Task<Flight> AddAsync(Flight flight)
        {
            await flightDataDb.AddAsync(flight);
            await flightDataDb.SaveChangesAsync();
            return flight;
        }

        public async Task<Flight> DeleteAsync(int id)
        {
            var flight = await flightDataDb.Flights.FirstOrDefaultAsync(x =>x.Id == id);
            if(flight != null) { return null; }

            flightDataDb.Flights.Remove(flight);
            await flightDataDb.SaveChangesAsync();
            return flight;
        }

        public async Task<IEnumerable<Flight>> GetAllAsync()
        {
            return await flightDataDb.Flights.ToListAsync();
        }

        public async Task<Flight> GetAsync(int id)
        {
            return await flightDataDb.Flights.FirstOrDefaultAsync(x => x.Id == id); 
        }

        public async Task<Flight> UpdateAsync(int id, Flight flight)
        {
            var existingFlight = await flightDataDb.Flights.FirstOrDefaultAsync(x => x.Id == id);
            if(existingFlight == null) { return null; }

            existingFlight.flight_Number = flight.flight_Number;
            existingFlight.From = flight.From;
            existingFlight.To = flight.To;
            existingFlight.seat_number = flight.seat_number;
            existingFlight.price = flight.price;
            existingFlight.arrival_Date = flight.arrival_Date;
            existingFlight.airline = flight.airline;
            existingFlight.arrival_Terminal = flight.arrival_Terminal;
            existingFlight.departure_Date = flight.departure_Date;
            existingFlight.departure_Terminal = flight.departure_Terminal;
            await flightDataDb.SaveChangesAsync();
            return existingFlight;
        }
    }
}
