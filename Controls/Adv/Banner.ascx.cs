using System;
using BIC.Data;
using BIC.Entity;


public partial class Controls_Adv_Banner : BIC.WebControls.BaseUIControl
{
    public string TypeOfAdv { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            BindingAdv();
    }

    protected void BindingAdv()
    {
        var bicData = new BicGetData { TableName="Adv",PageSize = 10};        
        bicData.Sorting.Add(new SortingItem("Priority", true));
        bicData.Selecting.Add(AdvEntity.FIELD_URL);
        bicData.Selecting.Add(AdvEntity.FIELD_IMAGEID);
        bicData.Selecting.Add(AdvEntity.FIELD_TARGET);
        bicData.Selecting.Add(AdvEntity.FIELD_DESCRIPTION);
        bicData.Selecting.Add(AdvEntity.FIELD_NAME);
        bicData.Conditioning.Add(new ConditioningItem("LanguageKey", Language, Operator.EQUAL, CompareType.STRING));
        bicData.Conditioning.Add(new ConditioningItem(AdvEntity.FIELD_TYPEOFADVID, TypeOfAdv, Operator.EQUAL, CompareType.STRING));
        bicData.Conditioning.Add(new ConditioningItem(AdvEntity.FIELD_ISACTIVE, "1", Operator.EQUAL, CompareType.STRING));

        var data = bicData.GetPagingData();
        dlSliderList.DataSource = data;
        dlSliderList.DataBind();
    }
}