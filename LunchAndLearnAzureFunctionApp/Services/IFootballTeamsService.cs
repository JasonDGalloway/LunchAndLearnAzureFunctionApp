using System.Collections.Generic;

namespace LunchAndLearnAzureFunctionApp.Services
{
	public interface IFootballTeamsService
    {
        List<string> GetTeamNames();
        List<string> GetTeamNames(string city);
    }
}
