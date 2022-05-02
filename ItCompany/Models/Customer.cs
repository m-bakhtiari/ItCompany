using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ItCompany.Models
{
    public class Customer
    {
        [Key]
        public Guid Id { get; set; }
        public string ImageName { get; set; }

    }
}
