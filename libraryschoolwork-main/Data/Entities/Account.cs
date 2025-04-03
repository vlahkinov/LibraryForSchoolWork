using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Account : BaseEntity
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(3)]
        [RegularExpression("[A-Za-z]")]
        public string FullName { get; set; }
        [Required]
        public string Password { get; set; }
        public virtual Role Role { get; set; }
        public int RoleId { get; set; }
        public bool IsDeleted { get; set; }

    }
}
