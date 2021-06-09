using System;
using System.Data;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using BIC.Utils;
using BIC.WebControls;
using Telerik.Web.UI;

public partial class Admin_Components_Support_ListingSearchEngine : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           radMenuContext.LoadContentFile(string.Format("~/admin/XMLData/Grid/Edit_" + BicLanguage.CurrentLanguageAdmin + ".xml"));
        }
    }
    public void Loaddata(string filename)
    {
        string mappath = HttpContext.Current.Server.MapPath(string.Format("~/admin/XMLData/{0}.xml", filename));
        XDocument xmldoc = XDocument.Load(mappath);
        var ds = new DataSet();
        ds.ReadXml(mappath);
        rgManager.DataSource = ds.Tables[0];
        rgManager.VirtualItemCount = xmldoc.Element("SearchEngine").Elements("key").Count();
    }
    private void GetDataSource()
    {
        Loaddata("SearchEngine");
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