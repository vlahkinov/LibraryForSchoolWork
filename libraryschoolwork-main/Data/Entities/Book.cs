using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Book : BaseEntity
    {
        [Required]
        public string Title { get; set; }
        public int Year { get; set; }
        public string Author { get; set; }
        public bool IsDeleted { get; set; }
    }
}
