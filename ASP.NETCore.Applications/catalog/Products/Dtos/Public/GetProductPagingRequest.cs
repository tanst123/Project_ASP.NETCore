using ASP.NETCore.Applications.catalog.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NETCore.Applications.catalog.Products.Dtos.Public
{
    public class GetProductPagingRequest : PagingRequestBase
    {
        public int? CategoryId { get; set; }
    }
    
}
