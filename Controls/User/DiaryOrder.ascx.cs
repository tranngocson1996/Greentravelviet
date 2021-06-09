using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using BIC.Biz;
using BIC.Data;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Controls_User_DiaryOrder : BaseUIControl
{
    public int id;
    protected double OrderSubTotal;
    protected string OrderMenuId;

    protected void Page_Load(object sender, EventArgs e)
    {
        BindGrid();

        if (BicMemberShip.CurrentUserName == "")
        {
            Response.Redirect(BicApplication.URLRoot);
        }
        Page.Header.Title = BicResource.GetValue("ShoppingCart", "OrderDetail");
        OrderMenuId = BicHtml.GetRequestString("id", "0");
        if (!IsPostBack)
        {
            LoadProductData();
            LoadOrderInfo();
        }
       
        Session["backlist"] = null;
    }
    private void BindGrid()
    {
        var user = Membership.GetUser(BicMemberShip.CurrentUserName);
        if (user != null)
        {
            if (user.ProviderUserKey != null)
            {
                string b = user.ProviderUserKey.ToString();
                grdOrder.DataSource = OrderMenuBiz.GetOrderMenByCusID(b);
                grdOrder.DataBind();
            }
        }
    }

    protected double GetPoint(int orderId)
    {
        double savepoint = 0;
        var lstDetail = OrderDetailBiz.GetOrderDetailByOrderMenuID(orderId);
        foreach (var d in lstDetail)
        {
            var pro = ProductBiz.GetProductByID(d.ProductID);
            var menu = MenuUserBiz.GetMenuUserByID(pro.MainMenuUserID);
            var point = BicConvert.ToDouble(pro.Price) * BicConvert.ToDouble(menu.MenuIcon) / 100 * d.Total; // Total lưu giá trị số lượng sp
            savepoint = savepoint + point;
        }
        return savepoint;
    }

    protected void grdOrder_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        grdOrder.CurrentPageIndex = e.NewPageIndex;
        BindGrid();
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
          
            var tongtien = (totalVAT + OrderSubTotal);
            lblMoneyTotal.Text = OrderSubTotal.ToString("##,###");
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
            lblTongTien.Text = tongtien.ToString("##,###");
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
                // ltrTen.Text = item.BillingFullName;
                //ltrPhone.Text = item.BillingPhone;
                //ltrAddress.Text = item.BillingShippingAddress;
                //ltrCity.Text = item.BillingCity;
                //ltrEmail.Text = item.BillingEmail;
                //ltrNgheNghiep.Text = item.BillingCompany;
                //ltrNotes.Text = item.OrderNote;
                //ltrNip.Text = item.InvoiceTaxCode;
                ltrOrder.Text = item.OrderStatus;
                ltrTen2.Text = item.ShippingFullName;
                ltrPhone2.Text = item.ShippingPhone;
                ltrStatus.Text = item.ShippingStatus;
                //ltrNip2.Text = item.Column2;
                //ltrAddress2.Text = item.ShippingAddress;
                //ltrCity2.Text = item.ShippingCity;
                //ltrEmail2.Text = item.ShippingEmail;
                ltrNgheNghiep2.Text = item.ShippingAddress + ", " +
                                      DistrictBiz.GetDistrictByID(BicConvert.ToInt32(item.ShippingState)).DistrictName +
                                      ", " + CityBiz.GetCityByID(BicConvert.ToInt32(item.ShippingCity)).CityName;
                //ltrNotes2.Text = item.Column1;
                //lblAddressRecervedOrder.Text = item.InvoiceAddress;
                ltPayMethod.Text = Common.GetNameByCategoryId(item.PaymentMethod);

                ltrShippingFee.Text = BicString.ToStringNO(item.OrderShippingFee.ToString());
                lblMoneyTotal.Text = BicString.ToStringNO(item.OrderSubTotal.ToString());
             
                pnOrderDetail.Visible = true;
                if (string.IsNullOrEmpty(item.ShippingMethod))
                    divShippingType.Visible = false;
                else
                    ltrShippingType.Text = Common.GetNameByCategoryId(item.ShippingMethod);

                ltrUsePoint.Text = item.UsePoint.ToString();
            }
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
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
                string mappath = HttpContext.Current.Server.MapPath(string.Format("~/admin/XMLData/{0}{1}", "Promotion_", BicLanguage.CurrentLanguage + ".xml"));
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
             
            }
        }
        catch (Exception)
        {
        }
        return phantram;
    }



    protected void ShoppingCart_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        var proID = (Label)e.Item.FindControl("lblID");
        var productlink = (HtmlAnchor)e.Item.FindControl("productLink");
        var productlink1 = (ImageViewer)e.Item.FindControl("ivArticle");
        var review = (HyperLink)e.Item.FindControl("ReviewProduct");
        if (!string.IsNullOrEmpty(proID.Text))
        {
            var proEntity = ProductBiz.GetProductByID(BicConvert.ToInt32(proID.Text));

            if (proEntity != null)
            {
                if (productlink != null)
                    productlink.HRef = string.Format("{0}{1}{2}{3}{4}", BicApplication.URLRoot, "",
                                                     proEntity.MenuUserName + "/",
                                                     string.IsNullOrEmpty(proEntity.Url) ? Common.convertToUnSign3(proEntity.Title) : proEntity.Url, ".html");


                if (productlink1 != null)
                    productlink1.Link = string.Format("{0}{1}{2}{3}{4}", BicApplication.URLRoot, "",
                                                     proEntity.MenuUserName + "/",
                                                     string.IsNullOrEmpty(proEntity.Url) ? Common.convertToUnSign3(proEntity.Title) : proEntity.Url, ".html");
                if (review != null)
                {
                    BicSession.SetValue("ReviewProductId", proID.Text);
                    var profile = new ProfileCommon().GetProfile(BicMemberShip.CurrentUserName);
                    if (profile != null)
                        review.NavigateUrl = string.Format("{0}/{1}.html", Common.GetSiteUrl(),
                            string.IsNullOrEmpty(profile.FullName) ? string.Empty : Common.convertToUnSign3(profile.FullName));
                    var order = OrderMenuBiz.GetOrderMenuByID(BicConvert.ToInt32(OrderMenuId, 0));
                    if (order == null) return;
                    review.Visible = (order.ShippingStatus == "Đã giao hàng");
                }
            }

        }
    }
    protected void lbtBackList_Click(object sender, EventArgs e)
    {
        //Session["backlist"] = true;
        //Response.Redirect("/vi/edit-profile.html");
        //Response.Redirect("nhaccuatui.com");
    }
    protected void grdOrder_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        try
        {
            if (e.CommandArgument != null)
            {
                string itemId = e.CommandArgument.ToString();
                string name = e.CommandName;
                switch (name)
                {
                    case "ViewDetail":
                        Session["backlist"] = true;
                        pnOrderDetail.Visible = true;
                        Response.Redirect(string.Format("/trang-ca-nhan.html?tab=order&id={0}", itemId));
                        break;
                }
            }
        }
        catch (Exception ex)
        {

        }
    }
}