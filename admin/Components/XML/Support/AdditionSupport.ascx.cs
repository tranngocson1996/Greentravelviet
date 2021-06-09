using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using BIC.Utils;
using BIC.WebControls;

public partial class Admin_Components_Support_AdditionSupport : BaseUserControl
{
    protected int Id;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!BicSession.ToString("Language").Equals(""))
        {
            ddlLanguage.SelectedValue = BicSession.ToString("Language");
        }
    }
    protected void SaveXML(int key)
    {
        int newkey = 0;
        try
        {
            string sRealPath = HttpContext.Current.Server.MapPath(string.Format("~/admin/XMLData/LiveSupport_{0}.xml", ddlLanguage.SelectedValue));
            File.SetAttributes(sRealPath, FileAttributes.Normal);
            XDocument xmldoc = XDocument.Load(sRealPath);
            try{newkey = (int)xmldoc.Descendants("LiveSupport").Elements().Last().Attribute("key") + 1;}
            catch (Exception)
            {newkey = 0; }
            bool b = xmldoc.Descendants("LiveSupport").Elements().Attributes("key").Contains(new XAttribute("key", newkey));
            var xkey = new XElement("key", new XAttribute("key", newkey), new XAttribute("name", Server.HtmlEncode(txtName.Text)), new XAttribute("type", ddlType.SelectedValue), new XAttribute("value", Server.HtmlEncode(txtValue.Text)), new XAttribute("description", Server.HtmlEncode(txtDescription.Text)), new XAttribute("phone", Server.HtmlEncode(txtPhone.Text)));
            xmldoc.Element("LiveSupport").Add(xkey);
            xmldoc.Save(HttpContext.Current.Server.MapPath("~/admin/XMLData/LiveSupport_" + ddlLanguage.SelectedValue + ".xml"));
            Clear();
            BicAdmin.NavigateToList();
        }
        catch (Exception ex)
        {
            ltrNote.Text = string.Format("<span class='validate'>[{0}]</span> | ", ex.Message);
        }
    }
    protected void Clear()
    {
        txtName.Text = string.Empty;
        txtValue.Text = string.Empty;
        txtDescription.Text = string.Empty;
    }
    protected void Save(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "Update")
        {
            SaveXML(Id);
        }
    }
    protected void ddlLanguage_SelectedIndexChanged(object o, EventArgs e)
    {
        BicSession.SetValue("Language", ddlLanguage.SelectedValue);
    }
}