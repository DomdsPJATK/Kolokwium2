using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design.Internal;

namespace Kolokwium2.Model
{
    public class TournamentDbContext : DbContext
    {

        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<PlayerTeam> PlayerTeams { get; set; }
        public DbSet<Championship> Championships { get; set; }
        public DbSet<ChampionshipTeam> ChampionshipTeams { get; set; }
        
        protected TournamentDbContext()
        {
        }

        public TournamentDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Player>(opt =>
            {
                opt.HasKey(p => p.IdPlayer);
                opt.Property(p => p.IdPlayer).ValueGeneratedOnAdd();
                opt.Property(p => p.FirstName).HasMaxLength(30).IsRequired();
                opt.Property(p => p.LastName).HasMaxLength(50).IsRequired();
            });
            
            modelBuilder.Entity<Team>(opt =>
            {
                opt.HasKey(p => p.IdTeam);
                opt.Property(p => p.IdTeam).ValueGeneratedOnAdd();
                opt.Property(p => p.TeamName).HasMaxLength(30).IsRequired();
            });
            
            modelBuilder.Entity<Championship>(opt =>
            {
                opt.HasKey(p => p.IdChampionship);
                opt.Property(p => p.IdChampionship).ValueGeneratedOnAdd();
                opt.Property(p => p.OfficialName).HasMaxLength(100).IsRequired();
            });

            modelBuilder.Entity<PlayerTeam>(opt =>
            {
                opt.HasKey(p => p.IdPlayer);
                opt.HasKey(p => p.IdTeam);
                opt.Property(p => p.Comment).HasMaxLength(300);

                opt.HasOne(p => p.Player).WithMany(p => p.PlayerTeams).HasForeignKey(p => p.IdPlayer);
                opt.HasOne(p => p.Team).WithMany(p => p.PlayerTeams).HasForeignKey(p => p.IdTeam);
            });
            
            modelBuilder.Entity<ChampionshipTeam>(opt =>
            {
                opt.HasKey(p => p.IdTeam);
                opt.HasKey(p => p.IdChampionship);
                
                opt.HasOne(p => p.Championship).WithMany(p => p.ChampionshipTeams).HasForeignKey(p => p.IdChampionship);
                opt.HasOne(p => p.Team).WithMany(p => p.ChampionshipTeams).HasForeignKey(p => p.IdTeam);
            });

        }
        
    }
}