using System;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Controls_Tools_PrintProduct : BaseUIControl
{
    protected int Id;

    protected void Page_Load(object sender, EventArgs e)
    {
        Id = BicRouting.GetRequestString("id", 0);
        if (!IsPostBack)
            BindingProductDetail();
    }

    protected void BindingProductDetail()
    {
        ProductEntity prodEntity = ProductBiz.GetProductByID(Id);
        if (prodEntity != null)
        {
            Page.Title = string.Format("{1} - {0}", prodEntity.Title,
                                       BicXML.ToString("PrefixArticle", "SearchEngine"));

            lblProduct.Text = prodEntity.Title;
            ltlBody.Text = prodEntity.Body;
        }
        else
            Page.Visible = false;
    }
}