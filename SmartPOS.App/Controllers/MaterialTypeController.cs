using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using SmartPOS.App.Models;
using SmartPOS.Entity.EntityModels;
using SmartPOS.Manager;

namespace SmartPOS.App.Controllers
{
    public class MaterialTypeController : Controller
    {
     MaterialTypeManager materialTypeManager=new MaterialTypeManager();   
        CommonManager commonManager= new CommonManager();
        // GET: MaterialType
        public ActionResult MaterialType()
        {
            List<Common> materialTypes = commonManager.GetAllMaterialTypes();
            ViewBag.MaterialType = materialTypes;
            return View();
        }

        [HttpPost]
        public ActionResult MaterialType(MaterailTypeVm model)
        {
            if (ModelState.IsValid)
            {
                Entity.EntityModels.MaterialType materialType = Mapper.Map<Entity.EntityModels.MaterialType>(model);
                if (materialType.Id == 0)
                {
                    ViewBag.message = materialTypeManager.Save(materialType);
                }
                else
                {
                    ViewBag.message = materialTypeManager.Update(materialType);
                }
                model = new MaterailTypeVm();
                ModelState.Clear();
            }
            List<Common> materialTypes = commonManager.GetAllMaterialTypes();
            ViewBag.MaterialType = materialTypes;
            return View(model);
        }

        public JsonResult GetMaterialTypeById(int id)
        {
            MaterialType materialType = materialTypeManager.GetMaterialTypeById(id);
            return Json(materialType, JsonRequestBehavior.AllowGet);
        }
    }
}