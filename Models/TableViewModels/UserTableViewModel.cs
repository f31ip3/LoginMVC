using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Login_MVC.Models.TableViewModels
{
    public class UserTableViewModel
    {//Esta clase me sirve para ostrar la información 
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int IdState { get; set; }
        public int? Edad { get; set; }
    }
}