using System;
using System.Collections;
using System.Data;
using System.Text.RegularExpressions;
using System.Web;
using BIC.Biz;

namespace BIC.Utils
{
    public class Number
    {
        public static string GetNumber(string input)
        {
            string text = string.Empty;
            if (string.IsNullOrEmpty(input)) return text;
            string[] digits = Regex.Split(input, @"\D+");
            foreach (string value in digits)
            {
                int number;
                if (int.TryParse(value, out number))
                {
                    text += value;
                }
            }
            return text;
        }
    }

    public class ProductCart
    {
        public int proID { get; set; }
        public string proName { get; set; }
        public int ImageId { get; set; }
        public int Quantity { get; set; }
        public string Price { get; set; }
        public string Code { get; set; }
        public string ProductVat { get; set; }
        public string TotalFullVat { get; set; }


        public ProductCart()
        {
            proID = 0;
            proName = string.Empty;
            ImageId = 0;
            Quantity = 1;
            Price = "0";
            ProductVat = string.Empty;
            Code = string.Empty;
        }

        public double Total
        {
            get { return Quantity * BicConvert.ToDouble(Price); }
            set { throw new NotImplementedException(); }
        }

    }

    public class Cart
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
        public string CheckTT2(ProductCart product)
        {
                if (Hashtable[product.proID] != null)
                {
                    var b = (ProductCart)Hashtable[product.proID];
                    if (b.Quantity == 1)
                    {
                        return "Bạn đã thêm sản phẩm này vào giỏ hàng!";
                    }
                    else
                    { return "Bạn đã mua sản phẩm này, mời bạn xem giỏ hàng!"; }
                }
            return "";
        }
        public decimal TotalCart { get; set; }
        public decimal Totalpoint { get; set; }
        public double TotalQuanlity { get; set; }
        public Cart()
        {
            TotalCart = HttpContext.Current.Session["TotalCart"] != null ? Convert.ToDecimal(HttpContext.Current.Session["TotalCart"]) : 0;
            TotalQuanlity = HttpContext.Current.Session["TotalQuanlity"] != null ? BicConvert.ToDouble(HttpContext.Current.Session["TotalQuanlity"]) : 0;
            Totalpoint = HttpContext.Current.Session["TotalPoint"] != null
                ? BicConvert.ToDecimal(HttpContext.Current.Session["TotalPoint"])
                : 0;
            HttpContext.Current.Session.Add("cart", Hashtable);
        }
        public bool Add(ProductCart product)
        {
            if (Hashtable[product.proID] == null)
            {
                Hashtable.Add(product.proID, product);
                TotalCart += Convert.ToDecimal(product.TotalFullVat);
                TotalQuanlity += product.Quantity;
                Totalpoint += Convert.ToDecimal(product.ProductVat);
                Save();
            }
            else
            {
                var productEntity = ProductBiz.GetProductByID(product.proID);
                var menuEntity = MenuUserBiz.GetMenuUserByID(productEntity.MainMenuUserID);
                var b = (ProductCart)Hashtable[product.proID];
                int checkQuantity = b.Quantity + product.Quantity;
                if (checkQuantity > 500)
                    return false;
                b.Quantity += product.Quantity;
                b.ProductVat = "0";
                b.TotalFullVat = (b.Quantity * Convert.ToDouble(b.Price)).ToString();
                Update(b);
                TotalCart += Convert.ToDecimal(product.TotalFullVat);
                TotalQuanlity += product.Quantity;
                Save();
                BicAjax.Alert("Sản phẩm này đã có trong giỏ hàng!");
            }
            return true;
        }
        public void Update(ProductCart product)
        {
            var b = (ProductCart)Hashtable[product.proID];
            if (product.Quantity <= 0)
            {
                Remove(product.proID);
            }
            else
            {
                var productEntity = ProductBiz.GetProductByID(product.proID);
                var menuEntity = MenuUserBiz.GetMenuUserByID(productEntity.MainMenuUserID);
                TotalCart -= Convert.ToDecimal(b.TotalFullVat);
                TotalQuanlity -= b.Quantity;
                TotalQuanlity += product.Quantity;
                b.Quantity = product.Quantity;
                b.ProductVat = "0";
                decimal a = BicConvert.ToDecimal(Convert.ToDecimal(b.Price) * b.Quantity);
                string c = (b.ProductVat);
                decimal d = a + Convert.ToDecimal(c);
                b.TotalFullVat = ((Convert.ToDouble(b.Price) * b.Quantity)).ToString();
                TotalCart += Convert.ToDecimal(b.TotalFullVat);
            }
            Save();
        }
        public bool Remove(int iID)
        {
            try
            {
                if (Hashtable[iID] == null) return false;
                var b = (ProductCart)Hashtable[iID];
                TotalCart -= Convert.ToDecimal(b.TotalFullVat);
                TotalQuanlity -= b.Quantity;
                Hashtable.Remove(iID);
                Save();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public void Save()
        {
            HttpContext.Current.Session["cart"] = Hashtable;
            HttpContext.Current.Session["TotalCart"] = TotalCart;
            HttpContext.Current.Session["TotalQuanlity"] = TotalQuanlity;
            HttpContext.Current.Session["TotalPoint"] = Totalpoint;
        }
        public void Clear()
        {
            HttpContext.Current.Session["cart"] = null;
            HttpContext.Current.Session["TotalCart"] = null;
            HttpContext.Current.Session["TotalQuanlity"] = null;
            HttpContext.Current.Session["TotalPoint"] = null;
        }
    }
}