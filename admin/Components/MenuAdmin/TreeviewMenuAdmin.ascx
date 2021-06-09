<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TreeviewMenuAdmin.ascx.cs" Inherits="admin_Components_MenuAdmin_TreeviewMenuAdmin" %>
<script type="text/javascript">
    function contextMenuItemClicking(sender, args) {var menuItem = args.get_menuItem();var treeNode = args.get_node();menuItem.get_menu().hide();switch (menuItem.get_value()) {
                                                                                                                                                     case "Delete":
                                                                                                                                                         var result = confirm("Bạn chắc chắn muốn xóa bản ghi: " + treeNode.get_text());args.set_cancel(!result);break;
        case "Rename":
            treeNode.startEdit();break;
                                                                                                                                                 }}
</script>
<telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
    <telerik:RadTreeView ID="bicTreeView" OnClientContextMenuItemClicking="contextMenuItemClicking" AllowNodeEditing="True" OnNodeEdit="bicTreeView_NodeEdit"
                         runat="server" EnableDragAndDrop="True" OnNodeDrop="bicTreeView_HandleDrop" MultipleSelect="true" EnableDragAndDropBetweenNodes="true"
                         Skin="Telerik" OnContextMenuItemClick="bicTreeView_ContextMenuItemClick" CausesValidation="False">
        <ContextMenus>
            <telerik:RadTreeViewContextMenu EnableRoundedCorners="true" Skin="Telerik" ID="MainContextMenu" runat="server">
                <Items>
                    <telerik:RadMenuItem Value="Edit" Text="<%$Resources:Admin, Admin_MenuAdmin_TreeviewMenuAdmin_Edit%>" ImageUrl="~/admin/Styles/icon/ContextMenu/edit.gif">
                    </telerik:RadMenuItem>
                    <telerik:RadMenuItem Value="Rename" PostBack="false" Text="<%$Resources:Admin, Admin_MenuAdmin_TreeviewMenuAdmin_Rename%>" ImageUrl="~/admin/Styles/icon/ContextMenu/rename.gif">
                    </telerik:RadMenuItem>
                    <%--<telerik:RadMenuItem Value="Duplicate" Text="<%$Resources:Admin, Admin_MenuAdmin_TreeviewMenuAdmin_Cloning%>" ImageUrl="~/admin/Styles/icon/ContextMenu/duplicate.gif">
                    </telerik:RadMenuItem>--%>
                    <telerik:RadMenuItem Value="Up" Text="<%$Resources:Admin, Admin_MenuAdmin_TreeviewMenuAdmin_Up%>" ImageUrl="~/admin/Styles/icon/ContextMenu/up.gif">
                    </telerik:RadMenuItem>
                    <telerik:RadMenuItem Value="Down" Text="<%$Resources:Admin, Admin_MenuAdmin_TreeviewMenuAdmin_Down%>" ImageUrl="~/admin/Styles/icon/ContextMenu/down.gif">
                    </telerik:RadMenuItem>
                    <telerik:RadMenuItem Value="Delete" Text="<%$Resources:Admin, Admin_MenuAdmin_TreeviewMenuAdmin_Delete%>" ImageUrl="~/admin/Styles/icon/ContextMenu/delete.gif">
                    </telerik:RadMenuItem>
                </Items>
            </telerik:RadTreeViewContextMenu>
        </ContextMenus>
    </telerik:RadTreeView>
</telerik:RadAjaxPanel>
<telerik:RadAjaxLoadingPanel runat="server" Skin="Telerik" ID="RadAjaxLoadingPanel1" BackgroundPosition="Center" EnableSkinTransparency="true">
</telerik:RadAjaxLoadingPanel>