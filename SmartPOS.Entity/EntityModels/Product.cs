using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPOS.Entity.EntityModels
{
   public class Product
    {
        public int Id { get; set; }
        public int MaterialTypeId { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public string Model { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
     //   public Byte Image { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
