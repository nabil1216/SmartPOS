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
        public string MaterialTypeId { get; set; }
        [DisplayName("Brand")]
        public string BrandId { get; set; }
        [DisplayName("Category")]
        public string CategoryId { get; set; }
        [DisplayName("Model No")]
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
      //  public byte[] Image { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}