using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Medical_shop.Models.Authority
{
    public class RegistrationModel
    {
        public string Name { get; set; }

        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.Password)]
        public string SpecialPassword { get; set; }

        [DataType(DataType.Password)]
        [Compare("SpecialPassword", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmSpecialPassword { get; set; }
    }
}