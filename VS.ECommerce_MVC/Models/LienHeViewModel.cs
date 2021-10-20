using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VS.ECommerce_MVC.Models
{
    public class LienHeViewModel
    {
        [Required(ErrorMessage = "Yêu cầu nhập tên đăng nhập")]
        public string vname { set; get; }

        [Required(ErrorMessage = "Yêu cầu nhập email")]
        [Display(Name = "Email")]
        public string vemail { set; get; }
    }
}