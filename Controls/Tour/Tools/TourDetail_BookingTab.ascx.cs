using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using BIC.Data;
using System.Data;
using BIC.Biz;
using BIC.Utils;
using BIC.Handler;
using BIC.WebControls;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using BIC.Data;
using BIC.Entity;
public partial class Controls_Tour_TourDetail_BookingTab : BIC.WebControls.BaseUIControl
{
    private int MenuUserId;
    private string Menuname = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        MenuUserId = BicRouting.GetRequestString("id", 0);
        if (!IsPostBack)
        {
            ClearForm();
            LoadDropDownList(drlNationality, "Nationality");
            LoadDropDownList(drlstyle, "AccommodationStyle");
        }
        


 btnBook.CssClass = Language == "vi" ? "btnsendbook vi" : "btnsendbook en";
    }
    protected void btnBook_Click(object sender, CommandEventArgs e)
    {



        if (e.CommandName == "Booking")
        {



            if (txtTelephone.Text == "" || txtFullname.Text == ""|| txtTelephone.Text == "Telephone" ||txtEmail.Text=="")
            {
                BicAjax.Alert(BicResource.GetValue("Requires1"));

            }
            else
            {


                var content = BicHtml.GetContents("~/Controls/Tour/temp/TourBook_"+Language+".html");
                //content = content.Replace("", txtAddress.Text);
                if (txtRequire.Text == txtRequire.Attributes["val"])
                {
                    txtRequire.Text = string.Empty;
                }
                content = content.Replace("[Domain]", BicXML.ToString("Domain", "MailConfig"));
                content = content.Replace("[SaleMail]", BicXML.ToString("SaleMail", "MailConfig"));
                content = content.Replace("[DateTime]", DateTime.Now.ToString("MMM dd, yyyy"));
                content = content.Replace("[Tour]", GetUserName(MenuUserId));
                content = content.Replace("[Name]", txtFullname.Text);
                content = content.Replace("[Address]", txtAddress.Text);
                content = content.Replace("[Country]", drlNationality.Text);
                content = content.Replace("[Tel]", txtTelephone.Text);
                content = content.Replace("[Mobi]", txtEmail.Text);
                content = content.Replace("[ArrDate]", txtArrDatebook.Text);
                content = content.Replace("[DepDate]", txtDepDatebook.Text);
                content = content.Replace("[NoAdult]", txtGuestOver12.Text);
                content = content.Replace("[NoChild]", txtGuestUnder12.Text);
                content = content.Replace("[NoBaby]", txtGuestUnder2.Text);
                content = content.Replace("[NoTotal]", SumText(new TextBox[] { txtGuestOver12, txtGuestUnder12, txtGuestUnder2 }).ToString());
                content = content.Replace("[AcStyle]", drlstyle.Text);
                content = content.Replace("[RoomTotal]", SumText(new TextBox[] { txtRoomTriple, txtRoomSingle, txtRoomTwin }).ToString());
                content = content.Replace("[RoomSingle]", txtRoomSingle.Text);
                content = content.Replace("[RoomTwin]", txtRoomTwin.Text);
                content = content.Replace("[RoomTriple]", txtRoomTriple.Text);
                content = content.Replace("[Require]", txtRequire.Text);
                try
                {

                    if (BicEmail.SendToWebMaster("Contact", content, txtEmail.Text, txtFullname.Text))
                        if (BicEmail.SendToCustomer(txtEmail.Text, "Customize Trip", content))
                        {
                            BicAjax.Alert(BicResource.GetValue("Message", "SEND_MAIL_SUCCESS"));
                            Page handler = HttpContext.Current.Handler as Page;
                            if (handler != null)
                            {
                                ScriptManager.RegisterStartupScript(handler, handler.GetType(), "clear", " $('.tourDetailBlock input[type=text]').attr('value', '');", true);
                            }
                            ClearForm();
                       
                        }
                }
                catch (Exception ex)
                {
                    BicAjax.Alert("Email không đúng định dạng");
                
                    LogEvent.LogToFile(ex.ToString());
                }


            }
        }
        if (e.CommandName == "Cancel")
        {
           
            ClearForm();
           
        }
    

    }
    private void ClearForm()
    {
      
        ClearTextBox();
        txtRequire.Text = txtRequire.Attributes["val"];
        LoadDropDownList(drlNationality, "Nationality");
        LoadDropDownList(drlstyle, "AccommodationStyle");

    }
    private string GetUserName(int menuUserId)
    {
        var Menuname = string.Empty;
        var entity = TourBiz.GetTourByID(menuUserId);
        Menuname = entity.TenTour;
        return Menuname;
    }
    private string ReplaceText(string input, string Replacement, TextBox txtInput)
    {
        return input.Replace(Replacement, txtInput.Text);
    }
    private string ReplaceText(string input, string Replacement, object txtInput)
    {
        return input.Replace(Replacement, txtInput.ToString());
    }
    private string ReadNumber(int num)
    {
        switch (num)
        {
            case 1: return "One ";
            case 2: return "Two ";
            case 3: return "Three ";
            case 4: return "Four ";
            case 5: return "Five ";
            default: return "Zero ";
        }
    }
    private int SumText(TextBox[] tbs)
    {
        int sum = 0, num = 0;
        foreach (TextBox item in tbs)
        {
            int.TryParse(item.Text, out num);
            sum += num;
        }
        return sum;
    }
    private void ClearTextBox()
    {
        foreach (Control item in rapContact3.Controls)
        {
            if (item.GetType() == typeof(TextBox))
            {
                ((TextBox)item).Text = string.Empty;
            }
        }
        //txtFullname.Text = string.Empty;
        //txtAddress.Text = string.Empty;
        //drlNationality.Text = string.Empty;
        //txtTelephone.Text = string.Empty;
        //txtEmail.Text = string.Empty;

        //txtGuestOver12.Text = string.Empty;
        //txtGuestUnder12.Text = string.Empty;
        //txtGuestUnder2.Text = string.Empty;

        //txtRoomSingle.Text = string.Empty;
        //txtRoomTwin.Text = string.Empty;
        //txtRoomTriple.Text = string.Empty;
        //txtRequire.Text = string.Empty;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
       
        ClearForm();
    }
    private void LoadDropDownList(DropDownList drl, string type)
    {
        try
        {

            XDocument xmldoc = XDocument.Load(HttpContext.Current.Server.MapPath(string.Format("~/admin/XMLData/RequestQuote_"+Language+".xml")));
            IEnumerable<XElement> q = from xe in xmldoc.Descendants("key") where (string)xe.Attribute("type") == type select xe;
            var dt = new DataTable();
            dt.Columns.Add("name");
            dt.Columns.Add("value");
            foreach (XElement xe in q)
            {
                DataRow row = dt.NewRow();
                row[0] = Server.HtmlDecode(xe.Attribute("name").Value);
                row[1] = Server.HtmlDecode(xe.Attribute("value").Value);
                dt.Rows.Add(row);
            }
            drl.DataSource = dt;
            drl.DataValueField = "value";
            drl.DataTextField = "name";
            drl.DataBind();
        }
        catch (Exception ex)
        {
            LogEvent.LogToFile(ex.ToString());
        }
    }
}
