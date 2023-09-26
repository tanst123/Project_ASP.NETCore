using ASP.NETCore.Applications.catalog.Dtos;
using ASP.NETCore.Applications.catalog.Products.Dtos;
using ASP.NETCore.Applications.catalog.Products.Dtos.Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NETCore.Applications.catalog.Products
{
    public interface IManageProductService
    {
        Task<int> Create(ProductCreateDto request);
        Task<int> Update(ProductUpdateDto request);
        Task<int> Delete(int ProductId);
        Task<bool> UpdatePrice(int productId, decimal newPrice);
        Task<bool> UpdateStock(int productId, int addedQuantity);
        Task AddViewCount(int productId);
        Task<List<ProductViewModel>> GetAll();
        Task<PagedResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest request);
    }
}
