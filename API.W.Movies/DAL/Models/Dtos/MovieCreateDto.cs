using System.ComponentModel.DataAnnotations;

namespace API.W.Movies.DAL.Models.Dtos
{
    public class MovieCreateDto
    {
        internal int ReleaseYear;

        [Required(ErrorMessage = "El título de la película es obligatorio.")]
        [MaxLength(200, ErrorMessage = "El número máximo de caracteres es de 200.")]
        public string Title { get; set; }
        public string Description { get; set; }
        public int Duration { get; internal set; }
        public string Clasification { get; internal set; }
        public int CategoryId { get; internal set; }
    }
}
