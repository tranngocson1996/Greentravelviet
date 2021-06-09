<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GoogleMaps.ascx.cs" Inherits="Controls_GoogleMap_GoogleMaps" %>
<%@ Import Namespace="BIC.Utils" %>
<div id="map" class="map"></div>
<asp:HiddenField ID="hdLat" runat="server" ClientIDMode="Static" />
<asp:HiddenField ID="hdLng" runat="server" ClientIDMode="Static" />
<asp:HiddenField ID="hdTitle" runat="server" ClientIDMode="Static" />
<asp:HiddenField ID="hdDescription" runat="server" ClientIDMode="Static" />
<asp:HiddenField ID="hdZoom" runat="server" ClientIDMode="Static" />
<script type="text/javascript" src="http://maps.google.com/maps/api/js?key=AIzaSyDxXlqTr2NQ6_pS9FWD9aX7NNyWEBzFZ_0&language=vi"></script>
<script type="text/javascript">
    window.onload = function () {
        var title = $("#hdTitle").val() != "" ? $.trim($("#hdTitle").val()) : "";
        var lat = $("#hdLat").val() != "" ? $.trim($("#hdLat").val()) : "";
        var lng = $("#hdLng").val() != "" ? $.trim($("#hdLng").val()) : "";
        var description = $("#hdDescription").val() != "" ? $.trim($("#hdDescription").val()) : "";
        var zoom = $("#hdZoom").val() != "" ? $.trim($("#hdZoom").val()) : "5";
        var mapOptions = {
            scrollwheel: false,
            center: new google.maps.LatLng(lat, lng),
            zoom: parseInt(zoom),
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };
        var infoWindow = new google.maps.InfoWindow();
        var map = new google.maps.Map(document.getElementById("map"), mapOptions);

        var myLatlng = new google.maps.LatLng(lat,lng);
        var marker = new google.maps.Marker({
            position: myLatlng,
            map: map,
            title: title,
            icon: "/favicon.ico"
        });
        (function (marker) {
            google.maps.event.addListener(marker, "click", function (e) {
                infoWindow.setContent(description);
                infoWindow.open(map, marker);
            });
        })
        (marker);
    };
</script>
