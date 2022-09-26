using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [ValidationAspect(typeof(ProductValidator))]//Burada AOP kullanarak gerekli ilerlemeleri sağlamaktayız.
        //İnterception teknikleri kullanılacaktır.
        public IResult Add(Product product)
        {
            _productDal.Add(product);
            return new Result(true,Messages.SuccessMessages);
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new Result(true,Messages.Deleted);
        }

        public IDataResult<List<Product>> GetList()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll().ToList(),Messages.SuccessMessages);
        }

        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new Result(true, Messages.Updated);
        }
    }
}
