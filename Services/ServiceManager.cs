using Services.Contracts;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IGameService _gameService;
        private readonly ICategoryService _categoryService;
        private readonly IOrderService _orderService;
        private readonly IAuthService _authService;

        public ServiceManager(IGameService gameService, 
        ICategoryService categoryService, 
        IOrderService orderService, 
        IAuthService authService)
        {
            _gameService = gameService;
            _categoryService = categoryService;
            _orderService = orderService;
            _authService = authService;
        }

        public IGameService GameService => _gameService;

        public ICategoryService CategoryService => _categoryService;

        public IOrderService OrderService => _orderService;

        public IAuthService AuthService => _authService;
    }
}