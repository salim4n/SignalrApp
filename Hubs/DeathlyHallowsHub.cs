using Microsoft.AspNetCore.SignalR;

namespace SignalrApp.Hubs
{
    public class DeathlyHallowsHub : Hub
    {
        public Dictionary<string, int> GetRaceStatus()
        {
            return SD.DealthyHallowRace;
        }
    }
}
