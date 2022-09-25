using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {

        public ErrorDataResult(T data, string message) : base(data, false, message)
        {
            //Tüm değerleri gönderen ctor ifadesini yazalım

        }
        public ErrorDataResult(T data) : base(data, false)
        {
            //Sadece data döndüren değeri yazalım
        }
        public ErrorDataResult(string message) : base(default,false,message)
        {
            //Data döndürmeyen sadece,message döndüren ifadeyi yazalım.
        }
        public ErrorDataResult():base(default,false)
        {
            //Hiçbir ifade döndürmeyen ifadeyi yazdıralım

        }
    }
}
