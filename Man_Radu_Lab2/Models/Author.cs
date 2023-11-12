using System;
using System.ComponentModel.DataAnnotations;

namespace Man_Radu_Lab2.Models
{
	public class Author
    {
        public int ID { get; set; }

        [Display(Name = "FirstName")]
        public string? FirstName { get; set; }

        [Display(Name = "LastName")]
        public string? LastName { get; set; }

        public ICollection<Book>? Books { get; set; }
    }
}

