using MVC_Login_B.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_Login_B.Models
{
    [Table("TB_M_Login")]
    public class ClassLogin : basemodel
    {
       
        public string Email { get; set; }
        public string Password { get; set; }

    }
}