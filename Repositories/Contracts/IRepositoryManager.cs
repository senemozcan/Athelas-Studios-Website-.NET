namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {
        IGameRepository Game { get;}
        ICategoryRepository Category{get;}
        IOrderRepository Order {get;}
        void Save(); 
    }

}