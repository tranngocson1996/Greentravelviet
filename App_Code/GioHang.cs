using BIC.Biz;
using BIC.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

/// <summary>
/// Summary description for GioHang
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class GioHang : WebService
{

    public GioHang()
    {

    }
    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string AddToCart(int pid, string price)
    {
        string gia = string.IsNullOrEmpty(price) ? "0" : price;
        string count = AddToCart(pid, 1, gia);
        CountCart cart = new CountCart();
        cart.Total = count;
        return new JavaScriptSerializer().Serialize(cart);
    }
    protected string AddToCart(int pid, int quantity, string price)
    {
        try
        {
            string count = "";
            var productEntity = ProductBiz.GetProductByID(pid);
            //var menupoint = BicConvert.ToDecimal(MenuUserBiz.GetMenuUserByID(productEntity.MainMenuUserID).MenuIcon);
            if (productEntity != null)
            {
                var product = new ProductCart();
                product.proID = pid;
                product.proName = productEntity.Title;
                product.Quantity = quantity; //Số lượng
                product.Price = price;
                product.ProductVat = "0";
                product.ImageId = productEntity.ImageID;
                product.Code = "0";
                product.TotalFullVat = (BicConvert.ToDecimal(price) * quantity).ToString();
                var cart = new Cart();
                if (cart.Add(product))
                {
                    count = BicSession.ToString("TotalQuanlity");
                    return count;
                }
                else
                {
                    return "0";
                }

            }
            return "0";
        }
        catch (Exception ex)
        {
            return "0";
        }
    }
    public class CountCart
    {
        public string Total { get; set; }
    }
}
