using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartPOS.App.Models
{
    public class ProductVm
    {
        public int? Id { get; set; }
        [DisplayName("Items")]
        public int MaterialTypeId { get; set; }
        [DisplayName("Brand")]
        public int BrandId { get; set; }
        [DisplayName("Category")]
        public int CategoryId { get; set; }
        public string Model { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
      //  public byte[] Image { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}