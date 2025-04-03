using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.Account
{
    public class AccountDto
    {
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(3)]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9-'\s]+$")]
        public string FullName { get; set; }
        
        public int RoleId { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",ErrorMessage="Invalid password")]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage ="Passwords don't match")]
        public string PasswordConfirmation { get; set; }
        public bool IsDeleted { get; set; }

    }
}
