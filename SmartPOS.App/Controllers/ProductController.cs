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
    public class ProductController : Controller
    {
        CommonManager commonManager=new CommonManager();
        ProductManager productManager=new ProductManager();
        // GET: Product
        public ActionResult Product()
        {
            List<Product> products = productManager.GetAllProduct();
            ViewBag.Product = products;

            ViewBag.MaterialType = GetItemForMaterailTypeDropdownList();
            ViewBag.Brand = GetItemForBrandDropdownList();
            ViewBag.Category = GetItemForCategoryDropdownList();
          
            return View();
          
        }

        [HttpPost]
        public ActionResult Product(ProductVm model)
        {
            if (ModelState.IsValid)
            {
                Entity.EntityModels.Product product = Mapper.Map<Entity.EntityModels.Product>(model);
                if (product.Id == 0)
                {
                    ViewBag.message = productManager.Save(product);
                }
                else
                {
                    ViewBag.message = productManager.Update(product);
                }
                model = new ProductVm();
                ModelState.Clear();
            }
            ViewBag.MaterialType = GetItemForMaterailTypeDropdownList();
            ViewBag.Brand = GetItemForBrandDropdownList();
            ViewBag.Category = GetItemForCategoryDropdownList();

            return View(model);
        }
        private List<SelectListItem> GetItemForBrandDropdownList()
        {
            List<SelectListItem> brands = new List<SelectListItem>()
            {
                new SelectListItem() {Value = "", Text = "Select...."}
            };
            foreach (Common brand in GetAllBrand())
            {
                var item = new SelectListItem() { Value = brand.Id.ToString(), Text = brand.Name };
                brands.Add(item);
            }

            return brands;
        }
        private List<SelectListItem> GetItemForCategoryDropdownList()
        {
            List<SelectListItem> categories = new List<SelectListItem>()
            {
                new SelectListItem() {Value = "", Text = "Select...."}
            };
            foreach (Common category in GetAllCategory())
            {
                var item = new SelectListItem() { Value = category.Id.ToString(), Text = category.Name };
                categories.Add(item);
            }

            return categories;
        }
        public List<Common> GetAllBrand()
        {
            List<Common> Brands = commonManager.GetAllBrand();
            return Brands;
        }
        public List<Common> GetAllCategory()
        {
            List<Common> Brands = commonManager.GetAllCategories();
            return Brands;
        }
        private List<SelectListItem> GetItemForMaterailTypeDropdownList()
        {
            List<SelectListItem> Materials = new List<SelectListItem>()
            {
                new SelectListItem() {Value = "", Text = "Select...."}
            };
            foreach (Common material in GetAllMaterial())
            {
                var item = new SelectListItem() { Value = material.Id.ToString(), Text = material.Name };
                Materials.Add(item);
            }

            return Materials;
        }

        public List<Common> GetAllMaterial()
        {
            List<Common> materialTypes = commonManager.GetAllMaterialTypes();
            return materialTypes;
        }

        //public ActionResult FillCategory(int state)
        //{
        //    var cities = db.Cities.Where(c => c.StateId == state);
        //    return Json(cities, JsonRequestBehavior.AllowGet);
        //}

        public JsonResult FillCategory(int id)
        {
            List<Category> category = productManager.FillCategory(id).ToList();

          // Category category = productManager.FillCategory(id);
            return Json(category, JsonRequestBehavior.AllowGet);
        }
    }
}