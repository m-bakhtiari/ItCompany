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
        public List<Customer> Customers { get; set; }
        public Email Email { get; set; }
        public int CustomersCount { get; set; }
        public int ProductCount { get; set; }
        public int EmployeeCount { get; set; }
        public int MessageCount { get; set; }
    }
}
