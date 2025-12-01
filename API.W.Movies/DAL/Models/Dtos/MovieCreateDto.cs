using System.ComponentModel.DataAnnotations;

namespace API.W.Movies.DAL.Models.Dtos
{
    public class MovieCreateDto
    {
        [Required(ErrorMessage = "El título de la película es obligatorio.")]
        [MaxLength(200, ErrorMessage = "El número máximo de caracteres es de 200.")]
        public string Title { get; set; }
        public string Description { get; set; }

    }
}
