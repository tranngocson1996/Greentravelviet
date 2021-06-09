<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdditionHotel.ascx.cs" Inherits="Admin_Components_Hotel_AdditionHotel" %>
<%@ Import Namespace="BIC.Utils" %>
<%@ Register Src="~/admin/Components/ImageGallery/ImageSelector.ascx" TagName="ImageSelector" TagPrefix="bic" %>
<div class="form-tool">
    <bic:ToolBar ID="tbTop" runat="server" />
    <asp:LinkButton ID="lbtnSave" CssClass="btn-save" runat="server" OnCommand="Save" CommandName="AddNew"><%= BicResource.GetValue("Admin","Admin_Save") %></asp:LinkButton>
</div>
<div class="form-caption">
    <%=BIC.Utils.BicMessage.InsertTitle%>
    <span class="note"><em>*</em>
        <%=BIC.Utils.BicMessage.RequireTitle%>
    </span>
</div>
<div class="form-view">
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Tên khách sạn<span class="validate">*</span>
            </div>
            <div class="input">
                <asp:TextBox ID="txtHotelName" CssClass="input-text" Width="95%" runat="server" /></div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Ảnh đại diện
            </div>
            <div class="input">
                <bic:ImageSelector ID="isImageID" runat="server" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Mô tả chi tiết
            </div>
            <div class="input">
                <%=IncludeAdmin.RadEditor()%>
                <bic:Editor Height="600px" ID="reBody" Width="98%" ToolsFile="~/admin/XMLData/Editor/RibbonFullSetOfTools.xml" ContentFilters="None"
                    runat="server" StripFormattingOnPaste="NoneSupressCleanMessage, MSWord, MSWordNoFonts" ToolbarMode="RibbonBar" Skin="Office2007" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Duyệt
            </div>
            <div class="input">
                <asp:CheckBox ID="chkIsActive" Checked="true" runat="server" /></div>
        </div>
    </div>
</div>
<div class="form-tool-bottom">
    <bic:ToolBar ID="tbBottom" runat="server" />
    <asp:LinkButton ID="lbtnSave2" CssClass="btn-save" runat="server" OnCommand="Save" CommandName="AddNew"><%= BicResource.GetValue("Admin","Admin_Save") %></asp:LinkButton>
</div>
<telerik:RadInputManager runat="server" ID="rimBICCMS" EnableEmbeddedSkins="false" Skin="BICCMS">
    <telerik:TextBoxSetting BehaviorID="bhHotelName" EmptyMessage="Nhập tên khách sạn" Validation-IsRequired="true">
        <TargetControls>
            <telerik:TargetInput ControlID="txtHotelName" />
        </TargetControls>
    </telerik:TextBoxSetting>
</telerik:RadInputManager>