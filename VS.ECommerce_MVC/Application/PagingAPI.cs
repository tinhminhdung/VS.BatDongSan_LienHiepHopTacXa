using Entity;
using MoreAll;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using VS.ECommerce_MVC;

    public class PagingAPI
    {
        private int MaxPageSize = 20;
        private int _pageSize = 10;
        public int PageNumber { get; set; }
        public int pageSize
        {

            get { return _pageSize; }
            set
            {
                _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
            }
        }

        public string QuerySearch { get; set; }
    }


