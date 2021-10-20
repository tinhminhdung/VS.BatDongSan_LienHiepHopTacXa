using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace VS.ECommerce_MVC.cms.Admin.settings
{
    public partial class ExecuteSQL : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnExecute_Click(object sender, EventArgs e)
        {
           // try
            //{
                using (SqlConnection dbConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    using (SqlCommand dbCmd = new SqlCommand(txtCmd.Text, dbConn))
                    {
                        dbCmd.CommandType = CommandType.Text;
                        dbConn.Open();
                        dbCmd.ExecuteNonQuery();
                        dbConn.Close();
                    }
                }
                lbThongbao.Text = "Thành công.";
            //}
            //catch
            //{
            //    lbThongbao.Text = "Lỗi.";
            //}
        }
    }
}