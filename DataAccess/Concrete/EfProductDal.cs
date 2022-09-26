using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfProductDal : EfEntityRepositoryBase<Product, ElectronicShopContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetailDtos()
        {
            using (ElectronicShopContext context = new ElectronicShopContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId
                             select new ProductDetailDto { CategoryId = c.CategoryId, CategoryName = c.CategoryName, Id = p.Id };
                return result.ToList();
            
            }
        }
    }
}
