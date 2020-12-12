using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Login_MVC.Models;  //hago referencia a mi entity Fraenword
using Login_MVC.Models.TableViewModels;
using Login_MVC.Models.ViewModels;

namespace Login_MVC.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            List<UserTableViewModel> lst = null;
            //Realiso el contexto, Muestro mi informacion realizando el contexto
            using (EmpresasPatitoEntities db =new EmpresasPatitoEntities())
            {//para llenar una lista
                lst = (
                         from d in db.Usuarios
                          where d.idState == 1
                          orderby d.email
                          select new UserTableViewModel  //Asi lleno mi objeto
                          {
                              Id = d.id,
                              Email = d.email,
                              Edad = d.Edad
                          }
                      ).ToList();//Mi objeto la convierrto en lista
            }
                return View(lst);//lo mando como lista mi view models
        }//Nota: Para mostrarlo lo mandamos a index

       [HttpGet]
        public ActionResult Add()
        {
            try
            {
                return View();
            }
            catch(Exception ex)
            {
                return Redirect(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult Add(UserViewModel model)
        {
            try
            {
                if(!ModelState.IsValid)//si no es valido regresame a la vista
                {
                    return View(model);//regresame el modelo y llenamelo con los helper en Add.cshtml
                }
                //lo pasamos al base de datos creando un contexto
                using (var db= new EmpresasPatitoEntities())
                {
                    Usuario oUser = new Usuario();
                    oUser.idState = 1;
                    oUser.email = model.Email;
                    oUser.Edad = model.Edad;
                    oUser.password = model.Password;

                    //despues lo agregamos en la base de datos y lo guardamos
                    db.Usuarios.Add(oUser);
                    db.SaveChanges();
                }
                //Me regresa a la vista
                return Redirect(Url.Content("~/User/"));
            }
            catch (Exception ex)
            {
                return Redirect(ex.Message);
            }
        }
        public ActionResult Edit(int Id)
        {
            try
            {
                EditUserViewModel model = new EditUserViewModel();

                using (var db = new EmpresasPatitoEntities())
                {
                    var oUser = db.Usuarios.Find(Id);
                    model.Edad = (int)oUser.Edad;//es porque los tengo checados en mi tabla que no permite null por eso tuve que antepóner el int
                    model.Email = oUser.email;
                    model.Id = oUser.id;
                }
                    return View(model);
            }
            catch (Exception ex)
            {
                return Redirect(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult Edit(EditUserViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)//si no es valido regresame a la vista
                {
                    return View(model);//regresame el modelo y llenamelo con los helper en Add.cshtml
                }
                using (var db = new EmpresasPatitoEntities())
                {

                    var oUser = db.Usuarios.Find(model.Id);
                    oUser.email = model.Email;  //aqui ya voy por los datos para poder editarlos
                    oUser.Edad = model.Edad;

                    if(model.Password!=null && model.Password.Trim() != "")
                    {
                        oUser.password = model.Password;
                    }
                    //Con esta linia se edita mi objeto
                    db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }

                //Me regresa a la vista
                return Redirect(Url.Content("~/User/"));
            }
            catch(Exception ex)
            {
                return Redirect(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult Delete(int Id)
        {
            try
            {

                using (var db = new EmpresasPatitoEntities())
                {

                    var oUser = db.Usuarios.Find(Id);
                    oUser.idState = 3;//3 significa eliminado, el 2 incativo, 1 activo

                    //Con esta linia se edita mi objeto
                    db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }

                //Me regresa a la vista
                return Content("1");
            }
            catch (Exception ex)
            {
                return Redirect(ex.Message);
            }
        }
    }
}