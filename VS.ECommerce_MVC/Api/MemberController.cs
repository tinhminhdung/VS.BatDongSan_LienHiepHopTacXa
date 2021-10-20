using MoreAll;
using Services;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Linq;
using AutoMapper;
using VS.ECommerce_MVC.Models;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using System.Collections.Specialized;
using System.Web;

namespace VS.ECommerce_MVC.Api
{
    public class MemberController : ApiControllerBase
    {
        DatalinqDataContext db = new DatalinqDataContext();
        private string language = "VIE";

        [Route("Member/Create")]
        [HttpPost]
        public IHttpActionResult Create(Entity.Member person)
        {
            if (!ModelState.IsValid)
            {
                return Json(new
                {
                    status = false,
                    message = "Vui lòng điền thông tin đăng ký."
                });
            }
            else
            {
                Member list = db.Members.SingleOrDefault(s => s.Email.Contains(person.Email.Trim().ToLower()));
                Member listDienThoai = db.Members.SingleOrDefault(s => s.DienThoai.Contains(person.DienThoai.Trim().ToLower()));
                if (MoreAll.RegularExpressions.phone(person.DienThoai))
                {
                    return Json(new
                    {
                        status = false,
                        message = "Điện thoại không đúng định dạng."
                    });
                }
                else if (listDienThoai != null)
                {
                    return Json(new
                    {
                        status = false,
                        message = "Điện thoại đã tồn tại trong hệ thống."
                    });
                }
                else if (list != null)
                {
                    return Json(new
                    {
                        status = false,
                        message = "Email đã tồn tại trong hệ thống"
                    });
                }
                else
                {
                    //System.Threading.Thread.Sleep(1000);
                    //#region Senmail
                    //if (!Commond.Setting("Emailden").Equals(""))
                    //    Senmail(txtHoTen, txtaddress, txtphone, txtemail, txttieude, txtcontent);
                    //#endregion

                    string validatekey = DateTime.Now.Ticks.ToString();
                    Member obj = new Member();
                    obj.PasWord = person.PasWord;
                    obj.HoVaTen = person.HoVaTen;
                    obj.GioiTinh = 0;
                    obj.NgaySinh = DateTime.Now.ToString("dd/MM/yyyy");
                    obj.DiaChi = person.DiaChi;
                    obj.DienThoai = person.DienThoai;
                    obj.Email = person.Email;
                    obj.AnhDaiDien = "";
                    obj.NgayTao = DateTime.Now;
                    obj.Key = validatekey;
                    obj.TrangThai = 0;
                    obj.Lang = language;
                    db.Members.InsertOnSubmit(obj);
                    db.SubmitChanges();
                    return Json(new
                    {
                        status = true,
                        message = "Đăng ký tài khoản thành công"
                    });
                }
                return Json(new
                {
                    status = false,
                    message = "Đăng ký tài khoản thất bại..!"
                });
            }
        }

        [Route("Member/Login")]
        [HttpPost]
        public IHttpActionResult Dang_Nhap(string Tendangnhap, string Matkhau)
        {
            if (ModelState.IsValid)
            {
                if ((Tendangnhap.Trim().Length < 1) || (Matkhau.Trim().Length < 1))
                {
                    return Json(new
                    {
                        status = false,
                        message = "Vui lòng điền thông tin đăng nhập"
                    });
                }
                else
                {
                    if (RegularExpressions.IsValidEmail(Tendangnhap.Trim().ToLower()))
                    {
                        List<Entity.Member> table = SMember.Name_Text("select * from Members where Email='" + Tendangnhap.Trim().ToLower() + "' and PasWord='" + (Matkhau.Trim().ToLower()) + "' and TrangThai=1");
                        if (table.Count < 1)
                        {
                            return Json(new
                            {
                                status = false,
                                message = "Tài khoản không đúng hoặc chưa được kích hoạt.!"
                            });
                        }
                        else
                        {
                            MoreAll.MoreAll.SetCookie_AddDays("APIMembers", Tendangnhap.Trim().ToLower(), 5);
                            MoreAll.MoreAll.SetCookie_AddDays("APIMembersID", table[0].ID.ToString(), 5);

                            return Json(new
                            {
                                status = true,
                               // Cookie = resp,
                                message = "Đăng nhập thành công."
                            });

                        }
                    }
                    else if (!RegularExpressions.phone(Tendangnhap.Trim().ToLower()))
                    {
                        List<Entity.Member> table = SMember.Name_Text("select * from Members where DienThoai='" + Tendangnhap.Trim().ToLower() + "' and PasWord='" + (Matkhau.Trim().ToLower()) + "' and TrangThai=1");
                        if (table.Count < 1)
                        {
                            return Json(new
                             {
                                 status = false,
                                 message = "Tài khoản không đúng hoặc chưa được kích hoạt."
                             });
                        }
                        else
                        {
                            MoreAll.MoreAll.SetCookie_AddDays("APIMembers", Tendangnhap.Trim().ToLower(), 5);
                            MoreAll.MoreAll.SetCookie_AddDays("APIMembersID", table[0].ID.ToString(), 5);
                            return Json(new
                            {
                                status = true,
                               // Cookie = resp,
                                message = "Đăng nhập thành công."
                            });
                        }
                    }
                }
            }
            return Json(new
            {
                status = false,
                message = "Đăng nhập thất bại."
            });
        }

        [Route("Member/XinChao")]
        [HttpGet]
        public IHttpActionResult XinChao()
        {
            var cookie = Request.Headers.GetCookies("APIMembersID").FirstOrDefault();
            if (cookie != null)
            {
                Member dt = db.Members.SingleOrDefault(p => p.ID == int.Parse(cookie["APIMembersID"].Value));
                if (dt == null)
                {
                    return Json(new
                    {
                        status = false,
                        message = "không tìm thấy thành viên."
                    });
                }
                else if (dt != null)
                {
                    return Json(new
                    {
                        status = true,
                        message = dt
                    });
                }
            }
            return Json(new
            {
                status = false,
                message = "không tìm thấy thành viên."
            });
        }
    }
}
