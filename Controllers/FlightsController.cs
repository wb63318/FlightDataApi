using AutoMapper;
using FlightDataApi.Repos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlightDataApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class FlightsController : Controller
    {
        private readonly IFlightRepository flightRepository;
        private readonly IMapper mapper;

        public FlightsController(IFlightRepository flightRepository, IMapper mapper)
        {
            this.flightRepository = flightRepository;
            this.mapper = mapper;
        }
        [HttpGet("{id:int}")]
        [ActionName("GetFlightAsync")]
        public async Task<IActionResult> GetFlightAsync(int id)
        {
            var flight = await flightRepository.GetAsync(id);
            if(flight == null) { return NotFound(); }
            var flightDto = mapper.Map<Models.FlightDto>(flight);

            return Ok(flightDto);
        }
        [HttpGet]
        public async Task<IActionResult>GetFlightsAsync()
        {
            var flights = await flightRepository.GetAllAsync();
            var flightsDto = mapper.Map<List<Models.FlightDto>>(flights);
            return Ok(flightsDto);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateFlightAsync([FromRoute] int id,[FromBody] Models.UpdateFlightRequest updateFlight)
        {
            var flight = new Models.Flight()
            {
                flight_Number = updateFlight.flight_Number,
                From = updateFlight.From,
                To = updateFlight.To,
                airline = updateFlight.airline,
                departure_Date = updateFlight.departure_Date,
                arrival_Date = updateFlight.arrival_Date,
                departure_Terminal = updateFlight.departure_Terminal,
                arrival_Terminal = updateFlight.arrival_Terminal,
                seat_number = updateFlight.seat_number,
                price = updateFlight.price,
            };

            flight = await flightRepository.UpdateAsync(id, flight);
            if(flight == null) { return NotFound(); }
            var flightDto = new Models.FlightDto()
            {
                Id= flight.Id,
                flight_Number = flight.flight_Number,
                From = flight.From,
                To = flight.To,
                airline = flight.airline,
                departure_Date = flight.departure_Date,
                arrival_Date = flight.arrival_Date,
                departure_Terminal = flight.departure_Terminal,
                arrival_Terminal = flight.arrival_Terminal,
                seat_number = flight.seat_number,
                price = flight.price,
            };
            return Ok(flightDto);

        }


        [HttpDelete("{id:int}")]
        public async Task <IActionResult>DeleteFlightAsync(int id)
        {
            var flight = await flightRepository.DeleteAsync(id);
            if(flight == null) { return NotFound(); }
            var flightDto = new Models.FlightDto()
            {
                Id = flight.Id,
                flight_Number = flight.flight_Number,
                From = flight.From,
                To = flight.To,
                airline = flight.airline,
                departure_Date = flight.departure_Date,
                arrival_Date = flight.arrival_Date,
                departure_Terminal = flight.departure_Terminal,
                arrival_Terminal = flight.arrival_Terminal,
                seat_number = flight.seat_number,
                price = flight.price,
            };
            return Ok(flightDto) ;
        }
        [HttpPost]
        public async Task<IActionResult>AddFlightAsync(Models.AddFlightRequest addFlight)
        {
            var flight = new Models.Flight()
            {
                flight_Number = addFlight.flight_Number,
                From = addFlight.From,
                To = addFlight.To,
                airline =   addFlight.airline,
                departure_Date = addFlight.departure_Date,
                arrival_Date = addFlight.arrival_Date,
                departure_Terminal = addFlight.departure_Terminal,
                arrival_Terminal = addFlight.arrival_Terminal,
                seat_number = addFlight.seat_number,
                price = addFlight.price,
            };
            flight = await flightRepository.AddAsync(flight);
            var flightDto = new Models.FlightDto()
            {
                Id = flight.Id,
                flight_Number = flight.flight_Number,
                From = flight.From,
                To = flight.To,
                airline = flight.airline,
                departure_Date = flight.departure_Date,
                arrival_Date = flight.arrival_Date,
                departure_Terminal = flight.departure_Terminal,
                arrival_Terminal = flight.arrival_Terminal,
                seat_number = flight.seat_number,
                price = flight.price,
            };
            return CreatedAtAction(nameof(GetFlightAsync),new { id = flightDto.Id},flightDto);
        }

        
    }
}
