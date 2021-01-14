using System.Collections.Generic;
using System.Linq;
using LunchAndLearnAzureFunctionApp.Models;
using LunchAndLearnAzureFunctionApp.Repositories;
using Microsoft.Extensions.Options;

namespace LunchAndLearnAzureFunctionApp.Services
{
    public class AustralianFootballTeamsService : IFootballTeamsService<AustralianFootballSettings>
    {
        private readonly IFootballRepository<AustralianFootballSettings> _footballRepository;
        private readonly AustralianFootballSettings _footballSettings;

        public AustralianFootballTeamsService(IFootballRepository<AustralianFootballSettings> footballRepository, IOptions<AustralianFootballSettings> footballSettings)
        {
            _footballRepository = footballRepository;
            _footballSettings = footballSettings.Value;
        }

        public List<string> GetTeamNames(string city)
        {
            var list = _footballRepository
                .GetCityTeamNames()
                .Where(x => x.Key.ToUpper() == city.ToUpper())
                .Select(x => x.Value)
                .ToList();

            return list.Count == 0 ? new List<string> { "Sorry, no team." } : list;
        }

        public List<string> GetTeamNames() => _footballRepository.GetCityTeamNames().Select(x => x.Value).ToList();
    }
}
