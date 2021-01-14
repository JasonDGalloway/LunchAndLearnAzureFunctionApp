using LunchAndLearnAzureFunctionApp.Models;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace LunchAndLearnAzureFunctionApp.Repositories
{
	public class CanadianFootballRepository : ICanadianFootballRepository
    {
        private readonly List<KeyValuePair<string, string>> _footballTeams;
        private readonly CanadianFootballSettings _settings;

        public CanadianFootballRepository(IOptions<CanadianFootballSettings> settings)
        {
            _footballTeams = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("Hamilton", "Tiger-Cats"),
                new KeyValuePair<string, string>("Montreal", "Alouettes"),
                new KeyValuePair<string, string>("Toronto", "Argonauts"),
                new KeyValuePair<string, string>("Ottawa", "RedBlacks"),
                new KeyValuePair<string, string>("Saskatchewan", "Roughriders"),
                new KeyValuePair<string, string>("Calgary", "Stampeders"),
                new KeyValuePair<string, string>("Winnipeg", "Blue Bombers"),
                new KeyValuePair<string, string>("Edmonton", "Eskimos"),
                new KeyValuePair<string, string>("BC", "Lions")
            };

            _settings = settings.Value;
        }

        public List<KeyValuePair<string, string>> GetCityTeamNames()
        {
            return _footballTeams;
        }
    }
}