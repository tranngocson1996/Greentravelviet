using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web;
using System.Web.UI.HtmlControls;
using BIC.Biz;
using BIC.Entity;

namespace BIC.Utils
{
    public class BicImage
    {
        public static string CreateThumbs(string imageDir, string imgName, string thumbDir, int oldWidth, int oldHeight,
                                          int newWidth, int newHeight)
        {
            int width, height;
            if (oldWidth > oldHeight)
            {
                if (oldWidth > newWidth)
                {
                    width = newWidth;
                    height = Convert.ToInt32(((oldHeight*newWidth)/oldWidth));
                }
                else
                {
                    width = oldWidth;
                    height = oldHeight;
                }
            }
            else if (oldHeight > newHeight)
            {
                height = newHeight;
                width = Convert.ToInt32(((oldWidth*newHeight)/oldHeight));
            }
            else
            {
                width = oldWidth;
                height = oldHeight;
            }
            try
            {
                //CREATE BITMAP
                var readImage = new StreamReader(imageDir + "/" + imgName);
                var bitmap = new Bitmap(readImage.BaseStream);
                //EDIT THE BITMAP USING THE IMAGE EDITOR AND CREATE THUMBNAILS
                var imageEditor = new BicImageEditor(bitmap);
                var newSize = new Size(width, height);
                imageEditor.Resize(newSize);
              //SaveJPGWithCompressionSetting(imageEditor.Image, thumbDir + "/" + imgName, 75L);
                imageEditor.Image.Save(thumbDir + "/" + imgName);
                readImage.Close();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return string.Empty;
        }

        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;

            ImageCodecInfo[] encoders;

            encoders = ImageCodecInfo.GetImageEncoders();

            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)

                    return encoders[j];
            }

