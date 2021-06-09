using System;
using BIC.Utils;

public partial class Controls_GoogleMap_GoogleMaps : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var latlng = BicXML.ToString("GeoPosition", "SearchEngine");
            string[] str = latlng.Split(',');
            hdTitle.Value = BicXML.ToString("Title", "SearchEngine");
            hdDescription.Value = BicXML.ToString("Description", "SearchEngine");
            hdLat.Value = str[0];
            hdLng.Value = str[1].Trim();
            hdZoom.Value = "15";
        }
    }
}