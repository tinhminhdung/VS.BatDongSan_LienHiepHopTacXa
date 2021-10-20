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
using Framework;
using Entity;
using System.IO;
using System.Web;
using NganLuongAPI;
using System.Threading.Tasks;
using Vietdung.Common;
using OfficeOpenXml;
using System.Web.Script.Serialization;
using Framwork;

namespace VS.ECommerce_MVC.Api
{
    public class OrderController : ApiControllerBase
    {
        DatalinqDataContext db = new DatalinqDataContext();

        // Có thể dùng dạng Ajax trong Controllers --> apiCartController

        // Đối với 1 số bộ code cũ (Khác) thì phải chạy thêm cả phần khai báo trong (WebApiConfig.cs) và (SessionControllerHandler.cs) thì mới chạy được Session

        // Ví dụ chạy Session xem có nhận ko hay lỗi
        //public string Get(string input)
        //{
        //    var session = HttpContext.Current.Session;
        //    if (session != null)
        //    {
        //        if (session["Time"] == null)
        //            session["Time"] = DateTime.Now;
        //        return "Session Time: " + session["Time"] + input;
        //    }
        //    return "Session is not availabe" + input;
        //}

        [Route("Order/GetAll")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            if (System.Web.HttpContext.Current.Session[Commond.SessionCart] == null)
                System.Web.HttpContext.Current.Session[Commond.SessionCart] = new List<ShoppingCartViewModel>();
            var cart = (List<ShoppingCartViewModel>)System.Web.HttpContext.Current.Session[Commond.SessionCart];
            if (cart.Count() > 0)
            {
                return Json(new
                {
                    data = cart,
                    status = true,
                });
            }
            else
            {
                return Json(new
                {
                    status = false,
                    message = "Chưa có sản phẩm nào trong giỏ hàng."
                });
            }
        }

        [Route("Order/GetAllCount")]
        [HttpGet]
        public IHttpActionResult GetAllCount()
        {
            if (System.Web.HttpContext.Current.Session[Commond.SessionCart] == null)
                System.Web.HttpContext.Current.Session[Commond.SessionCart] = new List<ShoppingCartViewModel>();
            var cart = (List<ShoppingCartViewModel>)System.Web.HttpContext.Current.Session[Commond.SessionCart];
            if (cart.Count() > 0)
            {
                return Json(new
                {
                    Count = cart.Count(),
                    status = true,
                });
            }
            else
            {
                return Json(new
                {
                    status = false,
                    Count = "0"
                });
            }
        }

        public string GetMoneyCart()
        {
            double num = 0.0;
            if (System.Web.HttpContext.Current.Session[Commond.SessionCart] == null)
                System.Web.HttpContext.Current.Session[Commond.SessionCart] = new List<ShoppingCartViewModel>();
            var cart = (List<ShoppingCartViewModel>)System.Web.HttpContext.Current.Session[Commond.SessionCart];
            if (cart.Count() > 0)
            {
                for (int i = 0; i < cart.Count; i++)
                {
                    num += Convert.ToDouble(cart[i].Money.ToString());
                }
            }
            return num.ToString();
        }

        [Route("Order/GetQuantity")]
        [HttpGet]
        public IHttpActionResult GetQuantity()
        {
            double num = 0.0;
            if (System.Web.HttpContext.Current.Session[Commond.SessionCart] == null)
                System.Web.HttpContext.Current.Session[Commond.SessionCart] = new List<ShoppingCartViewModel>();
            var cart = (List<ShoppingCartViewModel>)System.Web.HttpContext.Current.Session[Commond.SessionCart];
            if (cart.Count() > 0)
            {
                for (int i = 0; i < cart.Count; i++)
                {
                    num += Convert.ToDouble(cart[i].Quantity.ToString());
                }
            }
            if (cart.Count() > 0)
            {
                return Json(new
                {
                    Quantity = num.ToString(),
                    status = true,
                });
            }
            else
            {
                return Json(new
                {
                    status = false,
                    Quantity = "0"
                });
            }
        }

        public string GetQuantitys()
        {
            double num = 0.0;
            if (System.Web.HttpContext.Current.Session[Commond.SessionCart] == null)
                System.Web.HttpContext.Current.Session[Commond.SessionCart] = new List<ShoppingCartViewModel>();
            var cart = (List<ShoppingCartViewModel>)System.Web.HttpContext.Current.Session[Commond.SessionCart];
            if (cart.Count() > 0)
            {
                for (int i = 0; i < cart.Count; i++)
                {
                    num += Convert.ToDouble(cart[i].Quantity.ToString());
                }
            }
            return num.ToString();
        }

