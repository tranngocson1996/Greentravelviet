using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;
using Telerik.Web.UI;

public partial class Admin_Components_Product_EditionProduct : BaseUserControl
{
    private int _id;

    protected void Page_Load(object sender, EventArgs e)
    {
        _id = BicHtml.GetRequestString("id", 0);
        if (!IsPostBack)
        {
            chkIsActive.Enabled = Approved;
            //BicXML.BindDropDownListFromXML(ddlTintieudiem, "~/admin/XMLData/Tintieudiem.xml");
            //BicXML.BindDropDownListFromXML(ddlTypeproducts, "~/admin/XMLData/ModelNews.xml");
            //ProductBiz.PositionWithPriorityEdit(ddlPosition);
            LoadDataFromEntity();
            ucCommentProduct.ProductID = _id;
        }
        RelatedProduct1.Lang = RelatedArticle.Lang = ddlLanguage.SelectedValue;
    }

    public void RemoveCache()
    {
        var keyList = new List<string>();
        IDictionaryEnumerator cacheEnum = HttpContext.Current.Cache.GetEnumerator();
        while (cacheEnum.MoveNext())
        {
            keyList.Add(cacheEnum.Key.ToString());
        }
        foreach (string key in keyList)
        {
            HttpContext.Current.Cache.Remove(key);
        }
    }

    private void LoadDataFromEntity()
    {
        BizObject.PurgeCacheItems("IDProduct_Product_" + _id); //clear cache bài viết trước khi lấy dữ liệu ra
        ProductEntity productEntity = ProductBiz.GetProductByID(_id);
        if (productEntity == null) return;
        txtTitle.Text = BicConvert.ToString(productEntity.Title);
        reBriefDescription.Content = BicConvert.ToString(productEntity.BriefDescription);
        reBody.Content = BicConvert.ToString(productEntity.Body);

        isImageId.ImageID = BicConvert.ToString(productEntity.ImageID);
        isVideoID.VideoID = BicConvert.ToString(productEntity.VideoID);
        txtViewCount.Text = BicConvert.ToString(productEntity.ViewCount);
        txtLink.Text = BicConvert.ToString(productEntity.Link);
        chkCommentEnable.Checked = BicConvert.ToBoolean(productEntity.CommentsEnabled);
        ismImageId.ImageIDArray = productEntity.ImageArray;
        ddlTypeproducts.SelectedValue = productEntity.TypeOfControl.ToString();
        chkNew.Checked = BicConvert.ToBoolean(productEntity.IsNew);
        chkIsActive.Checked = BicConvert.ToBoolean(productEntity.IsActive);
        ddlLanguage.SelectedValue = productEntity.LanguageKey;
        cbTarget.SelectedValue = productEntity.Target;
        txtPageTitle.Text = productEntity.PageTitle;
        txtSeoTitle.Text = productEntity.SeoTitle;
        chkIsFull.Checked = productEntity.IsFull;
        txtTag.Text = productEntity.Tag;
        ddlTintieudiem.SelectedValue = productEntity.TinTieuDiem.ToString();
        txtMetaDescription.Text = productEntity.MetaDescription;
        txtMetaKeyword.Text = productEntity.MetaKeyWord;
        ntxPosition.Text = productEntity.Priority.ToString();
        txtAllowUser.Text = productEntity.AllowUsers;
        //Thuộc tính sản phẩm
        txtCode.Text = productEntity.Code;
        txtPrice.Text = productEntity.Price;
        txtOldPrice.Text = productEntity.OldPrice;
        chkOutOfStock.Checked = BicConvert.ToBoolean(productEntity.OutOfStock);
        txtSaleOff.Text = productEntity.SaleOff;
        txtManufactory.Text = productEntity.Manufactory;

        //Thuộc tính mới
        txtBaoHanh.Text = productEntity.ImageArray2;
        reNewColumn1.Content = BicConvert.ToString(productEntity.NewColumn1);
        reNewColumn2.Content = BicConvert.ToString(productEntity.NewColumn2);
        reNewColumn3.Content = BicConvert.ToString(productEntity.NewColumn3);
        reNewColumn4.Content = BicConvert.ToString(productEntity.NewColumn4);


        MenuUserUtils.BindingRadTreeView(tvMenuUser, ddlLanguage.SelectedValue, "products", "cot1");
        MenuUserUtils.BindingRadTreeView(RadTreeView1, ddlLanguage.SelectedValue, "products", "cot2");
        MenuUserUtils.BindingRadTreeView(RadTreeView2, ddlLanguage.SelectedValue, "products", "cot3");

        MenuUserUtils.SetCheckedNodes(tvMenuUser, productEntity.MenuUserID);
        MenuUserUtils.SetCheckedNodes(RadTreeView1, productEntity.MenuUserID);
        MenuUserUtils.SetCheckedNodes(RadTreeView2, productEntity.MenuUserID);
        RadTreeView1.ExpandAllNodes();
        RadTreeView2.ExpandAllNodes();
        hdTreeMenu.Value = productEntity.MenuUserID;
        reBody.CssFiles.Add(productEntity.IsFull
            ? new EditorCssFile("~/BICSkins/BICCMS/Editor/EditorContentAreaStylesFull.css")
            : new EditorCssFile("~/BICSkins/BICCMS/Editor/EditorContentAreaStyles.css"));
    }

