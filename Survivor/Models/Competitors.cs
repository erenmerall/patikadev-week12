using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survivor.Models
{
    public class Competitors : BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}