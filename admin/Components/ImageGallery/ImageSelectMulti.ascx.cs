using System.Web.UI;
using BIC.Utils;

public partial class admin_Components_ImageGallery_ImageSelectMulti : UserControl
{
    private string _imageIdArray = string.Empty;

    public string ImageIDArray
    {
        get { return BicConvert.ToString(hdArrImage.Value); }
        set
        {
            _imageIdArray = value;
            hdArrImage.Value = value;
        }
    }
}