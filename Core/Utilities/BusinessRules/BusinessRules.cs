using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.BusinessRules
{
    public static class BusinessRules //İş kodları için oluşturulan motorumuz
    {
        public static IResult Run(params IResult[] rules)
        {
            foreach (var rule in rules)
            {
                if (!rule.Success)
                {
                    return rule;
                }
            }
            return null;
        }
    }
}
