using BIC.Utils;
using BIC.WebControls;

public partial class Controls_Menu_HorizontalTopPrimary : BaseUIControl
{
    public int TypeId { get; set; }

    protected void Page_Load(object sender, System.EventArgs e)
    {
        if(IsPostBack) return;
        mnMenu.WebServiceSettings.Method = "GetMenuCategories";
        mnMenu.WebServiceSettings.Path = BicApplication.URLRoot + "WebService/MenuService.asmx";
        mnMenu.LanguageKey = BicLanguage.CurrentLanguage;
        mnMenu.TypeId = TypeId;
        mnMenu.LoadData();
    }
}