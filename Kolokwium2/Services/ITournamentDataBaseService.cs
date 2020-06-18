using System.Collections.Generic;
using Kolokwium2.DTOs.Request;
using Kolokwium2.Model;

namespace Kolokwium2.Services
{
    public interface ITournamentDataBaseService
    {
        List<Team> getTeams(int id);
        void AddPlayerToTeam(int id, PlayerRequest request);
    }
}