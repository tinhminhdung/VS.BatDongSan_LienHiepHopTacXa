using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Paypal
{
    public class PaypalEntity
    {
        public string Business { get; set; }
        public string ItemName { get; set; }
        public string ItemNumber { get; set; }
        public string Amount { get; set; }
        public string NoShipping { get; set; }
        public string Quantity { get; set; }
        public string OS2 { get; set; }
    }
    public PaypalEntity SetOrderingValue(string itemName, string itemNumber, string amount, string noShipping, string quantity, string os2)
    {
        PaypalEntity ppEntity = new PaypalEntity();
        ppEntity.Business = MoreAll.Other.Giatri("paypal");
        ppEntity.ItemName = itemName;
        ppEntity.ItemNumber = itemNumber;
        ppEntity.Amount = amount;
        ppEntity.NoShipping = noShipping;
        ppEntity.Quantity = quantity;
        ppEntity.OS2 = os2;
        return ppEntity;
    }
}
