using Entities.Models;

namespace Repositories.Extensions
{
    public static class GameRepositoryExtension
    {
        public static IQueryable<Game> FilteredByCategoryId(this IQueryable<Game> games
        , int? categoryId)
        {
            if(categoryId is null)
                return games;
            else
                return games.Where(prd => prd.CategoryId.Equals(categoryId));
        }

        public static IQueryable<Game> FilteredBySearchTerm(this IQueryable<Game> games,
        String? searchTerm)
        {
            if(string.IsNullOrWhiteSpace(searchTerm))
                return games;
            else
                return games.Where(prd => prd.GameName.ToLower()
                    .Contains(searchTerm.ToLower()));
        }

        public static IQueryable<Game> FilteredByPrice(this IQueryable<Game> games,
             int MinPrice, int MaxPrice, bool isValidPrice)
        {
            if(isValidPrice)
                return games.Where(prd => prd.GamePrice >= MinPrice && prd.GamePrice <= MaxPrice);
            else 
                return games;
        }   
        public static IQueryable<Game> ToPaginate(this IQueryable<Game> games, int pageNumber, int pageSize)
        {
            return games
                .Skip(((pageNumber -1) * pageSize))
                .Take(pageSize);
        }
    }

}