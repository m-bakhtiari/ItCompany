using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ItCompany.Models.Dto
{
    public class CustomerDto
    {
        public Customer Customer { get; set; }
        public IFormFile Image { get; set; }
    }
}
