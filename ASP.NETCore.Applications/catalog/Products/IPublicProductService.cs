using ASP.NETCore.Applications.catalog.Dtos;
using ASP.NETCore.Applications.catalog.Products.Dtos;
using ASP.NETCore.Applications.catalog.Products.Dtos.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NETCore.Applications.catalog.Products
{
    public interface IPublicProductService
    {
        Task<PagedResult<ProductViewModel>> GetAllByCategoryId(GetProductPagingRequest request);
    }
}
