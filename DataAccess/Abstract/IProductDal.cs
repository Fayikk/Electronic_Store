using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
        //Burada bize sağlanan avantaj şudur.
        //Crud operasyonları için her interface doldurulmayacaktır.
        //Class kendine özgü özellik ve metodlara yer verecektir.
    }
}
