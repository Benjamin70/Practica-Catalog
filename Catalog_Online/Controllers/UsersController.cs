using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capa_Entidad;
using Capa_Negocio;

namespace Catalog_Online.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            var user = Users_Negocio.GetUsers();
            return View(user);
        }
    

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Users users)
        {
          
            Users_Negocio.Login_Users(users);
            if (users.Comprobation == true)
            {

                ViewBag.Registrados = "Usuario Registrado Exitosamente";
            }
            else
            {
                ViewBag.NoRegistrados = users.Messages;
                

            }
            return View("Register");

        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Users users)
        {
            Users_Negocio.Check_Users(users);
            if (users.Id_User != 0)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Registradosr = users.Messages;
                return View("Login");
            }
            
        }


        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            var users = Users_Negocio.GetUser(id).FirstOrDefault();
            return View(users);
        }

        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult Edit(Users users)
        {
            bool IsUpdate = Users_Negocio.UpdUsers(users);

            if (IsUpdate)
            {
                TempData["SuccessMessage"] = "Users details Update successfully.. !!";
            }
            else
            {
                TempData["ErroMessage"] = "Unable to save the category details";
            }
            return RedirectToAction("Index");

        }

      
    }
}
