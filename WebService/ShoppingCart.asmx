<%@ WebService Language="C#" Class="ShoppingCart" %>
using System;
using System.Collections;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using BIC.Biz;
using BIC.Utils;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]

public class ShoppingCart : WebService
{
    public Hashtable Hashtable
    {
        set { HttpContext.Current.Session.Add("cart", value); }
        get
        {
            var hashtable = (Hashtable)HttpContext.Current.Session["cart"] ?? new Hashtable();
            return hashtable;
        }
    }
    [WebMethod(EnableSession = true)]
    public string checkTT(int productId)
    {
        var productEntity = ProductBiz.GetProductByID(productId);
            
            if (productEntity != null)
            {  if (productEntity.OutOfStock)
                {
                    var menuEntity = MenuUserBiz.GetMenuUserByID(productEntity.MainMenuUserID);
                    var product = new ProductCart
                                      {
                                          proID = productId,
                                          proName = productEntity.Title,
                                          Quantity = 1,
                                          Price =
                                              string.IsNullOrEmpty(productEntity.Price)
                                                  ? "0"
                                                  : productEntity.Price.Replace(" USD", "").Replace(" VND", "").Replace(
                                                      " VNĐ", ""),
                                          ProductVat =
                                              string.IsNullOrEmpty(productEntity.Price)
                                                  ? "0"
                                                  : ((Convert.ToDecimal(
                                                      productEntity.Price.Replace(" USD", "").Replace(" VND", "").
                                                          Replace(" VNĐ", ""))*
                                                      (string.IsNullOrEmpty(productEntity.SaleOff)
                                                           ? 0
                                                           : Convert.ToDecimal(productEntity.SaleOff)))/100*1).ToString(),
                                          //ProductVat = "0",
                                          ImageId = productEntity.ImageID,
                                          Code = productEntity.Code,
                                          TotalFullVat =
                                              (1*
                                               Convert.ToDecimal(string.IsNullOrEmpty(productEntity.Price)
                                                                     ? "0"
                                                                     : productEntity.Price.Replace(" USD", "").Replace(
                                                                         " VND", "").Replace(" VNĐ", "")))
                                              .ToString()
                                      };
                    var cart = new Cart();
                    return cart.CheckTT2(product);   
                }}
        return "";
    }
    [WebMethod(EnableSession = true)]
    public bool AddCart(int productId, int numberProduct)
    {
        try
        {
              
            var productEntity = ProductBiz.GetProductByID(productId);
            
            if (productEntity == null) return false;
            if (productEntity.OutOfStock)
            {    
                var product = new ProductCart
                {
                    proID = productId,
                    proName = productEntity.Title,
                    Quantity = numberProduct,
                    Price =
                        string.IsNullOrEmpty(productEntity.Price)
                            ? "0"
                            : productEntity.Price.Replace(" USD", "").Replace(" VND", "").Replace(" VNĐ", ""),
                    ProductVat =
                        string.IsNullOrEmpty(productEntity.Price)
                            ? "0"
                            : ((Convert.ToDecimal(productEntity.Price.Replace(" USD", "").Replace(" VND", "").Replace(" VNĐ", "")) * (string.IsNullOrEmpty(productEntity.SaleOff) ? 0 : Convert.ToDecimal(productEntity.SaleOff))) / 100 * numberProduct).ToString(),
                   
                    ImageId = productEntity.ImageID,
                    Code = productEntity.Code,
                    TotalFullVat =
                        (numberProduct *
                         Convert.ToDecimal(string.IsNullOrEmpty(productEntity.Price)
                             ? "0"
                             : productEntity.Price.Replace(" USD", "").Replace(" VND", "").Replace(" VNĐ", "")))
                            .ToString()
                };


                var cart = new Cart();
                return cart.Add(product);   
            }
            return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
}