using LunchAndLearnAzureFunctionApp.Models;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace LunchAndLearnAzureFunctionApp.Repositories
{
	public class AustralianFootballRepository : IAustralianFootballRepository
    {
        private readonly List<KeyValuePair<string, string>> _footballTeams;
        private readonly AustralianFootballSettings _settings;

        public AustralianFootballRepository(IOptions<AustralianFootballSettings> settings)
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