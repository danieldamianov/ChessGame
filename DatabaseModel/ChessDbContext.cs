using DatabaseModel.Modles;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel
{
    public class ChessDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UsersGame> UsersGames { get; set; }
        public DbSet<Game> Games { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-B3I8JPR\\SQLEXPRESS;Database=ChessDb;Integrated Security = true");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Castling>()
                .HasOne(c => c.Game)
                .WithMany(g => g.Castlings)
                .HasForeignKey(c => c.GameId);

            modelBuilder.Entity<NormalMoveDabModel>()
                .HasOne(c => c.Game)
                .WithMany(g => g.NormalMoves)
                .HasForeignKey(c => c.GameId);

            modelBuilder.Entity<ProducingPawn>()
                .HasOne(c => c.Game)
                .WithMany(g => g.ProducingPawns)
                .HasForeignKey(c => c.GameId);

            modelBuilder.Entity<UsersGame>()
                .HasOne(us => us.FirstUser)
                .WithMany(u => u.UsersGamesLikeWhite)
                .HasForeignKey(us => us.FirstUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UsersGame>()
                .HasOne(us => us.SecondUser)
                .WithMany(u => u.UsersGamesLikeBlack)
                .HasForeignKey(us => us.SecondUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UsersGame>()
                .HasOne(us => us.Game)
                .WithMany(g => g.UsersGames)
                .HasForeignKey(us => us.GameId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UsersGame>()
                .HasKey(us => new { us.FirstUserId, us.SecondUserId, us.GameId });
        }
    }
}
