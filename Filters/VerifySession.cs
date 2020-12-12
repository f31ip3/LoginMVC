using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Login_MVC.Controllers;
using Login_MVC.Models;

namespace Login_MVC.Filters
{
    public class VerifySession: ActionFilterAttribute
    {
        //Primero hay que sobrecargar un metodo Nota: Primero haces lo mio y despues haces lo tuyo eso es sobrecargar
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //verifico si mi usuario exsiste
            var oUser = (Usuario)HttpContext.Current.Session["User"];//de mi tabla Usuarios voy por el usuario

            if (oUser == null)
            {
                if (filterContext.Controller is AccessController == false)//si  no eres de mi accesController te regreso a HomeController
                {
                    filterContext.HttpContext.Response.Redirect("~/Access/Index");//lo regreso a mi access index
                }
            } //Nota una vez creado el filtro lo agregamos en la carpeta de App_Start en la clase FilterConfig
            else
            {
                if (filterContext.Controller is AccessController == true)//si esres accesController mandalo a HomeController
                {
                    filterContext.HttpContext.Response.Redirect("~/Home/Index");//lo regreso homecontroler
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}