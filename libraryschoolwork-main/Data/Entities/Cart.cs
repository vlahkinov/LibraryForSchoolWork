using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Cart : BaseEntity
    {
        public ICollection<Book> Books { get; set; }
        public Client Client   { get; set; }
        public int ClientId { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        
    }
}
