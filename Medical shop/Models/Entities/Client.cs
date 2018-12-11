using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medical_shop.Models
{
    public class Client : Base
    {
        public string Name { get; set; }
        public string Date { get; set; }
        public string Email { get; set; }

        public List<Comment> Comments { get; set; }
        public List<Order> Orders { get; set; }

        public Client(int id) : base(id) {}
    }
}