using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;

namespace Services.Contracts
{
    public interface IGameService
    { 
        IEnumerable<Game> GetAllGames(bool trackChanges);
        IEnumerable<Game> GetLastestGames( int n, bool trackChanges);
        IEnumerable<Game> GetAllGamesWithDetails(GameRequestParameters p);
        IEnumerable<Game> GetShowcaseGames(bool trackChanges);
        Game? GetOneGame(int id, bool trackChanges);
        void CreateGame(GameDtoForInsertion gameDto);
        void UpdateOneGame(GameDtoForUpdate gameDto);
        void DeleteOneProduct(int id);
        GameDtoForUpdate GetOneGameForUpdate(int id, bool trackChanges);
    }
    

}   