using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Utils;
using BIC.WebControls;
using Telerik.Web.UI;

public partial class Controls_Product_Basket : BaseUIControl
{
    List<ProductCart> LstProduct = new List<ProductCart>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadShoppingCart();
        }
    }

    private void LoadShoppingCart()
    {
        lblNumber.Text = string.Format(BicResource.GetValue("ShoppingCart", "CountCart"), Session["TotalQuanlity"] != null ? BicSession.ToString("TotalQuanlity") : "0");
        lvShoppingCart.DataSource = Session["cart"] != null ? ((Hashtable)Session["cart"]).Values : null;
        lvShoppingCart.DataBind();
        string[] arrTotalAndDiscount = new string[2];

        if (Session["cart"] != null)
        {
            decimal total = 0;
            decimal fullvat = 0;

            foreach (var item in ((Hashtable)Session["cart"]).Values)
            {
                var i = item as ProductCart;
                if (i != null)
                {
                    total += Convert.ToDecimal((Convert.ToDecimal(i.Price) * i.Quantity).ToString());
                    LstProduct.Add(i);
                }
            }
            //var productCarts = ((Hashtable)Session["cart"]).Values as List<ProductCart>;
            //if (productCarts != null)
            //    productCarts.AddRange(lstProduct);
            Session["ProductList"] = LstProduct;
            //foreach (var listViewDataItem in lvShoppingCart.Items)
            //{
            //    var item = (Label)listViewDataItem.FindControl("lblTotal");
            //    string[] arr = item.Text.Split('&');
            //    total += Convert.ToDecimal(arr[0]);
            //}
            arrTotalAndDiscount[0] = total.ToString();
            //Session["SubTotal"] = total;
            //lblOrderSubTotal.Text = total.ToString();
            //lblFullVat.Text = fullvat.ToString();
        }
        else
        {
            //lblOrderSubTotal.Text = "0 ";
            //lblFullVat.Text = "0 ";
        }

        //lblTongTien.Text = lblMoneyTotal.Text = Session["TotalCart"] != null ? string.Format("{0:###,###.##}",
        //BicConvert.ToDouble(Session["TotalCart"])) : "0";
        //LoadDataToPhanTram(Convert.ToDecimal(lblMoneyTotal.Text));
        //if (lblPhanTram.Text.Equals("0"))
        //{
        //    showCartTable.Visible = false;
        //}

        //if (!string.IsNullOrEmpty(lblMoneyTotal.Text) && !string.IsNullOrEmpty(lblPhanTram.Text))
        //{
        //    decimal ck;
        //    ck = Convert.ToDecimal(Convert.ToDecimal(lblMoneyTotal.Text));
        //    lblSoTienChietKhau.Text = ck.ToString("0.00");
        //    lblSoTienChietKhau.Text = Session["TotalCart"] != null
        //                                  ? Convert.ToDouble(Session["TotalCart"]).ToString("0.00")
        //                                  : "0";
        //    arrTotalAndDiscount[1] = ck.ToString();
        //    Session["SubTotalAndDiscount"] = arrTotalAndDiscount;
        //    Session["TongTienSauChietKhau"] = Convert.ToDecimal(Session["TotalCart"]) - ck;
        //}
        //else
        //{
        //    Session["TongTienSauChietKhau"] = null;
        //}


        //var a = Convert.ToDecimal(lblMoneyTotal.Text);
        //var b = Convert.ToDecimal(lblSoTienChietKhau.Text);
        //Session["SubTotal"] = arrStr;
        //lblTongTienSauChietKhau.Text =
        //    (Convert.ToDecimal(lblMoneyTotal.Text) - Convert.ToDecimal(lblSoTienChietKhau.Text)).ToString("0.00");

        var process = BicRouting.GetRequestString("id", 0);
        if (BicConvert.ToInt32(process) < 2)
        {
            lblMoneyTotal.Text = string.Format("{0:N0}", Session["TotalCart"]);
        }
        if (BicConvert.ToInt32(process) == 2)
        {
            lblNumber.Visible = false;
            Actionheader.Visible = false;
            divBtnTools.Visible = false;
            TotalPayment.Visible = false;
            headerrQuantity.Visible = false;
            //lblMoneyTotal.Text = string.Format("{0:N0}", Session["TotalCart"]);
        }
        else
        {
            if (Session["ThongTinNguoiDat"] != null)
            {
                string[] ttNguoiDat = (string[])Session["ThongTinNguoiDat"];
                lblShippingFee.Text = ttNguoiDat[13] == "0" ? "0" : BicConvert.ToDouble(ttNguoiDat[13]).ToString("##,###");
                lblUsePoint.Text = ttNguoiDat[12] == "0" ? "0" : BicConvert.ToDouble(ttNguoiDat[12]).ToString("##,###");
                var free = BicConvert.ToInt32(ttNguoiDat[14]);
                if (BicConvert.ToDouble(Session["TotalCart"]) <= BicConvert.ToDouble(free))
                {
                    if (ttNguoiDat[15] == "0")
                    {
                        lblShippingFee.Text = BicConvert.ToDouble(ttNguoiDat[13]).ToString("##,###");
                        lblMoneyTotal.Text = string.Format("{0:N0}",
                            BicConvert.ToDouble(Session["TotalCart"]) + BicConvert.ToDouble(lblShippingFee.Text) -
                            BicConvert.ToDouble(lblUsePoint.Text));
                    }
                    else
                    {
                        lblShippingFee.Text = "0";
                        lblMoneyTotal.Text = string.Format("{0:N0}",
                            BicConvert.ToDouble(Session["TotalCart"]) - BicConvert.ToDouble(lblUsePoint.Text));
                    }
                }
                else
                {
                    lblShippingFee.Text = "0";
                    lblMoneyTotal.Text = string.Format("{0:N0}",
                        BicConvert.ToDouble(Session["TotalCart"]) - BicConvert.ToDouble(lblUsePoint.Text));
                }

                UPoint.Visible = true;
                shpFee.Visible = true;
                Actionheader.Visible = false;
            }
            else
            {
                lblShippingFee.Text = "0";
                lblUsePoint.Text = "0";
            }
            //Session["TotalCart"] = string.Format("{0}",
            //    BicConvert.ToDouble(Session["TotalCart"]) + BicConvert.ToDouble(lblShippingFee.Text) - BicConvert.ToDouble(lblUsePoint.Text));
        }
    }
    protected double GetSoluongByProduct(object productID)
    {
        double sl = 11;
        var productEntity = ProductBiz.GetProductByID(BicConvert.ToInt32(productID));
        if (productEntity != null)
        {
            sl = Convert.ToDouble(productEntity.NewColumn5);
        }
        return sl;
    }

    protected void ShoppingCart_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        var txtSoluong = (RadNumericTextBox)e.Item.FindControl("txtSoluong");
        var proID = (Label)e.Item.FindControl("lblID");
        var productlink = (HtmlAnchor)e.Item.FindControl("productLink");
        var productlink1 = (ImageViewer)e.Item.FindControl("ivArticle");
        var action = (HtmlTableCell)e.Item.FindControl("Action");
        var quantity = (HtmlTableCell)e.Item.FindControl("bodyQuantity");
        var process = BicRouting.GetRequestString("id", 0);
        if (BicConvert.ToInt32(process) > 1)
            action.Visible = false;
        if (BicConvert.ToInt32(process) == 2)
            quantity.Visible = false;
        if (!string.IsNullOrEmpty(proID.Text))
        {
            if (txtSoluong != null)
            {
                //txtSoluong.MinValue = 12;
                var proEntity = ProductBiz.GetProductByID(BicConvert.ToInt32(proID.Text));

                if (proEntity != null)
                {
                    txtSoluong.MinValue = 1;
                    txtSoluong.IncrementSettings.Step = 1;

                    if (productlink != null)
                        productlink.HRef = string.Format("{0}{1}{2}{3}{4}", BicApplication.URLRoot, BicLanguage.CurrentLanguage + "/",
                                                     proEntity.MenuUserName + ".pd" + "/",
                                                     string.IsNullOrEmpty(proEntity.Url) ? Common.convertToUnSign3(proEntity.Title) : proEntity.Url, ".html");
                    if (productlink1 != null)
                        productlink1.Link = string.Format("{0}{1}{2}{3}{4}", BicApplication.URLRoot, BicLanguage.CurrentLanguage + "/",
                                                     proEntity.MenuUserName + ".pd" + "/",
                                                     string.IsNullOrEmpty(proEntity.Url) ? Common.convertToUnSign3(proEntity.Title) : proEntity.Url, ".html");
                }
            }
        }
    }


    protected void lvShoppingCart_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Delete"))
        {
            var cart = new Cart();
            cart.Remove(BicConvert.ToInt32(e.CommandArgument));
            if (cart.Hashtable.Count == 0)
            {
                cart.Clear();
            }
            LoadShoppingCart();
        }
    }

    protected void lvShoppingCart_ItemDeleting(object sender, ListViewDeleteEventArgs e)
    {
        LoadShoppingCart();
    }

    protected void btnBuy_click(object sender, EventArgs e)
    {
        if (Session["cart"] != null)
            Response.Redirect(string.Format("{0}{1}/shopping-cart.sc{2}.html", BicApplication.URLRoot, BicLanguage.CurrentLanguage, "2"));
        else
            Response.Redirect(BicApplication.URLRoot);
    }

    protected void btlContinute_click(object sender, EventArgs e)
    {
        Response.Redirect(BicApplication.URLRoot);
    }

    protected void OnNumber1Changed(object sender, EventArgs e)
    {
        foreach (var item in lvShoppingCart.Items)
        {
            var cart = new Cart();
            var bookcart = new ProductCart();
            var txtQuantity = (RadNumericTextBox)item.FindControl("txtSoluong");

            var lblId = (Label)item.FindControl("lblID");
            if (txtQuantity != null)
                if (Convert.ToInt32(txtQuantity.Text) <= 0)
                {
                    BicAjax.Alert(BicResource.GetValue("ShoppingCart", "NotCart"));
                }
                else
                {
                    if (lblId != null) bookcart.proID = BicConvert.ToInt32(lblId.Text);
                    bookcart.Quantity = BicConvert.ToInt32(txtQuantity.Text);
                    cart.Update(bookcart);
                }
        }
        LoadShoppingCart();
        //if (!lblPhanTram.Text.Equals("0"))
        //{
        //    showCartTable.Visible = true;
        //}

    }

    public double SumPoints()
    {
        double sum = 0;
        string savePoint = string.Empty;
        foreach (var item in lvShoppingCart.Items)
        {
            var lblSavePoint = item.FindControl("lblSavePoint") as Label;
            if (lblSavePoint != null)
            {
                savePoint = lblSavePoint.Text.Trim().Replace(",", string.Empty);
            }
            sum += BicConvert.ToDouble(savePoint);
        }
        return sum;
    }

}