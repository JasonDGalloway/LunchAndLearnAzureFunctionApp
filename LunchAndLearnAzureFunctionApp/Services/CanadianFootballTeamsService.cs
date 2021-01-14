using System.Collections.Generic;
using System.Linq;
using LunchAndLearnAzureFunctionApp.Models;
using LunchAndLearnAzureFunctionApp.Repositories;
using Microsoft.Extensions.Options;

namespace LunchAndLearnAzureFunctionApp.Services
{
    public class CanadianFootballTeamsService : IFootballTeamsService<CanadianFootballSettings>
    {
        private readonly IFootballRepository<CanadianFootballSettings> _footballRepository;
        private readonly CanadianFootballSettings _footballSettings;

        public CanadianFootballTeamsService(IFootballRepository<CanadianFootballSettings> footballRepository, IOptions<CanadianFootballSettings> footballSettings)
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

            return list.Count == 0 ? new List<string> { "Sorry, no team.  Maybe your city can get the Ottawa RedBlacks cheap..." } : list;
        }

        public List<string> GetTeamNames() => _footballRepository.GetCityTeamNames().Select(x => x.Value).ToList();
    }
}
