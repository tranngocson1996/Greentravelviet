using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using BIC.Biz;
using BIC.Data;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;
using Telerik.Web.UI;

public partial class Admin_Components_OrderMenu_ViewOrderMenu : BaseUserControl
{

    public int Id;

    protected void Page_Load(object sender, EventArgs e)
    {
        Id = BicHtml.GetRequestString("id", 0);
        if (IsPostBack) return;
        BindDataToOrderDetail();
        LoadDataFromEntity();
        Session["StatusOrder"] = 0;
    }

    private void LoadDataFromEntity()
    {
        var ordermenuEntity = OrderMenuBiz.GetOrderMenuByID(Id);
        if (ordermenuEntity == null) return;
        lblDBOrderCode.Text = BicConvert.ToString(ordermenuEntity.OrderCode);
        lblDBOrderStatus.Text = BicConvert.ToString(ordermenuEntity.OrderStatus);
        lblDBPaymentStatus.Text = BicConvert.ToString(ordermenuEntity.PaymentStatus);
        ddlPaymentStatus.Items.FindByValue(ordermenuEntity.PaymentStatus).Selected = true;
        lblDBShippingDate.Text = BicConvert.ToString(ordermenuEntity.ShippingDate.ToString("dd/MM/yyyy"));
        //lblShippingStatus.Text = BicConvert.ToString(ordermenuEntity.ShippingStatus);
        lblDBCustomer.Text = BicConvert.ToString(ordermenuEntity.Customer);
        lblUserID.Text = ordermenuEntity.Customer;
        lblBillingEmail.Text = ordermenuEntity.BillingEmail;
        lblBillingAddress.Text = ordermenuEntity.BillingShippingAddress;
        //lblBillingCity.Text = ordermenuEntity.BillingCity;
        lblBillingName.Text = ordermenuEntity.BillingFullName;
        lblBillingPhone.Text = ordermenuEntity.BillingPhone;
        lblInvoiceAddress.Text = ordermenuEntity.InvoiceAddress;
        lblBillingCompany.Text = ordermenuEntity.BillingShippingAddress ;
        lblNip.Text = ordermenuEntity.InvoiceTaxCode;
        lblNip2.Text = ordermenuEntity.Column2;
        lblSavePoint.Text = (ordermenuEntity.SavePoint.ToString() == "0") ? "0" : ordermenuEntity.SavePoint.ToString("##,###");
        lblUsePoint.Text = (ordermenuEntity.UsePoint.ToString() == "0") ? "0" : ordermenuEntity.UsePoint.ToString("##,###");

        var tientruocthue = ordermenuEntity.OrderSubTotal.ToString("0.00");
        lblDBOrderSubTotal.Text = tientruocthue;       
        var ordertotal = Convert.ToDouble(ordermenuEntity.OrderSubTotal.ToString("0.00"));       
        var soluongsp = 0;
        foreach (GridViewRow row in grvView.Rows)
        {
            var txt = (RadNumericTextBox)row.FindControl("txtSoluong");
            if (txt != null)
                soluongsp += BicConvert.ToInt32(txt.Text);
        }
        var phantram = LoadDataToPhanTram(ordertotal, soluongsp);
        var giamgia = Convert.ToDouble((ordertotal * Convert.ToDouble(phantram) / 100).ToString("0.00"));
        lblDBOrderDiscount.Text = giamgia.ToString();
        //+ " " + BicResource.GetValue("Admin", "Product_LoaiTien");
        lblDBOrderShippingFee.Text = BicConvert.ToString(ordermenuEntity.OrderShippingFee);
        //+ " " + BicResource.GetValue("Admin", "Product_LoaiTien");
        lblDBPaymentMethod.Text = BicConvert.ToString(ordermenuEntity.PaymentMethod);
        //lblDBPaymentStatus.Text = BicConvert.ToString(ordermenuEntity.PaymentStatus);
        lblDBShippingMethod.Text = BicConvert.ToString(ordermenuEntity.ShippingMethod);
        lblDBShippingStatus.Text = BicConvert.ToString(ordermenuEntity.ShippingStatus);
        ddlShippingStatus.Items.FindByValue(ordermenuEntity.ShippingStatus).Selected = true;
        lblDBShippingFullName.Text = BicConvert.ToString(ordermenuEntity.ShippingFullName);
        lblDBShippingEmail.Text = BicConvert.ToString(ordermenuEntity.ShippingEmail);
        lblDBShippingPhone.Text = BicConvert.ToString(ordermenuEntity.ShippingPhone);
        lblShippingCompany.Text = BicConvert.ToString(ordermenuEntity.ShippingAddress) ;       
        lblDBShippingAddress.Text = BicConvert.ToString(ordermenuEntity.ShippingAddress);
        lblDBShippingDeliveredDate.Text = BicConvert.ToString(ordermenuEntity.ShippingDeliveredDate);
        lblDBShippingCity.Text = BicConvert.ToString(ordermenuEntity.ShippingCity);
        if (string.IsNullOrEmpty(ordermenuEntity.OrderNote))
            Note1.Visible = false;
        if (string.IsNullOrEmpty(ordermenuEntity.Column1))
            Note2.Visible = false;
        lblNoteBilling.Text = ordermenuEntity.OrderNote;
        lblNoteShipping.Text = ordermenuEntity.Column1;
        lbHinhThucVanChuyen.Text = ordermenuEntity.Column3 == "0" ? "Chuyển phát nhanh" : "Chuyển chậm";       

       
        lblTongTien.Text = ordertotal.ToString("##,###") + " USD";
        
    }
    private string LoadDataToPhanTram(double tongTien, int soluong)
    {
        var phantram = "0";
        try
        {
            if (!string.IsNullOrEmpty(tongTien.ToString()))
            {
                var mappath = HttpContext.Current.Server.MapPath(string.Format("~/admin/XMLData/{0}{1}", "Promotion_", "pl" + ".xml"));
                var xmldoc = XDocument.Load(mappath);
                var q =
                    from xe in xmldoc.Descendants("key") select xe;
                var dt = new DataTable();
                dt.Columns.Add("key");
                dt.Columns.Add("name");
                dt.Columns.Add("value");
                dt.Columns.Add("description");

                foreach (var xe in q)
                {
                    var row = dt.NewRow();
                    row[0] = xe.Attribute("key").Value;
                    row[1] = xe.Attribute("name").Value;
                    row[2] = xe.Attribute("value").Value;
                    row[3] = xe.Attribute("description").Value;
                    dt.Rows.Add(row); // Thêm dòng mới vào dtb
                }
                foreach (DataRow row in dt.Rows)
                {
                    var s = row[1].ToString().Split('-');
                    if (s.Length <= 0) continue;
                    if (BicConvert.ToDecimal(s[1]) <= 100)
                    {
                        phantram = soluong > 9 ? row[2].ToString() : "0";
                        return phantram;
                    }
                    if (!(tongTien >= Convert.ToDouble(s[0])) || !(tongTien <= Convert.ToDouble(s[1]))) continue;
                    phantram = row[2].ToString();
                    return phantram;
                }
            }
        }
        catch (Exception)
        {
        }
        return phantram;
    }
    private void BindDataToOrderDetail()
    {
        var bicData = new BicGetData("OrderDetail");
        bicData.Selecting.Add("*");
        bicData.Conditioning.Add(new ConditioningItem(OrderDetailEntity.FIELD_ORDERMENUID, Id.ToString(), Operator.EQUAL,
                                                      CompareType.NUMERIC));
        var data = bicData.GetAllData();
        grvView.DataSource = data;
        grvView.DataBind();
    }

