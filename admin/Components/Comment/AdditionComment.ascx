<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdditionComment.ascx.cs" Inherits="Admin_Components_Comment_AdditionComment" %>
<%@ Import Namespace="BIC.Utils" %>
<div class="form-tool">
    <bic:ToolBar ID="tbTop" runat="server" />
    <asp:LinkButton ID="lbtnSave" CssClass="btn-save" runat="server" OnCommand="Save" CommandName="AddNew"> <%=BicResource.GetValue("Admin","Admin_Save") %></asp:LinkButton>
</div>
<div class="form-caption">
    <%= BicMessage.InsertTitle %>
    <span class="note"><em>*</em>
        <%= BicMessage.RequireTitle %>
    </span>
</div>
<div class="form-view">

    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                <%=BicResource.GetValue("Admin","Admin_Comment_StyleComment")%> <span class="validate">*</span>
            </div>
            <div class="input">
                <asp:DropDownList ID="ddlTypeOfComment" CssClass="input-select" AutoPostBack="true" runat="server" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                <%=BicResource.GetValue("Admin","Admin_Comment_Sender")%><span class="validate">*</span>
            </div>
            <div class="input">
                <asp:TextBox ID="txtFullName" CssClass="input-text" Width="200px" runat="server" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                <%=BicResource.GetValue("Admin","System_Phone")%>
            </div>
            <div class="input">
                <asp:TextBox ID="txtPhone" CssClass="input-text" Width="200px" runat="server" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                <%=BicResource.GetValue("Admin","System_Email")%>
            </div>
            <div class="input">
                <asp:TextBox ID="txtEmail" CssClass="input-text" Width="200px" runat="server" />
            </div>
        </div>
    </div>
    <%--Thêm chức năng suggestion kiểu google cho ô dropdownlist sau:--%>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                <%=BicResource.GetValue("Admin","Admin_Comment_Posts")%>
            </div>
            <div class="input">
                <asp:Label ID="lblbv" CssClass="input-text" Width="90%" runat="server" TextMode="MultiLine" Height="100" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                <%=BicResource.GetValue("Admin","System_Content")%>
            </div>
            <div class="input">
                <bic:Editor Height="500px" ID="txtDescription" Width="98%" ToolsFile="~/admin/XMLData/Editor/RibbonFullSetOfTools.xml"
                    ContentFilters="None" runat="server" StripFormattingOnPaste="NoneSupressCleanMessage, MSWord, MSWordNoFonts"
                    ToolbarMode="RibbonBarShowOnFocus" Skin="Office2007" />
                <%--<asp:TextBox ID="txtDescription" CssClass="input-text" Width="90%" runat="server" TextMode="MultiLine" Height="100" />--%>
            </div>
        </div>
    </div>
    <div class="frow hidden">
        <div class="frow-wrapp">
            <div class="label">
                <%=BicResource.GetValue("Admin","System_IsHot")%>
            </div>
            <div class="input">
                <asp:CheckBox ID="chkIsHot" CssClass="" Width="" runat="server" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                <%=BicResource.GetValue("Admin","System_Browse")%>
            </div>
            <div class="input">
                <asp:CheckBox ID="chkIsActive" Checked="true" CssClass="" Width="" runat="server" />
            </div>
        </div>
    </div>
</div>
<div class="form-tool-bottom">
    <bic:ToolBar ID="tbBottom" runat="server" />
    <asp:LinkButton ID="lbtnSave2" CssClass="btn-save" runat="server" OnCommand="Save" CommandName="AddNew"> <%=BicResource.GetValue("Admin","Admin_Save") %></asp:LinkButton>
</div>
<telerik:RadInputManager runat="server" ID="rimBICCMS" EnableEmbeddedSkins="false" Skin="BICCMS">
    <telerik:TextBoxSetting BehaviorID="bhFullName" EmptyMessage="<%$Resources:Admin, Admin_Comment_EnterTheNameOfTheSender%>" Validation-IsRequired="true">
        <TargetControls>
            <telerik:TargetInput ControlID="txtFullName" />
        </TargetControls>
    </telerik:TextBoxSetting>
</telerik:RadInputManager>
