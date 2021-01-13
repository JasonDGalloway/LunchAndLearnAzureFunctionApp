using System.Collections.Generic;

namespace LunchAndLearnAzureFunctionApp.Repositories
{
	public class NorthAmericanFootballRepository : INorthAmericanFootballRepository
    {
        private readonly List<KeyValuePair<string, string>> _footballTeams;

        public NorthAmericanFootballRepository(List<KeyValuePair<string, string>> footballTeams)
        {
            _footballTeams = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("Arizona", "Cardinals"),
                new KeyValuePair<string, string>("Atlanta", "Falcons"),
                new KeyValuePair<string, string>("Baltimore", "Ravens"),
                new KeyValuePair<string, string>("Buffalo", "Bills"),
                new KeyValuePair<string, string>("Carolina", "Panthers"),
                new KeyValuePair<string, string>("Chicago", "Bears"),
                new KeyValuePair<string, string>("Cincinnati", "Bengals"),
                new KeyValuePair<string, string>("Cleveland", "Browns"),
                new KeyValuePair<string, string>("Dallas", "Cowboys"),
                new KeyValuePair<string, string>("Denver", "Broncos"),
                new KeyValuePair<string, string>("Detroit", "Lions"),
                new KeyValuePair<string, string>("Green Bay", "Packers"),
                new KeyValuePair<string, string>("Houston", "Texans"),
                new KeyValuePair<string, string>("Indianapolis", "Colts"),
                new KeyValuePair<string, string>("Jacksonville", "Jaguars"),
                new KeyValuePair<string, string>("Kansas City", "Chiefs"),
                new KeyValuePair<string, string>("Las Vegas", "Raiders"),
                new KeyValuePair<string, string>("Los Angeles", "Chargers"),
                new KeyValuePair<string, string>("Los Angeles", "Rams"),
                new KeyValuePair<string, string>("Miami", "Dolphins"),
                new KeyValuePair<string, string>("Minnesota", "Vikings"),
                new KeyValuePair<string, string>("New England", "Patriots"),
                new KeyValuePair<string, string>("New Orleans", "Saints"),
                new KeyValuePair<string, string>("New York", "Giants"),
                new KeyValuePair<string, string>("New York", "Jets (...Sorry)"),
                new KeyValuePair<string, string>("Philadelphia", "Eagles"),
                new KeyValuePair<string, string>("Pittsburgh", "Steelers"),
                new KeyValuePair<string, string>("San Francisco", "49ers"),
                new KeyValuePair<string, string>("Seattle", "Seahawks"),
                new KeyValuePair<string, string>("Tampa Bay", "Buccaneers"),
                new KeyValuePair<string, string>("Tennessee", "Titans"),
                new KeyValuePair<string, string>("Washington", "Football Team")
            };
        }

        public List<KeyValuePair<string, string>> GetCityTeamNames()
        {
            return _footballTeams;
        }
    }
}