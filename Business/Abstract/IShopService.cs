using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract//
{
    public interface IShopService
    {
        IResult Add(Shop shop);
        IResult Delete(Shop shop);
        IResult Update(Shop shop);

        IDataResult<List<Shop>> GetList();
    }
}
