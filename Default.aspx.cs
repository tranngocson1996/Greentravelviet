using System;
using BIC.Utils;
using BIC.WebControls;

public partial class _Default : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var temp = Common.GetPathUserControl();
        phPage.Controls.Add(Page.LoadControl(Page.ResolveUrl("~") + Common.GetPathUserControl()));
    }
}