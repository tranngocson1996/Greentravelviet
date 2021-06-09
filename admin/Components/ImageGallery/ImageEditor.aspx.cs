using System;
using System.Drawing;
using System.IO;
using System.Web.UI;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class admin_Components_ImageGallery_ImageEditor : BasePageAdmin
{
    private int _id;

    protected void Page_Load(object sender, EventArgs e)
    {
        _id = BicHtml.GetRequestString("id", 0);
        imgOriginal.Attributes.Add("onload", "getImgSize()");
        imgOriginal.Attributes.Add("onmouseover", "LoadCrop()");
    }

    private void ProcessImage()
    {
        //GET THE CURRENT IMAGE NAME
        string imageName = hdnField1.Value;
        //CREATE BITMAP
        var readImage = new StreamReader(Server.MapPath("~/FileUpload/Images/") + imageName);
        var bitmap = new Bitmap(readImage.BaseStream);
        //EDIT THE BITMAP USING THE TELERIK'S IMAGE EDITOR
        var imageEditor = new BicImageEditor(bitmap);
        //RESIZE
        var newSize = new Size(BicConvert.ToInt32(txtImgWidth.Value), BicConvert.ToInt32(txtImgHeight.Value));
        imageEditor.Resize(newSize);
        //FLIP
        switch (FlipList.SelectedValue)
        {
            case "0":
                imageEditor.Flip(false, false, 0);
                break;
            case "1":
                imageEditor.Flip(true, false, 180);
                break;
            case "2":
                imageEditor.Flip(false, true, 180);
                break;
            case "3":
                imageEditor.Flip(true, true, 0);
                break;
        }
        //ROTATE
        imageEditor.Flip(false, false, Int32.Parse(RotateList.SelectedValue)*90);
        //CROP
        if (CropWidth.Text != "0" && CropHeight.Text != "0")
        {
            if (!(CropX.Text == "" && CropY.Text == "" && CropWidth.Text == "" && CropHeight.Text == ""))
            {
                Int32 cropX = Convert.ToInt32(CropX.Text);
                Int32 cropY = Convert.ToInt32(CropY.Text);
                Int32 cropW = Convert.ToInt32(CropWidth.Text);
                if (cropW > imageEditor.Image.Width)
                {
                    cropW = imageEditor.Image.Width;
                }
                Int32 cropH = Convert.ToInt32(CropHeight.Text);
                if (cropH > imageEditor.Image.Height)
                {
                    cropH = imageEditor.Image.Height;
                }
                var crop = new Rectangle(cropX, cropY, cropW, cropH);
                imageEditor.Crop(crop);
            }
        }
        //SAVE THE NEW IMAGE
        imageEditor.Image.Save(Server.MapPath("~/FileUpload/Images/Temp/" + imageName));
        readImage.Close();
        var rand = new Random();
        //WORKAROUND CACHING
        imgOriginal.ImageUrl = "~/FileUpload/Images/Temp/" + imageName + "?" + rand.Next();
        ClearCrop();
    }

    private void ClearCrop()
    {
        CropX.Text = string.Empty;
        CropY.Text = string.Empty;
        CropHeight.Text = string.Empty;
        CropWidth.Text = string.Empty;
    }

    protected void btnShowNewImage_Click(object sender, EventArgs e)
    {
        ProcessImage();
    }

    protected void Save_Click(object sender, EventArgs e)
    {
        ImageEntity _imageEntity = ImageBiz.GetImageByID(_id);
        if (_imageEntity != null)
        {
            _imageEntity.Width = BicConvert.ToInt32(txtImgWidth.Value);
            _imageEntity.Height = BicConvert.ToInt32(txtImgHeight.Value);
            _imageEntity.CreatedDate = DateTime.Now;
            ImageBiz.UpdateImage(_imageEntity);
            string imageName = hdnField1.Value;
            var thempDir = new DirectoryInfo(MapPath("~/FileUpload/Images/Temp/"));
            var currentImage = new FileInfo(thempDir.FullName + "" + imageName);
            //IF NO CHANGES ARE MADE PREVENT SAVING THE IMAGE
            if (!File.Exists(currentImage.FullName))
            {
                string originalImageUrl = "Images/" + imageName;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "noimageedited",
                    "ShowImage('" + originalImageUrl + "');" + "alert('Bạn cần click Xem trước khi Lưu thay đổi.');",
                    true);
                return;
            }
            currentImage.CopyTo(MapPath("~/FileUpload/Images/" + imageName), true);
            string[] size = BicString.SplitComma(BicXML.ToString("thumb", "value", "ThumbSize"));
            if (size.Length == 2)
            {
                BicImage.CreateThumbs(MapPath("~/FileUpload/Images"), _imageEntity.Name,
                    MapPath("~/FileUpload/Images/thumb"), BicConvert.ToInt32(txtImgWidth.Value),
                    BicConvert.ToInt32(txtImgHeight.Value), BicConvert.ToInt32(size[0]), BicConvert.ToInt32(size[1]));
            }
            //DETELE THE TEMP FILE
            foreach (FileInfo file in thempDir.GetFiles())
            {
                file.Delete();
            }
            BicAjax.Alert("Lưu thông tin thành công, click X để hoàn tất quá trình chỉnh sửa!");
        }
    }
}