using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BooksApp.Models
{
    public class Books
    {
        [Key]
        public int Bookid { get; set; }

        [Required(ErrorMessage ="Enter BookName")]
        [Display(Name ="Book Name")]
        public string Bookname { get; set; }

        [Required(ErrorMessage = "Enter BookauthorName")]
        [Display(Name = "Author")]
        public string Bookauthor { get; set; }

        [Required(ErrorMessage = "Enter Book Description")]
        [Display(Name = "Description")]
        public string Bookdescription { get; set; }

        [Required(ErrorMessage = "Enter Book Price")]
        [Display(Name = "Price")]
        public int price { get; set; }

    }
}
