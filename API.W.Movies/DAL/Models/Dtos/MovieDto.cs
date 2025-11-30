namespace API.W.Movies.DAL.Models.Dtos
{
    public class MovieDto
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public int Duration { get; set; }
        public required string Clasification { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int CategoryId { get; set; }
    }
}
