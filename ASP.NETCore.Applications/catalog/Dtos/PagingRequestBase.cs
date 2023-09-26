using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NETCore.Applications.catalog.Dtos
{
    public class PagingRequestBase 
    {
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
    }
}
