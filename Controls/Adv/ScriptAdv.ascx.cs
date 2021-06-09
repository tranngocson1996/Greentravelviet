using System;
using System.Data;
using BIC.Data;
using BIC.Entity;
using BIC.WebControls;

public partial class Controls_Adv_ScriptAdv : BaseUIControl
{
    public int TypeOfAdv { get; set; }
    public int Name { get; set; }
    public int  PageSize { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindingAdv();
        }
    }
    protected void BindingAdv()
    {
        var bicData = new BicGetData { TableName = "Adv" };
        bicData.Sorting.Add(new SortingItem("Priority", true));
        //bicData.Selecting.Add(AdvEntity.FIELD_URL);
        //bicData.Selecting.Add(AdvEntity.FIELD_IMAGEID);
        //bicData.Selecting.Add(AdvEntity.FIELD_TARGET);
        if(PageSize > 0)
            bicData.PageSize = PageSize;

        bicData.Selecting.Add(AdvEntity.FIELD_DESCRIPTION);
        bicData.Conditioning.Add(new ConditioningItem("LanguageKey", Language, Operator.EQUAL, CompareType.STRING));
        bicData.Conditioning.Add(new ConditioningItem(AdvEntity.FIELD_TYPEOFADVID, TypeOfAdv.ToString(), Operator.EQUAL, CompareType.STRING));
        bicData.Conditioning.Add(new ConditioningItem(AdvEntity.FIELD_ISACTIVE, "1", Operator.EQUAL, CompareType.NUMERIC));
        DataTable data = bicData.GetAllData();
        dlSliderList.DataSource = data;
        dlSliderList.DataBind();
    }
}