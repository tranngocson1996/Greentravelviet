using System;
using BIC.Data;
using BIC.Entity;
using BIC.Utils;

using BIC.WebControls;
public partial class Controls_Adv_Adv : BaseUIControl
{
    public string TypeOfAdv { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            BindingAdv();
    }

    protected void BindingAdv()
    {
        var bicData = new BicGetData { TableName = "Adv" };
        bicData.Sorting.Add(new SortingItem("Priority", false));
        bicData.Selecting.Add(AdvEntity.FIELD_URL);
        bicData.Selecting.Add(AdvEntity.FIELD_IMAGEID);
        bicData.Selecting.Add(AdvEntity.FIELD_TARGET);
        bicData.Selecting.Add(AdvEntity.FIELD_DESCRIPTION);
        bicData.Conditioning.Add(new ConditioningItem("LanguageKey", BicLanguage.CurrentLanguage, Operator.EQUAL, CompareType.STRING));
        bicData.Conditioning.Add(new ConditioningItem(AdvEntity.FIELD_TYPEOFADVID, TypeOfAdv, Operator.EQUAL, CompareType.STRING));
        bicData.Conditioning.Add(new ConditioningItem(AdvEntity.FIELD_ISACTIVE, "1", Operator.EQUAL, CompareType.NUMERIC));
        var data = bicData.GetAllData();
        rptAdv.DataSource = data;
        rptAdv.DataBind();
    }
}