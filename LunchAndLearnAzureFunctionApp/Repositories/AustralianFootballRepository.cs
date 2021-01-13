using System.Collections.Generic;

namespace LunchAndLearnAzureFunctionApp.Repositories
{
	public class AustralianFootballRepository : IAustralianFootballRepository
    {
        private readonly List<KeyValuePair<string, string>> _footballTeams;

        public AustralianFootballRepository(List<KeyValuePair<string, string>> footballTeams)
        {
            _footballTeams = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("Arizona", "Cardinals"),
            };
        }

        public List<KeyValuePair<string, string>> GetCityTeamNames()
        {
            return _footballTeams;
        }
    }
}