using System;
using System.Collections.Generic;
using System.Text;

namespace LunchAndLearnAzureFunctionApp.Models
{
    public class FootballSettings
    {
        public string SelectedLeague { get; set; }
        public List<FootballLeagues> Leagues { get; set; }
    }
}
