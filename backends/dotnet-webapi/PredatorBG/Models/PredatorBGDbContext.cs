using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAPI.PredatorBG.Models.Enums;

namespace WebAPI.PredatorBG.Models
{
    public class PredatorBGDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Card> Cards { get; set; }

        public DbSet<Playable> Playables { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Lobby> Lobbies { get; set; }

        public DbSet<Avatar> Avatars { get; set; }

        public DbSet<Enemy> Enemies { get; set; }

        public DbSet<Damage> Damages { get; set; }

        public DbSet<DSkill> DSkill { get; set; }

        public DbSet<ESkill> ESkill { get; set; }

        public DbSet<ETeam> ETeam { get; set; }

        public DbSet<PSkill> PSkill { get; set; }

        public DbSet<PChar> PChar { get; set; }

        public DbSet<PTeam> PTeam { get; set; }

        public DbSet<PClass> PClass { get; set; }

        public PredatorBGDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
