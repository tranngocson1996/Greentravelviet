using System;
using System.Data;
using System.Linq;
using BIC.Biz;
using BIC.Data;
using BIC.Utils;
using BIC.WebControls;
using Telerik.Web.UI;

public partial class Admin_Components_ImageType_TreeViewImageType : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindingTreeView(); //Loading data to tree view
        }
    }
    public void BindingTreeView()
    {
        var bic = new BicGetData();
        bic.Selecting.Add("ParentID");
        bic.Selecting.Add("ImageTypeID");
        bic.Selecting.Add("Name");
        bic.TableName = "ImageType";
        bic.Sorting.Add(new SortingItem("ParentID", false));
        bic.Sorting.Add(new SortingItem("Priority", false));
        DataTable data = bic.GetAllData();
        bicTreeView.DataTextField = "Name";
        bicTreeView.DataFieldID = "ImageTypeID";
        bicTreeView.DataValueField = "ImageTypeID";
        bicTreeView.DataFieldParentID = "ParentID";
        bicTreeView.DataSource = data;
        bicTreeView.DataBind();
        bicTreeView.ExpandAllNodes();
    }
    protected void UpMenu(RadTreeNode clickedNode)
    {
        string selectedNode = clickedNode.Value;
        ImageTypeBiz.ImageTypeUpDown(BicConvert.ToInt32(selectedNode), true);
        BindingTreeView();
        bicTreeView.FindNodeByValue(selectedNode).Selected = true;
    }
    protected void DownMenu(RadTreeNode clickedNode)
    {
        string selectedNode = clickedNode.Value;
        ImageTypeBiz.ImageTypeUpDown(BicConvert.ToInt32(selectedNode), false);
        BindingTreeView();
        bicTreeView.FindNodeByValue(selectedNode).Selected = true;
    }
    protected void DeleteMenu(RadTreeNode clickedNode)
    {
        if (clickedNode.Value != string.Empty)
        {
            var dh = new DataHelper();
            if (dh.IsExist("ParentID", clickedNode.Value, "ImageType"))
                BicAjax.Alert(BicMessage.DeleteChildFirst);
            else if (ImageTypeBiz.DeleteImageType(BicConvert.ToInt32(clickedNode.Value)))
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
                    ImageTypeBiz.ChangePosition(BicConvert.ToInt32(sourceNode.Value), BicConvert.ToInt32(destNode.Value), 0);
                }
                break;
            case RadTreeViewDropPosition.Above:
                // sibling - above
                destNode.InsertBefore(sourceNode);
                ImageTypeBiz.ChangePosition(BicConvert.ToInt32(sourceNode.Value), BicConvert.ToInt32(destNode.Value), 1);
                break;
            case RadTreeViewDropPosition.Below:
                // sibling - below
                destNode.InsertAfter(sourceNode);
                ImageTypeBiz.ChangePosition(BicConvert.ToInt32(sourceNode.Value), BicConvert.ToInt32(destNode.Value), 2);
                break;
        }
    }
    protected void bicTreeView_NodeEdit(object sender, RadTreeNodeEditEventArgs e)
    {
        var dh = new DataHelper();
        if (dh.UpdateColumn("Name", e.Text, "ImageTypeID", e.Node.Value, "ImageType") == false)
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
            case "Add":
                BicAdmin.NavigateToAdd();
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