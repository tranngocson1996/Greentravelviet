<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdditionAdv.ascx.cs" Inherits="Admin_Components_Adv_AdditionAdv" %>
<%@ Import Namespace="BIC.Utils" %>
<style type="text/css">
    .RadTreeView.RadTreeView_Outlook {
        float: left;
    }
</style>
<div class="form-tool">
    <bic:ToolBar ID="tbTop" runat="server" />
    <asp:LinkButton ID="lbtnSave" CssClass="btn-save" runat="server" OnCommand="Save" CommandName="AddNew"><%=BicResource.GetValue("Admin","Admin_Save") %></asp:LinkButton>
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
                <%=BicResource.GetValue("Admin","System_Language") %>
            </div>
            <div class="input">
                <bic:Language ID="ddlLanguage" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlLanguage_SelectedIndexChanged" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                <%=BicResource.GetValue("Admin","Admin_Adv_NameAd") %> <span class="validate">*</span>
            </div>
            <div class="input">
                <asp:TextBox ID="txtName" CssClass="input-text" Width="95%" runat="server" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                URL
            </div>
            <div class="input">
                <bic:RequiredURL ID="txtURL" CssClass="input-text" Width="94%" runat="server" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                <%=BicResource.GetValue("Admin","Admin_Adv_AdPlacement") %>
            </div>
            <div class="input">
                
                <div style="width: 40%; float: left">
                    <asp:DropDownList ID="ddlTypeOfAdvID" CssClass="input-select" Width="300" runat="server" />
                </div>
                <div style="width: 30%; float: left">
                    <div class="label2" style="float: left; margin-right: 10px;">
                        <%=BicResource.GetValue("Admin","System_Target") %>
                    </div>
                    <bic:Target ID="ddlTarget" CssClass="input-select" Width="" runat="server" />
                </div>
                <div style="width: 30%; float: left">
                    <div class="label2" style="float: left; margin-right: 10px;">
                        <%=BicResource.GetValue("Admin","Admin_Adv_Order") %>
                    </div>
                    <asp:DropDownList runat="server" ID="ddlPosition" />
                </div>
            </div>
        </div>
    </div>

    <div class="frow hidden">
        <div class="frow-wrapp">
            <div class="label">
                <%=BicResource.GetValue("Admin","Admin_Adv_InThePage") %>
            </div>
            <div class="input">
                <telerik:RadTreeView runat="server" Skin="Outlook" CheckChildNodes="true" Width="280px" CheckBoxes="true" ID="tvOther" PersistLoadOnDemandNodes="true" LoadingStatusPosition="AfterNodeText"
                    CollapseAnimation-Duration="200" ExpandAnimation-Duration="200" ExpandAnimation-Type="InQuart" SingleExpandPath="False" OnNodeCheck="tvOther_OnNodeCheck" OnNodeExpand="tvMenuUser_NodeExpand">
                </telerik:RadTreeView>
                <telerik:RadTreeView runat="server" Skin="Outlook" Width="280px" CheckBoxes="true" CheckChildNodes="true" ID="tvnews" PersistLoadOnDemandNodes="true" LoadingStatusPosition="AfterNodeText"
                    CollapseAnimation-Duration="200" ExpandAnimation-Duration="200" ExpandAnimation-Type="InQuart" SingleExpandPath="False" OnNodeExpand="tvMenuUser_NodeExpand" MultipleSelect="True">
                </telerik:RadTreeView>

            </div>

        </div>
    </div>

    <%--<div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Lượt xem
            </div>
            <div class="input">
                <asp:TextBox ID="txtViewCount" CssClass="input-text" Width="100" runat="server" /></div>
        </div>
    </div>--%>
    <%--  <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Ngày hết hạn
            </div>
            <div class="input">
                <asp:TextBox ID="txtExpireDate" ClientIDMode="Static" CssClass="input-text" Width="100" runat="server" /></div>
        </div>
    </div>--%>
    <div class="frow hidden">
        <div class="frow-wrapp">
            <div class="label">
                <%=BicResource.GetValue("Admin","System_Content") %>
            </div>
            <div class="input">
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp advadmin">
            <%= IncludeAdmin.RadEditor() %>
            <bic:Editor Height="600px" ID="reDescription" Width="100%" ToolsFile="~/admin/XMLData/Editor/RibbonFullSetOfTools.xml" ContentFilters="None"
                runat="server" StripFormattingOnPaste="NoneSupressCleanMessage, MSWord, MSWordNoFonts" ToolbarMode="RibbonBar" Skin="Office2007" />
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                <%=BicResource.GetValue("Admin","System_Browse") %>
            </div>
            <div class="input">
                <asp:CheckBox ID="chkIsActive" Checked="true" CssClass="" Width="" runat="server" />
            </div>
        </div>
    </div>
</div>
<div class="form-tool-bottom">
    <bic:ToolBar ID="tbBottom" runat="server" />
    <asp:LinkButton ID="lbtnSave2" CssClass="btn-save" runat="server" OnCommand="Save" CommandName="AddNew"><%=BicResource.GetValue("Admin","Admin_Save") %></asp:LinkButton>
</div>
<telerik:RadInputManager runat="server" ID="rimBICCMS" EnableEmbeddedSkins="false" Skin="BICCMS">
    <telerik:TextBoxSetting BehaviorID="bhName" EmptyMessage="<%$Resources:Admin, Admin_Adv_EnterAd%>" Validation-IsRequired="true">
        <TargetControls>
            <telerik:TargetInput ControlID="txtName" />
        </TargetControls>
    </telerik:TextBoxSetting>
    <telerik:NumericTextBoxSetting BehaviorID="bhViewCount" DecimalDigits="0">
        <TargetControls>
            <telerik:TargetInput ControlID="txtViewCount" />
        </TargetControls>
    </telerik:NumericTextBoxSetting>
</telerik:RadInputManager>
