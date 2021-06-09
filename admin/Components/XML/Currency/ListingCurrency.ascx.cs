using System;
using System.Data;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using BIC.Utils;
using BIC.WebControls;
using Telerik.Web.UI;
using System.Net;
using System.Xml;

public partial class Admin_Components_Currency_ListingCurrency : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           //radMenuContext.LoadContentFile(string.Format("~/admin/XMLData/Grid/Edit_" + BicLanguage.CurrentLanguageAdmin + ".xml"));
            txtLink.Text = "http://www.vietcombank.com.vn/exchangerates/ExrateXML.aspx";
            txtLink.Enabled = false;
        }
    }
    public void Loaddata(string filename)
    {
        string mappath = HttpContext.Current.Server.MapPath(string.Format("~/admin/XMLData/{0}.xml", filename));
        if (System.IO.File.Exists(mappath))
        {
            XDocument xmldoc = XDocument.Load(mappath);
            var ds = new DataSet();
            ds.ReadXml(mappath);
            rgManager.DataSource = ds.Tables["Exrate"];
            rgManager.VirtualItemCount = xmldoc.Element("ExrateList").Elements("Exrate").Count();
            rgManager.PageSize = 20;
        }
    }
    private void GetDataSource()
    {
        Loaddata("Currency");
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

    protected void btnCapNhat_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtLink.Text))
        {
            var xmldoc = txtLink.Text;
            string mappath = HttpContext.Current.Server.MapPath("~/admin/XMLData/Currency.xml");
            var ds = new DataSet();
            ds.ReadXml(xmldoc);
            if(ds.Tables[0].Rows.Count == 0)
            {
                BicAjax.Alert("Đường dẫn bạn nhập không chính xác.");
            }
            else
            {
                System.IO.File.Delete(mappath);
                ds.WriteXml(mappath);
                GetDataSource();
                rgManager.DataBind();
            }
        }
        else
            BicAjax.Alert("Vui lòng nhập đường dẫn cập nhật xml từ Vietcombank");


    }

    protected void btnChange_Click(object sender, EventArgs e)
    {
        txtLink.Enabled = true;
    }
}