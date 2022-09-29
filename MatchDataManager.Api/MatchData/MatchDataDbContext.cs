
using MatchDataManager.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace MatchDataManager.Api.MatchData;

public class MatchDataDbContext:DbContext
{
    
    
    
    public MatchDataDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Location> Location { get; set; }
    public DbSet<Team> Team { get; set; }

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
        
        
    }/*
    protected override void OnConfiguring(DbContextOptionsBuilder optionsbuilder)
    {
        optionsbuilder.UseSqlite(@"Data source=MatchData\\app.db");
    }
    public DbSet<Location> Location { get; set; }
    public DbSet<Team> Team { get; set; }*/
    
    /*"ConnectionStrings": {
    "DefaultConnection" : "Data source=MatchData\\app.db"
  }*/
    
}