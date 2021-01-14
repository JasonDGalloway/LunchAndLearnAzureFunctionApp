using LunchAndLearnAzureFunctionApp.Models;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace LunchAndLearnAzureFunctionApp.Repositories
{
	public class XflFootballRepository : IFootballRepository<XflFootballSettings>
    {
        private readonly List<KeyValuePair<string, string>> _footballTeams;
        private readonly XflFootballSettings _settings;

        public XflFootballRepository(IOptions<XflFootballSettings> settings)
        {
            _footballTeams = new List<KeyValuePair<string, string>>();
            _settings = settings.Value;
        }

        public List<KeyValuePair<string, string>> GetCityTeamNames()
        {
            return _footballTeams;
        }
    }
}