using BIC.Biz;
using BIC.Utils;
using System;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

/// <summary>
/// Summary description for Gallery
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[ScriptService]
public class Gallery : WebService
{

    public Gallery()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string GetGallery(int id)
    {
        return GetImageGallery(BicConvert.ToInt32(id));
    }
    private string GetImageGallery(int Id)
    {
        string str = string.Empty;
        var obj = new ImageGallery();
        var article = ArticleBiz.GetArticleByID(Id);
        if(article != null)
        {            
            obj.Title = article.Title;
            obj.Images = LoadImageArray(article.ImageArray);
        }
        str = new JavaScriptSerializer().Serialize(obj);
        return str;
    }
    private string LoadImageArray(string imageArray)
    {
        string str = string.Empty;
        var ImageUrl = string.Empty;
        var ImageUrlThumb = string.Empty;
        if (!string.IsNullOrEmpty(imageArray))
        {
            string[] images = imageArray.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string image in images)
            {
                ImageUrl = BicImage.GetPathImage(BicConvert.ToInt32(image));
                ImageUrlThumb = BicImage.GetPathImageThumb(BicConvert.ToInt32(image));
                str += "<img data-image=\"" + ImageUrl + "\" src=\"" + ImageUrlThumb + "\" />";
            }
        }
        return str;
    }

}
public class ImageGallery
{
    public string Images { get; set; }
    public string Title { get; set; }
}