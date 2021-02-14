using Domain.TeamPlayers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings
{
    public class TeamPlayerMapping : IEntityTypeConfiguration<TeamPlayer>
    {
        public void Configure(EntityTypeBuilder<TeamPlayer> builder)
        {
            builder.HasKey(bc => new { bc.TeamId, bc.PlayerId });  
            
            builder
                .HasOne(bc => bc.Player)
                .WithMany(b => b.Teams)
                .HasForeignKey(bc => bc.PlayerId);

            builder
                .HasOne(bc => bc.Team)
                .WithMany(b => b.Players)
                .HasForeignKey(bc => bc.TeamId);  
        }
    }
}