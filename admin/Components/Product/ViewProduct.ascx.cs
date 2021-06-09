using System;
using System.Linq;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Admin_Components_Product_ViewProduct : BaseUserControl
{
    public int Id;

    protected void Page_Load(object sender, EventArgs e)
    {
        Id = BicHtml.GetRequestString("id", 0);
        if (IsPostBack) return;
        LoadDataFromEntity();
        tbBottom.PEdit = tbBottom.PDel = tbTop.PEdit = tbTop.PDel = Approved;
    }

    protected string GetNameMenu(string menus)
    {
        string result = string.Empty;
        string[] arrmenu = BicString.SplitComma(menus);
        result = arrmenu.Where(s => !string.IsNullOrWhiteSpace(s))
            .Aggregate(result, (current, s) => current + (MenuUserBiz.GetNameById(BicConvert.ToInt32(s)) + ", "));
        if (result.Length > 2)
            result = result.Remove(result.Length - 2, 2);
        return result;
    }

    protected string GetNameCategory(string categories)
    {
        string result = string.Empty;
        string[] arr = BicString.SplitComma(categories);
        result = arr.Where(s => !string.IsNullOrWhiteSpace(s))
            .Aggregate(result, (current, s) => current + (BicXML.ToString(s, "ModelNews_vi") + ", "));
        if (result.Length > 2)
            result = result.Remove(result.Length - 2, 2);
        return result;
    }

    private void LoadDataFromEntity()
    {
        ProductEntity productEntity = ProductBiz.GetProductByID(Id);
        if (productEntity == null) return;
        litTitle.Text = BicConvert.ToString(productEntity.Title);
        litBriefDescription.Text = BicConvert.ToString(productEntity.BriefDescription);
        litBody.Text = BicConvert.ToString(productEntity.Body);
        litMenuUser.Text = GetNameMenu(productEntity.MenuUserID);
        BicImage.ViewImageFix(htmlImage, productEntity.ImageID, 102, 66, true);
        aImage.HRef = BicImage.GetPathImage(productEntity.ImageID);
        txtSource.Text = BicConvert.ToString(productEntity.Source);
        txtViewCount.Text = BicConvert.ToString(productEntity.ViewCount);
        txtLink.Text = BicConvert.ToString(productEntity.Link);
        chkCommentEnable.Checked = BicConvert.ToBoolean(productEntity.CommentsEnabled);
        chkIsHome.Checked = BicConvert.ToBoolean(productEntity.IsHome);
        chkIsNew.Checked = BicConvert.ToBoolean(productEntity.IsNew);
        chkIsActive.Checked = BicConvert.ToBoolean(productEntity.IsActive);
        cbTarget.SelectedValue = BicConvert.ToString(productEntity.Target);
    }
}