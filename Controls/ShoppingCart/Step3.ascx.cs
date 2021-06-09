using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Data;
using BIC.Entity;
using BIC.Handler;
using BIC.Utils;
using BIC.WebControls;

public partial class Controls_Article_ThongtinDathang : BaseUIControl
{
    public ShoppingCartInformation ShoppingCartInformation { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        ShoppingCartInformation = (ShoppingCartInformation)Session["shoppingCartInformation"];
        if (!IsPostBack)
        {
            LoadShoppingCart();
            BindDropDownCity();
            BindDropDownCity1();
            BindingShippingMethod();
            BindingPayMethod();
            LoadFrreShip();
        }
    }

    private void BindingShippingMethod()
    {
        var bicData = new BicGetData("Category");
        bicData.Selecting.Add(
            "Name, Value, TypeOfCategory,IsActive,Priority,CategoryID");
        var con = new ConditioningItem
        {
            TypeOfCondition = TypeOfCondition.QUERY,
            Query = string.Format("TypeOfCategory=1 and IsActive=1")
        };

        bicData.Conditioning.Add(con);
        bicData.Sorting.Add(new SortingItem("Priority", false));
        var data = bicData.GetAllData();
        ddlShippingMethod.DataSource = data;
        ddlShippingMethod.DataValueField = "CategoryID";
        ddlShippingMethod.DataTextField = "Name";
        ddlShippingMethod.DataBind();
        ddlShippingMethod.Items.Insert(0, new ListItem("-- Chọn cách vận chuyển --", "0"));
    }

    private void BindingPayMethod()
    {
        var bicData = new BicGetData("Category");
        bicData.Selecting.Add(
            "Name, Value, TypeOfCategory,IsActive,Priority,CategoryID, Note");
        var con1 = new ConditioningItem
        {
            TypeOfCondition = TypeOfCondition.QUERY,
            Query = string.Format("TypeOfCategory=2 and IsActive=1")
        };
        bicData.Conditioning.Add(con1);
        var data1 = bicData.GetAllData();
        ddlPayMethod.DataSource = data1;
        ddlPayMethod.DataValueField = "CategoryID";
        ddlPayMethod.DataTextField = "Name";
        ddlPayMethod.DataBind();
        ddlPayMethod.Items.Insert(0, new ListItem("-- Chọn cách thanh toán --", "0"));

        lvThanhToanInfo.DataSource = data1;
        lvThanhToanInfo.DataBind();
    }

    private void LoadShoppingCart()
    {
        lblNumberProduct.Text = Session["TotalQuanlity"] != null ? BicSession.ToString("TotalQuanlity") : "0";
        lblTotalSaft.Text =
                Session["TotalCart"] != null ? BicString.ToStringNO(BicSession.ToString("TotalCart")) : "0";
        lvShoppingCart.DataSource = Session["cart"] != null ? ((Hashtable)Session["cart"]).Values : null;
        lvShoppingCart.DataBind();
        if (lvShoppingCart.Items.Count == 0)
            Response.Redirect("~/" + BicLanguage.CurrentLanguage + "/shopping-cart.sc1.html");
    }

    protected void ShoppingCart_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        var proID = (Label)e.Item.FindControl("lblID");
        var productlink = (HtmlAnchor)e.Item.FindControl("productLink");


