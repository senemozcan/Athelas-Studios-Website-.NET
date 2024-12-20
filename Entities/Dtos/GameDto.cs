using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record GameDto
    {
        public int GameId { get; init; }
        [Required(ErrorMessage = "Game name is required")]
        public String? GameName { get; init; } = String.Empty;

        [Required(ErrorMessage = "Game price is required")]
        public decimal GamePrice { get; init; }
        public String? Summary { get; init; } = String.Empty;
        public String? ImageUrl { get; set; }
        public int? CategoryId { get; init; } //foreign key
    }
}