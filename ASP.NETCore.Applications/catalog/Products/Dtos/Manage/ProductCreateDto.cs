using ASP.NETCore.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NETCore.Applications.catalog.Products.Dtos.Manage
{
    public class ProductCreateDto
    {
        public decimal Price { get; set; }
        public decimal OriginalPrice { get; set; }
        public int Stock { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public string SeoDescription { get; set; }
        public string SeoTitle { get; set; }
        public string SeoAlias { get; set; }
        public string LanguageId { get; set; }

    }
}
