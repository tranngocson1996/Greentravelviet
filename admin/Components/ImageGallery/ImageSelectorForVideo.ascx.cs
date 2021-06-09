using System.Web.UI;

public partial class admin_Components_ImageGallery_ImageSelectorForVideo : UserControl
{
    private string _imageId = "0";

    public string ImageID
    {
        get { return hdImageID.Value; }
        set
        {
            _imageId = value;
            hdImageID.Value = value;
        }
    }
}