using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService 
    {
       
        IResult Add(Product product);
        IResult Delete(Product product);
        IResult Update(Product product);

        IDataResult<List<Product>> GetList();
        IDataResult<List<ProductDetailDto>> GetProductDetails(); 
    }
}
