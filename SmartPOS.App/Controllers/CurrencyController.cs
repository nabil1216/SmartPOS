﻿using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using SmartPOS.App.Models;
using SmartPOS.Entity.EntityModels;
using SmartPOS.Manager;
namespace SmartPOS.App.Controllers
{
    public class CurrencyController : Controller
    {
        CurrencyManager currencyManager=new CurrencyManager();
        //GET: Currency
        //public ActionResult Index()
        //{
        //    return View();
        //}
        //DataTable
        public ActionResult Currency()
        {
            List<Currency> currencies = currencyManager.GetAllCurrencies();
            ViewBag.Currency = currencies;
            return View();
        }
        //save
        [HttpPost]
        public ActionResult Currency(CurrencyVm model)
        {
            if (ModelState.IsValid)
            {
                Entity.EntityModels.Currency currency = Mapper.Map<Entity.EntityModels.Currency>(model);
                if (currency.Id == 0)
                {
                    ViewBag.message = currencyManager.Save(currency);
                }
                else
                {
                    ViewBag.message = currencyManager.Update(currency);
                }
                model = new CurrencyVm();
                ModelState.Clear();
            }
            List<Currency> currencies = currencyManager.GetAllCurrencies();
            ViewBag.Currency = currencies;
            return View(model);
        }
        //Edit
         public JsonResult GetCurrencyById(int id)
        {
            Currency currency = currencyManager.GetById(id);
            return Json(currency, JsonRequestBehavior.AllowGet);
        }
    }
}