        if (!string.IsNullOrEmpty(proID.Text))
        {

            var proEntity = ProductBiz.GetProductByID(BicConvert.ToInt32(proID.Text));

            if (proEntity != null)
            {

                if (productlink != null)
                    productlink.HRef = string.Format("{0}{1}{2}{3}{4}", BicApplication.URLRoot,
                            BicLanguage.CurrentLanguage + "/",
                            proEntity.MenuUserName + "/",
                            string.IsNullOrEmpty(proEntity.Url)
                                ? Common.convertToUnSign3(proEntity.Title)
                                : proEntity.Url, ".html");
            }
        }
    }

    protected void BindDropDownCity()
    {
        // Bind Dropdown city
        ddlCity1.Items.Clear();
        var lstCity = CityBiz.GetAllCitys();
        if (!lstCity.Any()) return;
        ddlCity1.DataSource = lstCity;
        ddlCity1.DataTextField = "CityName";
        ddlCity1.DataValueField = "CityID";
        ddlCity1.DataBind();
        ddlCity1.Items.Insert(0, new ListItem("-- Chọn Tỉnh/Thành phố --", "0"));
    }

    protected void BindDropDownDistrict()
    {
        // Bind Dropdown district
        ddlDistrict1.Items.Clear();
        if (ddlCity1.SelectedValue == "0")
            ddlDistrict1.Items.Insert(0, new ListItem("-- Chọn Quận/Huyện --", "0"));
        else
        {
            var lstDist = DistrictBiz.GetDistrictByCityID(BicConvert.ToInt32(ddlCity1.SelectedValue));
            if (lstDist.Any())
            {
                ddlDistrict1.DataSource = lstDist;
                ddlDistrict1.DataTextField = "DistrictName";
                ddlDistrict1.DataValueField = "DistrictID";
                ddlDistrict1.DataBind();
                ddlDistrict1.Items.Insert(0, new ListItem("-- Chọn Quận/Huyện --", "0"));
            }
            else
            {
                ddlDistrict1.Items.Clear();
                ddlDistrict1.Items.Insert(0, new ListItem("-- Chọn Quận/Huyện --", "0"));
            }
        }
    }

    protected void BindDropDownCity1()
    {
        // Bind Dropdown city
        ddlCity2.Items.Clear();
        var lstCity = CityBiz.GetAllCitys();
        if (!lstCity.Any()) return;
        ddlCity2.DataSource = lstCity;
        ddlCity2.DataTextField = "CityName";
        ddlCity2.DataValueField = "CityID";
        ddlCity2.DataBind();
        ddlCity2.Items.Insert(0, new ListItem("-- Chọn Tỉnh/Thành phố --", "0"));
    }

    protected void BindDropDownDistrict1()
    {
        // Bind Dropdown district
        ddlDistrict2.Items.Clear();
        if (ddlCity2.SelectedValue == "0")
            ddlDistrict2.Items.Insert(0, new ListItem("-- Chọn Quận/Huyện --", "0"));
        else
        {
            var lstDist = DistrictBiz.GetDistrictByCityID(BicConvert.ToInt32(ddlCity2.SelectedValue));
            if (lstDist.Any())
            {
                ddlDistrict2.DataSource = lstDist;
                ddlDistrict2.DataTextField = "DistrictName";
                ddlDistrict2.DataValueField = "DistrictID";
                ddlDistrict2.DataBind();
                ddlDistrict2.Items.Insert(0, new ListItem("-- Chọn Quận/Huyện --", "0"));
            }
            else
            {
                ddlDistrict2.Items.Clear();
                ddlDistrict2.Items.Insert(0, new ListItem("-- Chọn Quận/Huyện --", "0"));
            }
        }
    }

    protected void ddlCity2_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        BindDropDownDistrict1();
    }

    protected void lbtNext_OnClick(object sender, EventArgs e)
    {
        if (Session["cart"] == null)
        {
            Response.Redirect(Common.GetLinkShort("/" + BicLanguage.CurrentLanguage + "/shopping-cart.sc1.html"));
        }
        else
        {
            if (ShoppingCartInformation == null)
            {
                Response.Redirect(Common.GetLinkShort("/" + BicLanguage.CurrentLanguage + "/shopping-cart.sc2.html"));
            }
            else
            {
                UserInformation nguoiDat = ShoppingCartInformation.NguoiDat;
                UserInformation nguoiNhan = ShoppingCartInformation.NguoiNhan == null
                    ? new UserInformation()
                    : ShoppingCartInformation.NguoiNhan;
                UserInformation thanhToan = ShoppingCartInformation.ThanhToan == null
                    ? new UserInformation()
                    : ShoppingCartInformation.ThanhToan;
                if (nguoiDat != null)
                {
                    nguoiNhan.FullName = txtFullName1.Value;
                    nguoiNhan.Address = txtAddress1.Value;
                    nguoiNhan.Phone = txtPhone1.Value;
                    nguoiNhan.City = ddlCity1.SelectedValue;
                    nguoiNhan.District = ddlDistrict1.SelectedValue;
                    nguoiNhan.Note = txtNode1.Value;
                    //Thong tin nguoi nhan                  
                    thanhToan.PassWord = "";
                    thanhToan.FullName = txtFullName2.Value;
                    thanhToan.Address = txtAddress2.Value;
                    thanhToan.UserName = "";
                    thanhToan.Phone = txtPhone2.Value;
                    thanhToan.City = ddlCity2.SelectedValue;
                    thanhToan.District = ddlDistrict2.SelectedValue;
                    thanhToan.Company = "";
                    thanhToan.GioiTinh = "";
                    thanhToan.Note = txtNote2.Value;
                    //Luu phuong thuc tra tien
                    ShoppingCartInformation.PayMethod = ddlPayMethod.SelectedValue;
                    ShoppingCartInformation.ShippingMethod = ddlShippingMethod.SelectedValue;
                    ShoppingCartInformation.NguoiDat = nguoiDat;
                    ShoppingCartInformation.NguoiNhan = nguoiNhan;
                    ShoppingCartInformation.ThanhToan = thanhToan;
                    BicSession.SetValue("shoppingCartInformation", ShoppingCartInformation);
                    //Gui email va sang buoc 4 thanh cong
                    SendEmail();
                }
                else
                {
                    Response.Redirect(Common.GetLinkShort("/" + BicLanguage.CurrentLanguage + "/shopping-cart.sc2.html"));
                }
            }
        }
    }

    private void SendEmail()
    {
        var cart = new Cart();
        if (Session["cart"] == null || ((Hashtable)Session["cart"]).Count <= 0) return;

        UserInformation nguoiDat = ShoppingCartInformation.NguoiDat;
        UserInformation nguoiNhan = ShoppingCartInformation.NguoiNhan;
        UserInformation thanhToan = ShoppingCartInformation.ThanhToan;
        if (ShoppingCartInformation != null)
        {
            string content =
                BicHtml.GetContents("~/Controls/ShoppingCart/ProductContact_" + BicLanguage.CurrentLanguage + ".htm");
            content = content.Replace("[DateTime]", DateTime.Now.ToString("dd/MM/yyyy"));
            content = content.Replace("[Domain]", BicXML.ToString("Domain", "MailConfig"));
            //Dia chi nhan hang
            if (nguoiNhan != null)
            {
                content = content.Replace("[Sender]", nguoiNhan.FullName);
                content = content.Replace("[Tel]", nguoiNhan.Phone);
                content = content.Replace("[Content]", nguoiNhan.Note);
                content = content.Replace("[Address]", nguoiNhan.Address + ", Quận/Huyện: " + Common.GetDistrictName(nguoiNhan.District) + ", Tỉnh: " + Common.GetCityName(nguoiNhan.City));
            }
            //Thông tin thanh toan
            if (thanhToan != null)
            {
                if (!string.IsNullOrEmpty(thanhToan.Phone) && !string.IsNullOrEmpty(thanhToan.FullName))//Neu so dien thoai khong co => Khong chon vao checkbox
                {
                    string contentThanhToan =
                     BicHtml.GetContents("~/Controls/ShoppingCart/DiaChiThanhToan_" + BicLanguage.CurrentLanguage +
                                      ".htm");
                    contentThanhToan = contentThanhToan.Replace("[Sender2]", thanhToan.FullName);
                    contentThanhToan = contentThanhToan.Replace("[Tel2]", thanhToan.Phone);
                    contentThanhToan = contentThanhToan.Replace("[Content2]", thanhToan.Note);
                    contentThanhToan = contentThanhToan.Replace("[Address2]", thanhToan.Address + ", Quận/Huyện: " + Common.GetDistrictName(thanhToan.District) + ", Tỉnh: " + Common.GetCityName(thanhToan.City));
                    content = content.Replace("[DiaChiThanhToan]", contentThanhToan);
                }
                else
                {
                    content = content.Replace("[DiaChiThanhToan]", string.Empty);
                }
            }
            else
            {
                content = content.Replace("[DiaChiThanhToan]", string.Empty);
            }

            content = content.Replace("[SaleMail]", BicXML.ToString("WebMasterEmail", "MailConfig"));
            content = content.Replace("[PaymentMethod]", Common.GetNameByCategoryId(ShoppingCartInformation.PayMethod));
            content = content.Replace("[ShippingMethod]",
                Common.GetNameByCategoryId(ShoppingCartInformation.ShippingMethod));

            //Them phan bang danh sach san pham duoc dat
            string sRow = string.Empty;
            IEnumerator ie = ((Hashtable)Session["cart"]).Values.GetEnumerator();
            double totalVat = 0;
            double totalFullVat = 0;
            double total = 0;
            int itemcount = 0;
            while (ie.MoveNext())
            {
                var b = (ProductCart)ie.Current;
                itemcount += b.Quantity;
                var imageEntity = ImageBiz.GetImageByID(b.ImageId);
                string imagName = Request.Url.AbsoluteUri.Replace(Request.Url.AbsolutePath, "") +
                                  Request.ApplicationPath + "/FileUpload/Images/thumb/" +
                                  imageEntity.Name;
                var proEntity = ProductBiz.GetProductByID(b.proID);
                string linkUrl = "javascript:void(0)";
                if (proEntity != null)
                    linkUrl = string.Format("{0}{1}{2}{3}{4}",
                        Request.Url.AbsoluteUri.Replace(Request.Url.AbsolutePath, "") + Request.ApplicationPath,
                        BicLanguage.CurrentLanguage + "/",
                        proEntity.MenuUserName + "/",
                        string.IsNullOrEmpty(proEntity.Url)
                            ? BicEncoding.ConvertUnicodeToNoSignAndTag(proEntity.Title, "")
                            : proEntity.Url, ".html");
                totalVat += Convert.ToDouble(Convert.ToDouble(b.ProductVat));
                totalFullVat += Convert.ToDouble(Convert.ToDouble(b.ProductVat)) +
                                Convert.ToDouble(Convert.ToDouble(b.Total));
                total += Convert.ToDouble(Convert.ToDouble(b.Quantity * Convert.ToDouble(b.Price)));
                sRow += string.Format(
                    "<tr>" +
                    "<td style=\"border: 1px solid #E2E2E2; line-height: 20px; padding: 8px;\">{0}</td>" +
                    "<td style=\"border: 1px solid #E2E2E2; line-height: 20px; padding: 8px;\">{5}</td>" +
                    "<td style=\"border: 1px solid #E2E2E2; line-height: 0px; padding: 1px; text-align: center;\">  " +
                    "<a href=" + linkUrl + "><img alt='avatar' src='{4}' width='38'/></a></td> " +
                    "<td style=\"text-align: center; color: #f15a22; border: 1px solid #E2E2E2; line-height: 20px; padding: 8px;\">{1}</td>" +
                    "<td style=\"border: 1px solid #E2E2E2; text-align: center; color: #f15a22;\">{2}</td>" +
                    "<td style=\"text-align: center; color: #f15a22;  border: 1px solid #E2E2E2; line-height: 20px; padding: 8px;\">{3}</td>" +
                    "</tr>",
                    "<a href=" + linkUrl + " style='text-decoration:none;'>" + b.proName + "</a>",
                    BicString.ToStringNO(b.Price),
                    b.Quantity,
                    BicString.ToStringNO(Convert.ToDouble(b.Quantity * Convert.ToDouble(b.Price)).ToString()),
                    imagName,
                    b.Code
                );
            }
            content = content.Replace("[Cart]", sRow);
            content = content.Replace("[Total]", string.Format("{0:N0}", total));
            content = content.Replace("[ShippingFee]", lblPhiVanChuyen.Text.ToString());
            content = content.Replace("[TongTien]", lblTotalMoney.Text.ToString());
            try
            {
                if (BicEmail.SendToWebMaster(
                    BicResource.GetValue("ShoppingCart", "SubjectMaster") +
                    String.Format("{0: hh:mm tt - dd/MM/yyyy}", DateTime.Now), content, nguoiDat.Email,
                    nguoiDat.FullName))
                    if (BicEmail.SendToCustomer(nguoiDat.Email,
                        BicResource.GetValue("ShoppingCart", "Subject") + BicXML.ToString("Domain", "MailConfig") +
                        " - " +
                        String.Format("{0: hh:mm tt - dd/MM/yyyy}", DateTime.Now), content))
                    {
                        SaveToOrder();
                        cart.Clear();
                        Session["shoppingCartInformation"] = null;
                        Response.Redirect(
                            Common.GetLinkShort("/" + BicLanguage.CurrentLanguage + "/shopping-cart.sc4.html"));
                    }
            }
            catch (Exception ex)
            {
                LogEvent.LogToFile("Step3 đặt hàng gửi Email -\n " + ex.StackTrace.ToString());
                //BicAjax.Alert("Đặt hàng không thành công!");
            }

        }
    }

    private void SaveToOrder()
    {
        var cart = new Cart();
        if (Session["cart"] == null || ((Hashtable)Session["cart"]).Count <= 0) return;
        IEnumerator ie = ((Hashtable)Session["cart"]).Values.GetEnumerator();

        UserInformation nguoiDat = ShoppingCartInformation.NguoiDat;
        UserInformation nguoiNhan = ShoppingCartInformation.NguoiNhan;
        UserInformation thanhToan = ShoppingCartInformation.ThanhToan;

        var item = new OrderMenuEntity();
        string month = DateTime.Now.Month.ToString();
        string day = DateTime.Now.Day.ToString();
        var ordercode = string.Empty;

        var dh = new DataHelper();
        var dt = dh.ExecuteSQL("select max(OrderMenuID) from OrderMenu");
        int orderMenuIDNew = 0;
        if (dt.Rows.Count > 0)
            orderMenuIDNew = BicConvert.ToInt32(dt.Rows[0][0]) + 1;
        item.OrderCode = ordercode = DateTime.Now.ToString("yyyyMMdd") + string.Format("{0:D4}", orderMenuIDNew);
        item.OrderStatus = "Mới tiếp nhận";
        var user = Membership.GetUser(BicMemberShip.CurrentUserName);
        if (user != null)
        {
            if (user.ProviderUserKey != null) item.Customer = user.ProviderUserKey.ToString();
        }
        item.OrderTax = 23;

        if (Session["TotalCart"] != null)
        {
            string tt = Session["TotalCart"].ToString();
            item.OrderSubTotal = Convert.ToDouble(tt);
        }
        item.CustomerIp = BicMemberShip.CurrentUserIP;
        item.PaymentMethod = ShoppingCartInformation.PayMethod;
        item.PaymentStatus = "Chưa thanh toán";
        item.ShippingMethod = ShoppingCartInformation.ShippingMethod;
        item.ShippingStatus = "Chưa giao hàng";
        item.BillingFullName = nguoiNhan.FullName;
        item.BillingPhone = nguoiNhan.Phone;
        item.BillingShippingAddress = nguoiNhan.Address;
        item.BillingCity = nguoiNhan.City;
        item.BillingEmail = nguoiDat.Email;
        item.BillingCompany = nguoiNhan.Company;
        item.OrderShippingFee = BicConvert.ToDouble(lblPhiVanChuyen.Text.Replace(",", ""));
        item.OrderNote = nguoiNhan.Note;
        item.SavePoint = 0;
        item.UsePoint = 0;
        item.OrderSubTotal = BicConvert.ToDouble(lblPhiVanChuyen.Text.Replace(",", "")) + BicConvert.ToDouble(lblTotalMoney.Text.Replace(",", "")); ;
        // Kiểu chuyển phát
        item.Column3 = "";
        // Quận huyện
        item.BillingState = "";

        if (string.IsNullOrEmpty(thanhToan.FullName))
        {
            thanhToan = nguoiNhan;
            item.ShippingFullName = thanhToan.FullName;
            item.ShippingEmail = nguoiDat.Email;
            item.ShippingPhone = thanhToan.Phone;
            item.ShippingAddress = thanhToan.Address;
            item.ShippingCity = thanhToan.City;
            item.ShippingCompany = thanhToan.Company;
            item.ShippingDate = DateTime.Now;
            //Quận Huyện
            item.ShippingState = thanhToan.District;
        }

        item.ShippingDeliveredDate = DateTime.Now;

        OrderMenuBiz.InsertOrderMenu(item);
        while (ie.MoveNext())
        {
            var productCart = (ProductCart)ie.Current;
            {
                var orDetail = new OrderDetailEntity
                {
                    OrderMenuID = item.OrderMenuID,
                    Tax = 23,
                    ProductCode = productCart.Code,
                    ProductName = productCart.proName,
                    ProductID = productCart.proID,
                    SubTotal = Convert.ToDouble(productCart.Quantity) * Convert.ToDouble(productCart.Price),
                    ProductPrice = Convert.ToDouble(productCart.Price),
                    Total = productCart.Quantity
                };
                OrderDetailBiz.InsertOrderDetail(orDetail);
            }
        }
    }
    protected void ddlShippingMethod_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        LoadFrreShip();
    }

    private void LoadFrreShip()
    {
        string shippingfee = "0";
        var shippingType = tblShippingType.SelectedValue;
        if (ddlDistrict1.SelectedValue != "0" && ddlCity1.SelectedValue != "0" && ddlShippingMethod.SelectedIndex > 0)
        {
            if (ddlCity1.SelectedIndex > 0)
            {
                var free = CityBiz.GetCityByID(BicConvert.ToInt32(ddlCity1.SelectedValue));
                if (free != null)
                {
                    if (shippingType == "0")
                    {
                        shippingfee = free.ChuyenNhanh;
                    }
                    else
                    {
                        shippingfee = free.ChuyenCham;
                    }
                }
            }
            if (ddlDistrict1.SelectedIndex > 0)
            {
                var free = DistrictBiz.GetDistrictByID(BicConvert.ToInt32(ddlDistrict1.SelectedValue));
                if (free != null)
                {
                    if (shippingType == "0")
                    {
                        shippingfee = free.ChuyenNhanh;
                    }
                    else
                    {
                        shippingfee = free.ChuyenCham;
                    }
                }
            }

            if (ddlShippingMethod.SelectedValue.Equals("1"))
            {
                shippingfee = "0";
            }
        }
        string phiTam = Session["TotalCart"] != null ? BicString.ToStringNO(BicSession.ToString("TotalCart")) : "0";
        lblPhiVanChuyen.Text = Common.ToStringNO(shippingfee);
        lblTotalMoney.Text =
            Common.ToStringNO((BicConvert.ToDouble(shippingfee) + BicConvert.ToDouble(phiTam)).ToString());
    }

    protected void tblShippingType_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        LoadFrreShip();
    }

    protected void ddlDistrict1_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        LoadFrreShip();
    }

    protected void ddlCity1_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        BindDropDownDistrict();
        LoadFrreShip();
    }
}