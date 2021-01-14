using System.Collections.Generic;
using LunchAndLearnAzureFunctionApp.Models;

namespace LunchAndLearnAzureFunctionApp.Services
{
	public interface IFootballTeamsService<T> where T : FootballSettings
    {
        List<string> GetTeamNames();
        List<string> GetTeamNames(string city);
    }
}