        [Route("Order/Add/{productId}")]
        [HttpPost]
        public IHttpActionResult Add(int productId)
        {

            var cart = (List<ShoppingCartViewModel>)System.Web.HttpContext.Current.Session[Commond.SessionCart];
            var product = SProducts.GetById(productId.ToString());
            if (cart == null)
            {
                cart = new List<ShoppingCartViewModel>();
            }
            if (product[0].Quantity == 0)
            {
                return Json(new
                {
                    status = false,
                    message = "Sản phẩm này hiện đang hết hàng"
                });
            }
            if (cart.Any(x => x.ProductId == productId))
            {
                foreach (var item in cart)
                {
                    if (item.ProductId == productId)
                    {
                        item.Quantity += 1;
                        item.Money = Convert.ToDouble(product[0].Price) * Convert.ToDouble(item.Quantity);
                    }
                }
            }
            else
            {
                ShoppingCartViewModel newItem = new ShoppingCartViewModel();
                newItem.ProductId = productId;
                newItem.Name = product[0].Name;
                newItem.Price = Convert.ToDouble(product[0].Price);
                newItem.Money = Convert.ToDouble(product[0].Price);
                //  newItem.Product = Mapper.Map<Entity.Products, ProductViewModel>(product);
                newItem.Quantity = 1;
                cart.Add(newItem);
            }
            System.Web.HttpContext.Current.Session[Commond.SessionCart] = cart;
            return Json(new
            {
                status = true
            });
        }

        // Dạng theo obj
        [Route("Order/Update/{cartData}")]
        [HttpPost]
        public IHttpActionResult Update(string cartData)
        {
            var cartViewModel = new JavaScriptSerializer().Deserialize<List<ShoppingCartViewModel>>(cartData);

            var cartSession = (List<ShoppingCartViewModel>)System.Web.HttpContext.Current.Session[Commond.SessionCart];
            foreach (var item in cartSession)
            {
                foreach (var jitem in cartViewModel)
                {
                    if (item.ProductId == jitem.ProductId)
                    {
                        item.Quantity = jitem.Quantity;
                    }
                }
            }
            System.Web.HttpContext.Current.Session[Commond.SessionCart] = cartSession;
            return Json(new
            {
                status = true
            });
        }

        // xem lại đang bị nhân sai
        //http://localhost:63136/apiCart/UpdateCart?ProductId=40&Quantity=5
        [Route("Order/UpdateCart/{ProductId}/{Quantity}")]
        [HttpPost]
        public IHttpActionResult UpdateCart(int ProductId, int Quantity)
        {
            var cartSession = (List<ShoppingCartViewModel>)System.Web.HttpContext.Current.Session[Commond.SessionCart];
            foreach (var item in cartSession)
            {
                if (item.ProductId == ProductId)
                {
                    item.Quantity = Quantity;
                    item.Money = Convert.ToDouble(item.Quantity) * Convert.ToDouble(item.Money);
                }
            }
            System.Web.HttpContext.Current.Session[Commond.SessionCart] = cartSession;
            return Json(new
            {
                status = true
            });
        }

        //http://localhost:63136/apiCart/DeleteItem?productId=40
        [Route("Order/DeleteItem/{productId}")]
        [HttpPost]
        public IHttpActionResult DeleteItem(int productId)
        {
            var cartSession = (List<ShoppingCartViewModel>)System.Web.HttpContext.Current.Session[Commond.SessionCart];
            if (cartSession != null)
            {
                cartSession.RemoveAll(x => x.ProductId == productId);
                System.Web.HttpContext.Current.Session[Commond.SessionCart] = cartSession;
                return Json(new
                {
                    status = true
                });
            }
            return Json(new
            {
                status = false
            });
        }

        //http://localhost:63136/apiCart/DeleteAll
        [Route("Order/DeleteAll")]
        [HttpPost]
        public IHttpActionResult DeleteAll()
        {
            System.Web.HttpContext.Current.Session[Commond.SessionCart] = new List<ShoppingCartViewModel>();
            return Json(new
            {
                status = true
            });
        }

        //public IHttpActionResult CheckOut()
        //{
        //    if (System.Web.HttpContext.Current.Session[Commond.SessionCart] == null)
        //    {
        //        return Redirect("/gio-hang.html");
        //    }
        //    return View();
        //}

        [HttpPost]
        [Route("Order/AddOderCart")]
        public IHttpActionResult Create(CartsViewModel orderVm)
        {
            try
            {
                var cartSession = (List<ShoppingCartViewModel>)System.Web.HttpContext.Current.Session[Commond.SessionCart];
                int cartid = FCarts.Insert(orderVm.Name, orderVm.Address, orderVm.Phone, orderVm.Email, orderVm.Contents, GetMoneyCart(), "VIE", "0", "", "", "0", "0");
                Entity.CartDetail oj = new Entity.CartDetail();
                foreach (var item in cartSession)
                {
                    #region MyRegion
                    oj.ID_Cart = int.Parse(cartid.ToString());
                    oj.ipid = int.Parse(item.ProductId.ToString());
                    oj.Price = Convert.ToSingle(item.Price.ToString());
                    oj.Quantity = int.Parse(item.Quantity.ToString());
                    oj.Money = Convert.ToSingle(item.Money.ToString());
                    oj.Mausac = int.Parse("0");
                    oj.Kichco = int.Parse("0");
                    oj.IDThanhVien = int.Parse("0");
                    #endregion
                    SCartDetail.CartDetail_Insert(oj);
                }
                System.Web.HttpContext.Current.Session[Commond.SessionCart] = new List<ShoppingCartViewModel>();
            }
            catch (Exception ex)
            {
                // return request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
                return Json(new
                {
                    status = false,
                    Message = ex.Message
                });
            }
            //return request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            return Json(new
            {
                status = true,
                Message = "Đặt hàng thành công."
            });
        }