    private ProductEntity LoadDataToEntity()
    {
        ProductEntity productEntity = ProductBiz.GetProductByID(_id);

        productEntity.ProductID = BicHtml.GetRequestString("id", 0);
        productEntity.Title = txtTitle.Text;
        productEntity.LanguageKey = ddlLanguage.SelectedValue;
        productEntity.BriefDescription = Server.HtmlDecode(reBriefDescription.Content);
        productEntity.Body = Server.HtmlDecode(reBody.Content);
        productEntity.CreatedDate = DateTime.Now;
        productEntity.MenuUserID = "," + BicString.Trim(hdTreeMenu.Value.Replace(",,", ",")) + ",";
        productEntity.CommentsEnabled = chkCommentEnable.Checked;
        productEntity.IsHome = chkIsHome.Checked;
        productEntity.IsActive = chkIsActive.Checked;
        productEntity.IsNew = chkNew.Checked;
        productEntity.ImageID = BicConvert.ToInt32(isImageId.ImageID);
        productEntity.Priority = BicConvert.ToInt32(ntxPosition.Text);
        productEntity.Target = cbTarget.SelectedValue;
        productEntity.Link = txtLink.Text;
        productEntity.CreatedBy = HttpContext.Current.User.Identity.Name;
        productEntity.ModifiedBy = HttpContext.Current.User.Identity.Name;
        productEntity.AllowUsers = txtAllowUser.Text;
        productEntity.ViewCount = BicConvert.ToInt32(txtViewCount.Text);
        productEntity.PageTitle = txtPageTitle.Text;
        productEntity.SeoTitle = txtSeoTitle.Text;
        productEntity.Tag = txtTag.Text;
        productEntity.TinTieuDiem = BicConvert.ToInt32(ddlTintieudiem.SelectedValue);
        productEntity.TinLienQuan = "";
        productEntity.SanPhamLienQuan = "";
        productEntity.ImageArray = ismImageId.ImageIDArray;
        productEntity.TypeOfControl = BicConvert.ToInt32(ddlTypeproducts.SelectedValue);
        productEntity.VideoID = BicConvert.ToInt32(isVideoID.VideoID);
        productEntity.VideoArray = "";
        productEntity.MetaDescription = txtMetaDescription.Text;
        productEntity.MetaKeyWord = txtMetaKeyword.Text;
        productEntity.IsFull = chkIsFull.Checked;
        //Thuộc tính
        productEntity.Code = txtCode.Text;
        productEntity.Price = txtPrice.Text;
        productEntity.OldPrice = txtOldPrice.Text;
        productEntity.OutOfStock = chkOutOfStock.Checked;
        productEntity.SaleOff = txtSaleOff.Text;
        productEntity.Manufactory = txtManufactory.Text;
        productEntity.Source = "";

        //Thuộc tính mới
        productEntity.ImageArray2 = txtBaoHanh.Text;
        productEntity.NewColumn1 = Server.HtmlDecode(reNewColumn1.Content);
        productEntity.NewColumn2 = Server.HtmlDecode(reNewColumn2.Content);
        productEntity.NewColumn3 = Server.HtmlDecode(reNewColumn3.Content);
        productEntity.NewColumn4 = Server.HtmlDecode(reNewColumn4.Content);
        productEntity.NewColumn5 = "";
        productEntity.NewColumn6 = "";

        return productEntity;
    }

    private void SaveTags(string tags, int ID)
    {
        string[] arrTag = tags.Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
        TagEntity tag;
        string[] oldTags = ProductBiz.GetProductByID(ID).Tag.Split(new[] { ',', ';' },
            StringSplitOptions.RemoveEmptyEntries);
        foreach (string item in arrTag)
        {
            if (Array.IndexOf(oldTags, item) < 0)
            {
                tag = TagBiz.GetTagByKey(item.Trim().ToLower(), 1);
                if (tag != null)
                {
                    tag.Id += ID + ",";
                    TagBiz.UpdateTag(tag);
                }
                else
                {
                    tag = new TagEntity
                    {
                        Id = "," + ID + ",",
                        Keyword = item.Trim().ToLower(),
                        IsActive = true,
                        Priority = 1,
                        TypeID = 1,
                    };
                    TagBiz.InsertTag(tag);
                }
            }
        }
        foreach (string item in oldTags)
        {
            if (Array.IndexOf(arrTag, item) < 0)
            {
                tag = TagBiz.GetTagByKey(item, 1);
                if (tag != null)
                {
                    tag.Id = tag.Id.Replace("," + ID + ",", ",");
                    TagBiz.UpdateTag(tag);
                }
            }
        }
    }

    protected void Save(object sender, CommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Update")
            {
                if (tvMenuUser.CheckedNodes.Count == 0 && RadTreeView1.CheckedNodes.Count == 0 &&
                    RadTreeView2.CheckedNodes.Count == 0)
                {
                    BicAjax.Alert(string.Format(BicResource.GetValue("Admin", "Admin_Product_Message1")));
                }
                else
                {
                    ProductEntity product = LoadDataToEntity();
                    SaveTags(txtTag.Text, product.ProductID);
                    ProductBiz.UpdateProduct(product);
                    RemoveCache();
                    BicAdmin.NavigateToList();
                }
            }
        }
        catch (Exception ex)
        {
            BicAjax.Alert(ex.Message);
        }
    }

    protected void ddlLanguage_SelectedIndexChanged(object o, EventArgs e)
    {
        BicSession.SetValue("ProductLanguage", ddlLanguage.SelectedValue);
        MenuUserUtils.BindingRadTreeView(tvMenuUser, ddlLanguage.SelectedValue, "products", "cot1");
        MenuUserUtils.BindingRadTreeView(RadTreeView1, ddlLanguage.SelectedValue, "products", "cot2");
        MenuUserUtils.BindingRadTreeView(RadTreeView2, ddlLanguage.SelectedValue, "products", "cot3");
        RelatedProduct1.Lang = RelatedArticle.Lang = ddlLanguage.SelectedValue;
    }
}