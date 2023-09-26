using ASP.NETCore.Applications.catalog.Dtos;
using ASP.NETCore.Applications.catalog.Products.Dtos;
using ASP.NETCore.Applications.catalog.Products.Dtos.Public;
using ASP.NETCore.Data.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NETCore.Applications.catalog.Products
{
    public class PublicProductService : IPublicProductService
    {
        private readonly EShopDBContext _context;

        public PublicProductService(EShopDBContext context) {
            _context = context;
        }
        public async Task<PagedResult<ProductViewModel>> GetAllByCategoryId(GetProductPagingRequest request)
        {
            // 1. Select join
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.Id equals pt.ProductId
                        join pic in _context.ProductInCategories on p.Id equals pic.ProductId
                        join c in _context.Categories on pic.CategoryId equals c.Id
                        select new { p, pt, pic };

            // 2. Filter
            if(request.CategoryId.HasValue && request.CategoryId.Value > 0)
            {
               query = query.Where(x => x.pic.CategoryId == request.CategoryId);
            }

            var totalRow = await query.CountAsync();

            var data = await query
                                 .Skip((request.pageIndex - 1) * request.pageSize)
                                 .Take(request.pageSize)
                                 .Select(x => new ProductViewModel()
                                 {
                                     Id = x.p.Id,
                                     Name = x.pt.Name,
                                     DateCreated = x.p.DateCreated,
                                     Description = x.pt.Description,
                                     Details = x.pt.Details,
                                     LanguageId = x.pt.LanguageId,
                                     Price = x.p.Price,
                                     OriginalPrice = x.p.OriginalPrice,
                                     Stock = x.p.Stock,
                                     ViewCount = x.p.ViewCount,
                                     SeoDescription = x.pt.SeoDescription,
                                     SeoTitle = x.pt.SeoTitle,
                                     SeoAlias = x.pt.SeoAlias,
                                 }).ToListAsync();

            var PageResult = new PagedResult<ProductViewModel>()
            {
                Items = data,
                TotalRecord = totalRow
            };

            await _context.SaveChangesAsync();
            return PageResult;

        }
    }
}
