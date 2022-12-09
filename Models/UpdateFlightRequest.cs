
using System.ComponentModel.DataAnnotations;

namespace FlightDataApi.Models
{
    public class UpdateFlightRequest
    {
        public int flight_Number { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string airline { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime departure_Date { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime arrival_Date { get; set; }
        public string arrival_Terminal { get; set; }
        public string departure_Terminal { get; set; }
        public string seat_number { get; set; }
        public int price { get; set; }
    }
}
