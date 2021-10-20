using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoreAll.Templates
{
    public class QueryString
    {
        public static string hp { get { return MoreAll.GetParamValue("hp"); } }
        public static string tid { get { return MoreAll.GetParamValue("tid"); } }
        public static string fid { get { return MoreAll.GetParamValue("fid"); } } 
        public static string oid { get { return MoreAll.GetParamValue("oid"); } } 
        public static string ID { get { return MoreAll.GetParamValue("ID"); } } 
        public static string CurrentModuleCode { get { return MoreAll.GetParamValue("u"); } } 
        public static string cid { get { return MoreAll.GetParamValue("cid"); } } 
        public static string pid { get { return MoreAll.GetParamValue("pid"); } } 
        public static string nid { get { return MoreAll.GetParamValue("nid"); } } 
        public static string ivideo { get { return MoreAll.GetParamValue("ivideo"); } } 
        public static string iphoto { get { return MoreAll.GetParamValue("iphoto"); } }
    }
}
