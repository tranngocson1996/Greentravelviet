<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Welcome.ascx.cs" Inherits="admin_Controls_Welcome" %>
<%@ Import Namespace="BIC.Utils" %>
<script language="javascript" type="text/javascript">
    $(document).ready(function () { Scroll($("#content1"), $("#slider1")); Scroll($("#content2"), $("#slider2")); Scroll($("#content3"), $("#slider3")); Scroll($("#content4"), $("#slider4")); });
</script>
<div class="form-view-welcome">
    <div class="form-tool">
        <%= BicXML.ToString("AdminTitle", "SearchEngine") %>
    </div>
    <div class="catelog-wrapper">
        <div class="co1 ">
            <div class="content-scroll" id="content1">
                <telerik:RadTreeView ID="rtCategory" runat="server" Skin="Telerik" OnNodeDataBound="rtCategory_NodeDataBound" />
            </div>
            <div class="slider-wrapper">
                <div class="content-slider" id="slider1">
                </div>
            </div>
        </div>
        <div class="space">
        </div>
        <div class="co1 ">
            <div class="content-scroll" id="content2">
                <telerik:RadTreeView ID="rtFunction" runat="server" Skin="Telerik" OnNodeDataBound="rtCategory_NodeDataBound" />
            </div>
            <div class="slider-wrapper">
                <div class="content-slider" id="slider2">
                </div>
            </div>
        </div>
        <div class="space">
        </div>
        <div class="co1 ">
            <div class="content-scroll" id="content3">
                <telerik:RadTreeView ID="rtUtils" runat="server" Skin="Telerik" OnNodeDataBound="rtCategory_NodeDataBound" />
            </div>
            <div class="slider-wrapper">
                <div class="content-slider" id="slider3">
                </div>
            </div>
        </div>
        <div class="space">
        </div>
        <div class="co1 colast ">
            <div class="content-scroll" id="content4">
                <telerik:RadTreeView ID="rtHelp" runat="server" Skin="Telerik" OnNodeDataBound="rtCategory_NodeDataBound" />
            </div>
            <div class="slider-wrapper">
                <div class="content-slider" id="slider4">
                </div>
            </div>
        </div>
        <div class="clear">
        </div>
        <div class="line">
        </div>
    </div>
</div>
