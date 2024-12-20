using Entities.Models;
using Entities.RequestParameters;

namespace Repositories.Contracts
{
    public interface IGameRepository : IRepositoryBase<Game>
    {
        IQueryable<Game> GetAllGames(bool trackChanges);
        IQueryable<Game> GetAllGamesWithDetails(GameRequestParameters p);
        IQueryable<Game> GetShowcaseGames(bool trackChanges);
        Game? GetOneGame(int id, bool trackChanges);
        void CreateOneGame(Game game);
        void DeleteOneProduct(Game game);
        void UpdateOneGame(Game entity);
    }
}