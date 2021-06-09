using System;
using System.Data;
using System.IO;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Data;
using BIC.Entity;
using BIC.Handler;
using BIC.Utils;
using BIC.WebControls;

public partial class admin_Components_ImageGallery_ImageManager : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ImageTypeBiz.BuildImageTypeTree(ddlImageTypeID);
            ddlImageTypeID.SelectedIndex = BicSession.ToInt32("SelectCategoryImage");
            hdfLangManager.Value = BicHtml.GetRequestString("l") == ""
                ? BicXML.ToString("DefaultLanguageAdmin", "SearchEngine")
                : BicHtml.GetRequestString("l");
            BinddingImageManager();
        }
    }

    public void BinddingImageManager()
    {
        var data = new BicGetData();
        data.Selecting.Add(ImageEntity.FIELD_IMAGEID);
        data.Selecting.Add(ImageEntity.FIELD_WIDTH);
        data.Selecting.Add(ImageEntity.FIELD_HEIGHT);
        data.Selecting.Add(ImageEntity.FIELD_NAME);
        data.Selecting.Add(ImageEntity.FIELD_PATH);
        data.Sorting.Add(new SortingItem(ImageEntity.FIELD_CREATEDDATE, true));
        if (ddlImageTypeID.SelectedValue != "0")
            data.Conditioning.Add(new ConditioningItem(ImageEntity.FIELD_IMAGETYPEID, ddlImageTypeID.SelectedValue,
                Operator.EQUAL, CompareType.NUMERIC));
        if (txtName.Text != string.Empty)
        {
            data.Conditioning.Add(new ConditioningItem(ImageEntity.FIELD_NAME,
                string.Format("%{0}%", BicString.Trim(txtName.Text)), Operator.LIKE, CompareType.STRING));
        }
        if (!BicMemberShip.CurrentUserName.Equals("administrator") &&
            !Roles.IsUserInRole(BicMemberShip.CurrentUserName, "Administrator"))
        {
            data.Conditioning.Add(new ConditioningItem(ImageEntity.FIELD_USERNAME, BicMemberShip.CurrentUserName,
                Operator.EQUAL, CompareType.STRING));
        }

        Pager1.PageIndex = BicSession.ToInt32("SelectedIndexImage");

        data.PageIndex = Pager1.PageIndex;
        data.TableName = "Image";
        data.PageSize = Pager1.PageSize;
        dlImage.DataSource = data.GetPagingData();
        dlImage.DataBind();
        Pager1.TotalItems = data.TotalItems;
        if (txtName.Text != string.Empty)
            lblMessage.Text = string.Format("<b>Kết quả tìm kiếm: </b>Tìm được><b> {0} ảnh</b> với tên <b>\"{1}\"</b>",
                data.TotalItems, BicConvert.ToString(txtName.Text));
        else
            lblMessage.Text = @"<b>" + BicResource.GetValue("Admin", "Admin_Gallery_Anhduoctailengandaynhat") + "</b>";
        if (data.TotalItems <= Pager1.PageSize && Pager1.PageIndex == 0)
            Pager1.Visible = false;
        else
            Pager1.Visible = true;
    }

    //Action of datalist control
    protected void Action(object sender, CommandEventArgs e)
    {
        try
        {
            int imageId = BicConvert.ToInt32(e.CommandArgument);
            ImageEntity imageEntity = ImageBiz.GetImageByID(imageId);
            if (e.CommandName.Equals("Delete"))
            {
                if (imageEntity != null)
                {
                    if (!string.IsNullOrEmpty(imageEntity.Name))
                    {
                        string pathfile = BicApplication.URLPath(imageEntity.Path) + imageEntity.Name;
                        string paththumb = BicApplication.URLPath(imageEntity.Path + "thumb") + imageEntity.Name;
                        string realfile = BicApplication.RealPath + imageEntity.Path + imageEntity.Name;
                        string realthumb = BicApplication.RealPath + imageEntity.Path + "thumb/" + imageEntity.Name;
                        if (File.Exists(realfile))
                        {
                            if (BicFile.Delete(pathfile, realfile))
                            {
                                if (File.Exists(realthumb))
                                {
                                    if (BicFile.Delete(paththumb, realthumb))
                                    {
                                        if (ImageBiz.DeleteImage(BicConvert.ToInt32(imageId)))
                                            BinddingImageManager();
                                    }
                                }
                                else
                                {
                                    if (ImageBiz.DeleteImage(BicConvert.ToInt32(imageId)))
                                        BinddingImageManager();
                                }
                            }
                        }
                        else
                        {
                            if (File.Exists(realthumb))
                            {
                                if (BicFile.Delete(paththumb, realthumb))
                                {
                                    if (ImageBiz.DeleteImage(BicConvert.ToInt32(imageId)))
                                        BinddingImageManager();
                                }
                            }
                            else
                            {
                                if (ImageBiz.DeleteImage(BicConvert.ToInt32(imageId)))
                                    BinddingImageManager();
                            }
                        }
                    }
                    else
                    {
                        if (ImageBiz.DeleteImage(imageId))
                            BinddingImageManager();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            LogEvent.LogToFile(ex.ToString());
        }
    }

    protected void Pager1_PageIndexChanged(object sender, PagerUIEventArgs e)
    {
        BicSession.SetValue("SelectedIndexImage", Pager1.PageIndex);
        BinddingImageManager();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BinddingImageManager();
        Pager1.PageIndex = 0;
    }

    protected void txtName_TextChanged(object sender, EventArgs e)
    {
        BinddingImageManager();
        Pager1.PageIndex = 0;
        txtName.Focus();
    }

    protected void ddlImageTypeID_SelectedIndexChanged(object sender, EventArgs e)
    {
        BinddingImageManager();
        Pager1.PageIndex = 0;
        txtName.Focus();
        BicSession.SetValue("SelectCategoryImage", ddlImageTypeID.SelectedIndex);
    }

    protected void dlImage_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        //if (e.Item.DataItemIndex != -1 && e.Item.DataItemIndex != ListItemType.Separator)
        //{
        var myHtmlImage = (HtmlImage) e.Item.FindControl("htmlImage");
        var fullExpand = (HtmlAnchor) e.Item.FindControl("fullExpand");
        var drv = (DataRowView) e.Item.DataItem;
        if (drv == null) return;
        int id = BicConvert.ToInt32(drv[ImageEntity.FIELD_IMAGEID]);
        string width = BicConvert.ToString(drv[ImageEntity.FIELD_WIDTH]);
        string height = BicConvert.ToString(drv[ImageEntity.FIELD_HEIGHT]);
        string path = !string.IsNullOrEmpty(BicConvert.ToString(drv[ImageEntity.FIELD_NAME]))
            ? (BicApplication.URLPath(BicConvert.ToString(drv[ImageEntity.FIELD_PATH])) +
               BicConvert.ToString(drv[ImageEntity.FIELD_NAME]))
            : BicConvert.ToString(drv[ImageEntity.FIELD_PATH]);
        //Sự kiện khi click vào ảnh -> Trả về Id ảnh cho một control
        //myHtmlImage.Attributes.Add("ondblclick", string.Format("returnImage('{0}','{1}','{2}','{3}');", id, width, height, path));
        myHtmlImage.Attributes.Add("ondblclick",
            string.Format("return ImageClick('{0}','{1}','{2}','{3}');", id, width, height, path));
        //Thiết lập sự kiện xem ảnh lớn
        fullExpand.HRef = path;
        fullExpand.Attributes.Add("onclick",
            "return hs.expand(this,{ wrapperClassName: 'highslide-no-border',align: 'center' })");
        //Gọi phương thức hiển thị ảnh
        if (!string.IsNullOrEmpty(BicConvert.ToString(drv[ImageEntity.FIELD_NAME])))
            BicImage.ViewImage(myHtmlImage, id, 100, 100, true);
        else
            myHtmlImage.Src = path;
        //}
    }
}