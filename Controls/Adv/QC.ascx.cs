using System;
using System.Data;
using System.Web.UI;
using BIC.Data;
using BIC.Entity;
using BIC.Utils;

public partial class Controls_Adv_Adv : UserControl
{
    public string TypeOfAdv { get; set; }
    public string CssClass { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            BindingAdv();
    }

    protected void BindingAdv()
    {
        var bicData = new BicGetData { TableName = "Adv" };
        bicData.Sorting.Add(new SortingItem("Priority", true));
        bicData.Selecting.Add(AdvEntity.FIELD_URL);
        bicData.Selecting.Add(AdvEntity.FIELD_IMAGEID);
        bicData.Selecting.Add(AdvEntity.FIELD_TARGET);
        bicData.Selecting.Add(AdvEntity.FIELD_DESCRIPTION);
        bicData.Conditioning.Add(new ConditioningItem("LanguageKey", BicLanguage.CurrentLanguage, Operator.EQUAL, CompareType.STRING));
        bicData.Conditioning.Add(new ConditioningItem(AdvEntity.FIELD_TYPEOFADVID, TypeOfAdv, Operator.EQUAL, CompareType.STRING));
        bicData.Conditioning.Add(new ConditioningItem(AdvEntity.FIELD_ISACTIVE, "1", Operator.EQUAL, CompareType.NUMERIC));
        DataTable data = bicData.GetAllData();
        dlAdvList.DataSource = data;
        dlAdvList.DataBind();
    }
}