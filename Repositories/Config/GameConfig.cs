using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class GameConfig : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasKey(g => g.GameId);
            builder.Property(g => g.GameName).IsRequired();
            builder.Property(g => g.GamePrice).IsRequired();
            
            builder.HasData(
                new Game() { GameId = 1, CategoryId=2,ImageUrl = "/images/1.jpg",  GameName = "Varyete", GamePrice = 150 , ShowCase = true},
                new Game() { GameId = 2, CategoryId=1,ImageUrl = "/images/2.jpg",  GameName = "Dead Colors", GamePrice = 250 , ShowCase = false},
                new Game() { GameId = 3, CategoryId=2,ImageUrl = "/images/3.jpg",  GameName = "Serenity", GamePrice = 1_000 , ShowCase = false},
                new Game() { GameId = 4, CategoryId=2,ImageUrl = "/images/4.jpg",  GameName = "The Chandrians", GamePrice = 1_500 , ShowCase = true},
                new Game() { GameId = 5, CategoryId=2,ImageUrl = "/images/5.jpg",  GameName = "Dune: The Buthlerian Jihad", GamePrice = 1_150 , ShowCase = false},
                new Game() { GameId = 6, CategoryId=2,ImageUrl = "/images/6.jpg",  GameName = "Dune: 1", GamePrice = 1_150 , ShowCase = false},
                new Game() { GameId = 7, CategoryId=1,ImageUrl = "/images/7.jpg",  GameName = "Dune: 2", GamePrice = 1_150 , ShowCase = true},
                new Game() { GameId = 8, CategoryId=1,ImageUrl = "/images/8.jpg",  GameName = "Dune: 3", GamePrice = 1_150 , ShowCase = true},
                new Game() { GameId = 9, CategoryId=2,ImageUrl = "/images/9.jpg",  GameName = "Dune: 4", GamePrice = 1_150 , ShowCase = false}
            );
        }
    }
}