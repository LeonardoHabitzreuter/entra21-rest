using System.Reflection;
using Domain.Players;
using Domain.TeamPlayers;
using Domain.Teams;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Infra
{
    public class BrasileiraoContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamPlayer> TeamPlayers { get; set; }

        // override, pois estamos sobrescrevando o comportamento/método padrão
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Initial Catalog = nome do banco de dados que será criado
            // PWD = password
            optionsBuilder.UseSqlServer("Data Source=localhost;User Id=sa;PWD=some(!)Password;Initial Catalog=Brasileirao");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Nesta linha estamos informando ao EF de onde ele irá ler as configurações de mapeamento das entidades
            modelBuilder.ApplyConfigurationsFromAssembly(
                Assembly.GetExecutingAssembly()
            );
        }
    }
}