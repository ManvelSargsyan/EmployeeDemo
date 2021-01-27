using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Employee.Entities
{
    public class EmployeeEntity : EntityBase
    {
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]

        public string LastName { get; set; }
        [MaxLength(50)]

        public string MiddleName { get; set; }
        public int Age { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(20)]
        public string PhoneNumber { get; set; }
    }
}
