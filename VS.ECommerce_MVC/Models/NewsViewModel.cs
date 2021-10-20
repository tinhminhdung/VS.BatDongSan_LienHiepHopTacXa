using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VS.ECommerce_MVC.Models
{
    public class NewsViewModel
    {
        public int inid { get; set; }
        public int icid { get; set; }
        public string Title { get; set; }
        public string Brief { get; set; }
        public string Images { get; set; }
        public string ImagesSmall { get; set; }

        public System.Nullable<System.DateTime> Create_Date;
        public string TangName { get; set; }
        public int Views { get; set; }
        public string Contents { get; set; }
    }
}