using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.Account
{
    public class AccountDtoWithId
    {
        public int Id { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(3)]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9-'\s]+$")]
        public string FullName { get; set; }
        
        public int RoleId { get; set; }
        [Required]
        public string Password { get; set; }
        public bool IsDeleted { get; set; }


    }
}
