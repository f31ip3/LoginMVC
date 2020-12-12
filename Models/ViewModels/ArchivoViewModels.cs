using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Login_MVC.Models.ViewModels
{
    public class ArchivoViewModels
    {
        [Required]
        [DisplayName("Mi Archivo")]
        public HttpPostedFileBase Archivo1 { get; set; }

        [Required]
        [DisplayName("Mi Archivo 2")]
        public HttpPostedFileBase Archivo2 { get; set; }
        [Required]
        [DisplayName("Mi Cadena")]
        public string Cadena { get; set; }
    }
}