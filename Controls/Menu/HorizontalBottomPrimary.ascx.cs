using BIC.Utils;
using BIC.WebControls;

public partial class Controls_Menu_HorizontalBottomPrimary : BaseUIControl
{
    public int TypeID { get; set; }
    protected void Page_Load(object sender, System.EventArgs e)
    {
        mnMenu.WebServiceSettings.Method = "GetMenuCategories";
        mnMenu.WebServiceSettings.Path = BicApplication.URLRoot + "WebService/MenuService.asmx";
        if (IsPostBack) return;
        mnMenu.LanguageKey = Language;
        mnMenu.TypeId = TypeID;
        mnMenu.LoadData();
    }
}