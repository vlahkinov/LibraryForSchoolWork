using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        [MinLength(3)]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9-'\s]+$")]
        public string Title { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        public int AccountId { get; set; }
        public virtual ICollection<CartDto>? Carts { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
