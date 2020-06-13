
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Models
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Http;
    using Web.Data.Entities;
    public class ProductViewModel:Product
    {
        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }
    }
}
