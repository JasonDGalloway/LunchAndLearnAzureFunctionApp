using System.Collections.Generic;
using System.Linq;
using LunchAndLearnAzureFunctionApp.Models;
using LunchAndLearnAzureFunctionApp.Repositories;
using Microsoft.Extensions.Options;

namespace LunchAndLearnAzureFunctionApp.Services
{
    public class NorthAmericanFootballTeamsService : IFootballTeamsService<NorthAmericanFootballSettings>
    {
        private readonly IFootballRepository<NorthAmericanFootballSettings> _footballRepository;
        private readonly NorthAmericanFootballSettings _footballSettings;
        
        public NorthAmericanFootballTeamsService(IFootballRepository<NorthAmericanFootballSettings> footballRepository, IOptions<NorthAmericanFootballSettings> footballSettings)
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

            return list.Count == 0 ? new List<string> { "Sorry, no team.  Maybe your city can get the Jets cheap..." } : list;
        }

        public List<string> GetTeamNames() => _footballRepository.GetCityTeamNames().Select(x => x.Value).ToList();
    }
}
