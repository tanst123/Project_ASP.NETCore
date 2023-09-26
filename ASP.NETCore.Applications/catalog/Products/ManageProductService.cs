using ASP.NETCore.Applications.catalog.Dtos;
using ASP.NETCore.Applications.catalog.Products.Dtos;
using ASP.NETCore.Applications.catalog.Products.Dtos.Manage;
using ASP.NETCore.Data.EF;
using ASP.NETCore.Data.Entites;
using ASP.NETCore.Utilities.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ASP.NETCore.Applications.catalog.Products
{
    public class ManageProductService : IManageProductService
    {
        private readonly EShopDBContext _context;

        public ManageProductService(EShopDBContext context)
        {
            _context = context;
        }

        public async Task AddViewCount(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if(product != null)
            {
                product.ViewCount += 1;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> Create(ProductCreateDto request)
        {
            var product = new Product()
            {
                Price = request.Price,
                OriginalPrice = request.OriginalPrice,
                Stock = request.Stock,
                ViewCount = 0,
                DateCreated = DateTime.Now,
                ProductTranslations = new List<ProductTranslation> 
                { 
                    new ProductTranslation()
                    {
                        Name = request.Name ,
                        Description = request.Description,
                        Details = request.Details ,
                        SeoDescription = request.SeoDescription ,
                        SeoTitle = request.SeoTitle ,
                        SeoAlias = request.SeoAlias ,
                        LanguageId = request.LanguageId
                    }
                }
            };

           _context.Add(product);
           return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int ProductId)
        {
            var product = await _context.Products.FindAsync(ProductId);
            if(product == null)
            {
                throw new EShopException($"cannot find a product {ProductId}");
            }
            _context.Remove(product);
            return await _context.SaveChangesAsync();
        }
        public async Task<PagedResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest request)
        {
            //1. Select join

            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.Id equals pt.ProductId
                        join pic in _context.ProductInCategories on p.Id equals pic.ProductId
                        join c in _context.Categories on pic.CategoryId equals c.Id
                        select new { p, pt, pic };
            //2.filter
            if(!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.pt.Name.Contains(request.Keyword));
            }

            if(request.CategoryIds.Count() > 0)
            {
                query = query.Where(x => request.CategoryIds.Contains(x.pic.CategoryId));
            }

            // Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.pageIndex - 1) * request.pageSize)
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
                TotalRecord = totalRow,
                Items = data
            };
            return PageResult;
        }

        public async Task<int> Update(ProductUpdateDto request)
        {
            var product = await _context.Products.FindAsync(request.Id);
            var productTranslation = await _context.ProductTranslations.FirstOrDefaultAsync(x => request.Id == x.ProductId);

            if(product == null || productTranslation == null) {
                throw new EShopException($"Can not find a product with {request.Id}");
            }
            productTranslation.Name = request.Name ;
            productTranslation.Description = request.Description ;
            productTranslation.Details = request.Details ;
            productTranslation.SeoDescription = request.SeoDescription ;
            productTranslation.SeoTitle = request.SeoTitle ;
            productTranslation.SeoAlias = request.SeoAlias;

            return await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdatePrice(int productId, decimal newPrice)
        {
            var product = await _context.Products.FindAsync(productId);
            if(product == null ) throw new EShopException($"Can not find a product with {productId}");
            product.Price = newPrice;
           return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateStock(int productId, int addedQuantity)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) throw new EShopException($"Can not find a product with {productId}");
            product.Stock += addedQuantity;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
