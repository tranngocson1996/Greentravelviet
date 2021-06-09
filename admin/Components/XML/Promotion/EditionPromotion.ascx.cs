using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using BIC.Utils;
using BIC.WebControls;

public partial class Admin_Components_Promotion_EditionPromotion : BaseUserControl
{
    protected int Id;
    protected void Page_Load(object sender, EventArgs e)
    {
        Id = BicHtml.GetRequestString("id", 0);
        if (IsPostBack) return;
        tbBottom.PAdd = tbTop.PAdd = tbBottom.PDel = tbTop.PDel = false;
        if (!BicSession.ToString("Language").Equals(""))
        {
            ddlLanguage.SelectedValue = BicSession.ToString("Language");
            ddlLanguage.Enabled = false;
        }
        LoadXML(Id);
    }
    protected void LoadXML(int key)
    {
        if (key != 0)
        {
            try
            {
                XDocument xmldoc = XDocument.Load(HttpContext.Current.Server.MapPath(string.Format("~/admin/XMLData/Promotion_{0}.xml", BicSession.ToString("Language"))));
                XElement xmlelement = xmldoc.Element("TypePromotion").Elements("key").Single(x => (int?)x.Attribute("key") == key);
                txtValue.Text = Server.HtmlDecode(xmlelement.Attribute("value").Value);
                //ddlType.SelectedValue = xmlelement.Attribute("type").Value;
                txtName.Text = Server.HtmlDecode(xmlelement.Attribute("name").Value);
                txtDescription.Text = Server.HtmlDecode(xmlelement.Attribute("description").Value);
            }
            catch (Exception ex)
            {
                ltrNote.Text = string.Format("<span class='validate'>[{0}]</span> | ", ex.Message);
            }
        }
    }
    protected void SaveXML(int key)
    {
        if (key != 0)
        {
            try
            {
                string mappath = HttpContext.Current.Server.MapPath(string.Format("~/admin/XMLData/Promotion_{0}.xml", BicSession.ToString("Language")));
                File.SetAttributes(mappath, FileAttributes.Normal);
                XDocument xmldoc = XDocument.Load(mappath);
                XElement xmlelement = xmldoc.Element("TypePromotion").Elements("key").Single(x => (int?)x.Attribute("key") == key);
                xmlelement.Attribute("value").SetValue(Server.HtmlEncode(txtValue.Text));
                //xmlelement.Attribute("type").SetValue(ddlType.SelectedValue);
                xmlelement.Attribute("name").SetValue(Server.HtmlEncode(txtName.Text));
                xmlelement.Attribute("description").SetValue(Server.HtmlEncode(txtDescription.Text));
                xmldoc.Save(mappath);
                Page.RegisterClientScriptBlock("cong", string.Format("<script>alert('Cập nhật file thành công.');window.location='{0}';</script>", BicAdmin.UrlList()));
            }
            catch (Exception ex)
            {
                ltrNote.Text = string.Format("<span class='validate'>[{0}]</span> | ", ex.Message);
            }
        }
    }
    protected void Save(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "Update")
        {
            SaveXML(Id);
        }
    }
}