using Business.Abstract;
using Business.Constants;
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
    public class ShopManager : IShopService
    {
        IShopDal _ıshopDal;
        public ShopManager(IShopDal ıshopDal)
        {
            _ıshopDal = ıshopDal;
        }

        public IResult Add(Shop shop)
        {
            _ıshopDal.Add(shop);
            return new SuccessResult();
        }
                                    
        public IResult Delete(Shop shop)
        {
            _ıshopDal.Delete(shop);
            return new SuccessResult();
        }

        public IDataResult<List<Shop>> GetList()
        {
            return new SuccessDataResult<List<Shop>>(_ıshopDal.GetAll(), Messages.SuccessMessages);
        }

        public IResult Update(Shop shop)
        {
            _ıshopDal.Update(shop);
            return new Result(true);
        }
    }
}
