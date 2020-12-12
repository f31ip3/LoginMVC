using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Login_MVC.Models.ViewModels
{
    public class UserViewModel
    {
        [Required]
        [EmailAddress]
        [StringLength(100,ErrorMessage = "El {0} debe tener al menos {1} caracteres",MinimumLength =1)]
        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name = "Confirma Contraseña")]
        [Compare("Password",ErrorMessage = "Las Contraseñas no son iguales")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required]
        public int Edad { get; set; }
    }

    public class EditUserViewModel
    {   
        [Key]
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name = "Confirma Contraseña")]
        [Compare("Password", ErrorMessage = "Las Contraseñas no son iguales")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required]
        public int Edad { get; set; }
    }
}