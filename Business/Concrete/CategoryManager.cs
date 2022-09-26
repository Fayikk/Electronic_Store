using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _ıcategoryDal;
        public CategoryManager(ICategoryDal ıcategoryDal)
        {
            _ıcategoryDal = ıcategoryDal;
        }


        public IResult Add(Category category)
        {
            _ıcategoryDal.Add(category);
            return new Result(true, Messages.SuccessMessages);
        }

        public IResult Delete(Category category)
        {
            _ıcategoryDal.Delete(category);
            return new Result(true, Messages.Deleted);
        }

        public IDataResult<List<Category>> GetList()
        {
            return new SuccessDataResult<List<Category>>(_ıcategoryDal.GetAll().ToList(), Messages.SuccessMessages);

        }

        public IResult Update(Category category)
        {
            _ıcategoryDal.Update(category);
            return new Result(true, Messages.Updated);
        }
    }
}
