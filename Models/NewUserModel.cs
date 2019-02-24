using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreOwin.Models
{
    public class NewUserModel
    {
        [MinLength(3)]
        public string UserName { get; set; }
        [MinLength(6)]
        public string Password { get; set; }
        [MinLength(3)]
        public string Name { get; set; }
        public string SurName { get; set; }
        [EmailAddress]
        public string Emails { get; set; }
        public string Phone { get; set; }

    }
}
