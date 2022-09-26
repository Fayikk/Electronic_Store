using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class ProductDetailDto : IDto
    {
        public int CategoryId { get; set; }
        public int ShopId { get; set; }
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string ShopName { get; set; }

    }
}
