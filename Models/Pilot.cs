
namespace LittleAirline.Models
{
    internal class Pilot
    {
        public int PilotId { get; set; }
        public string Name { get; set; }
        public ICollection<FlightPilot> FlightPilots { get; set; }
    }
}
