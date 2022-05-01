using System;
using System.ComponentModel.DataAnnotations;

namespace ItCompany.Models
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string JobTitle { get; set; }

        public string Image { get; set; }
    }
}
