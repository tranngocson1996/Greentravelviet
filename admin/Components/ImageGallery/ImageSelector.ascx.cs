using System.Web.UI;
using BIC.Utils;

public partial class admin_Components_ImageGallery_ImageSelector : UserControl
{
    private string _imageId = "0";

    public string ImageID
    {
        get
        {
            string[] arr = BicString.SplitComma(hdImageID.Value);
            if (arr.Length > 0)
                return arr[0];
            return "0";
        }
        set
        {
            _imageId = value;
            hdImageID.Value = value;
        }
    }
}