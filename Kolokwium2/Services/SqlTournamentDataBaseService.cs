using System;
using System.Collections.Generic;
using System.Linq;
using Kolokwium2.DTOs.Request;
using Kolokwium2.Exceptions;
using Kolokwium2.Model;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2.Services
{
    public class SqlTournamentDataBaseService : ITournamentDataBaseService
    {
        private readonly TournamentDbContext _context;

        public SqlTournamentDataBaseService(TournamentDbContext context)
        {
            _context = context;
        }

        public List<Team> getTeams(int id)
        {
            // var teams = _context.ChampionshipTeams.Include(p => p.ChampionshipTeams);
            return new List<Team>();
        }

        public void AddPlayerToTeam(int id, PlayerRequest request)
        {
            var team = _context.Teams.SingleOrDefault(m => m.IdTeam == id);
            var player =
                _context.Players.SingleOrDefault(
                    m => m.FirstName == request.firstName && m.LastName == request.lastName);

            if (player == null)
            {
                throw new PlayerNotExistsException($"Gracz o imieniu: {request.firstName} i nazwisku: {request.lastName} nie istnieje!");
            }
        
            DateTime now = DateTime.Today;
            int age = now.Year - player.DateOfBirth.Year;
            if (now < player.DateOfBirth.AddYears(age)) age--;
            
            if (age > team.MaxAge)
            {
                throw new WrongAgeException("Zawodnik jest za stary na tę druzynę!");
            }

            if (_context.PlayerTeams.Any(m => m.IdPlayer == player.IdPlayer && m.IdTeam == team.IdTeam))
            {
                throw new PlayerAlreadyExistException("Taki zawodnik juz istneije!");
            }

            _context.PlayerTeams.Add(new PlayerTeam()
            {
                IdPlayer = player.IdPlayer,
                Comment = request.comment,
                IdTeam = team.IdTeam,
                NumOnShirt = request.numOnShirt,
            });
            _context.SaveChanges();
        }
    }
}