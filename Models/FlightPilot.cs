
namespace LittleAirline.Models
{
    internal class FlightPilot
    {
        public int FlightId { get; set; }
        public Flight Flight { get; set; }

        public int PilotId { get; set; }
        public Pilot Pilot { get; set; }

    }
}
