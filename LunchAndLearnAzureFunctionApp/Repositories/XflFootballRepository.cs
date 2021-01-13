using System.Collections.Generic;

namespace LunchAndLearnAzureFunctionApp.Repositories
{
	public class XflFootballRepository : IXflFootballRepository
    {
        private readonly List<KeyValuePair<string, string>> _footballTeams;

        public XflFootballRepository(List<KeyValuePair<string, string>> footballTeams)
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