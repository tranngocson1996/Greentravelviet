using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Data;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class admin_Components_Video_VideoManager : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            VideoCategoryBiz.BuildVideoCategoryTree(ddlVideoCategoryID);
            BinddingImageManager();
            Session["VideoID"] = null;
        }
    }
    public void BinddingImageManager()
    {
        var data = new BicGetData { PageIndex = Pager1.PageIndex, TableName = "Video", PageSize = Pager1.PageSize };
        data.Selecting.Add(VideoEntity.FIELD_VIDEOID);
        data.Selecting.Add(VideoEntity.FIELD_IMAGEID);
        data.Selecting.Add(VideoEntity.FIELD_NAME);
        data.Selecting.Add(VideoEntity.FIELD_PATH);
        data.Selecting.Add(VideoEntity.FIELD_URL);
        data.Sorting.Add(new SortingItem(VideoEntity.FIELD_CREATEDDATE, true));
        if(ddlVideoCategoryID.SelectedIndex > 0)
            data.Conditioning.Add(new ConditioningItem(VideoEntity.FIELD_VIDEOCATEGORYID, ddlVideoCategoryID.SelectedValue, Operator.EQUAL, CompareType.NUMERIC));
        if(txtName.Text != string.Empty)
            data.Conditioning.Add(new ConditioningItem(VideoEntity.FIELD_NAME, string.Format("%{0}%", BicString.Trim(txtName.Text)), Operator.LIKE, CompareType.STRING));
        dlImage.DataSource = data.GetPagingData();
        dlImage.DataBind();
        Pager1.TotalItems = data.TotalItems;
        lblMessage.Text = txtName.Text != string.Empty ? string.Format("<b>Kết quả tìm kiếm: </b>Tìm được><b> {0} video</b> với tên <b>\"{1}\"</b>", data.TotalItems, BicConvert.ToString(txtName.Text)) : "<b>"+BicResource.GetValue("Admin","Admin_Video_Videoduoctailengandaynhat")+"</b>";
        if(data.TotalItems <= Pager1.PageSize && Pager1.PageIndex == 0)
            Pager1.Visible = false;
        else
            Pager1.Visible = true;
    }
    protected void Action(object sender, CommandEventArgs e)
    {
        int videoId = BicConvert.ToInt32(e.CommandArgument);
        var videoEntity = VideoBiz.GetVideoByID(videoId);
        switch(e.CommandName)
        {
            case "Delete":
                if(videoEntity != null)
                    if(!string.IsNullOrEmpty(videoEntity.Path))
                    {
                        string pathfile = BicApplication.URLRoot + "FileUpload/Medias/" + videoEntity.Path;
                        string realfile = BicApplication.RealPath + "FileUpload/Medias/" + videoEntity.Path;
                        if(File.Exists(realfile))
                        {
                            if(BicFile.Delete(pathfile))
                                if(VideoBiz.DeleteVideo(videoId))
                                    BinddingImageManager();
                        }
                        else
                            Page.ClientScript.RegisterClientScriptBlock(GetType(), "Congbt", "alert('File không tồn tại hoặc đã bị xóa.')", true);
                    }
                    else
                        if(VideoBiz.DeleteVideo(videoId)) BinddingImageManager();
                break;
            case "Edit":
                Session["VideoID"] = BicConvert.ToString(videoId);
                Response.Redirect("UploadVideo.aspx");
                break;
        }
    }
    protected void Pager1_PageIndexChanged(object sender, PagerUIEventArgs e)
    {
        BinddingImageManager();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BinddingImageManager();
    }
    protected void txtName_TextChanged(object sender, EventArgs e)
    {
        Pager1.PageIndex = 0;
        BinddingImageManager();
    }
    protected void ddlVideoCategoryID_SelectedIndexChanged(object sender, EventArgs e)
    {
        Pager1.PageIndex = 0;
        BinddingImageManager();
    }
    protected void dlImage_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        var myHtmlImage = (HtmlImage)e.Item.FindControl("htmlImage");
        var drv = (DataRowView)e.Item.DataItem;
        if(drv == null) return;
        int idimage = BicConvert.ToInt32(drv[VideoEntity.FIELD_IMAGEID]);
        BicImage.ViewImage(myHtmlImage, idimage, 100, 100, true);
    }
}