using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Entity;
using BIC.Handler;
using BIC.Utils;
using BIC.WebControls;
using Telerik.Web.UI;
using Image = System.Drawing.Image;

public partial class admin_Components_ImageGallery_UploadImage : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindListFromXML(rblResizeWidth,
                string.Format("{0}ResizeImage_{1}.xml", BicApplication.URLPath("Admin/XMLData"),
                    BicHtml.GetRequestString("l", BicXML.ToString("DefaultLanguageAdmin", "SearchEngine"))));
            ImageTypeBiz.BuildImageTypeTree(ddlImageTypeID);

            if (BicSession.ToInt32("SelectCategoryImage") != 0)
                ddlImageTypeID.SelectedIndex = BicSession.ToInt32("SelectCategoryImage");
            else
                ddlImageTypeID.SelectedItem.Text = "Chọn danh mục chứa ảnh";
            rblResizeWidth.SelectedIndex = 0;
        }
    }

    public static void BindListFromXML(RadioButtonList rbl, string sPath)
    {
        try
        {
            rbl.DataValueField = "Key";
            rbl.DataTextField = "name";
            var xml = new BicXML {XmlPath = sPath};
            rbl.DataSource = xml.GetXMLContent().Tables[0];
            rbl.DataBind();
        }
        catch (Exception ex)
        {
            LogEvent.LogToFile(ex.ToString());
        }
    }

    protected void rauUpload_FileUploaded(object sender, FileUploadedEventArgs e)
    {
        int newWidth = BicConvert.ToInt32(rblResizeWidth.SelectedValue);
        try
        {
            string value = e.File.GetName();
            string ext = value.Substring(value.LastIndexOf('.'), value.Length - value.LastIndexOf('.'));
                //Lấy ra đuôi mở rộng của ảnh
            string nameNotExt = value.Substring(0, value.LastIndexOf('.')); //Lấy ra tên ảnh bỏ đuôi mở rộng
            var chars = new String(nameNotExt.Where(c => c != '-' && (c < '0' || c > '9')).ToArray());
                //Xóa hết số khỏi tên ảnh
            if (chars == string.Empty)
                chars = ddlImageTypeID.SelectedValue;
            string imageName = BicImage.ConvertImageName(chars); //Xóa hết những ký tự đặc biệt ở tên ảnh

            string targetFolder = Server.MapPath("~/FileUpload/Images");
            if (BicFile.FileExist(BicApplication.URLPath("FileUpload/Images") + imageName + ext))
                //Check tên ảnh đã tồn tại chưa, nếu tồn tại tự động thêm số vào đuôi
            {
                bool flagStop = false;
                int i = 1;
                while (flagStop == false)
                {
                    if (BicFile.FileExist(BicApplication.URLPath("FileUpload/Images") + imageName + "_" + i + ext))
                    {
                        i++;
                    }
                    else
                        flagStop = true;
                }
                imageName = imageName + "_" + i + ext;
            }
            else
                imageName = imageName + ext;


            string imageType = e.File.GetExtension();
            int height;
            int width;
            using (Stream stream = e.File.InputStream)
            {
                var oBitmap = new Bitmap(Image.FromStream(stream));
                var pixel = GraphicsUnit.Pixel;
                RectangleF rcBound = oBitmap.GetBounds(ref pixel);
                oBitmap.Dispose();
                width = BicConvert.ToInt32(rcBound.Width);
                height = BicConvert.ToInt32(rcBound.Height);
            }
            e.File.SaveAs(Path.Combine(targetFolder, imageName), true);
            string returnResult;
            //Resize ảnh
            try
            {
                if (width > newWidth && rblResizeWidth.SelectedValue != "0")
                {
                    int newHeight = Convert.ToInt32(((height*newWidth)/width));
                    returnResult = BicImage.Resize(targetFolder, imageName, targetFolder, width, height, newWidth,
                        newHeight);
                    if (returnResult != string.Empty)
                        BicFile.Delete(string.Format(BicApplication.URLRoot + "FileUpload/Images/" + imageName));

                    height = newHeight;
                    width = newWidth;
                }
            }
            catch (Exception ex)
            {
                LogEvent.LogToFile(ex.ToString());
            }
            string[] size = BicString.SplitComma(BicXML.ToString("thumb", "value", "ThumbSize"));
            if (size.Length == 2)
            {
                returnResult = BicImage.CreateThumbs(targetFolder, imageName, targetFolder + "/thumb", width, height,
                    BicConvert.ToInt32(size[0]), BicConvert.ToInt32(size[1]));
                if (returnResult != string.Empty)
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "noimageedited",
                        string.Format("if (confirm('{0}')){} else {}", returnResult), true);
                    BicFile.Delete(string.Format(BicApplication.URLRoot + "FileUpload/Images/" + imageName));
                }
            }
            var imageEntity = new ImageEntity
            {
                Path = "FileUpload/Images/",
                Name = imageName,
                Width = width,
                Height = height,
                ImageTypeID = BicConvert.ToInt32(ddlImageTypeID.SelectedValue),
                UserName = BicMemberShip.CurrentUserName,
                FileType = imageType,
                CreatedDate = DateTime.Now
            };
            if (ImageBiz.InsertImage(imageEntity) == false)
            {
                BicAjax.Alert("Có lỗi xảy ra, thêm mới ảnh không thành công!");
            }
            else
            {
                BicHtml.Navigate("Gallery.aspx?l=" +
                                 BicHtml.GetRequestString("l", BicXML.ToString("DefaultLanguageAdmin", "SearchEngine")));
            }
        }
        catch (Exception ex)
        {
            LogEvent.LogToFile(ex.ToString());
        }
    }

    protected void ibtnRefresh_Click(object sender, ImageClickEventArgs e)
    {
        ImageTypeBiz.BuildImageTypeTree(ddlImageTypeID);
    }

    //protected void btnInsertImgLink_Click(object sender, EventArgs e)
    //{
    //    InsertLinkImg(txtImageLink1.Text.Trim(), lblerr1);
    //    InsertLinkImg(txtImageLink2.Text.Trim(), lblerr2);
    //    InsertLinkImg(txtImageLink3.Text.Trim(), lblerr3);
    //    InsertLinkImg(txtImageLink4.Text.Trim(), lblerr4);
    //    InsertLinkImg(txtImageLink5.Text.Trim(), lblerr5);
    //}
    //private void InsertLinkImg(string link, Label lblErr)
    //{
    //    const string list = "|.jpg|.png|.gif|.bmp|";
    //    if (!string.IsNullOrEmpty(link))
    //    {
    //        string filetype = link.Substring(link.Length - 4, 4);
    //        if (list.Contains("|" + filetype + "|"))
    //        {
    //            var imageEntity = new ImageEntity
    //                                  {
    //                                      Path = link,
    //                                      ImageTypeID = 1,
    //                                      UserName = BicMemberShip.CurrentUserName,
    //                                      FileType = filetype,
    //                                      CreatedDate = DateTime.Now
    //                                  };
    //            ImageBiz.InsertImage(imageEntity);
    //        }
    //        else
    //            lblErr.Text = @"Link ảnh không đúng định dạng";
    //    }
    //}
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        BicSession.SetValue("SelectCategoryImage", ddlImageTypeID.SelectedIndex);
        BicHtml.Navigate("Gallery.aspx?l=" +
                         BicHtml.GetRequestString("l", BicXML.ToString("DefaultLanguageAdmin", "SearchEngine")));
    }
}