            return null;
        }

        private static void SaveJPGWithCompressionSetting(Image image, string szFileName, long lCompression)
        {
            var eps = new EncoderParameters(1);

            eps.Param[0] = new EncoderParameter(Encoder.Quality, lCompression);

            ImageCodecInfo ici = GetEncoderInfo("image/jpeg");

            image.Save(szFileName, ici, eps);
        }

        /// <summary>
        /// Thay đổi kích thước ảnh
        /// </summary>
        /// <param name="imageDir">Đường dẫn vật lý chứa ảnh</param>
        /// <param name="imgName">Tên ảnh</param>
        /// <param name="thumbDir">Đường dẫn vật lý chứa ảnh nhỏ</param>
        /// <param name="oldWidth"></param>
        /// <param name="oldHeight"></param>
        /// <param name="newWidth"></param>
        /// <param name="newHeight"></param>
        public static string Resize(string imageDir, string imgName, string thumbDir, int oldWidth, int oldHeight,
                                    int newWidth, int newHeight)
        {
            try
            {
                //CREATE BITMAP
                var readImage = new StreamReader(imageDir + "/" + imgName);
                var bitmap = new Bitmap(readImage.BaseStream);
                //EDIT THE BITMAP USING THE IMAGE EDITOR AND CREATE THUMBNAILS
                var imageEditor = new BicImageEditor(bitmap);
                var newSize = new Size(newWidth, newHeight);
                imageEditor.Resize(newSize);
                //SAVE THE NEW IMAGE
                imageEditor.Image.Save(HttpContext.Current.Server.MapPath("~/FileUpload/Images/Temp/" + imgName));
                readImage.Close();
                var thempDir = new DirectoryInfo(HttpContext.Current.Server.MapPath("~/FileUpload/Images/Temp/"));
                var currentImage = new FileInfo(thempDir.FullName + "" + imgName);
                currentImage.CopyTo(HttpContext.Current.Server.MapPath("~/FileUpload/Images/" + imgName), true);
                //DETELE THE TEMP FILE
                foreach (FileInfo file in thempDir.GetFiles("*.jpg"))
                {
                    file.Delete();
                }
                imageEditor.Dispose();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return string.Empty;
        }

        /// <summary>
        /// Hàm chuyển tên ảnh thành dạng chữ không dấu và thay dấu cách thành _
        /// </summary>
        /// <param name="value">Tên ảnh ban đầu</param>
        /// <returns></returns>
        public static string ConvertImageName(string value)
        {
            value =
                value.Replace(" ", "_").Replace("&", "").Replace("%", "").Replace("@", "").Replace("!", "").Replace(
                    "(", "").Replace(")", "").Replace("-", "").Replace("?", "").Replace(".", "");

            if (BicLanguage.CurrentLanguageAdmin == "vi")
                return BicEncoding.ConvertUnicodeToNoSign(value).ToLower();
            return value;
        }

        /// <summary>
        /// Hàm chuyển tên ảnh thành dạng chữ không dấu và thay dấu cách thành _
        /// </summary>
        /// <param name="value">Tên ảnh ban đầu</param>
        /// <returns></returns>
        public static string ConvertVideoName(string value)
        {
            value =
                BicEncoding.ConvertUnicodeToNoSign(
                    value.Replace(" ", "_").Replace("&", "").Replace("%", "").Replace("@", "").Replace("!", "").Replace(
                        "(", "").Replace(")", "").Replace("-", "").Replace("?", ""));
            if (BicLanguage.CurrentLanguageAdmin == "vi")
                return BicEncoding.ConvertUnicodeToNoSign(value).ToLower();
            else
                return value;
        }

        /// <summary>
        /// Lấy tên ảnh từ 1 đường dẫn
        /// </summary>
        /// <param name="urlImage">Đường dẫn ảnh đầy đủ</param>
        /// <returns></returns>
        public static string GetName(string urlImage)
        {
            string fileName = urlImage.LastIndexOf("/") != 0
                                  ? urlImage.Substring(urlImage.LastIndexOf("/") + 1)
                                  : urlImage.Substring(urlImage.LastIndexOf(@"\") + 1);
            return fileName;
        }

        /// <summary>
        /// Phương thức lấy đường dẫn ảnh từ bảng Image
        /// </summary>
        /// <param name="id">Mã ảnh cần đọc thông tin trong bản Image</param>
        /// <returns>Đường dẫn kiểu string</returns>
        public static string GetPathImage(int id)
        {
            string path = string.Empty;
            ImageEntity imageEntiy = ImageBiz.GetImageByID(id);
            if (imageEntiy != null)
            {
                path = BicApplication.URLPath(imageEntiy.Path) + imageEntiy.Name;
            }
            return path;
        }

        public static string GetPathImageThumb(int id)
        {
            string path = string.Empty;
            ImageEntity imageEntiy = ImageBiz.GetImageByID(id);
            if (imageEntiy != null)
            {
                path = BicApplication.URLPath(imageEntiy.Path) + "thumb/" + imageEntiy.Name;
            }
            else
            {
                path = "Styles/images/no-image.png";
            }
            return path;
        }

        public static string PathViewer(int iId)
        {
            ImageEntity imageEntity = ImageBiz.GetImageByID(iId);
            if (imageEntity != null)
            {
                return string.Format("{0}imageviewer.aspx?id={1}&w={2}&h={3}&p={4}", BicApplication.URLRoot,
                                     imageEntity.ImageID, imageEntity.Width, imageEntity.Height,
                                     imageEntity.Path + imageEntity.Name);
            }
            return string.Empty;
        }

        public static void ViewImage(HtmlImage img, int iId, int width, int height, bool isThumb)
        {
            ImageEntity imageEntity = ImageBiz.GetImageByID(iId);
            if (imageEntity != null)
            {
                if (imageEntity.Width > imageEntity.Height)
                {
                    if (imageEntity.Width > width)
                    {
                        img.Width = width;
                        img.Height = Convert.ToInt32(((imageEntity.Height*width)/imageEntity.Width));
                    }
                    else
                    {
                        img.Width = imageEntity.Width;
                        img.Height = imageEntity.Height;
                    }
                }
                else if (imageEntity.Height > height)
                {
                    img.Height = height;
                    img.Width = Convert.ToInt32(((imageEntity.Width*height)/imageEntity.Height));
                }
                else
                {
                    img.Width = imageEntity.Width;
                    img.Height = imageEntity.Height;
                }
                if (Convert.ToInt32(img.Height) < height)
                {
                    img.Attributes["vspace"] =
                        Convert.ToInt32(((height/2) - (Convert.ToInt32(img.Height)/2))).ToString();
                }
                img.Src = string.Format(isThumb ? "{0}thumb/{1}" : "{0}{1}", BicApplication.URLPath(imageEntity.Path),
                                        imageEntity.Name);
            }
            else
            {
                img.Width = width;
                img.Height = height;
                img.Src = string.Format("{0}FileUpload/Images/thumb/img_unavaiable.jpg", BicApplication.URLRoot);
            }
        }

        public static void ViewImageFull(HtmlImage img, int iId, bool isThumb)
        {
            ImageEntity imageEntity = ImageBiz.GetImageByID(iId);
            //Lấy đường dẫn tuyệt đối của ImageViewer
            if (imageEntity != null)
            {
                img.Width = imageEntity.Width;
                img.Height = imageEntity.Height;
                img.Src = string.Format("{0}{1}", BicApplication.URLPath(imageEntity.Path), imageEntity.Name);
            }
            else
            {
                img.Visible = false;
            }
        }

        public static void ViewImageFix(HtmlImage img, int iId, int width, int height, bool isThumb)
        {
            img.Width = width;
            img.Height = height;
            ImageEntity imageEntity = ImageBiz.GetImageByID(iId);
            if (imageEntity != null)
            {
                ////Lấy đường dẫn tuyệt đối của ImageViewer
                img.Src = string.Format(isThumb ? "{0}thumb/{1}" : "{0}{1}", BicApplication.URLPath(imageEntity.Path),
                                        imageEntity.Name);
            }
            else
                img.Src = string.Format("{0}FileUpload/Images/thumb/img_unavaiable.jpg", BicApplication.URLRoot);
        }

        public static void ViewImageSingleSize(HtmlImage img, int iId, int size, bool byWidth, bool isThumb)
        {
            ImageEntity imageEntity = ImageBiz.GetImageByID(iId);
            if (imageEntity == null) return;
            if (byWidth == false)
            {
                img.Height = size;
                img.Width = Convert.ToInt32(((imageEntity.Width*size)/imageEntity.Height));
            }
            else
            {
                img.Width = size;
                img.Height = Convert.ToInt32(((imageEntity.Height*size)/imageEntity.Width));
            }
            img.Src = string.Format(isThumb ? "{0}thumb/{1}" : "{0}{1}", BicApplication.URLPath(imageEntity.Path),
                                    imageEntity.Name);
        }

        public static void GetPathImageByName(HtmlImage img, string nameImage, bool isThumb)
        {
            if (nameImage != null)
            {
                img.Src = string.Format("{0}FileUpload/Images/thumb/img_unavaiable.jpg", BicApplication.URLRoot);
                if (isThumb)
                {
                    img.Src = string.Format("{0}FileUpload/Images/thumb/{1}", BicApplication.URLRoot, nameImage);
                }
                else
                {
                    img.Src = string.Format("{0}FileUpload/Images/{1}", BicApplication.URLRoot, nameImage);
                }
            }
            else
            {
                img.Visible = false;
            }
        }
        public static string GetPathImageByName(string nameImage, bool isThumb)
        {
            var src = string.Format("{0}FileUpload/Images/thumb/img_unavaiable.jpg", BicApplication.URLRoot);
            if (nameImage != null)
            {               
                if (isThumb)
                {
                    src = string.Format("{0}FileUpload/Images/thumb/{1}", BicApplication.URLRoot, nameImage);
                }
                else
                {
                    src = string.Format("{0}FileUpload/Images/{1}", BicApplication.URLRoot, nameImage);
                }
            }
            return src;
        }
    }
}