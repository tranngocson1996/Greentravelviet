<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditionMenuAdmin.ascx.cs" Inherits="admin_Components_MenuAdmin_EditionMenuAdmin" %>
<%@ Import Namespace="BIC.Utils" %>
<%@ Register Src="TreeviewMenuAdmin.ascx" TagName="TreeviewMenuAdmin" TagPrefix="uc1" %>
<script type="text/javascript">
    function SetURL() {var controlid = document.getElementById('ddlControl').value;if (controlid != 0) document.getElementById('txtUrl').value = '&cid=' + document.getElementById('ddlControl').value + '&action=list';else document.getElementById('txtUrl').value = '';}
</script>
<script>
    $(function() {Scroll($("#content1"), $("#slider1"));Scroll($("#content1"), $("#slider2"));});
</script>
<div class="form-tool">
    <bic:ToolBar ID="tbTop" runat="server" />
    <asp:LinkButton ID="lbtnSave" CssClass="btn-save" runat="server" OnCommand="Save" CommandName="Edit"><%=BicResource.GetValue("Admin","Admin_MenuAdmin_Save") %></asp:LinkButton>
</div>
<div class="form-caption">
    <%= BicMessage.UpdateTitle %>
    <span class="note"><em>*</em>
        <%= BicMessage.RequireTitle %></span>
</div>
<div class="form-view-tree">
    <div class="main-wrapp">
        <div class="main">
            <div class="form-view f2">
                <div class="frow">
                    <div class="label">
                       <%=BicResource.GetValue("Admin","Admin_MenuAdmin_NameList")%><span class="validate">*</span>
                    </div>
                    <div class="input">
                        <asp:TextBox runat="server" ID="txtName" CssClass="input-text" Width="198px" />
                        <asp:Literal ID="ltlName" runat="server"></asp:Literal>
                    </div>
                </div>
                <div class="frow">
                    <div class="label">
                        <%=BicResource.GetValue("Admin","Admin_MenuAdmin_CategoriesParent")%>
                    </div>
                    <div class="input">
                        <asp:DropDownList ID="ddlParentID" runat="server" class="input-select" Width="210px">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="frow">
                    <div class="label">
                         <%=BicResource.GetValue("Admin","Admin_MenuAdmin_Function")%>
                    </div>
                    <div class="input">
                        <asp:DropDownList ID="ddlControl" runat="server" onchange='SetURL();' ClientIDMode="Static" class="input-select" Width="210px" />
                    </div>
                </div>
                <div class="frow" id="divUrl">
                    <div class="label">
                                               <%=BicResource.GetValue("Admin","Admin_MenuAdmin_SourceLinks")%>
                    </div>
                    <div class="input">
                        <input type="text" runat="server" id="txtUrl" clientidmode="Static" class="input-text" style="width:250px" />
                    </div>
                </div>
                <div class="frow">
                    <div class="label">
                <%=BicResource.GetValue("Admin","Admin_MenuAdmin_KeyShortcuts")%>
                    </div>
                    <div class="input">
                        <asp:DropDownList runat="server" ID="ddlAlphabetica" class="input-select">
                            <asp:ListItem Text="None" Value=""></asp:ListItem>
                            <asp:ListItem>B</asp:ListItem>
                            <asp:ListItem>C</asp:ListItem>
                            <asp:ListItem>G</asp:ListItem>
                            <asp:ListItem>I</asp:ListItem>
                            <asp:ListItem>J</asp:ListItem>
                            <asp:ListItem>K</asp:ListItem>
                            <asp:ListItem>M</asp:ListItem>
                            <asp:ListItem>N</asp:ListItem>
                            <asp:ListItem>Q</asp:ListItem>
                            <asp:ListItem>R</asp:ListItem>
                            <asp:ListItem>S</asp:ListItem>
                            <asp:ListItem>T</asp:ListItem>
                            <asp:ListItem>U</asp:ListItem>
                            <asp:ListItem>V</asp:ListItem>
                            <asp:ListItem>W</asp:ListItem>
                            <asp:ListItem>X</asp:ListItem>
                            <asp:ListItem>Y</asp:ListItem>
                            <asp:ListItem>Z</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="frow">
                    <div class="label">
                        <%=BicResource.GetValue("Admin","Admin_MenuAdmin_Icon")%>
                    </div>
                    <div class="input">
                        <input type="text" runat="server" id="txtIcon" class="input-text w2" />
                    </div>
                </div>
                <div class="frow">
                    <div class="label">
                       <%=BicResource.GetValue("Admin","System_Target")%>
                    </div>
                    <div class="input">
                        <bic:Target runat="server" ID="ddlTarget" CssClass="input-select wa">
                        </bic:Target>
                    </div>
                </div>
                <div class="frow">
                    <div class="label">
                       <%=BicResource.GetValue("Admin","System_Locks")%>
                    </div>
                    <div class="input">
                        <asp:CheckBox ID="chkIsActive" runat="server" />
                    </div>
                </div>
                <div class="frow">
                    <div class="label">
                         <%=BicResource.GetValue("Admin","System_Description")%>
                    </div>
                    <div class="input">
                        <telerik:RadEditor Height="300px" Width="100%" ID="reDescription" EnableResize="true" ToolsFile="~/admin/XMLData/Editor/BasicTools.xml"
                                           EnableViewState="False" runat="server" Skin="Windows7" StripFormattingOnPaste="All">
                        </telerik:RadEditor>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="side-wrapp">
        <div class="slider-wrapper-top">
            <div class="content-slider" id="slider2">
            </div>
        </div>
        <div class="side">
            <uc1:TreeviewMenuAdmin ID="tvMain" runat="server" />
        </div>
        <div class="slider-wrapper">
            <div class="content-slider" id="slider1">
            </div>
        </div>
    </div>
</div>
<div class="form-tool-bottom">
    <bic:ToolBar ID="tbBottom" runat="server" />
    <asp:LinkButton ID="lbtnSave2" CssClass="btn-save" runat="server" OnCommand="Save" CommandName="Edit"><%=BicResource.GetValue("Admin","Admin_MenuAdmin_Save") %></asp:LinkButton>
</div>