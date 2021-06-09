using System;
using System.Linq;
using System.Web.Security;
using BIC.Biz;
using BIC.Data;
using BIC.Handler;
using BIC.Utils;
using BIC.WebControls;

public partial class admin_Components_OrderMenu_OrderStatusChange : BasePageAdmin
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnMove_Click(object sender, EventArgs e)
    {
        MoveItem();
    }

    protected void MoveItem()
    {
        var lstId = BicString.Trim(BicHtml.GetRequestString("id", "0"));
        if (lstId == "0") return;
        var payStatus = ddlPaymentStatus.SelectedValue;
        var shipStatus = ddlShippingStatus.SelectedValue;
        try
        {
            var sql = string.Empty;
            if (payStatus == "Đã thanh toán" && shipStatus == "Đã giao hàng")
            {
                sql = string.Format(
                        @"Update OrderMenu set PaymentStatus = N'{0}', ShippingStatus = N'{1}', OrderStatus = N'Hoàn Tất' Where OrderMenuId in ({2})",
                        payStatus, shipStatus, lstId);
                var listId = BicString.SplitComma(lstId);
                foreach (var id in listId)
                {
                    var orderMenuEntity = OrderMenuBiz.GetOrderMenuByID(BicConvert.ToInt32(id));
                    if (!string.IsNullOrEmpty(orderMenuEntity.Customer))
                    {
                        var user = Membership.GetUser(Guid.Parse(orderMenuEntity.Customer));
                        if (user != null)
                        {
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
                                OrderMenuBiz.UpdateOrderMenu(orderMenuEntity);
                            }
                            profile.CurrentPoint = string.Format("{0}", BicConvert.ToDouble(profile.CurrentPoint) + orderMenuEntity.SavePoint);
                            //profile.UsedPoint = string.Format("{0}", BicConvert.ToDouble(profile.UsedPoint) + orderMenuEntity.UsePoint);
                            //profile.PointHistory = string.Format("{0};", "1-" + DateTime.Now + "-" + orderMenuEntity.OrderCode + "-" + d.OrderDetailID + "-" + point);
                            profile.Point = string.Format("{0}", BicConvert.ToDouble(profile.CurrentPoint) + BicConvert.ToDouble(profile.UsedPoint));
                            profile.Save();
                        }
                    }
                }
            }
            else if (shipStatus == "Chưa giao hàng" && payStatus == "Chưa thanh toán")
            {
                sql = string.Format(
                       @"Update OrderMenu set PaymentStatus = N'{0}', ShippingStatus = N'{1}', OrderStatus = N'Mới tiếp nhận' Where OrderMenuId in ({2})",
                       payStatus, shipStatus, lstId);
            }
            else
            {
                if (payStatus == "0" && shipStatus == "0")
                    sql = string.Empty;
                if (payStatus == "0" && shipStatus != "0")
                {
                    sql = string.Format(@"Update OrderMenu set ShippingStatus = N'{0}', OrderStatus = N'Đang xử lý' Where OrderMenuId in ({1})",
                    shipStatus, lstId);
                }
                if (payStatus != "0" && shipStatus == "0")
                {
                    sql = string.Format(@"Update OrderMenu set PaymentStatus = N'{0}', OrderStatus = N'Đang xử lý' Where OrderMenuId in ({1})",
                    payStatus, lstId);
                }
            }
            if (!string.IsNullOrEmpty(sql))
            {
                var dh = new DataHelper();
                dh.ExecuteSQL(sql);
            }
            if (shipStatus == "Đang giao hàng")
            {
                //Update lại trường số lượng
                var arr = BicString.SplitComma(lstId);
                foreach (var s in arr)
                {
                    var lstOrderDetail = OrderDetailBiz.GetOrderDetailByOrderMenuID(BicConvert.ToInt32(s));
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
                                product.NewColumn6 = string.Format("{0}", BicConvert.ToDouble(product.NewColumn6) - o.Total);
                                ProductBiz.UpdateProduct(product);
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            LogEvent.LogToFile(ex.ToString());
        }
        BizObject.PurgeCacheItems("OrderMenu_OrderMenu");
        BicAjax.Alert(string.Format(BicResource.GetValue("Admin", "Admin_Order_Message_Confirm_Changed")));
    }

}