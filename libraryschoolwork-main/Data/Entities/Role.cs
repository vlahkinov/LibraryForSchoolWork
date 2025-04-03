using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Role : BaseEntity
    {
        [Required]
        [MinLength(3)]
        [RegularExpression(@"^[a-zA-Z0-9_]*$")]
        public string Name { get; set; }

        public virtual ICollection<Account> Account { get; set; }
    }

}
