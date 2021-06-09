using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using BIC.Utils;
using BIC.WebControls;

public partial class Admin_Components_SearchEngine_EditionSearchEngine : BaseUserControl
{
    protected int Id;
    protected void Page_Load(object sender, EventArgs e)
    {
        Id = BicHtml.GetRequestString("id", 0);
        if (IsPostBack) return;
        tbBottom.PAdd = tbTop.PAdd = tbBottom.PDel = tbTop.PDel = false;
        LoadXml(Id);
    }
    protected void LoadXml(int key)
    {
        if (key != 0)
        {
            try
            {
                XDocument xmldoc = XDocument.Load(HttpContext.Current.Server.MapPath("~/admin/XMLData/SearchEngine.xml"));
                XElement xmlelement = xmldoc.Element("SearchEngine").Elements("key").Single(x => (int?) x.Attribute("datakey") == key);
                lblConfigName.Text = Server.HtmlDecode(xmlelement.Attribute("name").Value);
                txtValue.Text = Server.HtmlDecode(xmlelement.Attribute("value").Value);
            }
            catch (Exception ex)
            {
                ltrNote.Text = string.Format("<span class='validate'>[{0}]</span> / ", ex.Message);
            }
        }
    }
    protected void SaveXml(int key)
    {
        if (key != 0)
        {
            try
            {
                string sRealPath = HttpContext.Current.Server.MapPath("~/admin/XMLData/SearchEngine.xml");
                File.SetAttributes(sRealPath, FileAttributes.Normal);
                XDocument xmldoc = XDocument.Load(sRealPath);
                XElement xmlelement = xmldoc.Element("SearchEngine").Elements("key").Single(x => (int?) x.Attribute("datakey") == key);
                xmlelement.Attribute("value").SetValue(HttpUtility.HtmlEncode(txtValue.Text));
                xmldoc.Save(sRealPath);
                Page.RegisterClientScriptBlock("cong", string.Format("<script>alert('Cập nhật file thành công.');window.location='{0}';</script>", BicAdmin.UrlList()));
            }
            catch (Exception ex)
            {
                ltrNote.Text = string.Format("<span class='validate'>[{0}]</span> / ", ex.Message);
            }
        }
    }
    protected void Save(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "Update")
        {
            SaveXml(Id);
        }
    }
}