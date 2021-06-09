<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Maps.ascx.cs" Inherits="Controls_GoogleMap_Maps" %>
<%--<script type="text/javascript" src="http://maps.google.com/maps/api/js?sensor=true"></script>--%>
<script src="https://maps.googleapis.com/maps/api/js?v=3.exp&sensor=false"></script>
<script type="text/javascript" src='<%=Page.ResolveUrl("~/Controls/GoogleMap/map.js")%>'></script>
<link type="text/css" rel="Stylesheet" href='<%=Page.ResolveUrl("~/Controls/GoogleMap/maps.css")%>' />
<script type="text/javascript">
    $(document).ready(function () {
        mapgoogle();
        function mapgoogle() {
            function callback(pos, addr, addr_ext) {
                var strPos = pos.toString();
                $("#hdX").val(strPos.split(',')[0].replace("(", ""));
                $("#hdY").val(strPos.split(',')[1].replace(")", ""));
                $("#hdAddress").val(addr_ext);
                $("#hdView").val("0");
            }

            var opt = {
                posX: $("#hdX").val() != "" ? $.trim($("#hdX").val()) : undefined,
                posY: $("#hdY").val() != "" ? $.trim($("#hdY").val()) : undefined,
                callback: callback,
                width: 650,
                height: 556,
                container: "#maps1",
                search: true,
                buttunTitle: "",
                addressInput: $("#hdAddress").val() != "" ? $.trim($("#hdAddress").val()) : "",
                view: $.trim($("#hdView").val())
            };
            var addr_picker = new AddressPicker(opt);

            addr_picker.open();
        }
        
    });
</script>
<div id="maps1"></div>
<asp:HiddenField ID="hdX" runat="server" ClientIDMode="Static" />
<asp:HiddenField ID="hdY" runat="server" ClientIDMode="Static" />
<asp:HiddenField ID="hdAddress" runat="server" ClientIDMode="Static" />
<asp:HiddenField ID="hdView" runat="server" ClientIDMode="Static" />
<asp:TextBox runat="server" ClientIDMode="Static" CssClass="hidden" ID="txtXY"></asp:TextBox>
