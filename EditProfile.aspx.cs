using System;
using BIC.Utils;
using BIC.WebControls;

public partial class EditProfile : BasePage
{
    public string TabProfile { get; set; }
    public string TabOrder { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string tab = BicHtml.GetRequestString("tab", string.Empty);
            if (tab == "order")
            {
                TabOrder = "active";
                TabProfile = "";
            }
            else
                TabProfile = "active ";
        }
    }
}