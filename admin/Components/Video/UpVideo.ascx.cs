using System;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Data;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;
using Telerik.Web.UI;

public partial class Admin_Components_Video_UpVideo : BaseUserControl
{
    private string _filename = string.Empty;
    private string _filetype = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(IsPostBack) return;
        ddlTypeOfVideoID.LoadData();
        hdfLangManager.Value = BicHtml.GetRequestString("l") == "" ? BicXML.ToString("DefaultLanguage", "SearchEngine") : BicHtml.GetRequestString("l");
    }
    protected void rauUpload_FileUploaded(object sender, FileUploadedEventArgs e)
    {
        e.File.ContentLength.ToString();
        _filetype = e.File.ContentType;
        _filename = BicImage.ConvertImageName(e.File.FileName);
        string fullPath = Server.MapPath(ruMedia.TargetFolder + "/" + _filename);
        e.File.SaveAs(fullPath, true);
    }

    private VideoEntity LoadDataToEntity()
    {
        var videoEntity = new VideoEntity { Name = BicConvert.ToString(txtName.Text), VideoCategoryID = BicConvert.ToInt32(ddlTypeOfVideoID.SelectedValue), VideoTypeID = 1, ImageID = !string.IsNullOrEmpty(isImageID.ImageID) ? BicConvert.ToInt32(isImageID.ImageID) : 0, Description = BicConvert.ToString(reDescription.Content), Viewed = 0, IsNew = true, IsHome = true, IsActive = true, Path = !string.IsNullOrEmpty(_filename) ? _filename : string.Empty, Filetype = ddlVideoType.SelectedValue.Trim(), Url = BicConvert.ToString(txtUrl.Text.Trim()), Priority = 0, CreatedDate = DateTime.Now, Height = 0, Width = 0 };
        return videoEntity;
    }
    protected void Save(object sender, CommandEventArgs e)
    {
        try
        {
            switch(e.CommandName)
            {
                case "AddNew":
                    if(!string.IsNullOrEmpty(_filename) || !string.IsNullOrEmpty(txtUrl.Text))
                    {
                        if(!VideoBiz.InsertVideo(LoadDataToEntity()))
                            BicAjax.Alert(BicMessage.InsertFail);
                        else
                        {
                            BicHtml.Navigate("ListVideo.aspx");
                            txtName.Text = txtUrl.Text = string.Empty;
                        }
                    }
                    else
                    {
                        Page.ClientScript.RegisterClientScriptBlock(GetType(), "Congbt", "alert('Bạn chưa chọn file video Upload')", true);
                    }
                    break;
            }
        }
        catch(Exception ex)
        {
            BicAjax.Alert(ex.Message);
        }
    }
}