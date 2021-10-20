using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VS.ECommerce_MVC.Models
{
    public class VideoViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Brief { get; set; }
        public string Images { get; set; }
        public string ImagesSmall { get; set; }
        public DateTime CreateDate { get; set; }
        public string TangName { get; set; }
        public string Youtube { get; set; }
        public string Alt { get; set; }
        public int Menu_ID { get; set; }
    }
}