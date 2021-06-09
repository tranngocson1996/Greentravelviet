using System;
using BIC.Utils;

public partial class Controls_GoogleMap_Maps : System.Web.UI.UserControl
{
    public string PosX
    {
        get { return BicConvert.ToString(hdX.Value.Trim()); }
        set { hdX.Value = value.Trim(); }
    }

    public string Address
    {
        get { return BicConvert.ToString(hdAddress.Value.Trim()); }
        set { hdAddress.Value = value.Trim(); }
    }

    public string PosY
    {
        get { return BicConvert.ToString(hdY.Value.Trim()); }
        set { hdY.Value = value.Trim(); }
    }

    public bool isView { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        hdView.Value = BicConvert.ToString(isView);
    }
}