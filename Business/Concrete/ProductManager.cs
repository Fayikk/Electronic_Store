using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.BusinessRules;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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
         ICategoryService _categoryService;//Burada microservices değinmiş olduk.
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [ValidationAspect(typeof(ProductValidator))]//Burada AOP kullanarak gerekli ilerlemeleri sağlamaktayız.
                                                    //İnterception teknikleri kullanılacaktır.
        [SecuredOperation("product.add")]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Product product)
        {
            IResult result = BusinessRules.Run(CheckIfProductNameExists(product.Name));
            if (result != null)
            {
                return result;
            }
            //Şimdi birde gelin metodumuza iş kodlarını yazalım.
            _productDal.Add(product);
            return new Result(true,Messages.SuccessMessages);
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new Result(true,Messages.Deleted);
        }
        [CacheAspect]
        public IDataResult<List<Product>> GetList()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll().ToList(),Messages.SuccessMessages);
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {

            return new DataResult<List<ProductDetailDto>>(_productDal.GetProductDetailDtos(),true);
        }

        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new Result(true, Messages.Updated);
        }



       

        private IResult CheckIfProductNameExists(string Name)
        {
            var result = _productDal.GetAll(p => p.Name == Name).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult(Messages.SuccessMessages);
        }
    }
}
