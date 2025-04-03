using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.Book
{
    public class BookDto
    {
        public int Id  { get; set; }
        [Required]
        [MinLength(3)]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9-'\s]+$")]
        public string Title { get; set; }
        [Range(0,2040)]
        public int Year { get; set; }
        public string Author { get; set; }
    }
}
