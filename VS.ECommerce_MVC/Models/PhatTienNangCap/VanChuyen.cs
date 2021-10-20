using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VS.ECommerce_MVC.Models.PhatTienNangCap
{
    public class VanChuyen
    {
        public class PriceGhtkRequestModel
        {
            public string pick_province { get; set; }
            public string pick_district { get; set; }
            public string province { get; set; }
            public string district { get; set; }
            public string address { get; set; }
            public float weight { get; set; }
            public double value { get; set; }
            public string transport { get; set; }
        }

        public class PriceGhtkResultModel
        {
            public bool success { get; set; }
            public string message { get; set; }
            public GhtkFeeModel fee { get; set; }
        }

        public class GhtkFeeModel
        {
            public string name { get; set; }
            public decimal fee { get; set; }
            public decimal insurance_fee { get; set; }
            public string delivery_type { get; set; }
            public double a { get; set; }
            public string dt { get; set; }
            public bool delivery { get; set; }
        }
    }
}