namespace Entities.Models
{
    public class Category
    {
        public int CategoryId {get;set;}
        public String? CategoryName{get;set;} = String.Empty;
        public ICollection<Game> Games {get;set;} //collection navigation property
        
    }
}