using System;
using System.Data;
using BIC.Utils;
using BIC.WebControls;
using Telerik.Web.UI;

public partial class Admin_Components_Support_ListingMailConfig : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            radMenuContext.LoadContentFile(string.Format("~/admin/XMLData/Grid/Edit_"+BicLanguage.CurrentLanguageAdmin+".xml"));
        }
    }
    public void Loaddata(string filename)
    {
        var xml = new BicXML();
        xml.XmlPath = "~/admin/XMLData/" + filename;
        DataSet dt = xml.GetXMLContent();
        rgManager.DataSource = dt;
    }
    private void GetDataSource()
    {
        Loaddata("MailConfig.xml");
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
            case "Edit":
                BicAdmin.NavigateToEdit(id.ToString());
                break;
        }
    }
}