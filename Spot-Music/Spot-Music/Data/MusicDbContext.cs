using Microsoft.EntityFrameworkCore;
using Spot_Music.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spot_Music.Data
{
    public class MusicDbContext : DbContext
    {
        public DbSet<Song> Songs { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Songs_Artists> Songs_Artists { get; set; }
        
        public DbSet<Users_Songs> Users_Songs { get; set; }

        public MusicDbContext(DbContextOptions<MusicDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Songs_Artists>().HasKey(c=> new { c.SongId,c.ArtistId });

            modelBuilder.Entity<Users_Songs>().HasKey(d => new { d.UserId, d.SongId });
        }
    }

}

    
