<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdditionImageType.ascx.cs" Inherits="Admin_Components_ImageType_AdditionImageType" %>
<%@ Import Namespace="BIC.Utils" %>
<%@ Register Src="TreeviewImageType.ascx" TagName="TreeviewImageType" TagPrefix="uc1" %>
<script type="text/javascript" language="javascript">
    $(function() {Scroll($("#content1"), $("#slider1"));Scroll($("#content1"), $("#slider2"));});
</script>
<div class="form-tool">
    <bic:ToolBar ID="tbTop" runat="server" />
    <asp:LinkButton ID="lbtnSave" CssClass="btn-save" runat="server" OnCommand="Save" CommandName="AddNew"></asp:LinkButton>
</div>
<div class="form-caption">
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <%= BicMessage.InsertTitle %>
        <span class="note"><em>*</em>
            <%= BicMessage.RequireTitle %></span>
    </telerik:RadCodeBlock>
</div>
<div class="form-view-tree">
    <div class="main-wrapp">
        <div class="main">
            <div class="form-view f2">
                <div class="frow">
                    <div class="label">
                        Tên danh mục<span class="validate">*</span>
                    </div>
                    <div class="input">
                        <asp:TextBox runat="server" ID="txtName" CssClass="input-text" Width="260px" />
                    </div>
                </div>
                <div class="frow">
                    <div class="label">
                        Chuyên mục cha
                    </div>
                    <div class="input">
                        <asp:DropDownList ID="ddlParentID" runat="server" class="input-select" Width="210px">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="frow">
                    <div class="label">
                        Khóa
                    </div>
                    <div class="input">
                        <asp:CheckBox ID="chkIsActive" runat="server" />
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
        <div class="side" id="content1">
            <uc1:TreeviewImageType ID="tvMain" runat="server" />
        </div>
        <div class="slider-wrapper">
            <div class="content-slider" id="slider1">
            </div>
        </div>
    </div>
</div>
<div class="form-tool-bottom">
    <bic:ToolBar ID="tbBottom" runat="server" />
    <asp:LinkButton ID="lbtnSave2" CssClass="btn-save" runat="server" OnCommand="Save" CommandName="AddNew"></asp:LinkButton>
</div>
</telerik:RadInputManager>