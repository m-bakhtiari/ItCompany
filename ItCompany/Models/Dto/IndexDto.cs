using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItCompany.Models.Dto
{
    public class IndexDto
    {
        public Message Message { get; set; }
        public List<ProductGroup> ProductGroups { get; set; }
        public List<Slide> Slides { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
