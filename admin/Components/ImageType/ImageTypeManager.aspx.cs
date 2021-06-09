using System;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Data;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;
using Telerik.Web.UI;

public partial class admin_Components_MenuUser_MenuUserManager : BasePageAdmin
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SetView(false);
            BindingImageType(bicTreeView);
        }
    }
    public static void BindingImageType(RadTreeView rtv)
    {
        rtv.Nodes.Clear();
        var bic = new BicGetData();
        bic.Selecting.Add("ParentID");
        bic.Selecting.Add("ImageTypeID");
        bic.Selecting.Add("Name");
        bic.TableName = "ImageType";
        bic.Sorting.Add(new SortingItem("ParentID", false));
        bic.Sorting.Add(new SortingItem("Priority", false));
        DataTable data = bic.GetAllData();
        rtv.DataTextField = "Name";
        rtv.DataFieldID = "ImageTypeID";
        rtv.DataValueField = "ImageTypeID";
        rtv.DataFieldParentID = "ParentID";
        rtv.DataSource = data;
        rtv.DataBind();
        rtv.ExpandAllNodes();
        rtv.Nodes.Insert(0, new RadTreeNode("<b>Danh mục gốc</b>", "0"));
    }
    protected void SetView(bool b)
    {
        lbtnReset.Visible = b;
        lbtnSave.Visible = b;
        tblInfo.Visible = b;
        tblHelp.Visible = !b;
    }
    protected void Command(object sender, CommandEventArgs e)
    {
        try
        {
            switch (e.CommandName)
            {
                case "AddNew":
                    AddNew();
                    break;
                case "Save":
                    Save();
                    break;
            }
        }
        catch (Exception ex)
        {
            BicAjax.Alert(ex.Message);
        }
    }
    protected void UnLockedControl(bool status)
    {
        txtName.Disabled = !status;
        ddlParentID.Enabled = status;
        chkIsActive.Enabled = status;
    }
    protected void UpMenu(RadTreeNode clickedNode)
    {
        string selectedNode = clickedNode.Value;
        ImageTypeBiz.ImageTypeUpDown(BicConvert.ToInt32(selectedNode), true);
        BindingImageType(bicTreeView);
        bicTreeView.FindNodeByValue(selectedNode).Selected = true;
    }
    protected void DownMenu(RadTreeNode clickedNode)
    {
        string selectedNode = clickedNode.Value;
        ImageTypeBiz.ImageTypeUpDown(BicConvert.ToInt32(selectedNode), false);
        BindingImageType(bicTreeView);
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
    protected void AddNew()
    {
        ViewState["Action"] = "Add";
        ImageTypeBiz.BuildImageTypeTree(ddlParentID);
        SetView(true);
        ddlParentID.Enabled = true;
        ddlParentID.SelectedIndex = 0;
        ClearInputData();
    }
    protected void EditMenu(RadTreeNode clickedNode)
    {
        if (clickedNode.Value != "0")
        {
            ViewState["Action"] = "Edit";
            SetView(true);
            ddlParentID.Enabled = false;
            ImageTypeBiz.BuildImageTypeTree(ddlParentID);
            LoadDataFromEntity(clickedNode);
            bicTreeView.FindNodeByValue(clickedNode.Value).Selected = true;
        }
        else
        {
            BicHtml.Alert("Hay chon danh muc khac \"Danh muc goc\"!");
        }
    }
    protected void Save()
    {
        if (ViewState["Action"].ToString() == "Add")
        {
            if (ImageTypeBiz.InsertImageType(LoadDataToEntity()))
            {
                tblInfo.Visible = false;
                BindingImageType(bicTreeView);
                ClearInputData();
            }
            else
            {
                BicHtml.Alert("Co loi, cap nhat danh muc khong thanh cong!");
            }
        }
        if (ViewState["Action"].ToString() == "Edit")
        {
            if (ImageTypeBiz.UpdateImageType(LoadDataToEntity()))
            {
                tblInfo.Visible = false;
                BindingImageType(bicTreeView);
                ClearInputData();
            }
            else
            {
                BicHtml.Alert("Co loi, cap nhat danh muc khong thanh cong!");
            }
        }
    }
    protected void btnCancel_ServerClick(object sender, EventArgs e)
    {
        tblInfo.Visible = false;
    }
    private void ClearInputData()
    {
        txtName.Value = string.Empty;
        chkIsActive.Checked = false;
    }
    private void LoadDataFromEntity(RadTreeNode clickedNode)
    {
        ImageTypeEntity _imagetypeEntity = ImageTypeBiz.GetImageTypeByID(BicConvert.ToInt32(clickedNode.Value));
        if (_imagetypeEntity != null)
        {
            txtName.Value = _imagetypeEntity.Name;
            chkIsActive.Checked = !_imagetypeEntity.IsActive;
            if (BicControl.DropExistValue(_imagetypeEntity.ParentID, ddlParentID))
                ddlParentID.SelectedValue = _imagetypeEntity.ParentID.ToString();
        }
    }
    private ImageTypeEntity LoadDataToEntity()
    {
        var _imagetypeEntity = new ImageTypeEntity();
        if (ViewState["Action"].ToString() == "Edit")
        {
            _imagetypeEntity.ImageTypeID = BicConvert.ToInt32(bicTreeView.SelectedNode.Value);
        }
        _imagetypeEntity.IsActive = !chkIsActive.Checked;
        _imagetypeEntity.Name = txtName.Value;
        _imagetypeEntity.ParentID = BicConvert.ToInt32(ddlParentID.SelectedValue);
        return _imagetypeEntity;
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
                AddNew();
                break;
            case "Edit":
                EditMenu(clickedNode);
                break;
            case "Delete":
                DeleteMenu(clickedNode);
                break;
        }
    }
    protected void bicTreeView_HandleDrop(object sender, RadTreeNodeDragDropEventArgs e)
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
            BicHtml.Alert("Cập nhật tên danh mục không thành công!");
        else
            e.Node.Text = e.Text;
    }
}