<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdditionAdvVideo.ascx.cs" Inherits="Admin_Components_AdvVideo_AdditionAdvVideo" %>
<%@ Import Namespace="BIC.Utils" %>
<div class="form-tool">
    <bic:ToolBar ID="tbTop" runat="server" />
    <asp:LinkButton ID="lbtnSave" CssClass="btn-save" runat="server" OnCommand="Save" CommandName="AddNew"></asp:LinkButton>
</div>
<div class="form-caption">
    <%= BicMessage.InsertTitle %>
    <span class="note"><em>*</em>
        <%= BicMessage.RequireTitle %>
    </span>
</div>
<div class="form-view">
    <div class="frow hidden">
        <div class="frow-wrapp">
            <div class="label">
                Ngôn ngữ
            </div>
            <div class="input">
                <bic:Language ID="ddlLanguage" runat="server" />
            </div>
        </div>
    </div>
    <div class="frow alt">
        <div class="frow-wrapp">
            <div class="label">
                Tên<span class="validate">*</span>
            </div>
            <div class="input">
                <asp:TextBox ID="txtName" CssClass="input-text" Width="95%" runat="server" /></div>
        </div>
    </div>
  
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                URL Youtube
            </div>
            <div class="input">
                <asp:TextBox ID="txtURL" CssClass="input-text" Width="400" runat="server" /></div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Upload File
            </div>
            <div class="input">
                <input type="file" id="filePath" width="" class="" runat="server" /></div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Target
            </div>
            <div class="input">
                <bic:Target ID="ddlTarget" CssClass="input-select" Width="" runat="server" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Thời gian bắt đầu
            </div>
            <div class="input">
                <asp:RadioButtonList runat="server" ID="cbTimeSelect" RepeatColumns="12" RepeatDirection="Horizontal" CellPadding="5">
                    <asp:ListItem Value="0" Text="00"></asp:ListItem>
                    <asp:ListItem Value="1" Text="01"></asp:ListItem>
                    <asp:ListItem Value="2" Text="02"></asp:ListItem>
                    <asp:ListItem Value="3" Text="03"></asp:ListItem>
                    <asp:ListItem Value="4" Text="04"></asp:ListItem>
                    <asp:ListItem Value="5" Text="05"></asp:ListItem>
                    <asp:ListItem Value="6" Text="06"></asp:ListItem>
                    <asp:ListItem Value="7" Text="07"></asp:ListItem>
                    <asp:ListItem Value="8" Text="08"></asp:ListItem>
                    <asp:ListItem Value="9" Text="09"></asp:ListItem>
                    <asp:ListItem Value="10" Text="10"></asp:ListItem>
                    <asp:ListItem Value="11" Text="11"></asp:ListItem>
                    <asp:ListItem Value="12" Text="12"></asp:ListItem>
                    <asp:ListItem Value="13" Text="13"></asp:ListItem>
                    <asp:ListItem Value="14" Text="14"></asp:ListItem>
                    <asp:ListItem Value="15" Text="15"></asp:ListItem>
                    <asp:ListItem Value="16" Text="16"></asp:ListItem>
                    <asp:ListItem Value="17" Text="17"></asp:ListItem>
                    <asp:ListItem Value="18" Text="18"></asp:ListItem>
                    <asp:ListItem Value="19" Text="19"></asp:ListItem>
                    <asp:ListItem Value="20" Text="20"></asp:ListItem>
                    <asp:ListItem Value="21" Text="21"></asp:ListItem>
                    <asp:ListItem Value="22" Text="22"></asp:ListItem>
                    <asp:ListItem Value="23" Text="23"></asp:ListItem>
                </asp:RadioButtonList>
                <asp:TextBox ID="txtThoiGianBatDau" CssClass="input-text" Width="200" runat="server" Visible="False" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Thời lượng hiển thị
            </div>
            <div class="input">
                <asp:TextBox ID="txtKhoangThoiGian" CssClass="input-text" Width="" runat="server" /></div>
        </div>
    </div>
   <%-- <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Vị trí
            </div>
            <div class="input">
                <asp:DropDownList ID="ddlTypeOfAdvID" CssClass="input-select" Width="200" runat="server" />
            </div>
        </div>
    </div>--%>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Trang hiển thị
            </div>
            <div class="input">
                <telerik:RadTreeView runat="server" Skin="Outlook" CheckChildNodes="true" Width="280px" CheckBoxes="true" ID="tvOther" PersistLoadOnDemandNodes="true" LoadingStatusPosition="AfterNodeText" CssClass="left"
                                     CollapseAnimation-Duration="200" ExpandAnimation-Duration="200" ExpandAnimation-Type="InQuart" SingleExpandPath="False" OnNodeCheck="tvOther_OnNodeCheck" OnNodeExpand="tvMenuUser_NodeExpand">
                </telerik:RadTreeView>
                <telerik:RadTreeView runat="server" Skin="Outlook" Width="280px" CheckBoxes="true" CheckChildNodes="true" ID="tvnews" PersistLoadOnDemandNodes="true" LoadingStatusPosition="AfterNodeText" CssClass="left"
                                     CollapseAnimation-Duration="200" ExpandAnimation-Duration="200" ExpandAnimation-Type="InQuart" SingleExpandPath="False" OnNodeExpand="tvMenuUser_NodeExpand" MultipleSelect="True">
                </telerik:RadTreeView>
                <asp:TextBox ID="txtMenuUserID" CssClass="input-text" Text=",58," Width="200" runat="server" Visible="False" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Chữ hiển thị
            </div>
            <div class="input">
                <asp:TextBox ID="txtTextDisplay" CssClass="input-text" Width="400" runat="server" /></div>
        </div>
    </div>
      <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Link website liên kết
            </div>
            <div class="input">
                <asp:TextBox ID="txtLink" CssClass="input-text" Width="95%" runat="server" /></div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Mô tả
            </div>
            <div class="input">
                <bic:Editor Height="600px" Width="98%" ID="reDescription" EnableResize="true" ToolbarMode="RibbonBar" ToolsFile="~/admin/XMLData/Editor/RibbonFullSetOfTools.xml" runat="server" StripFormattingOnPaste="NoneSupressCleanMessage, MSWord, MSWordNoFonts" Skin="Office2007" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Lượt xem
            </div>
            <div class="input">
                <asp:TextBox ID="txtViewCount" CssClass="input-text" Width="100" runat="server" /></div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Thứ tự</div>
            <div class="input">
                <asp:DropDownList runat="server" ID="ddlPosition" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Duyệt
            </div>
            <div class="input">
                <asp:CheckBox runat="server" Enable="<%# Approved %>" Checked="true" ID="chkIsActive" /></div>
        </div>
    </div>
