using System;
using System.Collections.Generic;
using System.Linq;
using LunchAndLearnAzureFunctionApp.Models;
using LunchAndLearnAzureFunctionApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace LunchAndLearnAzureFunctionApp.Services
{
    public class FootballTeamsService : IFootballTeamsService
    {
        private readonly IFootballRepository _footballRepository;
        private readonly FootballSettings _footballSettings;
        
        public FootballTeamsService(IFootballRepository footballRepository, IOptions<FootballSettings> footballSettings)
        {
            _footballRepository = footballRepository;
            _footballSettings = footballSettings.Value;
        }

        public List<string> GetTeamNames(string city)
        {
            if (_footballSettings.Leagues.Any(x => x.Acronym == _footballSettings.SelectedLeague) == false)
            {
                throw new ArgumentException("invalid league selected");
            }

            if (_footballSettings.SelectedLeague == "NFL")
            {
                var list = _footballRepository.GetCityTeamNames()
                    .Where(x => x.Key.ToUpper() == city.ToUpper()).Select(x => x.Value).ToList();
                return list.Count == 0 ? new List<string> { "Sorry, no team.  Maybe your city can get the Jets cheap..." } : list;
            }
            
            return new List<string> { $"Sorry your league {_footballSettings.SelectedLeague} is not available." };

        }

        public List<string> GetTeamNames() => _footballRepository.GetCityTeamNames().Select(x => x.Value).ToList();
    }
}
