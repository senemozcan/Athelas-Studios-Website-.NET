using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class GameManager : IGameService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public GameManager(IRepositoryManager manager , IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public void CreateGame(GameDtoForInsertion gameDto)
        {
            Game game = _mapper.Map<Game>(gameDto);
            _manager.Game.Create(game);
            _manager.Save();
        }

        public void DeleteOneProduct(int id)
        {
            Game game = GetOneGame(id, false);
            if (game is not null)
            {
                _manager.Game.DeleteOneProduct(game);
                _manager.Save();
            }
        }

        public IEnumerable<Game> GetAllGames(bool trackChanges)
        {
            return _manager.Game.GetAllGames(trackChanges);
        }

        public IEnumerable<Game> GetAllGamesWithDetails(GameRequestParameters p)
        {
            return _manager.Game.GetAllGamesWithDetails(p);
        }

        public IEnumerable<Game> GetLastestGames(int n, bool trackChanges)
        {
            return _manager
            .Game
            .FindAll(trackChanges)
            .OrderByDescending(prd => prd.GameId)
            .Take(n);
        }

        public Game? GetOneGame(int id, bool trackChanges)
        {
            var game = _manager.Game.GetOneGame(id, trackChanges);
            if (game is null)
                throw new Exception("game is not found");
            return game;
        }

        public GameDtoForUpdate GetOneGameForUpdate(int id, bool trackChanges)
        {
            var game = GetOneGame(id,trackChanges);
            var gameDto = _mapper.Map<GameDtoForUpdate>(game);
            return gameDto;
        }

        public IEnumerable<Game> GetShowcaseGames(bool trackChanges)
        {
            var games = _manager.Game.GetShowcaseGames(trackChanges);
            return games;
        }

        public void UpdateOneGame(GameDtoForUpdate gameDto)
        {
           // var entity = _manager.Game.GetOneGame(gameDto.GameId, true);
        //     entity.GameName = gameDto.GameName;
        //     entity.GamePrice = gameDto.GamePrice;
        //     entity.CategoryId = gameDto.CategoryId;
             var entity = _mapper.Map<Game>(gameDto);
            _manager.Game.UpdateOneGame(entity);
            _manager.Save();
        }
    }
}