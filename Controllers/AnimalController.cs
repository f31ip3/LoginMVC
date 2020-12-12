using Login_MVC.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Login_MVC.Controllers
{
    public class AnimalController : Controller
    {
        // GET: Animal
        public ActionResult Index()
        {
            try
            {
                //Para llenar un combobox del padre
                List<SelectListItem> lst = new List<SelectListItem>();

                //mando llamar la coneccion de mi base de adtos con el using()
                using (Models.EmpresasPatitoEntities db = new Models.EmpresasPatitoEntities())
                {
                    //utiliso linq para llenar el elemento lst
                    lst = (from d in db.animal_clases
                           select new SelectListItem
                           {
                               Value = d.id.ToString(),
                               Text = d.name  //el elemento que se va a ver
                           }).ToList();//lo combierto a una lista
                }

                return View(lst);//regreso en la vita una lista
            }
            catch (Exception ex)
            {
                return Redirect(ex.Message);
            }
        }
        [HttpGet]
        public JsonResult Animal(int IdAnimalClass)        {

                List<ElementJsonIntKey> lst = new List<ElementJsonIntKey>();//el objheto se ha llenado
                using (Models.EmpresasPatitoEntities db = new Models.EmpresasPatitoEntities())//creamos nuestra coneccion
                {
                    //utilizamos linq para obtener los datos de la consulta
                    lst = (from d in db.animals
                           where d.idAnimal_class == IdAnimalClass
                           select new ElementJsonIntKey
                           {
                               Id_Value = d.id,
                               Id_Text = d.name
                           }
                        ).ToList();
                }
                return Json(lst, JsonRequestBehavior.AllowGet);//convierte mi lista en json
               //despues vamos a index para realizar la solicitud asincornoa con javascript
        }
    }
}