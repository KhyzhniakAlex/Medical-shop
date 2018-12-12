using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medical_shop.Models.Entities
{
    public class RuleForAdmin : Base
    {
        public string RulePassword { get; set; }
        public bool isFree { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}