using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data , string message) : base(data,true,message)
        {
            //Tüm değerleri döndüren ifadeyi yazalım
        }
        public SuccessDataResult() : base(default,true)
        {
            //Hiçbir değer döndürmeyen ifadeyi yazalım

        }
        public SuccessDataResult(string message) : base(default,true,message)
        {
            //Sadece mesaj döndürecek değeri yazalım
        }
        public SuccessDataResult(T data) : base(data,true)
        {
            //Sadedce data döndürsün
        }
    }
}