    protected string GetImage(int productId)
    {
        var product = ProductBiz.GetProductByID(productId);
        if (product != null)
        {
            return BicImage.GetPathImage(product.ImageID);
        }
        return "";
    }

    protected void grvView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandArgument == null) return;
            var itemId = Convert.ToInt32(e.CommandArgument);
            var name = e.CommandName;
            switch (name)
            {
                case "DeleteItem":

                    var orderEntity = OrderDetailBiz.GetOrderDetailByID(itemId);
                    if (orderEntity != null)
                    {
                        OrderDetailBiz.DeleteOrderDetail(itemId);
                    }
                    Session["StatusOrder"] = 1;
                    BindDataToOrderDetail();
                    BindOrderSubTotal();
                    break;
                case "EditItem":
                    pnUpdateProduct.Visible = true;

                    orderinfo.Visible = false;
                    billinginfo.Visible = false;
                    productdetail.Visible = true;
                    var prod = OrderDetailBiz.GetOrderDetailByID(itemId);
                    if (prod != null)
                    {
                        IdOrderDetail.Value = itemId.ToString();
                        txtTotal.Text = prod.Total.ToString();
                        ltProductCode.Text = prod.ProductCode;
                        ltProductName.Text = prod.ProductName;

                    }
                    //grvView.DataBind();
                    break;
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        var orderEntity = OrderDetailBiz.GetOrderDetailByID(BicConvert.ToInt32(IdOrderDetail.Value));
        if (orderEntity != null)
        {
            orderEntity.Total = BicConvert.ToInt32(txtTotal.Text);
        }
    }

    protected void BindOrderSubTotal()
    {
        double OrderSubTotal = 0;
        foreach (GridViewRow item in grvView.Rows)
        {
            var id = (HiddenField)item.FindControl("GetOrderDetailId");
            if (id == null) continue;
            var orderEntity = OrderDetailBiz.GetOrderDetailByID(Convert.ToInt32(id.Value));
            if (orderEntity != null)
                OrderSubTotal += Convert.ToDouble(orderEntity.SubTotal);
        }
        var orderMenu = OrderMenuBiz.GetOrderMenuByID(Id);
        orderMenu.OrderSubTotal = OrderSubTotal;
        OrderMenuBiz.UpdateOrderMenu(orderMenu);
        LoadDataFromEntity();
    }

    protected void OnNumber1Changed(object sender, EventArgs e)
    {
        double OrderSubTotal = 0;
        var orderMenu = OrderMenuBiz.GetOrderMenuByID(Id);
        if (orderMenu == null)
        {
            BindDataToOrderDetail();
            BicAjax.Alert("Order không tồn tại!, vui lòng xem lại");
            return;
        }
        foreach (GridViewRow item in grvView.Rows)
        {
            var txtQuantity = (RadNumericTextBox)item.FindControl("txtSoluong");

            var id = (HiddenField)item.FindControl("GetOrderDetailId");
            if (txtQuantity == null) continue;
            if (Convert.ToInt32(txtQuantity.Text) <= 0)
            {
                BicAjax.Alert(BicResource.GetValue("Admin", "Admin_NotQuantity"));
            }
            else
            {
                var orderEntity = OrderDetailBiz.GetOrderDetailByID(Convert.ToInt32(id.Value));
                if (orderEntity == null) continue;
                orderEntity.Total = Convert.ToInt32(txtQuantity.Text);
                orderEntity.SubTotal = orderEntity.Total * orderEntity.ProductPrice;
                OrderDetailBiz.UpdateOrderDetail(orderEntity);
                Session["StatusOrder"] = 1;
                BindDataToOrderDetail();
                OrderSubTotal += Convert.ToDouble(orderEntity.SubTotal);
            }
        }
        orderMenu.OrderSubTotal = OrderSubTotal;
        OrderMenuBiz.UpdateOrderMenu(orderMenu);
        LoadDataFromEntity();
        //LoadShoppingCart();
    }

    protected void txtShippingFee_TextChanged(object sender, EventArgs e)
    {
        try
        {
            var orderMenu = OrderMenuBiz.GetOrderMenuByID(Id);
            if (orderMenu == null) return;
            if (string.IsNullOrEmpty(txtShippingFee.Text)) return;
            orderMenu.OrderShippingFee = Convert.ToDouble(txtShippingFee.Text);
            OrderMenuBiz.UpdateOrderMenu(orderMenu);
            txtShippingFee.Attributes.Add("class", "hidden");
            LoadDataFromEntity();
        }
        catch (Exception)
        {
            BicAjax.Alert("Phí vận chuyển Không hợp lệ");
        }

    }

    protected void ddlOrderStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        //string value = ddlOrderStatus.SelectedValue;
        //var orderMenuEntity = OrderMenuBiz.GetOrderMenuByID(Id);
        //if (orderMenuEntity != null)
        //{
        //    Session["StatusOrder"] = 0;
        //    orderMenuEntity.OrderStatus = value;
        //    OrderMenuBiz.UpdateOrderMenu(orderMenuEntity);
        //    lblDBOrderStatus.Text = value;
        //    ddlOrderStatus.Attributes.Add("class", "hidden");
        //}
    }

    protected void ddlShippingStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        var value = ddlShippingStatus.SelectedValue;
        var orderMenuEntity = OrderMenuBiz.GetOrderMenuByID(Id);
        if (orderMenuEntity == null) return;
        Session["StatusOrder"] = 0;
        if (value == "0") return;
        orderMenuEntity.ShippingStatus = value;
        OrderMenuBiz.UpdateOrderMenu(orderMenuEntity);
        lblDBShippingStatus.Text = value;
        ddlShippingStatus.Attributes.Add("class", "hidden");
        UpdateOrderStatus();
        // Update lại trường số lượng trong bảng Product
        if (ddlShippingStatus.SelectedValue == "Đang giao hàng")
        {
            var lstOrderDetail = OrderDetailBiz.GetOrderDetailByOrderMenuID(orderMenuEntity.OrderMenuID);
            if (lstOrderDetail.Any())
            {
                foreach (var o in lstOrderDetail)
                {
                    var product = ProductBiz.GetProductByID(o.ProductID);
                    if (product != null)
                    {
                        var result = BicConvert.ToInt32(product.NewColumn6) - o.Total;
                        if (result <= 0)
                        {
                            //BicAjax.Alert(BicResource.GetValue("Admin", ""));
                            product.OutOfStock = false;
                        }
                        product.SaleOff = string.Format("{0}", BicConvert.ToDouble(product.NewColumn6) - o.Total);
                        ProductBiz.UpdateProduct(product);
                    }

                }
            }
        }
    }

    protected void ddlPaymentStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        var value = ddlPaymentStatus.SelectedValue;
        var orderMenuEntity = OrderMenuBiz.GetOrderMenuByID(Id);
        if (orderMenuEntity == null) return;
        Session["PaymentStatus"] = 0;
        if (value == "0") return;
        orderMenuEntity.PaymentStatus = value;
        OrderMenuBiz.UpdateOrderMenu(orderMenuEntity);
        lblDBPaymentStatus.Text = value;
        ddlPaymentStatus.Attributes.Add("class", "hidden");
        UpdateOrderStatus();
    }

    protected void UpdateOrderStatus()
    {
        if (lblDBShippingStatus.Text == "Đã giao hàng" && lblDBPaymentStatus.Text == "Đã thanh toán")
        {
            var orderMenuEntity = OrderMenuBiz.GetOrderMenuByID(Id);
            if (orderMenuEntity != null)
            {
                if (string.IsNullOrEmpty(orderMenuEntity.Customer)) return;
                var user = Membership.GetUser(Guid.Parse(orderMenuEntity.Customer));
                if (user == null) return;
                var profile = Profile.GetProfile(user.UserName);
                if (BicConvert.ToDouble(profile.CurrentPoint) < orderMenuEntity.UsePoint)
                {
                    //BicAjax.Alert("Đơn hàng: " + orderMenuEntity.OrderCode + "\n" + BicResource.GetValue("Message", "Order_UsePoint_Not_Enought"));
                    orderMenuEntity.OrderSubTotal += orderMenuEntity.UsePoint -
                                                                 BicConvert.ToDouble(profile.CurrentPoint);
                    orderMenuEntity.OrderNote += "\n" +
                                                 BicResource.GetValue("Message",
                                                     "Order_UsePoint_Not_Enought");
                    orderMenuEntity.UsePoint = BicConvert.ToDouble(profile.CurrentPoint);
                }
                profile.CurrentPoint = string.Format("{0}", BicConvert.ToDouble(profile.CurrentPoint) + orderMenuEntity.SavePoint - orderMenuEntity.UsePoint);
                //profile.UsedPoint = string.Format("{0}",
                //    BicConvert.ToDouble(profile.UsedPoint) + orderMenuEntity.UsePoint);
                //profile.PointHistory = string.Format("{0};", "1-" + DateTime.Now + "-" + orderMenuEntity.OrderCode + "-" + d.OrderDetailID + "-" + point);
                profile.Point = string.Format("{0}", BicConvert.ToDouble(profile.CurrentPoint) + BicConvert.ToDouble(profile.UsedPoint));
                profile.Save();
                Session["OrderStatus"] = 0;
                //orderMenuEntity.PaymentStatus = "Đã thanh toán";
                //orderMenuEntity.ShippingStatus = "Đã giao hàng";
                orderMenuEntity.OrderStatus = "Hoàn tất";
                //OrderMenuBiz.UpdateOrderMenu(orderMenuEntity);
                lblDBOrderStatus.Text = "Hoàn tất";
                OrderMenuBiz.UpdateOrderMenu(orderMenuEntity);
                //ddlPaymentStatus.Attributes.Add("class", "hidden");
            }
        }
        else if (lblDBShippingStatus.Text == "Chưa giao hàng" && lblDBPaymentStatus.Text == "Chưa thanh toán")
        {
            var orderMenuEntity = OrderMenuBiz.GetOrderMenuByID(Id);
            if (orderMenuEntity == null) return;
            Session["StatusOrder"] = 0;
            orderMenuEntity.OrderStatus = "Mới tiếp nhận";
            OrderMenuBiz.UpdateOrderMenu(orderMenuEntity);
            lblDBOrderStatus.Text = "Mới tiếp nhận";
            //ddlOrderStatus.Attributes.Add("class", "hidden");
        }
        else
        {
            var orderMenuEntity = OrderMenuBiz.GetOrderMenuByID(Id);
            if (orderMenuEntity == null) return;
            Session["StatusOrder"] = 0;
            orderMenuEntity.OrderStatus = "Đang xử lý";
            OrderMenuBiz.UpdateOrderMenu(orderMenuEntity);
            lblDBOrderStatus.Text = "Đang xử lý";
            //ddlOrderStatus.Attributes.Add("class", "hidden");
        }
    }

    protected void lbtDeleteAll_Click(object sender, EventArgs e)
    {
        var arrId = new List<int>();
        try
        {
            foreach (GridViewRow row in grvView.Rows)
            {
                var cb = (CheckBox)row.FindControl("chkSelect");
                if (cb == null || !cb.Checked) continue;
                var itemId = Convert.ToInt32(grvView.DataKeys[row.RowIndex].Value);
                arrId.Add(itemId);
            }
            if (arrId.Count > 0)
            {
                foreach (var i in arrId)
                {
                    var orderDetailEntity = OrderDetailBiz.GetOrderDetailByID(i);
                    if (orderDetailEntity != null)
                    {
                        OrderDetailBiz.DeleteOrderDetail(i);
                    }
                }
            }
            BindDataToOrderDetail();
        }
        catch (Exception)
        {
            throw;
        }
    }

    protected void grvView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        var txtSoluong = (RadNumericTextBox)e.Row.FindControl("txtSoluong");
        var lkdelete = (LinkButton)e.Row.FindControl("lnkDelete");
        var proID = (HiddenField)e.Row.FindControl("GetProductID");
        if (proID == null) return;
        if (txtSoluong != null)
        {
            if (!Edited)
                txtSoluong.Enabled = false;

            var proEntity = ProductBiz.GetProductByID(BicConvert.ToInt32(proID.Value));
            if (proEntity != null)
            {
                //txtSoluong.MinValue = !string.IsNullOrEmpty(proEntity.NewColumn5)
                //                                        ? Convert.ToDouble(proEntity.NewColumn5)
                //                                        : 12;
                // txtSoluong.IncrementSettings.Step = !string.IsNullOrEmpty(proEntity.NewColumn5)
                    // ? Convert.ToDouble(proEntity.NewColumn5)
                    // : 12;

                //txtSoluong.MinValue = !string.IsNullOrEmpty(proEntity.NewColumn5)
                //                          ? Convert.ToDouble(proEntity.NewColumn5)
                //                          : 12;
            }
        }
        if (lkdelete == null) return;
        if (!Deleted)
            lkdelete.Visible = false;
    }

    protected void txtShippingCode_OnTextChanged(object sender, EventArgs e)
    {
        try
        {
            var orderMenu = OrderMenuBiz.GetOrderMenuByID(Id);
            if (orderMenu == null) return;
            if (string.IsNullOrEmpty(txtShippingCode.Text)) return;
            orderMenu.Column4 = txtShippingCode.Text.Trim();
            OrderMenuBiz.UpdateOrderMenu(orderMenu);
            lblShippingCode.Text = txtShippingCode.Text.Trim();
            txtShippingCode.Attributes.Add("class", "hidden");
            //LoadDataFromEntity();
        }
        catch (Exception)
        {
            BicAjax.Alert("Mã vận chuyển Không hợp lệ");
        }
    }
}
