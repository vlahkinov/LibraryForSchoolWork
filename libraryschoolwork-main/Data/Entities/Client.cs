using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Client : BaseEntity
    {
        public string BookPreferences { get; set; }
        public int Age { get; set; }
        public Cart Cart { get; set; }
        public int CardId { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}
