using System.Collections;
using System.Collections.Generic;

namespace Kolokwium2.Model
{
    public class Team
    {
        public int IdTeam { get; set; }
        public string TeamName { get; set; }
        public int MaxAge { get; set; }

        public ICollection<PlayerTeam> PlayerTeams { get; set; }
        public ICollection<ChampionshipTeam> ChampionshipTeams { get; set; }
    }
}