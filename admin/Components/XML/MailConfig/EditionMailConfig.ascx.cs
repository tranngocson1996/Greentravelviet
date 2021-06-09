using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using BIC.Utils;
using BIC.WebControls;

public partial class Admin_Components_Support_EditionSupport : BaseUserControl
{
    protected int Id;
    protected void Page_Load(object sender, EventArgs e)
    {
        Id = BicHtml.GetRequestString("id", 0);
        if (!IsPostBack)
        {
            tbBottom.PAdd = tbTop.PAdd = tbBottom.PDel = tbTop.PDel = false;
            LoadXML(Id);
        }
    }
    protected void LoadXML(int key)
    {
        if (key != 0)
        {
            try
            {
                XDocument xmldoc = XDocument.Load(HttpContext.Current.Server.MapPath("~/admin/XMLData/MailConfig.xml"));
                XElement xmlelement = xmldoc.Element("MailConfig").Elements("type").Single(x => (int?) x.Attribute("datakey") == key);
                if (key != 6)
                {
                    divPass.Visible = false;
                    divPass2.Visible = false;
                    lblConfigName.Text = xmlelement.Attribute("name").Value;
                    txtValue.Text = xmlelement.Attribute("value").Value;
                }
                else
                {
                    divNotPass.Visible = false;
                    lblConfigName.Text = xmlelement.Attribute("name").Value;
                    txtPass1.Text = xmlelement.Attribute("value").Value;
                    if (xmlelement.Attribute("value").Value != string.Empty)
                    {
                        ltrNote.Text = "<span class='validate'>["+string.Format(BicResource.GetValue("Admin","Admin_XML_MailConfig_ConfiguredPassword")) + "]</span> |";
                    }
                }
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
                string sRealPath = HttpContext.Current.Server.MapPath("~/admin/XMLData/MailConfig.xml");
                File.SetAttributes(sRealPath, FileAttributes.Normal);
                if (key != 6)
                {
                    XDocument xmldoc = XDocument.Load(sRealPath);
                    XElement xmlelement = xmldoc.Element("MailConfig").Elements("type").Single(x => (int?) x.Attribute("datakey") == key);
                    xmlelement.Attribute("value").SetValue(Server.HtmlEncode(txtValue.Text));
                    xmldoc.Save(sRealPath);
                    Page.RegisterClientScriptBlock("cong", string.Format("<script>alert('Cập nhật file thành công.');window.location='{0}';</script>", BicAdmin.UrlList()));
                }
                else
                {
                    if (!txtPass1.Text.Equals(string.Empty))
                    {
                        XDocument xmldoc = XDocument.Load(sRealPath);
                        XElement xmlelement = xmldoc.Element("MailConfig").Elements("type").Single(x => (int?) x.Attribute("datakey") == key);
                        xmlelement.Attribute("value").SetValue(BicSecurity.Encrypt(txtPass1.Text, true));
                        xmldoc.Save(sRealPath);
                        Page.RegisterClientScriptBlock("cong", string.Format("<script>alert('Cập nhật file thành công.');window.location='{0}';</script>", BicAdmin.UrlList()));
                    }
                    else
                    {
                        ltrNote.Text = "[" + string.Format(BicResource.GetValue("Admin", "Admin_XML_MailConfig_YouHaveNotEnteredAPassword")) + "]";
                    }
                }
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