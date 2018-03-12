using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartPOS.Entity.EntityModels;
using SmartPOS.Manager;

namespace SmartPOS.App.Controllers
{
    public class PurchaseOrderController : Controller
    {
        ProductManager productManager=new ProductManager();
        CommonManager commonManager=new CommonManager();
        // GET: PurchaseOrder
        public ActionResult PurchaseOrder()
        {
            return View();
        }

        public JsonResult FillCategory(string prefix)
        {
            List<Common> common = commonManager.GetAllProduct(prefix).ToList();

            // Category category = productManager.FillCategory(id);
            return Json(common, JsonRequestBehavior.AllowGet);
        }
    }
}