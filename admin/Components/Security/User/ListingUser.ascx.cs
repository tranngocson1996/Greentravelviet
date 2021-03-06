using System;
using System.Data;
using System.Web.Security;
using System.Web.UI.WebControls;
using BIC.Utils;
using BIC.Utils.BicExcel;
using BIC.WebControls;
using Telerik.Web.UI;

public partial class admin_Components_Security_ListingUser : BaseUserControl
{
    private int _cid;
    private int _mid;
    protected void Page_Load(object sender, EventArgs e)
    {
        _mid = BicHtml.GetRequestString("mid", 0);
        _cid = BicHtml.GetRequestString("cid", 0);
        if (IsPostBack) return;
        // BindingRoles();
        radMenuContext.LoadContentFile("~/admin/XMLData/Grid/MenuContextUsers_"+BicLanguage.CurrentLanguageAdmin+".xml");
        BindUser();
        radMenuContext.Items[1].Attributes.Add("onclick", "return showChangeOtherPass();return false;");
        radMenuContext.Items[1].PostBack = false;
        radMenuContext.Items[2].Attributes.Add("onclick", string.Format("var as;as=confirm('{0}');document.getElementById('confirmdelete').value = as;", BicMessage.Delete));
    }
    //protected void BindingRoles()
    //{
    //    ddlRole.DataSource = Roles.GetAllRoles();
    //    ddlRole.DataBind();
    //    ddlRole.Items.Insert(0, new ListItem("[Lọc theo nhóm]", "0"));
    //}
    protected void ddlRole_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindUser();
    }
    private void BindUser()
    {
        MembershipUserCollection allUsers = Membership.GetAllUsers();
        string searchText = txtSearchText.Text.Trim();
        if (searchText != string.Empty)
        {
            if (ddlSearchType.SelectedValue.Equals("1"))
                allUsers = Membership.FindUsersByEmail("%" + searchText + "%");
            else if (ddlSearchType.SelectedValue.Equals("0"))
                allUsers = Membership.FindUsersByName("%" + searchText + "%");
        }
        if (BicMemberShip.CurrentUserName != "administrator")
            allUsers.Remove("administrator");
        rgManager.DataSource = allUsers;
        rgManager.VirtualItemCount = allUsers.Count;
    }
    protected ProfileCommon GetProfile(string userName)
    {
        ProfileCommon profile = Profile.GetProfile(userName);
        return profile;
    }
    protected void rgManager_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        BindUser();
    }
    protected void rptBeginLetter_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        rgManager.Rebind();
    }
    protected void rgManager_DeleteCommand(object source, GridCommandEventArgs e)
    {
        string userName = BicConvert.ToString(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["UserName"]);
        if (userName != string.Empty)
            DelUser(userName);
    }
    protected void rgManager_ItemCommand(object source, GridCommandEventArgs e)
    {
        MembershipUser user = Membership.GetUser(e.CommandArgument.ToString());
        switch (e.CommandName)
        {
            case "IsLockedOut":
                if (user.IsLockedOut)
                {
                    user.UnlockUser();
                    Membership.UpdateUser(user);
                    rgManager.Rebind();
                }
                break;
            case "IsApproved":
                user.IsApproved = !user.IsApproved;
                Membership.UpdateUser(user);
                rgManager.Rebind();
                break;
            case "AddNew":
                Response.Redirect(string.Format("default.aspx?cid={0}&l={1}", 9, BicHtml.GetRequestString("l", "vi")));
                break;
            case "Delete":
                DelUser(user.UserName);
                rgManager.Rebind();
                break;
            case "ImportExcel":
                ImportExcel();
                break;
            case "ExportExcel":
                ExportExcel();
                break;
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindUser();
        rgManager.Rebind();
    }
    protected void txtSearchText_TextChanged(object sender, EventArgs e)
    {
        BindUser();
        rgManager.Rebind();
    }
    protected void ddlSearchType_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
    protected void DelUser(string userName)
    {
        if (userName != string.Empty)
            if (userName == "administrator")
            {
                BicAjax.Alert("Bạn không thể xóa tài khoản quản trị");
            }
            else if (userName == BicMemberShip.CurrentUserName)
            {
                BicAjax.Alert("Bạn không thể xóa tài khoản đang đăng nhập.");
            }
            else
            {
                Membership.DeleteUser(userName);
            }
    }
    protected void radMenuContext_ItemClick(object sender, RadMenuEventArgs e)
    {
        int _id = Convert.ToInt32(Request.Form["radGridClickedRowIndex"]);
        //BicConvert.ToInt32(rgManager.MasterTableView.DataKeyValues[radGridClickedRowIndex]["ControlID"]);
        string userName = rgManager.MasterTableView.DataKeyValues[_id]["UserName"].ToString().Trim();
        switch (e.Item.Value)
        {
            case "Add":
                BicHtml.Navigate(string.Format("?mid={0}?cid={1}&action=add&l={2}", _mid, _cid, BicHtml.GetRequestString("l", "vi")));
                break;
            case "Delete":
                DelUser(userName);
                rgManager.Rebind();
                break;
            case "Edit":
                BicHtml.Navigate(string.Format("?mid={0}&cid={1}&action=edit&UserName={2}&l={3}", _mid, _cid, userName, BicHtml.GetRequestString("l", "vi")));
                break;
        }
    }
    protected void ExportExcel()
    {
        rgManager.ExportSettings.ExportOnlyData = true;
        rgManager.ExportSettings.IgnorePaging = true;
        rgManager.ExportSettings.FileName = string.Format("User_{0}", DateTime.Now.ToString("dd_MM_yyyy"));
        rgManager.MasterTableView.ExportToExcel();
    }
    protected void ImportExcel()
    {
        string inValidByUser = string.Empty;
        string inValidByEmail = string.Empty;
        ;
        //IIS7 64bit: ApplicationPool>ASP.Net 4.0>Advance Setting > Enable 32-bit Application
        DataTable dt = Import.Query(Server.MapPath("~/User.xls"));
        foreach (DataRow dr in dt.Rows)
        {
            string username = dr["UserName"].ToString();
            string email = dr["Email"].ToString();
            string password = BicString.BuiltRamdomText(4);
            if (Membership.GetUser(username) != null)
            {
                inValidByUser += username + ",";
                continue;
            }
            if (Membership.GetUserNameByEmail(email) != null)
            {
                inValidByEmail += username + ",";
                continue;
            }
            try
            {
                Membership.CreateUser(username, password, email);
                //BicEmail.SendEmailToCustomers()
            }
            catch (Exception ex)
            {
                BicAjax.Alert(ex.Message);
            }
        }
        rgManager.Rebind();
        if (inValidByUser != string.Empty || inValidByEmail != string.Empty)
            //ko hien dc alert
            BicAjax.Alert("Dữ liệu đã được import.\nTài khoản đã có người sử dụng: " + inValidByUser + "\nEmail của tài khoản đã có người sử dụng: " + inValidByEmail);
        else
        {
            BicAjax.Alert("Dữ liệu đã được import");
        }
        BicAjax.Alert("OK");
    }
}