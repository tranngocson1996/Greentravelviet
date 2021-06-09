using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using BIC.Utils;
using BIC.WebControls;
using Telerik.Web.UI;

public partial class Admin_Components_Config_ListingConfig : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BicSession.SetValue("Language", ddlLanguage.SelectedValue);

            radMenuContext.LoadContentFile(string.Format("~/admin/XMLData/Grid/Edit_" + BicLanguage.CurrentLanguageAdmin + ".xml"));
        }
    }
    protected void ddlLanguage_SelectedIndexChanged(object o, EventArgs e)
    {
        BicSession.SetValue("Language", ddlLanguage.SelectedValue);
        GetDataSource();
        rgManager.DataBind();
    }
    private void GetDataSource()
    {
        var xml = new BicXML();
        xml.XmlPath = "~/admin/XMLData/" + string.Format("Config_{0}.xml", ddlLanguage.SelectedValue);
        if (!string.IsNullOrEmpty(ddlType.SelectedValue))
            rgManager.DataSource = xml.GetXMLContent().Tables[0].Select("type='" + ddlType.SelectedValue + "'");
        else
            rgManager.DataSource = xml.GetXMLContent();
    }
    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetDataSource();
        rgManager.DataBind();
    }
    protected void txtSearch_TextChanged(object sender, EventArgs e)
    {
        GetDataSource();
        rgManager.DataBind();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        GetDataSource();
        rgManager.DataBind();
    }
    protected void rgManager_DeleteCommand(object source, GridCommandEventArgs e)
    {
        int id = BicConvert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["datakey"]);
        rgManager.DataBind();
    }
    protected void rgManager_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        GetDataSource();
    }
    protected void radMenuContext_ItemClick(object sender, RadMenuEventArgs e)
    {
        int index = Convert.ToInt32(Request.Form["radGridClickedRowIndex"]);
        int id = Convert.ToInt32(rgManager.Items[index].GetDataKeyValue("datakey"));
        switch (e.Item.Value)
        {
            case "Add":
                BicAdmin.NavigateToAdd();
                break;
            case "View":
                BicAdmin.NavigateToView(id.ToString());
                break;
            case "Delete":
                bool confirm = Convert.ToBoolean(Request.Form["confirmdelete"]);
                if (confirm)
                {
                    rgManager.Rebind();
                    DeleteXML(id);
                }
                break;
            case "Edit":
                BicAdmin.NavigateToEdit(id.ToString());
                break;
        }
    }
    protected void DeleteXML(int key)
    {
        string mappath = HttpContext.Current.Server.MapPath(string.Format("~/admin/XMLData/Config_{0}.xml", ddlLanguage.SelectedValue));
        File.SetAttributes(mappath, FileAttributes.Normal);
        XDocument xmldoc = XDocument.Load(mappath);
        XElement xmlelement = xmldoc.Element("TypeConfig").Elements("type").Single(x => (int?) x.Attribute("datakey") == key);
        xmlelement.Remove();
        xmldoc.Save(mappath);
    }
}