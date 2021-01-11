using Microsoft.EntityFrameworkCore;
using MyGames.Models;

namespace MyGames.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {   
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            modelBuilder.Entity<FriendGame>()
                .Property(fg => fg.Id)
                .ValueGeneratedOnAdd();

            // modelBuilder.Entity<FriendGame>()
            //     .HasKey(fg => new {fg.FriendId, fg.GameId});
        }

        public DbSet<Friend> Friends { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<FriendGame> FriendGames { get; set; }
    }
}