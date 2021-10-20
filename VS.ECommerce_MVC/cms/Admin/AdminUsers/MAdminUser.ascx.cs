using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Services;
using MoreAll;
using VS.ECommerce_MVC;

namespace VS.Lieugiai.cms.Admin.AdminUsers
{
    public partial class MAdminUser : System.Web.UI.UserControl
    {
        DatalinqDataContext db = new DatalinqDataContext();
        private string lang = Captionlanguage.Language;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (System.Web.HttpContext.Current.Session["lang"] != null)
            {
                this.lang = System.Web.HttpContext.Current.Session["lang"].ToString();
            }
            else
            {
                System.Web.HttpContext.Current.Session["lang"] = this.lang;
                this.lang = System.Web.HttpContext.Current.Session["lang"].ToString();
            }
            if (MoreAll.MoreAll.GetCookie("URole") != null)
            {
                string[] strArray = MoreAll.MoreAll.GetCookie("URole").ToString().Trim().Split(new char[] { '|' });
                Reset_Checkbox();
                if (strArray.Length > 0)
                {
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        if (strArray[i].ToString().Equals("4"))
                        {
                            if (!base.IsPostBack)
                            {
                                load();
                            }
                        }
                    }
                }
            }
        }

        void load()
        {
            List<Entity.AdminUser> str = SAdminUser.GETBYALL();
            this.rp_admins.DataSource = str;
            this.rp_admins.DataBind();
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            this.lt_info.Text = "";
            this.hd_insertnew.Value = "";
            this.pn_detail.Visible = false;
            this.pnupdatepassword.Visible = false;
            this.pn_list.Visible = true;
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            if (this.hd_insertnew.Value.Equals("insert"))
            {
                if (this.txt_username.Text.Trim().Length < 1)
                {
                    return;
                }
                if (this.txt_password.Text.Trim().Length < 1)
                {
                    return;
                }
            }
            int locked = 1;
            if (this.chk_enable.Checked)
            {
                locked = 0;
            }
            string role = "";
            if (this.CheckBox1.Checked)
            {
                role = role + "1";
            }
            if (this.CheckBox2.Checked)
            {
                role = role + "|2";
            }
            if (this.CheckBox3.Checked)
            {
                role = role + "|3";
            }
            if (this.CheckBox4.Checked)
            {
                role = role + "|4";
            }
            if (this.CheckBox5.Checked)
            {
                role = role + "|5";
            }
            if (this.CheckBox6.Checked)
            {
                role = role + "|6";
            }
            if (this.CheckBox7.Checked)
            {
                role = role + "|7";
            }
            if (this.CheckBox8.Checked)
            {
                role = role + "|8";
            }
            if (this.CheckBox9.Checked)
            {
                role = role + "|9";
            }
            if (this.CheckBox10.Checked)
            {
                role = role + "|10";
            }
            if (this.CheckBox11.Checked)
            {
                role = role + "|11";
            }
            if (this.CheckBox12.Checked)
            {
                role = role + "|12";
            }
            if (this.CheckBox13.Checked)
            {
                role = role + "|13";
            }
            if (this.CheckBox14.Checked)
            {
                role = role + "|14";
            }
            if (this.CheckBox15.Checked)
            {
                role = role + "|15";
            }
            if (this.CheckBox16.Checked)
            {
                role = role + "|16";
            }
            if (this.CheckBox17.Checked)
            {
                role = role + "|17";
            }
            if (this.CheckBox18.Checked)
            {
                role = role + "|18";
            }
            if (this.CheckBox19.Checked)
            {
                role = role + "|19";
            }
            if (this.CheckBox20.Checked)
            {
                role = role + "|20";
            }
            if (this.CheckBox21.Checked)
            {
                role = role + "|21";
            }
            Entity.AdminUser obj = new Entity.AdminUser();

            if (this.hd_insertnew.Value.Trim().Equals("insert"))
            {
                obj.VUSER_NAME = txt_username.Text;
                obj.VUSER_PWD = SecurityUtilities.EncodeMD5(this.txt_password.Text.Trim());
                obj.VROLE = role;
                obj.IASSIGN = 1;
                obj.DASSIGN_DATE = DateTime.Now;
                obj.ILOCKED = locked;
                SAdminUser.INSERT(obj);
                this.pn_list.Visible = true;
                this.pn_detail.Visible = false;
                load();
            }
            else
            {
                //obj.ID = int.Parse(this.hdid.Value);
                //obj.VUSER_NAME = txt_username.Text;
                //obj.VUSER_PWD = SecurityUtilities.EncodeMD5(this.txt_password.Text.Trim());
                //obj.VROLE = role;
                //obj.IASSIGN = 1;
                //obj.DASSIGN_DATE = DateTime.Now;
                //obj.ILOCKED = locked;
                //SAdminUser.UPDATE(obj);

                AdminUser abc = db.AdminUsers.SingleOrDefault(p => p.ID == int.Parse(this.hdid.Value));
                abc.VROLE = role;
                abc.IASSIGN = 1;
                db.SubmitChanges();

            }
            this.pn_list.Visible = true;
            this.pn_detail.Visible = false;
            load();
        }

        protected void btnupdatenewpassword_Click(object sender, EventArgs e)
        {
            if (this.txtnewpassword.Text.Trim().Length > 0)
            {
                Entity.AdminUser obj = new Entity.AdminUser();
                obj.ID = int.Parse(this.hdid.Value);
                obj.VUSER_PWD = SecurityUtilities.EncodeMD5(txtnewpassword.Text);
                SAdminUser.UPDATE_PASSWORD(obj);
                this.pnupdatepassword.Visible = false;
                this.pn_list.Visible = true;
            }
        }

        protected void Delete_Load(object sender, EventArgs e)
        {
            ((LinkButton)sender).Attributes["onclick"] = "return confirm('Xóa tài khoản vừa chọn ?')";
        }

        protected bool EnableUpdatePassword(string role)
        {
            return true;
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.lang);
        }

        protected void lnk_insertnewadmin_Click(object sender, EventArgs e)
        {
            if (MoreAll.MoreAll.GetCookie("URole") != null)
            {
                string[] strArray = MoreAll.MoreAll.GetCookie("URole").ToString().Trim().Split(new char[] { '|' });
                Reset_Checkbox();
                if (strArray.Length > 0)
                {
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        if (strArray[i].ToString().Equals("4"))
                        {
                            this.hd_insertnew.Value = "insert";
                            this.pn_detail.Visible = true;
                            this.pn_list.Visible = false;
                            this.txt_password.Enabled = true;
                            this.txt_username.Enabled = true;
                            this.txt_username.Text = "";
                            this.txt_password.Text = "";
                        }
                    }
                }
            }
        }

        protected string Lock(string ilocked)
        {
            if (ilocked.Equals("0"))
            {
                return "Đang hoạt động";
            }
            return "Bị kh\x00f3a";
        }

        protected string lockunlock(string locked)
        {
            if (locked.Trim().Equals("0"))
            {
                return "<i class=\"icon-check-empty\"></i>";
            }
            return "<i class=\"icon-check\"></i>";
        }

        protected void Reset_Checkbox()
        {
            this.CheckBox1.Checked = false;
            this.CheckBox2.Checked = false;
            this.CheckBox3.Checked = false;
            this.CheckBox4.Checked = false;
            this.CheckBox5.Checked = false;
            this.CheckBox6.Checked = false;
            this.CheckBox7.Checked = false;
            this.CheckBox8.Checked = false;
            this.CheckBox9.Checked = false;
            this.CheckBox10.Checked = false;
            this.CheckBox11.Checked = false;
            this.CheckBox12.Checked = false;
            this.CheckBox13.Checked = false;
            this.CheckBox14.Checked = false;
            this.CheckBox15.Checked = false;
            this.CheckBox16.Checked = false;
            this.CheckBox17.Checked = false;
            this.CheckBox18.Checked = false;
            this.CheckBox19.Checked = false;
            this.CheckBox20.Checked = false;
            this.CheckBox21.Checked = false;
            this.chk_enable.Checked = true;
        }

        protected void rp_admins_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string commandName = e.CommandName;
            if (commandName != null)
            {
                if (!(commandName == "updatepassword"))
                {
                    if (!(commandName == "Delete"))
                    {
                        string str2;
                        if (!(commandName == "ChangeStatus"))
                        {
                            if (commandName == "update")
                            {
                                this.hdid.Value = e.CommandArgument.ToString();
                                this.hd_insertnew.Value = "update";
                                this.pn_detail.Visible = true;
                                this.pn_list.Visible = false;
                                this.txt_username.Enabled = false;
                                this.txt_password.Enabled = false;
                                this.lt_info.Text = " - Update User";
                                List<Entity.AdminUser> table = SAdminUser.GETBYID(e.CommandArgument.ToString());
                                this.Reset_Checkbox();
                                if (table.Count > 0)
                                {
                                    this.txt_username.Text = table[0].VUSER_NAME.ToString();
                                    this.txt_password.Text = table[0].VUSER_PWD.ToString();
                                    if (table[0].ILOCKED.ToString().Equals("0"))
                                    {
                                        this.chk_enable.Checked = true;
                                    }
                                    else
                                    {
                                        this.chk_enable.Checked = false;
                                    }
                                    string[] strArray = table[0].VROLE.ToString().Split(new char[] { '|' });
                                    if (strArray.Length > 0)
                                    {
                                        for (int i = 0; i < strArray.Length; i++)
                                        {
                                            if (strArray[i].ToString().Equals("1"))
                                            {
                                                this.CheckBox1.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("2"))
                                            {
                                                this.CheckBox2.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("3"))
                                            {
                                                this.CheckBox3.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("4"))
                                            {
                                                this.CheckBox4.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("5"))
                                            {
                                                this.CheckBox5.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("6"))
                                            {
                                                this.CheckBox6.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("7"))
                                            {
                                                this.CheckBox7.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("8"))
                                            {
                                                this.CheckBox8.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("9"))
                                            {
                                                this.CheckBox9.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("10"))
                                            {
                                                this.CheckBox10.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("11"))
                                            {
                                                this.CheckBox11.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("12"))
                                            {
                                                this.CheckBox12.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("13"))
                                            {
                                                this.CheckBox13.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("14"))
                                            {
                                                this.CheckBox14.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("15"))
                                            {
                                                this.CheckBox15.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("16"))
                                            {
                                                this.CheckBox16.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("17"))
                                            {
                                                this.CheckBox17.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("18"))
                                            {
                                                this.CheckBox18.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("19"))
                                            {
                                                this.CheckBox19.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("20"))
                                            {
                                                this.CheckBox20.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("21"))
                                            {
                                                this.CheckBox21.Checked = true;
                                            }
                                        }
                                    }
                                    if (table[0].ILOCKED.ToString().Equals("0"))
                                    {
                                        this.chk_enable.Checked = true;
                                    }
                                }
                            }
                            return;
                        }
                        string str = e.CommandArgument.ToString().Trim().Substring(0, e.CommandArgument.ToString().IndexOf("|"));
                        if (e.CommandArgument.ToString().Substring(e.CommandArgument.ToString().IndexOf("|") + 1, (e.CommandArgument.ToString().Length - e.CommandArgument.ToString().IndexOf("|")) - 1) == "1")
                        {
                            str2 = "0";
                        }
                        else
                        {
                            str2 = "1";
                        }
                        Entity.AdminUser obj = new Entity.AdminUser();
                        obj.ID = int.Parse(str);
                        obj.ILOCKED = int.Parse(str2);
                        SAdminUser.UPDATE_STATUS(obj);
                        load();
                        return;
                    }
                }
                else
                {
                    this.hdid.Value = e.CommandArgument.ToString();
                    this.pn_list.Visible = false;
                    this.pnupdatepassword.Visible = true;
                    this.lt_info.Text = " -  Cập nhật password";
                    return;
                }
                SAdminUser.DELETE(e.CommandArgument.ToString().Trim());
                load();
            }
        }
    }
}