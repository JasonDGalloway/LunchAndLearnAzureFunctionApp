using System.Collections.Generic;
using System.Linq;
using LunchAndLearnAzureFunctionApp.Repositories;

namespace LunchAndLearnAzureFunctionApp.Services
{
    public class FootballTeamsService : IFootballTeamsService
    {
        private readonly IFootballRepository _footballRepository;

        public FootballTeamsService(IFootballRepository footballRepository)
        {
            _footballRepository = footballRepository;
        }

        public List<string> GetTeamNames(string city)
        {
            var list = _footballRepository.GetCityTeamNames()
                .Where(x => x.Key.ToUpper() == city.ToUpper()).Select(x => x.Value).ToList();
            return list.Count == 0 ? new List<string> { "Sorry, no team.  Maybe your city can get the Jets cheap..." } : list;
        }

        public List<string> GetTeamNames() => _footballRepository.GetCityTeamNames().Select(x => x.Value).ToList();
    }
}
