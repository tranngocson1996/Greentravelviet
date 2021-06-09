using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using BIC.Data;
using BIC.Utils;
using BIC.WebControls;

public partial class admin_Components_Product_RelatedProduct : UserControl
{
    public string Lang
    {
        get
        {
            object obj = ViewState["LanguageKey"];
            return string.IsNullOrEmpty(Convert.ToString(obj)) ? string.Empty : (string) obj;
        }
        set { ViewState["LanguageKey"] = value; }
    }

    private DataTable RelatedList
    {
        get { return (DataTable) ViewState["RelatedProduct"]; }
        set { ViewState["RelatedProduct"] = value; }
    }

    public int totalItem
    {
        get { return BicConvert.ToInt32(ViewState["TotalItem"]); }
        set { ViewState["TotalItem"] = value; }
    }

    public string RelatedProductId
    {
        get
        {
            object obj = ViewState["RelatedProductId"];
            return string.IsNullOrEmpty(Convert.ToString(obj)) ? string.Empty : (string) obj;
        }
        set { ViewState["RelatedProductId"] = value; }
    }

    public ArrayList RelatedProductIds
    {
        get
        {
            var a = new ArrayList();
            a.AddRange(RelatedProductId.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries));
            return a;
        }
    }

    public string MenuUserId
    {
        set { lvRelatedProduct.MenuUserId = value; }
    }

    private DataTable LoadProduct()
    {
        if (string.IsNullOrEmpty(RelatedProductId))
            return null;
        var bicData = new BicGetData("Product");
        bicData.Selecting.Add("ProductId,Title");
        bicData.Conditioning.Add(new ConditioningItem
        {
            Query = "ProductId in (" + RelatedProductId + ")",
            TypeOfCondition = TypeOfCondition.QUERY
        });
        bicData.Sorting.Add(
            new SortingItem("(CharIndex(',' + CONVERT(NVARCHAR,ProductId) +',','," + RelatedProductId + ",'))", false));
        return bicData.GetAllData();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (RelatedList == null)
            {
                RelatedList = LoadProduct();
                if (RelatedList == null || RelatedList.Rows.Count == 0)
                {
                    RelatedList = new DataTable();
                    RelatedList.Columns.Add("ProductId");
                    RelatedList.Columns.Add("Title");
                }
                lvProduct.DataSource = RelatedList;
                lvProduct.DataBind();
            }
            GetValue();
        }
        pRelatedProduct.PageIndex = lvRelatedProduct.PageIndex;
        pRelatedProduct.PageSize = lvRelatedProduct.PageSize;
        pRelatedProduct.TotalItems = totalItem;
    }

    public void GetValue()
    {
        lvRelatedProduct.IgnoreProductId = BicHtml.GetRequestString("id", "0");
        if (!string.IsNullOrEmpty(txtFilter.Text.Trim()))
        {
            lvRelatedProduct.QueryCondition = string.Format("LanguageKey = '{0}' and Title like N'%{1}%'", Lang,
                txtFilter.Text.Trim());
        }
        else
        {
            lvRelatedProduct.QueryCondition = string.Format("LanguageKey = '{0}' ", Lang);
        }
        lvRelatedProduct.LoadData();
        totalItem = lvRelatedProduct.TotalItem;
    }

    protected void pRelatedProduct_OnPageIndexChanged(object sender, PagerUIEventArgs e)
    {
        lvRelatedProduct.PageIndex = pRelatedProduct.PageIndex = e.NewPageIndex;
        GetValue();
    }

    protected void BtSearchClick(object sender, EventArgs e)
    {
        GetValue();
        lvRelatedProduct.PageIndex = pRelatedProduct.PageIndex = 0;
        pRelatedProduct.PageSize = lvRelatedProduct.PageSize;
        pRelatedProduct.TotalItems = totalItem;
    }

    protected void lvRelatedProduct_OnItemDataBound(object sender, ListViewItemEventArgs e)
    {
        var drv = (DataRowView) e.Item.DataItem;
        var chk = (CheckBox) e.Item.FindControl("chkRelated");
        if (drv != null)
        {
            chk.Checked = (RelatedProductIds.IndexOf(drv["ProductId"].ToString()) >= 0);
        }
    }

    protected void chkRelated_OnCheckedChanged(object sender, EventArgs e)
    {
        var relatedProductIds = new ArrayList();
        relatedProductIds.AddRange(RelatedProductIds);
        var chk = (CheckBox) sender;
        DataRow dr;
        if (!chk.Checked)
        {
            dr = RelatedList.Rows[relatedProductIds.IndexOf(chk.Attributes["Value"])];
            if (dr != null)
            {
                RelatedList.Rows.Remove(dr);
            }
            relatedProductIds.Remove(chk.Attributes["Value"]);
        }
        else
        {
            string s = chk.Attributes["Value"];
            relatedProductIds.Add(s);
            dr = RelatedList.NewRow();
            dr["ProductId"] = s;
            dr["Title"] = chk.Attributes["Title"];
            RelatedList.Rows.Add(dr);
        }
        RelatedProductId = relatedProductIds.ToArray()
            .Aggregate(string.Empty,
                (current, productId) => current + ((current == string.Empty ? "" : ",") + productId));
        lvProduct.DataSource = RelatedList;
        lvProduct.DataBind();
    }

    protected void productRemove_Command(object sender, CommandEventArgs e)
    {
        var relatedProductIds = new ArrayList();
        relatedProductIds.AddRange(RelatedProductIds);
        DataRow dr = RelatedList.Rows[Convert.ToInt32(e.CommandName)];
        if (dr != null)
        {
            RelatedList.Rows.Remove(dr);
        }
        relatedProductIds.Remove(e.CommandArgument.ToString());
        RelatedProductId = relatedProductIds.ToArray()
            .Aggregate(string.Empty,
                (current, productId) => current + ((current == string.Empty ? "" : ",") + productId));
        lvProduct.DataSource = RelatedList;
        lvProduct.DataBind();
    }

    protected void Unnamed_Click(object sender, EventArgs e)
    {
        listSelect.Visible = false;
        overlay.Visible = false;
    }

    protected void Unnamed_Click1(object sender, EventArgs e)
    {
        listSelect.Visible = true;
        overlay.Visible = true;
        GetValue();
    }
}