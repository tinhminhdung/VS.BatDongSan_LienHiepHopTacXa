using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VS.ECommerce_MVC.Models;

public class ShoppingCartViewModel
{
    public int ProductId { set; get; }
  //  public ProductViewModel Product { set; get; }
    public string Name { set; get; }
    public int Quantity { set; get; }
    public Double Price { set; get; }
    public Double Money { set; get; }
}