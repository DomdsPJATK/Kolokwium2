using System;
using System.Collections;
using System.Collections.Generic;

namespace Kolokwium2.Model
{
    public class Player
    {
        public int IdPlayer { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public ICollection<PlayerTeam> PlayerTeams { get; set; }
    }
}