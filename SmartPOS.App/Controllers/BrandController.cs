﻿using System;
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
    public class BrandController : Controller
    {
        CommonManager commonManager=new CommonManager();
        BrandManager brandManager=new BrandManager();
        // GET: Brand
        public ActionResult Brand()
        {
            List<Common> brands = commonManager.GetAllBrand();
            ViewBag.Brand = brands;
            return View();

        }

        [HttpPost]
        public ActionResult Brand(BrandVm model)
        {
            if (ModelState.IsValid)
            {
                Entity.EntityModels.Brand brand = Mapper.Map<Entity.EntityModels.Brand>(model);
                if (brand.Id == 0)
                {
                    ViewBag.message = brandManager.Save(brand);
                }
                else
                {
                    ViewBag.message = brandManager.Update(brand);
                }
                model = new BrandVm();
                ModelState.Clear();
            }
            List<Common> brands = commonManager.GetAllBrand();
            ViewBag.Brand = brands;
            return View(model);
        }

        public JsonResult GetBrandById(int id)
        {
            Brand brand = brandManager.GetById(id);
            return Json(brand, JsonRequestBehavior.AllowGet);
        }
    }
}