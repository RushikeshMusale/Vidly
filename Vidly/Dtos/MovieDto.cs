using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
     
        [Required]
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }
        
        [Required]
        [Range(1, 20)]
        public int NumberInStock { get; set; }
       
        [Required]
        public byte GenreId { get; set; }

        //Somehow this does not work
        //public GenreDto Genre1 { get; set; } might be a limitation of automapper

        public GenreDto Genre { get; set; }

    }
}