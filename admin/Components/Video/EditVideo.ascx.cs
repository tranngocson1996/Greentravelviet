using System;
using System.IO;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Entity;
using BIC.Handler;
using BIC.Utils;
using BIC.WebControls;
using Telerik.Web.UI;

public partial class Admin_Components_Video_EditVideo : BaseUserControl
{
    protected int Id;
    private string _filename = string.Empty;
    private string _filenameold = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        Id = Session["VideoID"] != null ? BicConvert.ToInt32(Session["VideoID"]) : 0;
        if(!IsPostBack)
        {
            ddlTypeOfVideoID.LoadData();
            LoadDataFromEntity();
        }
    }
    protected void rauUpload_FileUploaded(object sender, FileUploadedEventArgs e)
    {
        e.File.ContentLength.ToString();
        _filename = BicImage.ConvertImageName(e.File.FileName);
        string fullPath = Server.MapPath(ruMedia.TargetFolder + "/" + _filename);
        e.File.SaveAs(fullPath, true);
    }
    private void LoadDataFromEntity()
    {
        VideoEntity videoEntity = VideoBiz.GetVideoByID(Id);
        if(videoEntity != null)
        {
            txtName.Text = BicConvert.ToString(videoEntity.Name);
            ddlTypeOfVideoID.SelectedValue = BicConvert.ToString(videoEntity.VideoCategoryID);
            ddlVideoType.SelectedValue = BicConvert.ToString(videoEntity.Filetype);
            isImageID.ImageID = BicConvert.ToString(videoEntity.ImageID);
            txtUrl.Text = BicConvert.ToString(videoEntity.Url);
            _filenameold = videoEntity.Path;
            if(_filenameold != string.Empty)
                lbFile.Text = _filenameold;
        }
    }
    private VideoEntity LoadDataToEntity()
    {
        VideoEntity videoEntity = VideoBiz.GetVideoByID(Id);
        if(!string.IsNullOrEmpty(_filename))
        {
            DeleteOldFile();
            videoEntity.Path = _filename;
        }
        videoEntity.Name = BicConvert.ToString(txtName.Text);
        videoEntity.VideoCategoryID = BicConvert.ToInt32(ddlTypeOfVideoID.SelectedValue);
        videoEntity.Filetype = ddlVideoType.SelectedValue;
        videoEntity.ImageID = BicConvert.ToInt32(isImageID.ImageID.Replace(",", ""));
        videoEntity.Url = BicConvert.ToString(txtUrl.Text.Trim());
        return videoEntity;
    }
    protected void DeleteOldFile()
    {
        if(File.Exists(Server.MapPath(string.Format("{0}{1}", BicApplication.URLPath("FileUpload/Medias"), _filenameold))))
        {
            BicFile.Delete(Server.MapPath(string.Format("{0}{1}", BicApplication.URLPath("FileUpload/Medias"), _filenameold)));
        }
        else
        {
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "Congbt", "alert('File không tồn tại.')", true);
        }
    }
    protected void Save(object sender, CommandEventArgs e)
    {
        try
        {
            if(e.CommandName == "Update")
            {
                if(VideoBiz.UpdateVideo(LoadDataToEntity()))
                    BicHtml.Navigate("ListVideo.aspx");
                else
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "Congbt", "alert('" + BicMessage.UpdateFail + "')", true);
                Session["VideoID"] = null;
            }
            if(e.CommandName == "AddNew")
            {
                Session["VideoID"] = null;
                Response.Redirect("UploadVideo.aspx");
            }
        }
        catch(Exception ex)
        {
            LogEvent.LogToFile(ex.ToString());
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "Congbt", "alert('" + BicMessage.UpdateFail + "')", true);
        }
    }
    protected void lbFile_Click(object sender, EventArgs e)
    {
        DeleteOldFile();
    }
}