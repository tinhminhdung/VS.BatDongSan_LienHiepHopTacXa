using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Services;
using MoreAll;
using System.Collections;

namespace VS.ECommerce_MVC.cms.Admin.Marketing
{
    public partial class MarketingSenmail : System.Web.UI.UserControl
    {
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
            bool isPostBack = base.IsPostBack;
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            string[] strArray = base.Request.Form["chk"].Split(new char[] { ',' });
            if (strArray.Length > 0)
            {
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (i < (strArray.Length - 1))
                    {
                        this.txtto.Text = this.txtto.Text + strArray[i] + ", ";
                    }
                    else
                    {
                        this.txtto.Text = this.txtto.Text + strArray[i];
                    }
                }
            }
            else
            {
                this.txtto.Text = "";
            }
            this.pndl.Visible = false;
            this.txtsubject.Focus();
        }

        protected void btnhuy2_Click(object sender, EventArgs e)
        {
            this.pndl.Visible = false;
        }

        protected void btnsend_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtsubject.Text.Trim().Length < 1)
                {
                    this.lblmsg.Text = "Nhập ti\x00eau đề thư !";
                    this.lblmsg.Visible = true;
                    this.txtsubject.Focus();
                }
                else if (this.txtcontent.Text.Trim().Length < 1)
                {
                    this.lblmsg.Text = "Nhập nội dung thư !";
                    this.lblmsg.Visible = true;
                    this.txtcontent.Focus();
                }
                else if (this.rdbselect.Checked && (this.txtto.Text.Trim().Length < 1))
                {
                    this.lblmsg.Text = "Nhập người nhận !";
                    this.lblmsg.Visible = true;
                    this.txtto.Focus();
                }
                else
                {
                    string bcc = "";
                    ArrayList list = new ArrayList();
                    string sendername = Email.email();
                    string password = Email.password();
                    int str2 = Convert.ToInt32(Email.port());
                    string host = Email.host();
                    if (this.rdball.Checked)
                    {
                        List<Entity.Marketing> table = SMarketing.GET_BYALL();
                        if (table.Count > 0)
                        {
                            for (int i = 0; i < table.Count; i++)
                            {
                                list.Add(table[i].Email.ToString());
                            }
                        }
                    }
                    else
                    {
                        string[] strArray = this.txtto.Text.Split(new char[] { ',' });
                        if (strArray.Length > 0)
                        {
                            for (int j = 0; j < strArray.Length; j++)
                            {
                                list.Add(strArray[j].Trim());
                            }
                        }
                    }
                    int num3 = 0;
                    if (list.Count > 0)
                    {
                        MarketingEmail.SendMail_with_BCC_delegate _delegate = new MarketingEmail.SendMail_with_BCC_delegate(MarketingEmail.SendMail_with_BCC);
                        num3 = list.Count / 100;
                        if (num3 > 0)
                        {
                            for (int k = 0; k <= num3; k++)
                            {
                                if (k < num3)
                                {
                                    bcc = "";
                                    for (int m = 100 * k; m < ((100 * k) + 100); m++)
                                    {
                                        bcc = bcc + list[m] + ",";
                                    }
                                    _delegate.BeginInvoke(sendername, sendername, password, sendername, bcc, host, Convert.ToInt32(str2), this.txtsubject.Text, this.txtcontent.Text, null, null);
                                }
                                else
                                {
                                    bcc = "";
                                    for (int n = 100 * num3; n < list.Count; n++)
                                    {
                                        bcc = bcc + list[n] + ",";
                                    }
                                    _delegate.BeginInvoke(sendername, sendername, password, sendername, bcc, host, Convert.ToInt32(str2), this.txtsubject.Text, this.txtcontent.Text, null, null);
                                }
                            }
                        }
                        else
                        {
                            for (int num7 = 0; num7 < list.Count; num7++)
                            {
                                if (num7 < (list.Count - 1))
                                {
                                    bcc = bcc + list[num7] + ",";
                                }
                                else
                                {
                                    bcc = bcc + list[num7];
                                }
                            }
                            _delegate.BeginInvoke(sendername, sendername, password, sendername, bcc, host, Convert.ToInt32(str2), this.txtsubject.Text, this.txtcontent.Text, null, null);
                        }
                        this.txtto.Text = "";
                        this.txtcontent.Text = "";
                        this.txtsubject.Text = "";
                    }
                    this.lblmsg.Text = "Gửi thư th\x00e0nh c\x00f4ng !";
                    this.lblmsg.Visible = true;
                }
            }
            catch (Exception)
            {
                this.lblmsg.Text = "Hệ thống Email của bạn có thể chưa điền hoặc chưa điền đúng hoặc chưa đúng thông tài khoản Gmail mà chúng tôi yêu cầu";
            }
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.lang);
        }

        protected void lkbsearch_Click(object sender, EventArgs e)
        {
            try
            {
                string[] searchfields = new string[] { "Name", "Email", "Address", "Phone" };
                List<Entity.Marketing> table = SMarketing.SEARCH(this.txtsearch.Text.Replace("&nbsp;", ""), searchfields);
                this.Repeater1.DataSource = table;
                this.Repeater1.DataBind();
            }
            catch (Exception)
            { }
        }

        protected void lnkclose_Click(object sender, EventArgs e)
        {
            this.pndl.Visible = false;
        }

        protected void lnksendto_Click(object sender, EventArgs e)
        {
            this.pndl.Visible = true;
            this.txtsearch.Text = "";
            List<Entity.Marketing> table = SMarketing.GET_BYALL();
            this.Repeater1.DataSource = table;
            this.Repeater1.DataBind();
        }

        protected void rdball_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdball.Checked)
            {
                this.pnto.Visible = false;
            }
        }

        protected void rdbselect_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdbselect.Checked)
            {
                this.pnto.Visible = true;
            }
            else
            {
                this.pnto.Visible = false;
            }
        }
    }
}