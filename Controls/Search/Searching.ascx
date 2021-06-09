<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Searching.ascx.cs" Inherits="Controls_Search_Searching" %>
<%@ Import Namespace="BIC.Utils" %>
<%=Include.Search()%>
<div class="title-search">Tìm tour du lịch</div>
<div class="searchtour">
    <div class="nhaptukhoa">
        <%=BicResource.GetValue("inputkey") %>
        <div class="searchBlock">
            <div class="search-box">
                <input type="text" runat="server" id="txtSearch" clientidmode="Static" class="input-text" placeholder="<%$Resources:Resource,Keyword%>" />
            </div>
        </div>
    </div>
    <div class="diadiem">
        <%=BicResource.GetValue("Place") %>
        <div class="searchBlock">
            <div class="search-text">
                <telerik:RadComboBox ID="drlDiaDiem" EmptyMessage="<%$Resources:Resource,Place%>" ShowDropDownOnTextboxClick="True" Filter="Contains" EnableLoadOnDemand="True" runat="server" DataValueField="MenuUserID" DataTextField="Name" HighlightTemplatedItems="true" Height="33"
                    AllowCustomText="True">
                </telerik:RadComboBox>
            </div>
        </div>
    </div>
    <div class="soluongngay">
        <%=BicResource.GetValue("NumDay") %>
        <div class="searchBlock">
            <div class="search-text ">
                <telerik:RadComboBox ID="drlSoLuongNgay" EmptyMessage="<%$Resources:Resource,NumDay%>" ShowDropDownOnTextboxClick="True" Filter="Contains" EnableLoadOnDemand="True" runat="server" DataValueField="MenuUserID" DataTextField="Name" HighlightTemplatedItems="true" Height="33"
                    AllowCustomText="True">
                </telerik:RadComboBox>
            </div>
        </div>
    </div>
    <div class="timkiem">
        <%=BicResource.GetValue("Search") %>
        <asp:Button ID="ibtSearch" runat="server" CssClass="btn-search" Text='<%$Resources:Resource,Search%>' ClientIDMode="Static" OnClick="ibtSearch_Click" />
    </div>
    <div class="khoanggia hidden">
        <div class="searchBlock">
            <div class="search-text">
                <telerik:RadComboBox ID="drlGia" CssClass="drlGia" EmptyMessage="<%$Resources:Resource,PriceK%>" ShowDropDownOnTextboxClick="True" Filter="Contains" EnableLoadOnDemand="True" runat="server" DataValueField="MenuUserID" DataTextField="Name" HighlightTemplatedItems="true" Height="33"
                    AllowCustomText="True">
                </telerik:RadComboBox>
            </div>
        </div>
    </div>
    <div class="loaihinh hidden">
        <div class="searchBlock">
            <div class="search-text">
                <telerik:RadComboBox ID="drlLoaiHinh" EmptyMessage="<%$Resources:Resource,TypeTour%>" ShowDropDownOnTextboxClick="True" Filter="Contains" EnableLoadOnDemand="True" runat="server" DataValueField="MenuUserID" DataTextField="Name" HighlightTemplatedItems="true" Height="33"
                    AllowCustomText="True">
                </telerik:RadComboBox>
            </div>
        </div>
    </div>


</div>

<script type="text/javascript">
    function clickButton1(e, buttonid) {
        var evt = e ? e : window.event;
        var bt = document.getElementById(buttonid);
        if (bt) {
            if (evt.keyCode == 13) {
                bt.click();
                return false;
            }
        }
    }

</script>
