using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ItCompany.Models
{
    public class ProductGroup
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public List<Product> Products  { get; set; }
    }
}
