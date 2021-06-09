<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TreeviewMenuUser.ascx.cs" Inherits="admin_Components_MenuUser_TreeviewMenuUser" %>
<script type="text/javascript">
    function contextMenuItemClicking(sender, args) {
        var menuItem = args.get_menuItem(); var treeNode = args.get_node(); menuItem.get_menu().hide(); switch (menuItem.get_value()) {
            case "Delete":
                var result = confirm("Bạn chắc chắn muốn xóa bản ghi: " + treeNode.get_text()); args.set_cancel(!result); break;
            case "Rename":
                treeNode.startEdit(); break;
        }
    }
</script>
<telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
    <telerik:RadTreeView ID="bicTreeView" Height="600" OnClientContextMenuItemClicking="contextMenuItemClicking" AllowNodeEditing="True" OnNodeEdit="bicTreeView_NodeEdit"
        runat="server" EnableDragAndDrop="True" OnNodeDrop="bicTreeView_HandleDrop" MultipleSelect="true" EnableDragAndDropBetweenNodes="true" Skin="Telerik"
        OnContextMenuItemClick="bicTreeView_ContextMenuItemClick" CausesValidation="False">
        <ContextMenus>
            <telerik:RadTreeViewContextMenu EnableRoundedCorners="true" Skin="Telerik" ID="MainContextMenu" runat="server">
                <Items>
                    <telerik:RadMenuItem Value="Add"    ImageUrl="~/admin/Styles/icon/ContextMenu/new.gif">
                    </telerik:RadMenuItem>
                    <telerik:RadMenuItem Value="Edit" Text="Chỉnh sửa" ImageUrl="~/admin/Styles/icon/ContextMenu/edit.gif">
                    </telerik:RadMenuItem>
                    <telerik:RadMenuItem Value="Rename" PostBack="false" Text="Đổi tên (F2)" ImageUrl="~/admin/Styles/icon/ContextMenu/rename.gif">
                    </telerik:RadMenuItem>
                    <telerik:RadMenuItem Value="Duplicate" Text="Nhân bản" ImageUrl="~/admin/Styles/icon/ContextMenu/duplicate.gif">
                    </telerik:RadMenuItem>
                    <telerik:RadMenuItem Value="Up" Text="Lên" ImageUrl="~/admin/Styles/icon/ContextMenu/up.gif">
                    </telerik:RadMenuItem>
                    <telerik:RadMenuItem Value="Down" Text="Xuống" ImageUrl="~/admin/Styles/icon/ContextMenu/down.gif">
                    </telerik:RadMenuItem>
                    <telerik:RadMenuItem Value="Delete" Text="Xóa" ImageUrl="~/admin/Styles/icon/ContextMenu/delete.gif">
                    </telerik:RadMenuItem>
                </Items>
            </telerik:RadTreeViewContextMenu>
        </ContextMenus>
    </telerik:RadTreeView>
</telerik:RadAjaxPanel>
<telerik:RadAjaxLoadingPanel runat="server" Skin="Telerik" ID="RadAjaxLoadingPanel1">
</telerik:RadAjaxLoadingPanel>
