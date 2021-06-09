using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using BIC.Utils;
using BIC.WebControls;
using Telerik.Web.UI;

public partial class Admin_Components_Support_ListingSupport : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!BicSession.ToString("Language").Equals(""))
        {
            ddlLanguage.SelectedValue = BicSession.ToString("Language");
        }
        else
        {
            BicSession.SetValue("Language", ddlLanguage.SelectedValue);
        }
        if (!IsPostBack)
        {
  
            radMenuContext.LoadContentFile(string.Format("~/admin/XMLData/Grid/Add_Edit_Delete_" + BicLanguage.CurrentLanguageAdmin + ".xml"));
            radMenuContext.Items[2].Attributes.Add("onclick", string.Format("var as;as=confirm('{0}?');document.getElementById('confirmdelete').value = as;", BicMessage.Delete));
        }
    }
    protected void ddlLanguage_SelectedIndexChanged(object o, EventArgs e)
    {
        BicSession.SetValue("Language", ddlLanguage.SelectedValue);
        GetDataSource();
        rgManager.DataBind();
    }
    public void Loaddata(string filename)
    {
        string mappath = HttpContext.Current.Server.MapPath(string.Format("~/admin/XMLData/{0}", filename));
        XDocument xmldoc = XDocument.Load(mappath);
        IEnumerable<XElement> q = from xe in xmldoc.Descendants("key") where (string)xe.Attribute("type") == ddlType.SelectedValue select xe;
        if (ddlType.SelectedIndex == 0)
        {
            q = from xe in xmldoc.Descendants("key") select xe;
        }
        var dt = new DataTable();
        dt.Columns.Add("key");
        dt.Columns.Add("name");
        dt.Columns.Add("value");
        dt.Columns.Add("description");
        dt.Columns.Add("type");

        foreach (XElement xe in q)
        {
            DataRow row = dt.NewRow();
            row[0] = xe.Attribute("key").Value;
            row[1] = xe.Attribute("name").Value;
            row[2] = xe.Attribute("value").Value;
            row[3] = xe.Attribute("description").Value;
            row[4] = xe.Attribute("type").Value;
            dt.Rows.Add(row); // Thêm dòng mới vào dtb
        }
        rgManager.DataSource = dt;
        rgManager.VirtualItemCount = q.Elements().Count();
    }
    private void GetDataSource()
    {
        Loaddata(string.Format("LiveSupport_{0}.xml", ddlLanguage.SelectedValue));
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
        int key = Convert.ToInt32(rgManager.Items[e.Item.ItemIndex].GetDataKeyValue("key"));
        DeleteXML(key);
        rgManager.DataBind();
    }
    protected void rgManager_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        GetDataSource();
    }
    protected void radMenuContext_ItemClick(object sender, RadMenuEventArgs e)
    {
        int index = Convert.ToInt32(Request.Form["radGridClickedRowIndex"]);
        int id = Convert.ToInt32(rgManager.Items[index].GetDataKeyValue("key"));
        switch (e.Item.Value)
        {
            case "Add":
                BicAdmin.NavigateToAdd();
                break;
            case "Delete":
                bool confirm = Convert.ToBoolean(Request.Form["confirmdelete"]);
                if (confirm)
                {
                    DeleteXML(id);
                    rgManager.Rebind();
                }
                break;
            case "Edit":
                BicAdmin.NavigateToEdit(id.ToString());
                break;
        }
    }
    protected void DeleteXML(int key)
    {
        string sRealPath = HttpContext.Current.Server.MapPath(string.Format("~/admin/XMLData/LiveSupport_{0}.xml", ddlLanguage.SelectedValue));
        File.SetAttributes(sRealPath, FileAttributes.Normal);
        XDocument xmldoc = XDocument.Load(sRealPath);
        XElement xmlelement = xmldoc.Element("LiveSupport").Elements("key").Single(x => (int?)x.Attribute("key") == key);
        xmlelement.Remove();
        xmldoc.Save(sRealPath);
    }
    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetDataSource();
        rgManager.DataBind();
    }
}