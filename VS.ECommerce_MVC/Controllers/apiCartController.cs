using Entity;
using Framwork;
using MoreAll;
using Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace VS.ECommerce_MVC.Controllers
{
    public class apiCartController : Controller
    {
        DatalinqDataContext db = new DatalinqDataContext();
        public ActionResult Index()
        {
            if (Session[Commond.SessionCart] == null)
                Session[Commond.SessionCart] = new List<ShoppingCartViewModel>();
            return View();
        }

        // Chú ý: Phải chạy bằng  postment

        //http://localhost:63136/apiCart/Add?productId=40
        // ko chạy dc bằng [HttpGet]
        // phải chạy bằng postment để test nhé
        [HttpPost]
        public JsonResult Add(int productId)
        {
            var cart = (List<ShoppingCartViewModel>)Session[Commond.SessionCart];
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
            Session[Commond.SessionCart] = cart;
            return Json(new
            {
                status = true
            });
        }


        //http://localhost:63136/apiCart/GetAll
        [HttpGet]
        public JsonResult GetAll()
        {
            if (System.Web.HttpContext.Current.Session[Commond.SessionCart] == null)
                System.Web.HttpContext.Current.Session[Commond.SessionCart] = new List<ShoppingCartViewModel>();
            var cart = (List<ShoppingCartViewModel>)System.Web.HttpContext.Current.Session[Commond.SessionCart];
            return Json(new
            {
                data = cart,
                status = true,
            }, JsonRequestBehavior.AllowGet);
        }


        // Dạng theo obj
        [HttpPost]
        public JsonResult Update(string cartData)
        {
            var cartViewModel = new JavaScriptSerializer().Deserialize<List<ShoppingCartViewModel>>(cartData);

            var cartSession = (List<ShoppingCartViewModel>)Session[Commond.SessionCart];
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
            Session[Commond.SessionCart] = cartSession;
            return Json(new
            {
                status = true
            });
        }


        //  // xem lại đang bị nhân sai
        //http://localhost:63136/apiCart/UpdateCart?ProductId=40&Quantity=5
        [HttpPost]
        public JsonResult UpdateCart(int ProductId, int Quantity)
        {
            var cartSession = (List<ShoppingCartViewModel>)Session[Commond.SessionCart];
            foreach (var item in cartSession)
            {
                if (item.ProductId == ProductId)
                {
                    item.Quantity = Quantity;
                    item.Money = Convert.ToDouble(item.Quantity) * Convert.ToDouble(item.Money);
                }
            }
            Session[Commond.SessionCart] = cartSession;
            return Json(new
            {
                status = true
            });
        }


        //http://localhost:63136/apiCart/DeleteItem?productId=40
        [HttpPost]
        public JsonResult DeleteItem(int productId)
        {
            var cartSession = (List<ShoppingCartViewModel>)Session[Commond.SessionCart];
            if (cartSession != null)
            {
                cartSession.RemoveAll(x => x.ProductId == productId);
                Session[Commond.SessionCart] = cartSession;
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
        [HttpPost]
        public JsonResult DeleteAll()
        {
            Session[Commond.SessionCart] = new List<ShoppingCartViewModel>();
            return Json(new
            {
                status = true
            });
        }

        public ActionResult CheckOut()
        {
            if (Session[Commond.SessionCart] == null)
            {
                return Redirect("/gio-hang.html");
            }
            return View();
        }

        //public ActionResult CreateOrder(string orderViewModel)
        //{
        //    var order = new JavaScriptSerializer().Deserialize<OrderViewModel>(orderViewModel);

        //    var orderNew = new Order();

        //    orderNew.UpdateOrder(order);

        //    if (Request.IsAuthenticated)
        //    {
        //        orderNew.CustomerId = User.Identity.GetUserId();
        //        orderNew.CreatedBy = User.Identity.GetUserName();
        //    }

        //    var cart = (List<ShoppingCartViewModel>)Session[CommonConstants.SessionCart];
        //    List<OrderDetail> orderDetails = new List<OrderDetail>();
        //    bool isEnough = true;
        //    foreach (var item in cart)
        //    {
        //        var detail = new OrderDetail();
        //        detail.ProductID = item.ProductId;
        //        detail.Quantity = item.Quantity;
        //        detail.Price = item.Product.Price;
        //        orderDetails.Add(detail);

        //        isEnough = _productService.SellProduct(item.ProductId, item.Quantity);
        //        break;
        //    }
        //    if (isEnough)
        //    {
        //        var orderReturn = _orderService.Create(ref orderNew, orderDetails);
        //        _productService.Save();

        //        if (order.PaymentMethod == "CASH")
        //        {
        //            return Json(new
        //            {
        //                status = true
        //            });
        //        }
        //        else
        //        {

        //            var currentLink = ConfigHelper.GetByKey("CurrentLink");
        //            RequestInfo info = new RequestInfo();
        //            info.Merchant_id = merchantId;
        //            info.Merchant_password = merchantPassword;
        //            info.Receiver_email = merchantEmail;



        //            info.cur_code = "vnd";
        //            info.bank_code = order.BankCode;

        //            info.Order_code = orderReturn.ID.ToString();
        //            info.Total_amount = orderDetails.Sum(x => x.Quantity * x.Price).ToString();
        //            info.fee_shipping = "0";
        //            info.Discount_amount = "0";
        //            info.order_description = "Thanh toán đơn hàng tại TeduShop";
        //            info.return_url = currentLink + "xac-nhan-don-hang.html";
        //            info.cancel_url = currentLink + "huy-don-hang.html";

        //            info.Buyer_fullname = order.CustomerName;
        //            info.Buyer_email = order.CustomerEmail;
        //            info.Buyer_mobile = order.CustomerMobile;

        //            APICheckoutV3 objNLChecout = new APICheckoutV3();
        //            ResponseInfo result = objNLChecout.GetUrlCheckout(info, order.PaymentMethod);
        //            if (result.Error_code == "00")
        //            {
        //                return Json(new
        //                {
        //                    status = true,
        //                    urlCheckout = result.Checkout_url,
        //                    message = result.Description
        //                });
        //            }
        //            else
        //                return Json(new
        //                {
        //                    status = false,
        //                    message = result.Description
        //                });
        //        }

        //    }
        //    else
        //    {
        //        return Json(new
        //        {
        //            status = false,
        //            message = "Không đủ hàng."
        //        });
        //    }

        //}
    }
}
