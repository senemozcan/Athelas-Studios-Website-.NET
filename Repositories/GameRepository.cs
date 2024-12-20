using Entities.Models;
using Entities.RequestParameters;
using Repositories.Contracts;
using Repositories.Extensions;

namespace Repositories
{
    public sealed class GameRepository : RepositoryBase<Game>, IGameRepository
    //sealed bu classin bir daha inherit edilemeyecegini ifade eder.
    {
        public GameRepository(RepositoryContext context) : base(context)
        {

        }

        public void CreateOneGame(Game game) => Create(game);

        public void DeleteOneProduct(Game game) => Remove(game);

        public IQueryable<Game> GetAllGames(bool trackChanges) => FindAll(trackChanges);

        public IQueryable<Game> GetAllGamesWithDetails(GameRequestParameters p)
        {
            return _context
                .Games
                .FilteredByCategoryId(p.CategoryId)
                .FilteredBySearchTerm(p.SearchTerm)
                .FilteredByPrice(p.MinPrice, p.MaxPrice, p.IsValidPrice)
                .ToPaginate(p.PageNumber , p.PageSize);
        }

        //interface
        public Game? GetOneGame(int id, bool trackChanges)
        {
            return FindByCondition(g => g.GameId.Equals(id), trackChanges);

        }

        public IQueryable<Game> GetShowcaseGames(bool trackChanges)
        {
            return FindAll(trackChanges)
                    .Where(g => g.ShowCase.Equals(true));
        }

        public void UpdateOneGame(Game entity) => Update(entity);


    }

}