using System.Collections.Generic;

namespace LunchAndLearnAzureFunctionApp.Models
{
    public class FootballSettings
    {
        public string SelectedLeague { get; set; }
        public List<FootballLeagues> Leagues { get; set; }
    }
}
