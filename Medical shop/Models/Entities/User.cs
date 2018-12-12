using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medical_shop.Models.Entities
{
    public class User : Base
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Date { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public List<Comment> Comments { get; set; }
        public List<Order> Orders { get; set; }
    }
}