using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using BIC.Biz;
using BIC.Data;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class ShoppingCart : BasePage
{
    public int id;
    protected double OrderSubTotal;
    protected string OrderMenuId;

    #region Method
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!HttpContext.Current.Profile.GetPropertyValue("TypeOfUser").ToString().Equals("System") &&
               BicMemberShip.CurrentUserName.ToLower() != "administrator")
            Response.Redirect(BicApplication.URLRoot);
        Page.Header.Title = BicResource.GetValue("ShoppingCart", "OrderDetail");
        OrderMenuId = BicRouting.GetRequestString("id", "0");
        if (!IsPostBack)
        {
            LoadProductData();
            LoadOrderInfo();
        }
    }

    protected void LoadProductData()
    {
        try
        {
            var bicData = new BicGetData("OrderDetail");
            bicData.Selecting.Add("*");
            //bicData.Sorting.Add(new SortingItem("CreateDate", true));
            bicData.Conditioning.Add(new ConditioningItem(OrderDetailEntity.FIELD_ORDERMENUID, OrderMenuId, Operator.EQUAL,
                                                          CompareType.STRING));
            var data = bicData.GetAllData();

            lvShoppingCart.DataSource = data;
            lvShoppingCart.DataBind();

            double totalVAT = 0;
            int soluongproduct = 0;
            foreach (DataRow item in data.Rows)
            {
                OrderSubTotal += Convert.ToDouble(item["SubTotal"]);
                totalVAT += Convert.ToDouble(item["SubTotal"]) * 23 / 100;
                soluongproduct += BicConvert.ToInt32(item["Total"]);
            }
            lblOrderSubTotal.Text = OrderSubTotal.ToString("##,###");
            lblFullVat.Text = totalVAT.ToString();
            string tongtien = (totalVAT + OrderSubTotal).ToString();
            lblMoneyTotal.Text = string.Format("{0}", tongtien);
            string phantram = LoadDataToPhanTram(totalVAT + OrderSubTotal, soluongproduct);
            if (phantram.Equals("0"))
                showCartTable.Visible = false;
            else
            {
                lblPhanTram.Text = phantram;
                double chietkhau = Convert.ToDouble(phantram) * (totalVAT + OrderSubTotal) / 100;
                lblSoTienChietKhau.Text = string.Format("{0:N0}", Convert.ToDouble(chietkhau.ToString()));
                lblTongTienSauChietKhau.Text = (Convert.ToDouble(tongtien) - chietkhau).ToString();
            }
            lblTongTien.Text = BicString.ToStringNO(tongtien);
        }
        catch (Exception)
        {
            throw;
        }
    }

    protected void LoadOrderInfo()
    {
        try
        {
            OrderMenuEntity item = OrderMenuBiz.GetOrderMenuByID(BicConvert.ToInt32(OrderMenuId));
            if (item != null)
            {
                lblOrderNo.Text = item.OrderCode;
                lblCreatedDate.Text = item.ShippingDate.ToString("dd/MM/yyyy");
                ltrTen.Text = item.BillingFullName;
                ltrPhone.Text = item.BillingPhone;
                ltrAddress.Text = item.BillingShippingAddress;
                //ltrCity.Text = item.BillingCity;
                ltrEmail.Text = item.BillingEmail;
                ltrNgheNghiep.Text = item.BillingShippingAddress;
                ltrNotes.Text = item.OrderNote;
                ltrNip.Text = item.InvoiceTaxCode;

                ltrTen2.Text = item.ShippingFullName;
                ltrPhone2.Text = item.ShippingPhone;
                ltrNip2.Text = item.Column2;
                ltrAddress2.Text = item.ShippingAddress;
                //ltrCity2.Text = item.ShippingCity;
                ltrEmail2.Text = item.ShippingEmail;
                ltrNgheNghiep2.Text = item.ShippingAddress;
                ltrNotes2.Text = item.Column1;
                lblAddressRecervedOrder.Text = item.InvoiceAddress;
                ltPayMethod.Text = item.PaymentMethod;
                ltShippingMethod.Text = item.ShippingMethod;
                lblShippingFee.Text = string.Format("{0:N0}", item.OrderShippingFee);
                lblUsePoint.Text = string.Format("{0:N0}", item.UsePoint);
                lblOrderSubTotal.Text = string.Format("{0:N0}", item.OrderSubTotal);
                if (string.IsNullOrEmpty(item.Column3))
                    divShippingType.Visible = false;
                else
                {
                    ltrShippingType.Text = item.Column3 == "0" ? "Chuyển phát nhanh" : "Tiết kiệm";
                }
            }
        }
        catch (Exception)
        {

            throw;
        }
    }

    protected int GetImageID(object productid)
    {
        if (productid != null)
        {
            var product = ProductBiz.GetProductByID(Convert.ToInt32(productid));
            if (product != null)
            {
                return product.ImageID;
            }
        }
        return 0;
    }

    protected string GetPriceVAT(object subTotal)
    {
        if (subTotal != null)
        {
            string sub = string.Format("{0:0.00}", subTotal);
            return (Convert.ToDouble(subTotal) * 23 / 100).ToString("0.00");
            //return ((BicConvert.ToDecimal(string.Format("{0:0.00}", subTotal)) * 23) / 100).ToString("0.00");
        }
        return "";
    }

    private string LoadDataToPhanTram(double tongTien, int soluong)
    {
        string phantram = "0";
        try
        {
            if (!string.IsNullOrEmpty(tongTien.ToString()))
            {
                string mappath = HttpContext.Current.Server.MapPath(string.Format("~/admin/XMLData/{0}{1}", "Promotion_", Language + ".xml"));
                XDocument xmldoc = XDocument.Load(mappath);
                IEnumerable<XElement> q =
                    from xe in xmldoc.Descendants("key") select xe;
                var dt = new DataTable();
                dt.Columns.Add("key");
                dt.Columns.Add("name");
                dt.Columns.Add("value");
                dt.Columns.Add("description");

                foreach (XElement xe in q)
                {
                    DataRow row = dt.NewRow();
                    row[0] = xe.Attribute("key").Value;
                    row[1] = xe.Attribute("name").Value;
                    row[2] = xe.Attribute("value").Value;
                    row[3] = xe.Attribute("description").Value;
                    dt.Rows.Add(row); // Thêm dòng mới vào dtb
                }
                foreach (DataRow row in dt.Rows)
                {
                    string[] s = row[1].ToString().Split('-');
                    if (s.Length > 0)
                    {
                        if (BicConvert.ToDecimal(s[1]) <= 100)
                        {
                            phantram = soluong > 9 ? row[2].ToString() : "0";
                            return phantram;
                        }

                        if (tongTien >= Convert.ToDouble(s[0]) && tongTien <= Convert.ToDouble(s[1]))
                        {
                            phantram = row[2].ToString();
                            return phantram;
                        }
                    }
                }
                //if (string.IsNullOrEmpty(lblPhanTram.Text))
                //{
                //    lblPhanTram.Text = "0";
                //}
            }
        }
        catch (Exception)
        {
        }
        return phantram;
    }

    #endregion Method

    protected void ShoppingCart_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        var proID = (Label)e.Item.FindControl("lblID");
        var productlink = (HtmlAnchor)e.Item.FindControl("productLink");
        var productlink1 = (ImageViewer)e.Item.FindControl("ivArticle");
        if (!string.IsNullOrEmpty(proID.Text))
        {
            var proEntity = ProductBiz.GetProductByID(BicConvert.ToInt32(proID.Text));

            if (proEntity != null)
            {
                if (productlink != null)
                    productlink.HRef = string.Format("{0}{1}{2}{3}{4}", BicApplication.URLRoot, Language + "/",
                                                     proEntity.MenuUserName + ".pd" + proEntity.MainMenuUserID + "/",
                                                     string.IsNullOrEmpty(proEntity.Url) ? BicEncoding.ConvertUnicodeToNoSignAndTag(proEntity.Title, "") : proEntity.Url, ".i" + proEntity.ProductID + ".html");


                if (productlink1 != null)
                    productlink1.Link = string.Format("{0}{1}{2}{3}{4}", BicApplication.URLRoot, Language + "/",
                                                     proEntity.MenuUserName + ".pd" + proEntity.MainMenuUserID + "/",
                                                     string.IsNullOrEmpty(proEntity.Url) ? BicEncoding.ConvertUnicodeToNoSignAndTag(proEntity.Title, "") : proEntity.Url, ".i" + proEntity.ProductID + ".html");
            }

        }
    }
}