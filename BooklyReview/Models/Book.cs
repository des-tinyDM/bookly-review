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
        [Required]
        public Genre Genre { get; set; }
        public byte GenreId { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        public byte NumberInStock { get; set; }
    }
}