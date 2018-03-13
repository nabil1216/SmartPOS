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
        public string MaterialTypeId { get; set; }
        public string BrandId { get; set; }
        public string CategoryId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
     //   public Byte Image { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Price { get; set; }
        public byte[] Barcode { get; set; }
    }
}
