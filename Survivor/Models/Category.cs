using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survivor.Models
{
    public class Category : BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
        public ICollection<Competitors> Competitors { get; set; }
    }
}