</div>
<div class="form-tool-bottom">
    <bic:ToolBar ID="tbBottom" runat="server" />
    <asp:LinkButton ID="lbtnSave2" CssClass="btn-save" runat="server" OnCommand="Save" CommandName="AddNew"></asp:LinkButton>
</div>
<telerik:RadInputManager runat="server" ID="rimBICCMS" EnableEmbeddedSkins="false" Skin="BICCMS">
    <telerik:TextBoxSetting BehaviorID="bhName" EmptyMessage="Nhập tên" Validation-IsRequired="true">
        <TargetControls>
            <telerik:TargetInput ControlID="txtName" />
        </TargetControls>
    </telerik:TextBoxSetting>
    <telerik:NumericTextBoxSetting BehaviorID="bhKhoangThoiGian" DecimalDigits="0" MinValue="0" MaxValue="24">
        <TargetControls>
            <telerik:TargetInput ControlID="txtKhoangThoiGian" />
        </TargetControls>
    </telerik:NumericTextBoxSetting>
    <telerik:NumericTextBoxSetting BehaviorID="bhViewCount" DecimalDigits="0">
        <TargetControls>
            <telerik:TargetInput ControlID="txtViewCount" />
        </TargetControls>
    </telerik:NumericTextBoxSetting>
</telerik:RadInputManager>