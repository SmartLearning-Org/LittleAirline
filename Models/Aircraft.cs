
namespace LittleAirline.Models
{
    internal class Aircraft
    {
        public int AircraftId { get; set; }
        public string Type { get; set; }
        public string Registration { get; set; }
        public ICollection<Flight> Flights { get; set; }
    }
}
