using System;
using System.Collections;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Utils;
using BIC.WebControls;
using Telerik.Web.UI;

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
        lblTotalSaft.Text = lblTotalMoney.Text = Session["TotalCart"] != null ? BicString.ToStringNO(BicSession.ToString("TotalCart")) : "0";
        lvShoppingCart.DataSource = Session["cart"] != null ? ((Hashtable)Session["cart"]).Values : null;
        lvShoppingCart.DataBind();
    }
    protected void ShoppingCart_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        var txtSoluong = (RadNumericTextBox)e.Item.FindControl("txtSoluong");
        var proID = (Label)e.Item.FindControl("lblID");
        var productlink = (HtmlAnchor)e.Item.FindControl("productLink");
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
              
                var proEntity = ProductBiz.GetProductByID(BicConvert.ToInt32(proID.Text));

                if (proEntity != null)
                {
                    txtSoluong.MinValue = 1;
                    txtSoluong.IncrementSettings.Step = 1;

                    if (productlink != null)
                        productlink.HRef = string.Format("{0}{1}{2}{3}{4}", BicApplication.URLRoot,BicLanguage.CurrentLanguage + "/",
                                proEntity.MenuUserName + "/",
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
    }

    protected void btnThanhToan_OnClick(object sender, EventArgs e)
    {
        if (Session["cart"] != null)
        {
            Response.Redirect("~/" + BicLanguage.CurrentLanguage + "/shopping-cart.sc2.html");
        }
        else
        {
            BicAjax.Alert("Không có sản phẩm nào trong giỏ hàng");
        }
    }
}