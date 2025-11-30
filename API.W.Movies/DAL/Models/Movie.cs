using System.ComponentModel.DataAnnotations;

namespace API.W.Movies.DAL.Models
{
    public class Movie : AuditBase
    {
        [Required]
        [Display(Name = "Título de la película")]
        public string Title { get; set; }
        [Display(Name = "Descripción de la película")]
        public string Description { get; set; }

        [Required]
        public int Duration { get; set; } //Duración en minutos 


        public required string Clasification { get; set; } //Clasificación de la película (G, PG, PG-13, R, etc.)

     
        [Display(Name = "Año de lanzamiento")]
        public int ReleaseYear { get; set; }

   
        [Display(Name = "Categoría")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
