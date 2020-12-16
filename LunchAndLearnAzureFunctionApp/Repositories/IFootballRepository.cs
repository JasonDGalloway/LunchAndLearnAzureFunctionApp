using System.Collections.Generic;

namespace LunchAndLearnAzureFunctionApp.Repositories
{
    public interface IFootballRepository
    {
        List<KeyValuePair<string, string>> GetCityTeamNames();
    }
}
