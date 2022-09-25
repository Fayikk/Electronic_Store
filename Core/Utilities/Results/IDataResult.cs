using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public interface IDataResult<out T> : IResult//out kullanımında başlangıç değerine gerek yoktur anlamına gelmektedir.
    {
        T Data { get; }
    }
}
