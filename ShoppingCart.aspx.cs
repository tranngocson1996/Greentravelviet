using System;
using BIC.Utils;
using BIC.WebControls;

public partial class ShoppingCart : BasePage
{
    public int id;
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Header.DataBind();
        LoadControl();
    }
    protected void LoadControl()
    {
        id = BicRouting.GetRequestString("id", 0);
        switch (id)
        {
            case 1:
                phCart.Controls.Add(Page.LoadControl(Page.ResolveUrl("~") + "Controls/ShoppingCart/Step1.ascx"));
                break;
            case 2:
                phCart.Controls.Add(Page.LoadControl(Page.ResolveUrl("~") + "Controls/ShoppingCart/Step2.ascx"));
                break;
            case 3:
                phCart.Controls.Add(Page.LoadControl(Page.ResolveUrl("~") + "Controls/ShoppingCart/Step3.ascx"));
                break;
            case 4: //Success
                phCart.Controls.Add(Page.LoadControl(Page.ResolveUrl("~") + "Controls/ShoppingCart/Step4.ascx"));
                break;
            default:
                phCart.Controls.Add(Page.LoadControl(Page.ResolveUrl("~") + "Controls/ShoppingCart/Step1.ascx"));
                break;
        }
    }
}