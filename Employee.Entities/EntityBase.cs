using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Entities
{
    public class EntityBase
    {
        public int Id { get; set; }
        public DateTime CreateDate  { get; set; }
        public DateTime? UpdateDate  { get; set; }
        public bool Deleted { get; set; }
    }
}
