using System;
using System.Web.UI;
using BIC.WebControls;

public partial class admin_Components_Video_VideoSelector : BaseUserControl
{
    private string _imageId = "0";
    public string VideoID
    {
        get { return hdVideoID.Value; }
        set
        {
            _imageId = value;
            hdVideoID.Value = value;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
    }
}