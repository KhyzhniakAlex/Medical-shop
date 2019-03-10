using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medical_shop.Models.Entities
{
    public class Comment : Base
    {
        public string Text { get; set; }
        public string Date { get; set; }
        public string Page { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}