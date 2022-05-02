using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ItCompany.Models
{
    public class ProductDto
    {
        public Product Product { get; set; }
        public IFormFile Image { get; set; }
    }
}
