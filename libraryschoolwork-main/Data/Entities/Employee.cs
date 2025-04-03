using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Employee : BaseEntity
    {
        public string Title { get; set; }
        public string PhoneNumber { get; set; }
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public bool IsActive { get; set; }
    }
}
