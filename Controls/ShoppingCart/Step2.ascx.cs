using System;
using System.Collections;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Utils;
using BIC.WebControls;
using System.Text.RegularExpressions;

public partial class Controls_Article_ThongtinDathang : BaseUIControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadShoppingCart();
        }
    }

    private void LoadShoppingCart()
    {
        lblNumberProduct.Text = Session["TotalQuanlity"] != null ? BicSession.ToString("TotalQuanlity") : "0";
        lblTotalSaft.Text =
            lblTotalMoney.Text =
                Session["TotalCart"] != null ? BicString.ToStringNO(BicSession.ToString("TotalCart")) : "0";
        lvShoppingCart.DataSource = Session["cart"] != null ? ((Hashtable)Session["cart"]).Values : null;
        lvShoppingCart.DataBind();
        if (lvShoppingCart.Items.Count == 0)
            Response.Redirect(Common.GetLinkShort("/" + BicLanguage.CurrentLanguage + "/shopping-cart.sc1.html"));
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
                    productlink.HRef =
                        Common.GetLinkShort(string.Format("{0}{1}{2}{3}{4}", BicApplication.URLRoot,
                            BicLanguage.CurrentLanguage + "/",
                            proEntity.MenuUserName + "/",
                            string.IsNullOrEmpty(proEntity.Url)
                                ? Common.convertToUnSign3(proEntity.Title)
                                : proEntity.Url, ".html"));
            }
        }
    }


    protected void btnThanhToan_OnClick(object sender, EventArgs e)
    {
        if (Session["cart"] == null)
        {
            Response.Redirect(Common.GetLinkShort("/" + BicLanguage.CurrentLanguage + "/shopping-cart.sc1.html"));
        }
        else
        {
            ShoppingCartInformation shoppingCartInformation = new ShoppingCartInformation();
            bool chkKhongDangKi = rbtKhongDangKi.Checked;
            bool chkTaiKhoan = rbtTaiKhoan.Checked;
            string email = txtEmail.Value;
            string password = txtMatKhau.Value;
            //bool isEmail = Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);

            if (chkKhongDangKi && Common.IsEmail(email))
                BicAjax.Alert("Vui lòng nhập đúng địa chỉ email");

            if (chkTaiKhoan && (string.IsNullOrEmpty(txtAccount.Value) || string.IsNullOrEmpty(password)))
                BicAjax.Alert("Bạn chưa nhập đủ thông tin đăng nhập");

            //không đăng ký
            if (chkKhongDangKi && !string.IsNullOrEmpty(email) && Common.IsEmail(email))
            {
                UserInformation cartInformation = new UserInformation();
                //khong dang ki tai khoan
                cartInformation.Email = email;
                //Luu lai vao trong Session["cartInformation"]
                shoppingCartInformation.NguoiDat = cartInformation;
                BicSession.SetValue("shoppingCartInformation", shoppingCartInformation);
                Response.Redirect(Common.GetLinkShort("/" + BicLanguage.CurrentLanguage + "/shopping-cart.sc3.html"));
            }

            //Đăng nhập tài khoản
            if (chkTaiKhoan && !string.IsNullOrEmpty(txtAccount.Value) && !string.IsNullOrEmpty(password))
            {
                string userName = txtAccount.Value;
                if (Common.IsEmail(txtAccount.Value))
                    userName = Membership.GetUserNameByEmail(txtAccount.Value);
                if (!string.IsNullOrEmpty(userName))
                {
                    if (Membership.ValidateUser(userName, password)) // Veryfight login
                    {
                        var user = Membership.GetUser(BicMemberShip.CurrentUserName);
                        UserInformation cartInformation = new UserInformation();
                        //Lay ra Profile tai khoan
                        ProfileCommon profile = Profile.GetProfile(userName);
                        //Da co tai khoan
                        cartInformation.Email = user.Email;
                        cartInformation.PassWord = password;
                        cartInformation.FullName = profile.FullName;
                        cartInformation.Address = profile.Address;
                        cartInformation.UserName = userName;
                        cartInformation.Phone = profile.Phone;
                        cartInformation.City = profile.City;
                        cartInformation.District = profile.District;
                        cartInformation.Company = profile.Company;
                        cartInformation.GioiTinh = profile.GioiTinh;
                        //Luu lai vao trong Session["cartInformation"]
                        shoppingCartInformation.NguoiDat = cartInformation;
                        BicSession.SetValue("shoppingCartInformation", shoppingCartInformation);
                        Response.Redirect(Common.GetLinkShort("/" + BicLanguage.CurrentLanguage + "/shopping-cart.sc3.html"));
                    }
                    else
                    {
                        BicAjax.Alert("Tài khoản hoặc mật khẩu không chính xác");
                    }
                }
                else
                {
                    BicAjax.Alert("Thông tin bạn nhập không đúng");
                }
            }

        }
    }
}