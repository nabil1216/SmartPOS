using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SmartPOS.App.Models
{
    public class PurchaseOrderVm
    {
        public int Id { get; set; }
        [DisplayName("Model No")]
        public string ModelNo { get; set; }
        [DisplayName("Product Name")]
        public string ProductName { get; set; }
    }
}