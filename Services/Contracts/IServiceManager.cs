namespace Services.Contracts
{
    public interface IServiceManager
    {
        IGameService GameService {get;}
        ICategoryService CategoryService {get;}
        IOrderService OrderService {get;}
        IAuthService AuthService {get;}
    }
}