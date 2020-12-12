using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Login_MVC.Models;

namespace Login_MVC.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Enter(string user, string password)
        {
            try
            {
                using (EmpresasPatitoEntities db = new EmpresasPatitoEntities()) {
                    //realizar una consulta con linq que simula las consultas de sql
                    var lst = from d in db.Usuarios
                              where d.email == user && d.password == password && d.idState == 1  //valida que se encuentre el dato en sql
                              select d;

                    if (lst.Count() > 0)
                    {
                        Session["User"] = lst.First();//me devuelve el primer elementop de una secuencia
                    }
                    else
                    {
                        return Content("Usuario invalido :(");
                    }

                  }
                 
                return Content("1");
            }
            catch(Exception ex)
            {
                return Redirect("Ocurrio un Error :("+ex.Message);
            }
        } 

    }
}