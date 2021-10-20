using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VS.ECommerce_MVC.Models
{
    public class ProductViewModel
    {
        public int ipid { get; set; }
        public string icid { get; set; }
        public int ID_Hang { get; set; }
        public string Name { get; set; }
        public string Brief { get; set; }
        public string Code { get; set; }
        public DateTime Create_Date { get; set; }
        public string Images { get; set; }
        public string ImagesSmall { get; set; }
        public string OldPrice { get; set; }
        public string Price { get; set; }
        public string TangName { get; set; }
        public string Alt { get; set; }
    }
}