        // sau khi thông qua 
        //http://localhost:63136/exportExcel/111
        //http://localhost:63136/Reports/Order-111-20210121103229.xlsx
        [Route("Order/exportExcel/{id}")]
        [HttpGet]
        public HttpResponseMessage ExportOrder(HttpRequestMessage request, int id)
        {
            var folderReport = ConfigHelper.GetByKey("ReportFolder");
            string filePath = HttpContext.Current.Server.MapPath(folderReport);
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            string documentName = GenerateOrder(id);
            if (!string.IsNullOrEmpty(documentName))
            {
                return request.CreateErrorResponse(HttpStatusCode.OK, folderReport + "/" + documentName);
            }
            else
            {
                return request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error export");
            }
            // If something fails or somebody calls invalid URI, throw error.
        }

        #region Export to Excel
        private string GenerateOrder(int orderId)
        {
            var folderReport = ConfigHelper.GetByKey("ReportFolder");
            string filePath = HttpContext.Current.Server.MapPath(folderReport);
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            // Template File
            string templateDocument =
                    HttpContext.Current.Server.MapPath("~/Uploads/Templates/OrderTemplate.xlsx");
            string documentName = string.Format("Order-{0}-{1}.xlsx", orderId, DateTime.Now.ToString("yyyyMMddhhmmsss"));
            string fullPath = Path.Combine(filePath, documentName);
            // Results Output
            MemoryStream output = new MemoryStream();
            try
            {
                // Read Template
                using (FileStream templateDocumentStream = File.OpenRead(templateDocument))
                {
                    // Create Excel EPPlus Package based on template stream
                    using (ExcelPackage package = new ExcelPackage(templateDocumentStream))
                    {
                        // Grab the sheet with the template, sheet name is "BOL".
                        ExcelWorksheet sheet = package.Workbook.Worksheets["Order"];
                        // Data Acces, load order header data.
                        var order = db.LCarts.SingleOrDefault(p => p.ID == orderId);
                        // Insert customer data into template
                        sheet.Cells[4, 1].Value = "Tên khách hàng: " + order.Name;
                        sheet.Cells[5, 1].Value = "Địa chỉ: " + order.Address;
                        sheet.Cells[6, 1].Value = "Điện thoại: " + order.Phone;
                        // Start Row for Detail Rows
                        int rowIndex = 9;

                        // load order details
                        var orderDetails = db.CartDetails.Where(s => s.ID_Cart == int.Parse(order.ID.ToString())).ToList();
                        int count = 1;
                        foreach (var orderDetail in orderDetails)
                        {
                            sheet.Cells[rowIndex, 1].Value = count.ToString();
                            // Cell 2, Order Number (Outline around columns 2-7 make it look like 1 column)
                            sheet.Cells[rowIndex, 2].Value = Commond.ShowNamePro(orderDetail.ipid.ToString());
                            // Cell 8, Weight in LBS (convert KG to LBS, and rounding to whole number)
                            sheet.Cells[rowIndex, 3].Value = orderDetail.Quantity.ToString();

                            sheet.Cells[rowIndex, 4].Value = Convert.ToDouble(orderDetail.Price).ToString("N0");
                            sheet.Cells[rowIndex, 5].Value = (Convert.ToDouble(orderDetail.Price) * Convert.ToDouble(orderDetail.Quantity)).ToString("N0");
                            // Increment Row Counter
                            rowIndex++;
                            count++;
                        }
                        double total = (double)(orderDetails.Sum(x => x.Quantity * x.Price));
                        sheet.Cells[24, 5].Value = total.ToString("N0");

                        var numberWord = "Thành tiền (viết bằng chữ): " + NumberHelper.ToString(total);
                        sheet.Cells[26, 1].Value = numberWord;
                        if (order.Create_Date.HasValue)
                        {
                            var date = order.Create_Date.Value;
                            sheet.Cells[28, 3].Value = "Ngày " + date.Day + " tháng " + date.Month + " năm " + date.Year;

                        }
                        package.SaveAs(new FileInfo(fullPath));
                    }
                    return documentName;
                }
            }
            catch (Exception ex)
            {
                return string.Empty;
            }

        }
        #endregion

    }
}

