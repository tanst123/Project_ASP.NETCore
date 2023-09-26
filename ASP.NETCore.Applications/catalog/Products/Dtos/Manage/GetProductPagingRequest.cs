using ASP.NETCore.Applications.catalog.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NETCore.Applications.catalog.Products.Dtos.Manage
{
    public class GetProductPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }

        public List<int> CategoryIds { get; set; }
    }
}
