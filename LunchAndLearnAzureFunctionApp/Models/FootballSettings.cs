using System.Collections.Generic;

namespace LunchAndLearnAzureFunctionApp.Models
{
    public class FootballSettings
    {
        public string LeagueName { get; set; }
        public List<FootballDivision> Divisions { get; set; }
        public string RepoConnectionString { get; set; }
    }
}
