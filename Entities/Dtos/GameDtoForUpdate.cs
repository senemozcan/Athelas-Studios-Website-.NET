namespace Entities.Dtos
{
    public record GameDtoForUpdate : GameDto
    {
        public bool Showcase { get; set; }

    }
}