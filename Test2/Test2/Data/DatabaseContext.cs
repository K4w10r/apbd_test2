using Microsoft.EntityFrameworkCore;
using Test2.Models;

namespace Test2.Data;

public class DatabaseContext : DbContext
{
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
        
    }
    
    public DbSet<Item> Items { get; set; }
    public DbSet<Character> Characters { get; set; }
    public DbSet<Title> Titles { get; set; }
    public DbSet<Backpack> Backpacks { get; set; }
    public DbSet<CharacterTitles> CharacterTitles { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Item>().HasData(new List<Item>
            {
                new Item {
                    Id = 1,
                    Name = "Torch",
                    Weight = 7
                },
                new Item {
                    Id = 2,
                    Name = "Map",
                    Weight = 3
                }
            });

            modelBuilder.Entity<Character>().HasData(new List<Character>
            {
                new Character {
                    Id = 1,
                    FirstName = "Adam",
                    LastName = "Nowak",
                    CurrentWeight = 30,
                    MaxWeight = 50
                    
                },
                new Character {
                    Id = 2,
                    FirstName = "Misiu",
                    LastName = "Pysiu",
                    CurrentWeight = 15,
                    MaxWeight = 38
                }
            });

            modelBuilder.Entity<Title>().HasData(new List<Title>
            {
                new Title
                {
                    Id = 1,
                    Name = "Drożdzówka",
                },
                new Title
                {
                    Id = 2,
                    Name = "Darth",
                },
                new Title
                {
                    Id = 3,
                    Name = "Drift King",
                }
            });

            modelBuilder.Entity<CharacterTitles>().HasData(new List<CharacterTitles>
            {
                new CharacterTitles
                {
                    CharacterId = 1,
                    TitleId = 1,
                    AquiredAt = DateTime.Today
                },
                new CharacterTitles
                {
                    CharacterId = 2,
                    TitleId = 2,
                    AquiredAt = DateTime.Today
                },
                new CharacterTitles
                {
                    CharacterId = 2,
                    TitleId = 3,
                    AquiredAt = DateTime.Now
                }
            });

            modelBuilder.Entity<Backpack>().HasData(new List<Backpack>
            {
                new Backpack
                {
                    CharacterId = 1 ,
                    ItemId = 1,
                    Amount = 1
                },
                new Backpack
                {
                    CharacterId = 1 ,
                    ItemId = 2,
                    Amount = 1
                },
                new Backpack
                {
                    CharacterId = 2 ,
                    ItemId = 1,
                    Amount = 2
                },
                new Backpack
                {
                    CharacterId = 2 ,
                    ItemId = 2,
                    Amount = 1
                }
            });
    }
    
}