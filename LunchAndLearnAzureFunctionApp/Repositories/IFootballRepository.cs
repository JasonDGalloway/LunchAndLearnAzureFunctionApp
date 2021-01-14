using System.Collections.Generic;
using LunchAndLearnAzureFunctionApp.Models;

namespace LunchAndLearnAzureFunctionApp.Repositories
{
	public interface IFootballRepository<T> where T : FootballSettings
    {
        List<KeyValuePair<string, string>> GetCityTeamNames();
    }
}
