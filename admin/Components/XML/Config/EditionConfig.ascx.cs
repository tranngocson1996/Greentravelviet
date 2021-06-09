using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using BIC.Handler;
using BIC.Utils;
using BIC.WebControls;

public partial class Admin_Components_Config_EditionConfig : BaseUserControl
{
    protected int Id;
    protected void Page_Load(object sender, EventArgs e)
    {
        Id = BicHtml.GetRequestString("id", 0);
        if (IsPostBack) return;
        LoadXML(Id);
        tbBottom.PAdd = tbTop.PAdd = tbBottom.PDel = tbTop.PDel = false;
    }
    protected void LoadXML(int key)
    {
        if (key != 0)
        {
            try
            {
                XDocument xmldoc = XDocument.Load(HttpContext.Current.Server.MapPath(string.Format("~/admin/XMLData/Config_{0}.xml", BicSession.ToString("Language"))));
                XElement xmlelement = xmldoc.Element("TypeConfig").Elements("type").Single(x => (int?) x.Attribute("datakey") == key);
                txtValue.Text = xmlelement.Attribute("value").Value;
                txtName.Text = xmlelement.Attribute("name").Value;
                ddlType.SelectedValue = xmlelement.Attribute("key").Value;
            }
            catch (Exception ex)
            {
                ltrNote.Text = string.Format("<span class='validate'>[{0}]</span> / ", ex.Message);
                LogEvent.LogToFile(ex.ToString());
            }
        }
    }
    protected void SaveXml(int key)
    {
        if (key != 0)
        {
            try
            {
                string mappath = HttpContext.Current.Server.MapPath(string.Format("~/admin/XMLData/Config_{0}.xml", BicSession.ToString("Language")));
                File.SetAttributes(mappath, FileAttributes.Normal);
                XDocument xmldoc = XDocument.Load(mappath);
                XElement xmlelement = xmldoc.Element("TypeConfig").Elements("type").Single(x => (int?) x.Attribute("datakey") == key);
                xmlelement.Attribute("value").SetValue(Server.HtmlEncode(txtValue.Text));
                xmlelement.Attribute("name").SetValue(txtName.Text);
                xmlelement.Attribute("key").SetValue(ddlType.SelectedValue);
                xmldoc.Save(mappath);
                Page.RegisterClientScriptBlock("cong", string.Format("<script>alert('Cập nhật file thành công.');window.location='{0}';</script>", BicAdmin.UrlList()));
            }
            catch (Exception ex)
            {
                ltrNote.Text = string.Format("<span class='validate'>[{0}]</span> / ", ex.Message);
                LogEvent.LogToFile(ex.ToString());
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