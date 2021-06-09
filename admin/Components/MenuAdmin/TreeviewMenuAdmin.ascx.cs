using System;
using System.Data;
using System.Linq;
using BIC.Biz;
using BIC.Data;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;
using Telerik.Web.UI;

public partial class admin_Components_MenuAdmin_TreeviewMenuAdmin : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindingTreeView(); //Loading data to tree view 
            //var conmenu = new RadTreeViewContextMenu();
            //conmenu.LoadContentFile("~/admin/XMLData/TreeView/TreeViewContextMenu.xml");
            //conmenu.Skin = "Telerik";
            //conmenu.EnableRoundedCorners = true;
            //bicTreeView.ContextMenus.Add(conmenu);
        }
    }
    public void BindingTreeView()
    {
        var bic = new BicGetData();
        bic.Selecting.Add("ParentID");
        bic.Selecting.Add("MenuAdminID");
        bic.Selecting.Add("Name");
        bic.TableName = "MenuAdmin";
        bic.Sorting.Add(new SortingItem("ParentID", false));
        bic.Sorting.Add(new SortingItem("Priority", false));
        DataTable data = bic.GetAllData();
        bicTreeView.DataTextField = "Name";
        bicTreeView.DataFieldID = "MenuAdminID";
        bicTreeView.DataValueField = "MenuAdminID";
        bicTreeView.DataFieldParentID = "ParentID";
        bicTreeView.DataSource = data;
        bicTreeView.DataBind();
        bicTreeView.ExpandAllNodes();
        foreach (RadTreeNode node in bicTreeView.GetAllNodes())
        {
            node.Text = BicResource.GetValue("Admin", node.Text);
        }
    }
    
    protected void UpMenu(RadTreeNode clickedNode)
    {
        string selectedNode = clickedNode.Value;
        MenuAdminBiz.MenuAdminUpDown(BicConvert.ToInt32(selectedNode), true);
        BindingTreeView();
        bicTreeView.FindNodeByValue(selectedNode).Selected = true;
    }
    protected void DownMenu(RadTreeNode clickedNode)
    {
        string selectedNode = clickedNode.Value;
        MenuAdminBiz.MenuAdminUpDown(BicConvert.ToInt32(selectedNode), false);
        BindingTreeView();
        bicTreeView.FindNodeByValue(selectedNode).Selected = true;
    }
    protected void DeleteMenu(RadTreeNode clickedNode)
    {
        if (clickedNode.Value != string.Empty)
        {
            var dh = new DataHelper();
            if (dh.IsExist("ParentID", clickedNode.Value, "MenuAdmin"))
                BicAjax.Alert(BicMessage.DeleteChildFirst);
            else if (MenuAdminBiz.DeleteMenuAdmin(BicConvert.ToInt32(clickedNode.Value)))
                clickedNode.Remove();
        }
        else
        {
            BicAjax.Alert(BicMessage.NoSelect);
        }
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
                    MenuAdminBiz.ChangePosition(BicConvert.ToInt32(sourceNode.Value), BicConvert.ToInt32(destNode.Value), 0);
                }
                break;
            case RadTreeViewDropPosition.Above:
                // sibling - above                    
                destNode.InsertBefore(sourceNode);
                MenuAdminBiz.ChangePosition(BicConvert.ToInt32(sourceNode.Value), BicConvert.ToInt32(destNode.Value), 1);
                break;
            case RadTreeViewDropPosition.Below:
                // sibling - below
                destNode.InsertAfter(sourceNode);
                MenuAdminBiz.ChangePosition(BicConvert.ToInt32(sourceNode.Value), BicConvert.ToInt32(destNode.Value), 2);
                break;
        }
    }
    protected void bicTreeView_NodeEdit(object sender, RadTreeNodeEditEventArgs e)
    {
        var dh = new DataHelper();
        if (dh.UpdateColumn("Name", e.Text, "MenuAdminID", e.Node.Value, "MenuAdmin") == false)
            BicAjax.Alert(BicMessage.UpdateFail);
        else
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
            case "Edit":
                BicAdmin.NavigateToEdit(clickedNode.Value);
                break;
            case "Delete":
                DeleteMenu(clickedNode);
                break;
        }
    }
}