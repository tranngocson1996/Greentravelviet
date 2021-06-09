using System;
using System.Data;
using System.Linq;
using BIC.Biz;
using BIC.Data;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;
using Telerik.Web.UI;

public partial class admin_Components_MenuUser_TreeviewMenuUser : BaseUserControl
{
    private string LANGUAGE = "vi";
    private string TYP_OF_MENU = "1";
    protected void Page_Load(object sender, EventArgs e)
    {


    }
    public void BindingTreeView(string language, string typeOfMenu)
    {
        MainContextMenu.Items[0].Text = BicResource.GetValue("Admin", "System_Add");
        MainContextMenu.Items[1].Text = BicResource.GetValue("Admin", "Admin_MenuUser_TreeviewMenuUser_Edit");
        MainContextMenu.Items[2].Text = BicResource.GetValue("Admin", "Admin_MenuUser_TreeviewMenuUser_EditName");
        MainContextMenu.Items[3].Text = BicResource.GetValue("Admin", "Admin_MenuUser_TreeviewMenuUser_Cloning");
        MainContextMenu.Items[4].Text = BicResource.GetValue("Admin", "Admin_MenuUser_TreeviewMenuUser_Up");
        MainContextMenu.Items[5].Text = BicResource.GetValue("Admin", "Admin_MenuUser_TreeviewMenuUser_Down");
        MainContextMenu.Items[6].Text = BicResource.GetValue("Admin", "Admin_MenuUser_TreeviewMenuUser_Delete");
        MainContextMenu.Items[6].Visible = Deleted;
        MainContextMenu.Items[0].Visible = Added;
        MainContextMenu.Items[1].Visible = Edited;
        MainContextMenu.Items[2].Visible = Edited;
        MainContextMenu.Items[3].Visible = Edited;
        MainContextMenu.Items[4].Visible = Edited;
        MainContextMenu.Items[5].Visible = Edited;

        bicTreeView.Nodes.Clear();
        var bic = new BicGetData();
        bic.Selecting.Add("ParentID");
        bic.Selecting.Add("MenuUserID");
        bic.Selecting.Add("Name");
        bic.TableName = "MenuUser";
        bic.Sorting.Add(new SortingItem("ParentID", false));
        bic.Sorting.Add(new SortingItem("Priority", false));
        bic.Conditioning.Add(new ConditioningItem("LanguageKey", language, Operator.EQUAL, CompareType.STRING));
        bic.Conditioning.Add(new ConditioningItem("TypeID", typeOfMenu, Operator.EQUAL, CompareType.NUMERIC));
        DataTable data = bic.GetAllData();
        bicTreeView.DataTextField = "Name";
        bicTreeView.DataFieldID = "MenuUserID";
        bicTreeView.DataValueField = "MenuUserID";
        bicTreeView.DataFieldParentID = "ParentID";
        bicTreeView.DataSource = data;
        bicTreeView.DataBind();
        bicTreeView.ExpandAllNodes();
    }
    protected void UpMenu(RadTreeNode clickedNode)
    {
        string selectedNode = clickedNode.Value;
        MenuUserBiz.MenuUserUpDown(BicConvert.ToInt32(selectedNode), true, LANGUAGE, BicConvert.ToInt32(TYP_OF_MENU));
        BindingTreeView(LANGUAGE, TYP_OF_MENU);
        bicTreeView.FindNodeByValue(selectedNode).Selected = true;
    }
    protected void DownMenu(RadTreeNode clickedNode)
    {
        string selectedNode = clickedNode.Value;
        MenuUserBiz.MenuUserUpDown(BicConvert.ToInt32(selectedNode), false, LANGUAGE, BicConvert.ToInt32(TYP_OF_MENU));
        BindingTreeView(LANGUAGE, TYP_OF_MENU);
        bicTreeView.FindNodeByValue(selectedNode).Selected = true;
    }
    protected void DeleteMenu(RadTreeNode clickedNode)
    {
        if (clickedNode.Value != string.Empty)
        {
            var dh = new DataHelper();
            if (dh.IsExist("ParentID", clickedNode.Value, "MenuUser"))
                BicAjax.Alert(BicMessage.DeleteChildFirst);
            else if (MenuUserBiz.DeleteMenuUser(BicConvert.ToInt32(clickedNode.Value), LANGUAGE))
                clickedNode.Remove();
                //BindingTreeView(LANGUAGE, TYP_OF_MENU);
        }
        else
            BicAjax.Alert(BicMessage.NoSelect);
    }
    protected void bicTreeView_HandleDrop(object o, RadTreeNodeDragDropEventArgs e)
    {
        RadTreeNode sourceNode = e.SourceDragNode;
        RadTreeNode destNode = e.DestDragNode;
        RadTreeViewDropPosition dropPosition = e.DropPosition;
        if (destNode != null)
        {
            if (sourceNode.TreeView.SelectedNodes.Count <= 1)
            {
                if (!sourceNode.IsAncestorOf(destNode))
                {
                    sourceNode.Owner.Nodes.Remove(sourceNode);
                    destNode.Nodes.Add(sourceNode);
                    PerformDragAndDrop(dropPosition, sourceNode, destNode);
                }
            }
            else if (sourceNode.TreeView.SelectedNodes.Count > 1)
            {
                foreach (RadTreeNode node in bicTreeView.SelectedNodes.Where(node => !node.IsAncestorOf(destNode)))
                {
                    node.Owner.Nodes.Remove(node);
                    destNode.Nodes.Add(node);
                    PerformDragAndDrop(dropPosition, node, destNode);
                }
            }
            destNode.Expanded = true;
            sourceNode.TreeView.ClearSelectedNodes();
        }
    }
    private static void PerformDragAndDrop(RadTreeViewDropPosition dropPosition, RadTreeNode sourceNode, RadTreeNode destNode)
    {
        if (sourceNode.Equals(destNode) || sourceNode.IsAncestorOf(destNode))
        {
            return;
        }
        //sourceNode.Owner.Nodes.Remove(sourceNode);
        switch (dropPosition)
        {
            case RadTreeViewDropPosition.Over:
                // child
                if (!sourceNode.IsAncestorOf(destNode))
                {
                    MenuUserBiz.ChangePosition(BicConvert.ToInt32(sourceNode.Value), BicConvert.ToInt32(destNode.Value), 0);
                }
                break;
            case RadTreeViewDropPosition.Above:
                // sibling - above
                destNode.InsertBefore(sourceNode);
                MenuUserBiz.ChangePosition(BicConvert.ToInt32(sourceNode.Value), BicConvert.ToInt32(destNode.Value), 1);
                break;
            case RadTreeViewDropPosition.Below:
                // sibling - below
                destNode.InsertAfter(sourceNode);
                MenuUserBiz.ChangePosition(BicConvert.ToInt32(sourceNode.Value), BicConvert.ToInt32(destNode.Value), 2);
                break;
        }
    }
    protected void bicTreeView_NodeEdit(object sender, RadTreeNodeEditEventArgs e)
    {
        MenuUserEntity menuUserEntity = MenuUserBiz.GetMenuUserByID(BicConvert.ToInt32(e.Node.Value));
        if (menuUserEntity == null) return;
        menuUserEntity.Name = e.Text;
        MenuUserBiz.UpdateMenuUser(menuUserEntity);
        //BicAjax.Alert(BicMessage.UpdateFail);
        //else
        e.Node.Text = e.Text;
    }
    protected void bicTreeView_ContextMenuItemClick(object sender, RadTreeViewContextMenuEventArgs e)
    {
        RadTreeNode clickedNode = e.Node;
        switch (e.MenuItem.Value)
        {
            case "Up":
                UpMenu(clickedNode);
                break;
            case "Down":
                DownMenu(clickedNode);
                break;
            case "Add":
                BicAdmin.NavigateToAdd();
                break;
            case "Edit":
                BicAdmin.NavigateToEdit(clickedNode.Value);
                break;
            case "Duplicate":
                BicAdmin.NavigateToDuplicate(clickedNode.Value);
                break;
            case "Delete":
                int id = BicHtml.GetRequestString("id", 0);
                DeleteMenu(clickedNode);
                if (id == BicConvert.ToInt32(clickedNode.Value))
                    BicAdmin.NavigateToAdd();
                break;
        }
    }

    protected void UpdateArticleProduct(string MenuUserID)
    {
        //Xóa Id trong cột MenuUserID
        string updateMenuUID = string.Format("UPDATE  {0} SET MenuUserID = REPLACE(MenuUserID,',{1},',',')", "TableName", MenuUserID);
        //UPDATE  Product SET MenuUserID = REPLACE(MenuUserID,',4,',',') WHERE ProductID != 1
        //Nếu là MainMenuUserID
        /*
            - Nếu có nhiều menu khác
            - Lấy menu đầu tiên làm Main

            + Update MainMenuUserID
            UPDATE  Product SET MainMenuUserID = REPLACE(SUBSTRING(MenuUserID,1, CHARINDEX(',', MenuUserID,2)),',','') WHERE MainMenuUserID = 1

            + Update MenuUserName
            UPDATE  Product SET MenuUserName = (SELECT UrlName FROM MenuUser WHERE MenuUserID = REPLACE(SUBSTRING(dbo.Product.MenuUserID,1, CHARINDEX(',', dbo.Product.MenuUserID,2)),',','')) WHERE MenuUserID = 1
            
            - Nếu không có menu khác IsActive = 0;

        */
    }
}