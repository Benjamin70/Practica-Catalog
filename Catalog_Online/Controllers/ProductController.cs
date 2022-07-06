using System;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capa_Entidad;
using Capa_Negocio;

namespace Catalog_Online.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var productList = Product_Negocio.GetProduct();
            return View(productList);
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            var proc = Product_Negocio.GetProductsByID(id).FirstOrDefault();
            return View(proc);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            bool IsInserted = false;
            if (ModelState.IsValid)
            {
                IsInserted =Product_Negocio.InsertProduct(product);
                if (IsInserted)
                {
                    TempData["SuccessMessage"] = "Product details saved successfully";
                }
                else
                {
                    TempData["ErroMessage"] = "Unable to save the product details";
                }
                
            }
            return RedirectToAction("Index");
        }
        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            var proc = Product_Negocio.GetProductsByID(id).FirstOrDefault();
            return View(proc);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                bool IsUpadate = Product_Negocio.UpdateProduct(product);

                if (IsUpadate)
                {
                    TempData["SuccessMessage"] = "Products details Update successfully.. !!";
                }
                else
                {
                    TempData["ErroMessage"] = "Unable to save the product details";
                }
            }

            return RedirectToAction("Index");
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            var proc = Product_Negocio.GetProductsByID(id).FirstOrDefault();
            return View(proc);
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id_Product)
        {
            if (ModelState.IsValid)
            {
                bool IsDelete = Product_Negocio.DeleteProduct(id_Product);
                if (IsDelete)
                {
                    TempData["SuccessMessage"] = "Product delete successfully.. !!";
                }
                else
                {
                    TempData["ErroMessage"] = "Unable to save the Delete details";
                }
            }
            return RedirectToAction("Index");
        }
    }
}
