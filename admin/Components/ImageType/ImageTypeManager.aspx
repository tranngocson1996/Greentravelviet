<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ImageTypeManager.aspx.cs" Inherits="admin_Components_MenuUser_MenuUserManager" %>

<%@ Import Namespace="BIC.Utils" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Quản lý nhóm ảnh</title>
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <%= IncludeAdmin.DefaultCss() %>
        <%= IncludeAdmin.JqueryUI() %>
        <%= IncludeAdmin.HighSlide() %>
        <%= IncludeAdmin.AdminImageUpload() %>
        <%= IncludeAdmin.AdminImageManager() %>
        <script type="text/javascript">
            $(function () { window.parent.$('#tabs > ul > li').removeClass('selected'); window.parent.$('#lnkcategory').parent().addClass('selected'); });
        </script>
    </telerik:RadCodeBlock>
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager runat="server">
        </telerik:RadScriptManager>
        <div class="body_view">
            <div class="gallery_caption2">
                <asp:LinkButton ID="lbtnAdd" CssClass="btn-addnew" runat="server" OnCommand="Command" CommandName="AddNew"><%=BicResource.GetValue("Admin","System_Add") %></asp:LinkButton>
                <a href='../../Components/ImageType/ImageTypeManager.aspx' class="btn-reset" id="lbtnReset" runat="server"><%=BicResource.GetValue("Admin","System_Reset") %></a>
                <asp:LinkButton ID="lbtnSave" CssClass="btn-save" runat="server" OnCommand="Command" CommandName="Save"><%=BicResource.GetValue("Admin","Admin_Save") %></asp:LinkButton>
                <div class="upload-right">
                </div>
            </div>
            <div class="frame_category">
                <div class="upload-left">
                    <div style="z-index: 999;">
                        <script type="text/javascript">
                            function contextMenuItemClicking(sender, args) {
                                var menuItem = args.get_menuItem(); var treeNode = args.get_node(); menuItem.get_menu().hide(); switch (menuItem.get_value()) {
                                    case "Delete":
                                        var result = confirm("Bạn chắc chắn muốn xóa nhóm " + treeNode.get_text() + " và tất cả hình ảnh thuộc nhóm này?"); args.set_cancel(!result); break;
                                    case "Rename":
                                        treeNode.startEdit(); break;
                                }
                            }
                        </script>
                        <telerik:RadTreeView ID="bicTreeView" Height="400" OnClientContextMenuItemClicking="contextMenuItemClicking" AllowNodeEditing="True" OnNodeEdit="bicTreeView_NodeEdit"
                            runat="server" EnableDragAndDrop="True" OnNodeDrop="bicTreeView_HandleDrop" MultipleSelect="true" EnableDragAndDropBetweenNodes="true" Skin="Telerik"
                            OnContextMenuItemClick="bicTreeView_ContextMenuItemClick">
                            <ContextMenus>
                                <telerik:RadTreeViewContextMenu EnableRoundedCorners="true" Skin="Telerik" ID="MainContextMenu" runat="server">
                                    <Items>
                                        <telerik:RadMenuItem Value="Add" Text="<%$Resources:Admin,System_Add%>" ImageUrl="~/admin/Styles/icon/ContextMenu/new.gif">
                                        </telerik:RadMenuItem>
                                        <telerik:RadMenuItem Value="Edit" Text="<%$Resources:Admin,Admin_MenuUser_TreeviewMenuUser_Edit%>" ImageUrl="~/admin/Styles/icon/ContextMenu/edit.gif">
                                        </telerik:RadMenuItem>
                                        <telerik:RadMenuItem Value="Rename" PostBack="false" Text="<%$Resources:Admin,Admin_MenuUser_TreeviewMenuUser_EditName%>" ImageUrl="~/admin/Styles/icon/ContextMenu/rename.gif">
                                        </telerik:RadMenuItem>
                                        <telerik:RadMenuItem Value="Duplicate" Text="<%$Resources:Admin,Admin_MenuUser_TreeviewMenuUser_Cloning%>" ImageUrl="~/admin/Styles/icon/ContextMenu/duplicate.gif">
                                        </telerik:RadMenuItem>
                                        <telerik:RadMenuItem Value="Up" Text="<%$Resources:Admin,Admin_MenuUser_TreeviewMenuUser_Up%>" ImageUrl="~/admin/Styles/icon/ContextMenu/up.gif">
                                        </telerik:RadMenuItem>
                                        <telerik:RadMenuItem Value="Down" Text="<%$Resources:Admin,Admin_MenuUser_TreeviewMenuUser_Down%>" ImageUrl="~/admin/Styles/icon/ContextMenu/down.gif">
                                        </telerik:RadMenuItem>
                                        <telerik:RadMenuItem Value="Delete" Text="<%$Resources:Admin,Admin_MenuUser_TreeviewMenuUser_Delete%>" ImageUrl="~/admin/Styles/icon/ContextMenu/delete.gif">
                                        </telerik:RadMenuItem>
                                    </Items>
                                </telerik:RadTreeViewContextMenu>
                            </ContextMenus>
                        </telerik:RadTreeView>
                    </div>
                </div>
                <div class="upload-right">
                    <div class="form-view f3 guhelp" runat="server" id="tblHelp">
                        <iframe src='<%= Page.ResolveUrl("~/admin/Styles/Flash/GalleryHelp/help.htm") %>' frameborder="0" width="440" height="400" allowtransparency="true" scrolling="no"></iframe>
                    </div>
                    <div class="form-view f3" runat="server" id="tblInfo">
                        <div class="frow">
                            <div class="label">
                                <%=BicResource.GetValue("Admin","Admin_MenuAdmin_NameList") %>
                            </div>
                            <div class="input">
                                <input type="text" runat="server" id="txtName" class="input-text full" />
                            </div>
                        </div>
                        <div class="frow">
                            <div class="label">
                                <%=BicResource.GetValue("Admin","Admin_MenuUser_ParentCategories") %>
                            </div>
                            <div class="input">
                                <asp:DropDownList ID="ddlParentID" class="input-select" Width="210" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="frow">
                            <div class="label">
                                <%=BicResource.GetValue("Admin","System_Locks") %>
                            </div>
                            <div class="input">
                                <asp:CheckBox ID="chkIsActive" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
