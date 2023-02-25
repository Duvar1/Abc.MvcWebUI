﻿using Abc.MvcWebUI.Entity;
using Abc.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Abc.MvcWebUI.Controllers
{
    [Authorize(Roles = "admin")]
    public class OrderController : Controller
    {
        DataContext db = new DataContext();

        public ActionResult Index()
        {
            var orders = db.Orders.Select(i => new AdminOrderModel()
            {
                Id = i.Id,
                OrderNumber = i.OrderNumber,
                OrderDate = i.OrderDate,
                OrderState = i.OrderState,
                Total = i.Total,
                Count = i.OrderLines.Count
            }).OrderByDescending(i=>i.OrderDate).ToList();
            
            
            return View(orders);
        }
    
        public ActionResult Details(int id)
        {
            var entity = db.Orders.Where(i => i.Id == id)
              .Select(i => new OrderDetailsModel()
              {
                  OrderId = i.Id,
                  OrderNumber = i.OrderNumber,
                  Total = i.Total,
                  OrderDate = i.OrderDate,
                  OrderState = i.OrderState,
                  AdresBasligi = i.AdresBasligi,
                  Adres = i.Adres,
                  Sehir = i.Sehir,
                  Semt = i.Semt,
                  Mahalle = i.Mahalle,
                  PostaKodu = i.PostaKodu,
                  OrderLines = i.OrderLines.Select(a => new OrderLineModel()
                  {
                      Price = a.Price,
                      ProductId = a.ProductId,
                      Image = a.Product.Image,
                      Quantity = a.Quantity,
                      ProductName = a.Product.Name
                  }).ToList()
              }).FirstOrDefault();
            return View(entity);
        }
        public ActionResult UpdateOrderState(int OrderId,EnumOrderState OrderState)
        {
            var order = db.Orders.FirstOrDefault(i => i.Id == OrderId);
            if (order != null)
            {
                order.OrderState = OrderState;
                db.SaveChanges();
                return RedirectToAction("Details",new {id = OrderId});

            }
            return RedirectToAction("Index");
        }
    }
}