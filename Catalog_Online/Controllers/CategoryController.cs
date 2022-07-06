using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Capa_Entidad;
using Capa_Negocio;

namespace Catalog_Online.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            var Cat = Category_Negocio.GetCatgory();
            return View(Cat);
        }

       
        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(Category category)
        {
            bool IsInserted = false;
            if (ModelState.IsValid)
            {
               IsInserted =  Category_Negocio.InsertCategory(category);
                if (IsInserted)
                {
                    TempData["SuccessMessage"] = "Category details saved successfully.. !!";
                }
                else
                {
                    TempData["ErroMessage"] = "Unable to save the category details";
                }
            }
             return RedirectToAction("Index", "Category");
            
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            var Cat = Category_Negocio.GetCategorieByID(id).FirstOrDefault();
            return View(Cat);
        }


        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            var Cat = Category_Negocio.GetCategorieByID(id).FirstOrDefault();
            return View(Cat);
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                bool IsUpdate = Category_Negocio.UpdCategory(category);

                if (IsUpdate)
                {
                    TempData["SuccessMessage"] = "Category details Update successfully.. !!";
                }
                else
                {
                    TempData["ErroMessage"] = "Unable to save the category details";
                }

            }
            return RedirectToAction("Index");
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int? id)
        {
            var Cat = Category_Negocio.GetCategorieByID(id).FirstOrDefault();
            return View(Cat);
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int Id_Category)
        {
            if (ModelState.IsValid)
            {
                bool IsDelete = Category_Negocio.DeleCategory(Id_Category);

                if (IsDelete)
                {
                    TempData["SuccessMessage"] = "Category delete successfully.. !!";
                }
                else
                {
                    TempData["ErroMessage"] = "Unable to save the category details";
                }
            }
            return RedirectToAction("Index");
        }
    }
}
