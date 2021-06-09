using System;
using BIC.Biz;
using BIC.Utils;
using BIC.WebControls;


public partial class Controls_Menu_MenuFilter : BaseUIControl
{
    public int MenuUserId { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadMenu();
        }
    }
    public void LoadMenu()
    {
        //Build he thong neu co menu ngang hang hoac co menu con
        if (MenuUserId != 0)
        {
            var mnEtt = MenuUserBiz.GetMenuUserByID(MenuUserId);
            if(mnEtt != null)
            {
                ltrDesc.Text = mnEtt.Description;
                menuParent.ParentId = mnEtt.MenuUserId;
                menuParent.PageSize = 1000;
                menuParent.Language = BicLanguage.CurrentLanguage;
                menuParent.LoadData();
            }
        }
    }
}