using System;
using System.Collections.Generic;

using MatchDataManager.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace MatchDataManager.Api.MatchData;

public class MatchDataDbContext:DbContext
{
    
    public DbSet<Location> Location { get; set; }
    public DbSet<Team> Team { get; set; }
    
    
    
    public MatchDataDbContext()
    {
        
    }
    public MatchDataDbContext(DbContextOptions options) : base(options)
    {
    }
    
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Location>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.City).HasMaxLength(255);
                entity.Property(e => e.Name).HasMaxLength(55);
            }
        );
        modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.CoachName).HasMaxLength(55);
                entity.Property(e => e.Name).HasMaxLength(255);
            }
        );
    }
    

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    //protected override void OnConfiguring(DbContextOptionsBuilder options)
    //    => options.UseSqlite($"Data Source={DbPath}");
}
