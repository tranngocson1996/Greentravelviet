using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Data;
using BIC.Handler;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;
using Telerik.Web.UI;
using Telerik.Web.UI.Calendar;

public partial class Admin_Components_OrderMenu_ListingOrderMenu : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        radMenuContext.LoadContentFile("~/admin/XMLData/Grid/Edit_View_Delete1.xml");
        radMenuContext.Items[1].Attributes.Add("onclick",
            string.Format("var as;as=confirm('{0}');document.getElementById('confirmdelete').value = as;", BicMessage.Delete));
        rgManager.MasterTableView.CurrentPageIndex = Session["OrderMenuPageIndex"] != null ? BicSession.ToInt32("OrderMenuPageIndex") : 0;
        GetDataSource();
        BindDropDownPaymentMethods();
        //SumTotalPoint();
        if (!string.IsNullOrEmpty(BicSession.ToString("Filter_StartDate")))
            radBDBeginDate.SelectedDate = BicConvert.ToDateTime(BicSession.ToString("Filter_StartDate"));
        if (!string.IsNullOrEmpty(BicSession.ToString("Filter_EndDate")))
            radBDEndDate.SelectedDate = BicConvert.ToDateTime(BicSession.ToString("Filter_EndDate"));
    }

    protected void SumTotalPoint()
    {
        //var lstUser = Membership.GetAllUsers();
        //double totalPoint = 0;
        //double totalUsePoint = 0;
        //double totalMoney = 0;
        //foreach (MembershipUser user in lstUser)
        //{
        //    var profile = Profile.GetProfile(user.UserName);
        //    totalPoint += BicConvert.ToDouble(profile.Point);
        //    totalUsePoint += BicConvert.ToDouble(profile.UsedPoint);
        //}

        //var lstOrderComplete = OrderMenuBiz.GetAllOrderMenus();
        //if (lstOrderComplete.Any())
        //{
        //    foreach (var order in lstOrderComplete)
        //    {
        //        if (order.OrderStatus.ToLower().Equals("hoàn tất"))
        //            totalMoney += order.OrderSubTotal;
        //    }
        //}
        //lblTotalpoint.Text = totalPoint.ToString("##,###");
        //lblTotalUsePoint.Text = totalUsePoint.ToString("##,###");
        //lblTotal.Text = totalMoney.ToString("##,###");
    }

    protected void BindDropDownPaymentMethods()
    {
        var payment = CategoryBiz.GetCategoriesByType(2);
        if (!payment.Any()) return;
        ddlPaymentMethod.DataSource = payment;
        ddlPaymentMethod.DataTextField = "Name";
        ddlPaymentMethod.DataValueField = "Value";
        ddlPaymentMethod.DataBind();
        ddlPaymentMethod.Items.Insert(0, new ListItem("-- Chọn phương thức --", "0"));
    }

    protected string GetFullName(string userId)
    {
        var result = string.Empty;
        if (string.IsNullOrEmpty(userId)) return result;
        var user = Membership.GetUser(Guid.Parse(userId));
        if (user == null) return result;
        var profile = Profile.GetProfile(user.UserName);
        result = profile.FullName;
        return result;
    }
    protected string GetCusName(string userId, int orderId)
    {
        var result = string.Empty;
        if (string.IsNullOrEmpty(userId))
        {
            var ordermenuEntity = OrderMenuBiz.GetOrderMenuByID(orderId);
            result = ordermenuEntity.ShippingFullName;
        }
        else
        {
            var user = Membership.GetUser(Guid.Parse(userId));
            if (user == null) return result;
            var profile = Profile.GetProfile(user.UserName);
            result = profile.FullName;
        }
        return result;
    }

    private void GetDataSource()
    {
        var bicData = new BicGetData
        {
            TableName = "OrderMenu",
            PageSize = rgManager.MasterTableView.PageSize,
            PageIndex = rgManager.MasterTableView.CurrentPageIndex
        };
        if (!string.IsNullOrEmpty(BicSession.ToString("UserIDViewOrder")))
        {
            var userID = Membership.GetUser(BicSession.ToString("UserIDViewOrder"));
            if (userID != null)
                if (userID.ProviderUserKey != null)
                    bicData.Conditioning.Add(new ConditioningItem(OrderMenuEntity.FIELD_CUSTOMER,
                        userID.ProviderUserKey.ToString(), Operator.EQUAL, CompareType.STRING));
            BicSession.SetValue("UserIDViewOrder", string.Empty);
        }
        bicData.Sorting.Add(new SortingItem("OrderMenuID", true));
        bicData.Selecting.Add(OrderMenuEntity.FIELD_ORDERMENUID);
        bicData.Selecting.Add(OrderMenuEntity.FIELD_ORDERCODE);
        //bicData.Selecting.Add(OrderMenuEntity.FIELD_ORDERSTATUS);
        bicData.Selecting.Add(OrderMenuEntity.FIELD_PAYMENTSTATUS);
        bicData.Selecting.Add(OrderMenuEntity.FIELD_PAYMENTMETHOD);
        bicData.Selecting.Add(OrderMenuEntity.FIELD_SHIPPINGMETHOD);
        bicData.Selecting.Add(OrderMenuEntity.FIELD_SHIPPINGSTATUS);
        bicData.Selecting.Add(OrderMenuEntity.FIELD_SAVE_POINT);
        bicData.Selecting.Add(OrderMenuEntity.FIELD_USE_POINT);

        bicData.Selecting.Add(OrderMenuEntity.FIELD_SHIPPINGPHONE);
        bicData.Selecting.Add(OrderMenuEntity.FIELD_SHIPPINGEMAIL);

        bicData.Selecting.Add(OrderMenuEntity.FIELD_ORDERSUBTOTAL);
        bicData.Selecting.Add(OrderMenuEntity.FIELD_SHIPPINGDATE);
        bicData.Selecting.Add(OrderMenuEntity.FIELD_CUSTOMER);
        if (txtSearch.Text != String.Empty)
        {
            bicData.Conditioning.Add(new ConditioningItem(OrderMenuEntity.FIELD_CUSTOMER, "%" + BicConvert.ToString(txtSearch.Text) + "%", Operator.LIKE, CompareType.STRING));
            bicData.Conditioning.Add(new ConditioningItem(OrderMenuEntity.FIELD_ORDERCODE,
                "%" + BicConvert.ToString(txtSearch.Text) + "%", Operator.LIKE, CompareType.STRING));
            bicData.Conditioning.Add(new ConditioningItem(OrderMenuEntity.FIELD_BILLINGFULLNAME,
                "%" + BicConvert.ToString(txtSearch.Text) + "%", Operator.LIKE, CompareType.STRING));
        }
        if (ddlPaymentStatus.SelectedIndex != 0)
        {
            bicData.Conditioning.Add(new ConditioningItem(OrderMenuEntity.FIELD_PAYMENTSTATUS,
                "%" + BicConvert.ToString(ddlPaymentStatus.SelectedValue) + "%", Operator.LIKE, CompareType.STRING));
        }
        if (ddlPaymentMethod.SelectedIndex != 0)
        {
            bicData.Conditioning.Add(new ConditioningItem(OrderMenuEntity.FIELD_PAYMENTMETHOD,
                "%" + BicConvert.ToString(ddlPaymentMethod.SelectedValue) + "%", Operator.LIKE, CompareType.STRING));
        }
        if (ddlShippingStatus.SelectedIndex != 0)
        {
            bicData.Conditioning.Add(new ConditioningItem(OrderMenuEntity.FIELD_SHIPPINGSTATUS,
                "%" + BicConvert.ToString(ddlShippingStatus.SelectedValue) + "%", Operator.LIKE, CompareType.STRING));
        }
        if (!string.IsNullOrEmpty(radBDBeginDate.DateInput.Text))
        {
            if (radBDBeginDate.SelectedDate != null)
                bicData.Conditioning.Add(new ConditioningItem
                {
                    TypeOfCondition = TypeOfCondition.QUERY,
                    Query =
                        string.Format("ModifiedDate >= '{0}'",
                            radBDBeginDate.SelectedDate.Value)
                });
        }
        if (!string.IsNullOrEmpty(radBDEndDate.DateInput.Text))
        {
            if (radBDEndDate.SelectedDate != null)
                bicData.Conditioning.Add(new ConditioningItem
                {
                    TypeOfCondition = TypeOfCondition.QUERY,
                    Query = string.Format("ModifiedDate <= '{0}'",
                        radBDEndDate.SelectedDate.Value.AddDays(1))
                });
        }
        var data = bicData.GetPagingData();
        var temp = bicData.GetAllData();
        rgManager.VirtualItemCount = bicData.TotalItems;
        rgManager.DataSource = data;
        rgManager.DataBind();
        double totalPoint = 0;
        double totalUsePoint = 0;
        double totalMoney = 0;
        foreach (DataRow s in temp.Rows)
        {
            totalPoint += BicConvert.ToDouble(s["SavePoint"].ToString());
            totalUsePoint += BicConvert.ToDouble(s["UsePoint"].ToString());
            totalMoney += BicConvert.ToDouble(s["OrderSubTotal"].ToString());
        }
        lblTotalpoint.Text = totalPoint.ToString("##,###");
        lblTotalUsePoint.Text = totalUsePoint.ToString("##,###");
        lblTotal.Text = totalMoney.ToString("##,###");
    }

    protected void rgManager_ItemCreated(object sender, GridItemEventArgs e)
    {
        if (!(e.Item is GridPagerItem)) return;
        var pager = (GridPagerItem)e.Item;
        var PageSizeComboBox = (RadComboBox)pager.FindControl("PageSizeComboBox");
        if (PageSizeComboBox == null) return;
        var comboItem = new RadComboBoxItem("All");
        PageSizeComboBox.Items.Insert(0, comboItem);
        PageSizeComboBox.AutoPostBack = true;
        PageSizeComboBox.SelectedIndexChanged += PageSizeComboBox_SelectedIndexChanged;
    }
    private void PageSizeComboBox_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        GetDataSource();
    }

    protected void rgManager_PageIndexChanged(object source, GridPageChangedEventArgs e)
    {
        rgManager.MasterTableView.CurrentPageIndex = e.NewPageIndex;
        BicSession.SetValue("OrderMenuPageIndex", rgManager.MasterTableView.CurrentPageIndex);
        GetDataSource();

    }
    protected void txtSearch_TextChanged(object sender, EventArgs e)
    {
        GetDataSource();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BicSession.SetValue("PaymentMethods", ddlPaymentMethod.SelectedValue);
        BicSession.SetValue("PaymentStatus", ddlPaymentStatus.SelectedValue);
        BicSession.SetValue("ShippingStatus", ddlShippingStatus.SelectedValue);
        BicSession.SetValue("ArticleDate1", radBDBeginDate.SelectedDate);
        BicSession.SetValue("ArticleDate2", radBDEndDate.SelectedDate);
        BicSession.SetValue("ArticlePageIndex", 0);
        rgManager.CurrentPageIndex = 0;
        GetDataSource();
    }

    protected void btnclear_OnClick(object sender, EventArgs e)
    {
        ddlPaymentMethod.SelectedIndex = 0;
        BicSession.SetValue("PaymentMethods", string.Empty);
        ddlPaymentStatus.SelectedIndex = 0;
        BicSession.SetValue("PaymentStatus", string.Empty);
        ddlShippingStatus.SelectedIndex = 0;
        BicSession.SetValue("ShippingStatus", string.Empty);
        radBDBeginDate.Clear();
        BicSession.SetValue("ArticleDate1", string.Empty);
        radBDEndDate.Clear();
        BicSession.SetValue("ArticleDate2", string.Empty);
        rgManager.CurrentPageIndex = 0;
        BicSession.SetValue("ArticlePageIndex", 0);
        GetDataSource();
    }
    protected void rgManager_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        GetDataSource();
    }
    protected void rgManager_ItemDataBound(object sender, GridItemEventArgs e)
    {

    }
    protected void radMenuContext_ItemClick(object sender, RadMenuEventArgs e)
    {
        var index = Convert.ToInt32(Request.Form["radGridClickedRowIndex"]);
        var id = Convert.ToInt32(rgManager.Items[index].GetDataKeyValue("OrderMenuID"));
        var ordermenuEntity = OrderMenuBiz.GetOrderMenuByID(id);
        switch (e.Item.Value)
        {
            case "Add":
                BicAdmin.NavigateToAdd();
                break;
            case "View":
                BicAdmin.NavigateToView(id.ToString());
                break;
            case "Delete":
                if (Deleted && ordermenuEntity.IsActive && Approved == false)
                    BicAjax.Alert("Bạn không có quyền xóa bản ghi đã duyệt.");
                else
                    if (Deleted)
                    {
                        var confirm = Convert.ToBoolean(Request.Form["confirmdelete"]);
                        if (confirm)
                        {
                            var bicData = new BicGetData("OrderDetail");
                            bicData.Selecting.Add("*");
                            bicData.Conditioning.Add(new ConditioningItem("OrderMenuID",
                                                                          ordermenuEntity.OrderMenuID.ToString(),
                                                                          Operator.EQUAL, CompareType.STRING));
                            var dt = bicData.GetAllData();
                            if (dt.Rows.Count > 0)
                            {
                                var lstDetailID = new List<int>();
                                foreach (DataRow row in dt.Rows)
                                {
                                    var orderDetailID = BicConvert.ToInt32(row[0]);
                                    lstDetailID.Add(orderDetailID);

                                }
                                if (lstDetailID.Count > 0)
                                {
                                    foreach (var i in lstDetailID)
                                    {
                                        OrderDetailBiz.DeleteOrderDetail(i);
                                    }
                                }
                            }
                            OrderMenuBiz.DeleteOrderMenu(id);
                            GetDataSource();

                        }
                    }
                    else
                        if (Deleted == false)
                            BicAjax.Alert(BicMessage.DenyDelete);
                break;
            case "Edit":
                if (Edited && ordermenuEntity.IsActive && Approved == false)
                    BicAjax.Alert("Bạn không có quyền sửa bản ghi đã duyệt");
                else
                    if (Edited)
                    {
                        BicAdmin.NavigateToEdit(id.ToString());
                    }
                    else
                        if (Edited == false)
                            BicAjax.Alert(BicMessage.DenyEdit);
                break;
        }
    }
    protected void ddlLanguage_SelectedIndexChanged(object o, EventArgs e)
    {
        GetDataSource();

    }
    protected void rgManager_ItemCommand(object source, GridCommandEventArgs e)
    {
        try
        {
            switch (e.CommandName)
            {
                case "IsNew":
                    var dhIsNew = new DataHelper();
                    var updateIsNew = e.CommandArgument.Equals("True") ? 0 : 1;
                    if (
                        dhIsNew.UpdateColumn("IsNew", updateIsNew, "ArticleID",
                                             e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ArticleID"].ToString
                                                 (),
                                             "Article") == false)
                        e.Canceled = true;
                    else
                        GetDataSource();

                    break;

                case "IsActive":
                    if (BicRadGrid.ExecuteBooleanCommand(e, e.CommandName, "ArticleId",
                                                         e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex][
                                                             "ArticleID"].ToString(), "Article"))
                        GetDataSource();
                    else
                        e.Canceled = true;
                    break;
                case "View":
                    var orderEntity = OrderMenuBiz.GetOrderMenuByID(BicConvert.ToInt32(e.CommandArgument));

                    if (Edited && orderEntity.IsActive && Approved == false)
                        BicAjax.Alert(string.Format(BicResource.GetValue("Admin", "Admin_Article_Message1")));
                    else if (Edited)
                    {
                        BicAdmin.NavigateToView(e.CommandArgument.ToString());
                    }
                    else if (Edited == false)
                        BicAjax.Alert(BicMessage.DenyEdit);
                    break;
                //case "ExportExcel":
                //    ExportExcelList();
                //    break;
                //case "ExportExcel1":
                //    ExportExcelDetail();
                //    break;
            }
        }
        catch (Exception ex)
        {
            LogEvent.LogToFile(ex.ToString());
        }
    }
    protected void lbtnDeleteSelected_Click(object sender, EventArgs e)
    {
        if (!Deleted)
            BicAjax.Alert(BicMessage.DenyDelete);
        else
        {
            foreach (GridDataItem item in rgManager.SelectedItems)
            {
                if (!item.Selected) continue;
                // Access data key
                var id = BicConvert.ToInt32(item.GetDataKeyValue("OrderMenuID"));
                // Access column

                var ordermenuEntity = OrderMenuBiz.GetOrderMenuByID(id);
                if (ordermenuEntity == null) return;

                if (ordermenuEntity.IsActive && Approved == false)
                    BicAjax.Alert(string.Format(BicResource.GetValue("Admin", "Admin_Article_Message1")));
                else
                {
                    var bicData = new BicGetData("OrderDetail");
                    bicData.Selecting.Add("*");
                    bicData.Conditioning.Add(new ConditioningItem("OrderMenuID",
                        ordermenuEntity.OrderMenuID.ToString(),
                        Operator.EQUAL, CompareType.STRING));
                    var dt = bicData.GetAllData();
                    if (dt.Rows.Count > 0)
                    {
                        var lstDetailID = new List<int>();
                        foreach (DataRow row in dt.Rows)
                        {
                            var orderDetailID = BicConvert.ToInt32(row[0]);
                            lstDetailID.Add(orderDetailID);

                        }
                        if (lstDetailID.Count > 0)
                        {
                            foreach (var i in lstDetailID)
                            {
                                OrderDetailBiz.DeleteOrderDetail(i);
                            }
                        }
                    }
                    OrderMenuBiz.DeleteOrderMenu(id);
                }
            }
            GetDataSource();
        }

    }

    protected void lbtnExportExcel_OnClick(object sender, EventArgs e)
    {
        ExportExcel(1);
    }

    protected void lbtnExportExcel1_OnClick(object sender, EventArgs e)
    {
        ExportExcel(2);
    }
    // Xuất dữ liệu sang excel
    protected void ExportExcel(int type)
    {
        DataTable data;
        BizObject.PurgeCacheItems("OrderMenu_ExportExcel");
        if (type == 1)
        {
            var bicData = new BicGetData { TableName = "OrderMenu" };
            //bicData.Selecting.Add(OrderMenuEntity.FIELD_ORDERMENUID);
            bicData.Selecting.Add("ROW_NUMBER() OVER (ORDER BY OrderMenuID DESC) as N'STT'");
            bicData.Selecting.Add(OrderMenuEntity.FIELD_ORDERCODE);
            bicData.Selecting.Add(OrderMenuEntity.FIELD_CUSTOMER);
            bicData.Selecting.Add(OrderMenuEntity.FIELD_PAYMENTSTATUS);
            bicData.Selecting.Add(OrderMenuEntity.FIELD_PAYMENTMETHOD);
            bicData.Selecting.Add(OrderMenuEntity.FIELD_SHIPPINGMETHOD);
            bicData.Selecting.Add(OrderMenuEntity.FIELD_SHIPPINGSTATUS);
            //bicData.Selecting.Add(OrderMenuEntity.FIELD_SAVE_POINT);
            //bicData.Selecting.Add(OrderMenuEntity.FIELD_USE_POINT);
            bicData.Selecting.Add(OrderMenuEntity.FIELD_ORDERSUBTOTAL);
            bicData.Selecting.Add(OrderMenuEntity.FIELD_SHIPPINGDATE);
            if (txtSearch.Text != String.Empty)
            {
                bicData.Conditioning.Add(new ConditioningItem(OrderMenuEntity.FIELD_CUSTOMER, "%" + BicConvert.ToString(txtSearch.Text) + "%", Operator.LIKE, CompareType.STRING));
                bicData.Conditioning.Add(new ConditioningItem(OrderMenuEntity.FIELD_ORDERCODE,
                    "%" + BicConvert.ToString(txtSearch.Text) + "%", Operator.LIKE, CompareType.STRING));
                bicData.Conditioning.Add(new ConditioningItem(OrderMenuEntity.FIELD_BILLINGFULLNAME,
                "%" + BicConvert.ToString(txtSearch.Text) + "%", Operator.LIKE, CompareType.STRING));
            }
            if (ddlPaymentStatus.SelectedIndex != 0)
            {
                bicData.Conditioning.Add(new ConditioningItem(OrderMenuEntity.FIELD_PAYMENTSTATUS,
                    "%" + BicConvert.ToString(ddlPaymentStatus.SelectedValue) + "%", Operator.LIKE, CompareType.STRING));
            }
            if (ddlPaymentMethod.SelectedIndex != 0)
            {
                bicData.Conditioning.Add(new ConditioningItem(OrderMenuEntity.FIELD_PAYMENTMETHOD,
                    "%" + BicConvert.ToString(ddlPaymentMethod.SelectedValue) + "%", Operator.LIKE, CompareType.STRING));
            }
            if (ddlShippingStatus.SelectedIndex != 0)
            {
                bicData.Conditioning.Add(new ConditioningItem(OrderMenuEntity.FIELD_SHIPPINGSTATUS,
                    "%" + BicConvert.ToString(ddlShippingStatus.SelectedValue) + "%", Operator.LIKE, CompareType.STRING));
            }
            if (!string.IsNullOrEmpty(radBDBeginDate.DateInput.Text))
            {
                if (radBDBeginDate.SelectedDate != null)
                    bicData.Conditioning.Add(new ConditioningItem
                    {
                        TypeOfCondition = TypeOfCondition.QUERY,
                        Query =
                            string.Format("ModifiedDate >= '{0}'",
                                radBDBeginDate.SelectedDate.Value)
                    });
            }
            if (!string.IsNullOrEmpty(radBDEndDate.DateInput.Text))
            {
                if (radBDEndDate.SelectedDate != null)
                    bicData.Conditioning.Add(new ConditioningItem
                    {
                        TypeOfCondition = TypeOfCondition.QUERY,
                        Query = string.Format("ModifiedDate <= '{0}'",
                            radBDEndDate.SelectedDate.Value.AddDays(1))
                    });
            }
            bicData.CachePrefix = "OrderMenu_ExportExcel";
            data = bicData.GetAllData();
        }
        else
        {
            var bicData = new DataHelper();
            var query =
                //"Select ROW_NUMBER() OVER (ORDER BY T1.OrderMenuID DESC) as N'STT', T1.ShippingDate as N'Ngày đặt hàng', N'<b>Code:</b> ' + T1.OrderCode as N'Mã đơn hàng', T2.ProductName as N'Tên sản phẩm', T2.ProductCode as N'Mã sản phẩm', T2.ProductPrice as N'Giá sản phẩm', T2.Total as N'Số lượng', T2.SubTotal as N'Thành tiền', T1.OrderShippingFee as N'Phí vận chuyển', Case When T1.Column3 = '0' then N'Chuyển phát nhanh' else N'Tiết kiệm' end as N'Loại dịch vụ', T1.SavePoint as N'Điểm tích lũy', T1.UsePoint as N'Điểm sử dụng', T1.OrderSubTotal as N'Tổng tiền cần thanh toán', CASE WHEN LEN(ISNULL(T1.OrderNote,'')) !=0  then N'<b>Ghi chú người đặt hàng:</b> ' end + T1.OrderNote + '<br/>' + CASE WHEN LEN(ISNULL(T1.OrderNote,'')) !=0 then N'<b>Ghi chú người nhận hàng:</b> ' end + T1.Column1 as N'Ghi chú', T1.BillingFullName as N'Tên người đặt hàng', T1.BillingShippingAddress as N'Địa chỉ người đặt hàng', T1.BillingPhone as N'Điện thoại người đặt hàng', T1.ShippingFullName as N'Tên người nhận hàng', T1.ShippingAddress as N'Địa chỉ nhận hàng', T1.ShippingPhone as N'Điện thoại người nhận hàng' From OrderMenu as T1 Inner Join OrderDetail as T2 on T1.OrderMenuID = T2.OrderMenuID";
                "Select ROW_NUMBER() OVER (ORDER BY T1.OrderMenuID DESC) as N'STT', T1.ShippingDate as N'Ngày đặt hàng', N'<b>Code:</b> ' + T1.OrderCode as N'Mã đơn hàng', T2.ProductName as N'Tên sản phẩm', T2.ProductCode as N'Mã sản phẩm', T2.ProductPrice as N'Giá sản phẩm', T2.Total as N'Số lượng', T2.SubTotal as N'Thành tiền', T1.OrderShippingFee as N'Phí vận chuyển', Case When T1.Column3 = '0' then N'Chuyển phát nhanh' else N'Tiết kiệm' end as N'Loại dịch vụ', T1.OrderSubTotal as N'Tổng tiền cần thanh toán', CASE WHEN LEN(ISNULL(T1.OrderNote,'')) !=0  then N'<b>Ghi chú người đặt hàng:</b> ' end + T1.OrderNote + '<br/>' + CASE WHEN LEN(ISNULL(T1.OrderNote,'')) !=0 then N'<b>Ghi chú người nhận hàng:</b> ' end + T1.Column1 as N'Ghi chú', T1.BillingFullName as N'Tên người đặt hàng', T1.BillingShippingAddress as N'Địa chỉ người đặt hàng', T1.BillingPhone as N'Điện thoại người đặt hàng', T1.ShippingFullName as N'Tên người nhận hàng', T1.ShippingAddress as N'Địa chỉ nhận hàng', T1.ShippingPhone as N'Điện thoại người nhận hàng' From OrderMenu as T1 Inner Join OrderDetail as T2 on T1.OrderMenuID = T2.OrderMenuID";
            var condition = string.Empty;
            if (txtSearch.Text != String.Empty)
            {
                condition = string.IsNullOrEmpty(condition) ? @" Where T1.OrderCode like N'%" + txtSearch.Text.Trim() + "%'" : condition + @" and T1.OrderCode like N'%" + txtSearch.Text.Trim() + "%'";
                condition = string.IsNullOrEmpty(condition) ? @" Where T1.BillingFullName like N'%" + txtSearch.Text.Trim() + "%'" : condition + @" and T1.BillingFullName like N'%" + txtSearch.Text.Trim() + "%'";
            }
            if (ddlPaymentStatus.SelectedIndex != 0)
            {
                condition = string.IsNullOrEmpty(condition) ? @" Where T1.PaymentStatus like N'%" + ddlPaymentStatus.SelectedValue + "%'" : condition + @" and T1.PaymentStatus like N'%" + ddlPaymentStatus.SelectedValue + "%'";
            }
            if (ddlPaymentMethod.SelectedIndex != 0)
            {
                condition = string.IsNullOrEmpty(condition)
                    ? @" Where T1.PaymentMethod like N'%" + ddlPaymentMethod.SelectedValue + "%'"
                    : condition + @" and T1.PaymentMethod like N'%" + ddlPaymentMethod.SelectedValue + "%'";
            }
            if (ddlShippingStatus.SelectedIndex != 0)
            {
                condition = string.IsNullOrEmpty(condition)
                    ? @" Where T1.ShippingStatus like N'%" + ddlShippingStatus.SelectedValue + "%'"
                    : condition + @" and T1.ShippingStatus like N'%" + ddlShippingStatus.SelectedValue + "%'";
            }
            if (!string.IsNullOrEmpty(radBDBeginDate.DateInput.Text))
            {
                if (radBDBeginDate.SelectedDate != null)
                    condition = string.IsNullOrEmpty(condition)
                        ? @" Where T1.ModifiedDate >= '" + radBDBeginDate.SelectedDate.Value + "'"
                        : condition + @" and T1.ModifiedDate >= '" + radBDBeginDate.SelectedDate.Value + "'";
            }
            if (!string.IsNullOrEmpty(radBDEndDate.DateInput.Text))
            {
                if (radBDEndDate.SelectedDate != null)
                    condition = string.IsNullOrEmpty(condition)
                        ? @" Where T1.ModifiedDate <= '" + radBDEndDate.SelectedDate.Value.AddDays(1) + "'"
                        : condition + @" and T1.ModifiedDate <= '" + radBDEndDate.SelectedDate.Value.AddDays(1) + "'";
            }
            if (!string.IsNullOrEmpty(condition))
                query = query + condition;
            data = bicData.ExecuteSQL(query);
        }
        var fileName = "Michair_Order_" + DateTime.Now.ToString("dd-MM-yyyy");
        var attach = "attachment;filename=" + fileName + ".xls";
        if (type == 1)
        {
            foreach (DataRow dr in data.Rows)
            {
                dr[1] = "<b>Code:</b> " + dr[1];
                dr[2] = string.IsNullOrEmpty(dr[2].ToString()) ? string.Empty : GetFullName(dr[2].ToString());
            }
        }
        var dgGrid = new GridView() { DataSource = data };
        dgGrid.DataBind();
        if (type == 1)
        {
            dgGrid.HeaderRow.Cells[1].Text = BicResource.GetValue("Admin", "Admin_Order_Header_Order_Code");
            dgGrid.HeaderRow.Cells[2].Text = BicResource.GetValue("Admin", "Admin_Order_Header_Order_Customer");
            dgGrid.HeaderRow.Cells[3].Text = BicResource.GetValue("Admin", "Admin_Order_Header_Order_PaymentStatus");
            dgGrid.HeaderRow.Cells[4].Text = BicResource.GetValue("Admin", "Admin_Order_Header_Order_PaymentMethods");
            dgGrid.HeaderRow.Cells[5].Text = BicResource.GetValue("Admin", "Admin_Order_Header_Order_ShippingMethod");
            dgGrid.HeaderRow.Cells[6].Text = BicResource.GetValue("Admin", "Admin_Order_Header_Order_ShippingStatus");
            dgGrid.HeaderRow.Cells[7].Text = BicResource.GetValue("Admin", "Admin_Order_Header_Order_OrderSubTotal");
            //dgGrid.HeaderRow.Cells[7].Text = BicResource.GetValue("Admin", "Admin_Order_Header_Order_SavePoint");
            dgGrid.HeaderRow.Cells[8].Text = BicResource.GetValue("Admin", "Admin_Order_Header_Order_OrderDate");
            //dgGrid.HeaderRow.Cells[8].Text = BicResource.GetValue("Admin", "Admin_Order_Header_Order_UsePoint");
           
            
        }

        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", attach);
        Response.ContentType = "application/vnd.ms-excel";
        Response.Charset = "";

        var tw = new StringWriter();
        var hw = new HtmlTextWriter(tw);
        hw.AddAttribute("xmlns:x", "urn:schemas-microsoft-com:office:excel");
        hw.RenderBeginTag(HtmlTextWriterTag.Html);
        hw.RenderBeginTag(HtmlTextWriterTag.Head);
        hw.RenderBeginTag(HtmlTextWriterTag.Style);
        hw.Write("br {mso-data-placement:same-cell;}");
        hw.RenderEndTag();
        hw.RenderEndTag();
        hw.RenderBeginTag(HtmlTextWriterTag.Body);
        dgGrid.RenderControl(hw);
        hw.RenderEndTag();
        hw.RenderEndTag();
        Response.Output.Write(HttpUtility.HtmlDecode(tw.ToString()));

        Response.Flush();
        Response.End();
    }

    protected void radBDBeginDate_OnSelectedDateChanged(object sender, SelectedDateChangedEventArgs e)
    {
        if (radBDBeginDate.SelectedDate != null)
            BicSession.SetValue("Filter_StartDate", radBDBeginDate.SelectedDate.Value);
    }

    protected void radBDEndDate_OnSelectedDateChanged(object sender, SelectedDateChangedEventArgs e)
    {
        if (radBDEndDate.SelectedDate != null) BicSession.SetValue("Filter_EndDate", radBDEndDate.SelectedDate.Value);
    }
}

