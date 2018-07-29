using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BooklyReview.Models;

namespace BooklyReview.ViewModels

{
    public class BookFormViewModel

    {

        public IEnumerable<Genre> Genres { get; set; }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public byte? GenreId { get; set; }
        [Required]
        public string Author { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }
        [Display(Name = "Number in Stock")]
        public byte? NumberInStock { get; set; }

        public string Title

        {

            get

            {
                return (Id != 0) ? "Edit Book" :  "New Book";
            }
        }

        public BookFormViewModel()
        {

        }

        public BookFormViewModel(Book book)
        {
            Id = book.Id;
            Name = book.Name;
            Author = book.Author;
            ReleaseDate = book.ReleaseDate;
            NumberInStock = book.NumberInStock;
            GenreId = book.GenreId;
        }
    }
}