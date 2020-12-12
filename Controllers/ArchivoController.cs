using Login_MVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Login_MVC.Controllers
{
    public class ArchivoController : Controller
    {
        // GET: Archivo
        public ActionResult Index()
        {
            if (TempData["Message"] != null)
                ViewBag.Message = TempData["Message"].ToString();
            return View();
        }

        [HttpPost]
        public ActionResult Save(ArchivoViewModels model)
        {
            try
            {
                string RutaSitio = Server.MapPath("~/");
                string PathArchivo1 = Path.Combine(RutaSitio + "/Files/archivo1.jpg");
                string PathArchivo2 = Path.Combine(RutaSitio + "/Files/archivo2.jpg");

                if (!ModelState.IsValid){

                    return View("Index",model);
                }
                model.Archivo1.SaveAs(PathArchivo1);
                model.Archivo2.SaveAs(PathArchivo2);

                @TempData["Message"] = "Se cargaron los archivos";

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return Redirect(ex.Message);
            }
        }
    }
}