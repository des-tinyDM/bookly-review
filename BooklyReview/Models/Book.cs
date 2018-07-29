using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using BooklyReview.Models;

namespace BooklyReview.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public Genre Genre { get; set; }

        [Required]
        [Display(Name="Genre")]
        public byte GenreId { get; set; }
        [Required]
        public string Author { get; set; }
        
        [Required]
        [Display(Name="Release Date")]
        public DateTime ReleaseDate { get; set; }
        [Display(Name="Number in Stock")]
        public byte NumberInStock { get; set; }
    }
}