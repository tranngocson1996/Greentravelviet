<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TourDetail_BookingTab.ascx.cs" Inherits="Controls_Tour_TourDetail_BookingTab" %>
<%@ Import Namespace="BIC.Utils" %>  
<div class="bookingTabBlock">
        <telerik:RadCodeBlock ID="RadCodeBlock3" runat="server">
            <telerik:RadAjaxPanel RestoreOriginalRenderDelegate="false" runat="server" ID="rapContact3" LoadingPanelID="ralpContact3" >
                
                <telerik:RadCodeBlock ID="RadCodeBlock6" runat="server">
<div id="wrapper_content">
        <div class="booking">
           <div class="tourinfo">
                <div class="infotitle title">
                   <%=BicResource.GetValue("TourInformation") %> 
                </div>
                <div class="caption">
                      <%=BicResource.GetValue("Arrivaldate") %> 
                    <asp:TextBox ID="txtArrDatebook" ClientIDMode="Static" runat="server" CssClass="tbox tpos"></asp:TextBox>
               
                </div>
                <div class="caption">
                     <%=BicResource.GetValue("Departuredate") %>
                    <asp:TextBox ID="txtDepDatebook"  ClientIDMode="Static" runat="server" CssClass="tbox tpos"></asp:TextBox>
               
                </div>
              <div class="caption" style="height: 82px;">
                     <%=BicResource.GetValue("Guest") %>
                    <div class="tpos">
                        <div>
                        <label>
                           <%=BicResource.GetValue("Adults") %></label><asp:TextBox ID="txtGuestOver12" runat="server" CssClass="tbox tsmall"></asp:TextBox></div>
                        <div>
                        <label>
                            <%=BicResource.GetValue("Children") %></label><asp:TextBox ID="txtGuestUnder12" runat="server" CssClass="tbox tsmall"></asp:TextBox></div>
                        <div>
                        <label>
                            <%=BicResource.GetValue("Baby") %></label><asp:TextBox ID="txtGuestUnder2" runat="server" CssClass="tbox tsmall last"></asp:TextBox></div>
                    </div>
                   
                </div>
              <div class="caption">
              <label>
                     <%=BicResource.GetValue("Accommodation") %></label>
                    <asp:DropDownList ID="drlstyle" runat="server" CssClass="drl" Width="210">
                 
                    </asp:DropDownList>
                </div>
               <div class="caption" style="height: 90px">
                     <%=BicResource.GetValue("typeofroom") %>  
                    <div class="tpos">
                        <div>
                        <label>
                           <%=BicResource.GetValue("Single") %></label>
                            <asp:TextBox ID="txtRoomSingle" runat="server" CssClass="tbox tsmall"></asp:TextBox></div>
                        <div>
                        <label>
                            <%=BicResource.GetValue("Twin") %></label>
                            <asp:TextBox ID="txtRoomTwin" runat="server" CssClass="tbox tsmall"></asp:TextBox></div>
                        <div>
                        <label>
                            <%=BicResource.GetValue("Triple") %> </label>
                            <asp:TextBox ID="txtRoomTriple" runat="server" CssClass="tbox tsmall"></asp:TextBox></div>
                    </div>
                   
                </div>
            </div>
            <div class="userinfo">
                <div class="infotitle title">
                     <%=BicResource.GetValue("GuestInformation") %>  
                </div>
                <div class="half">
                    <div class="caption">
                       <%=BicResource.GetValue("Fullname") %> <span style="color:red">*</span>   
                        <asp:TextBox ID="txtFullname" runat="server" CssClass="tbox tpos"></asp:TextBox>
                    </div>
                    <div class="caption">
                         <%=BicResource.GetValue("Address") %>
                        <asp:TextBox ID="txtAddress" runat="server" CssClass="tbox tpos"></asp:TextBox>
                    </div>
                    <div class="caption">
                        <label>
                         <%=BicResource.GetValue("Country") %> </label>
                         <asp:DropDownList ID="drlNationality" runat="server" CssClass="drl"></asp:DropDownList>
                        <%--<asp:TextBox ID="txtCountry" runat="server" CssClass="tbox tpos"></asp:TextBox>--%>
                    </div>
                    <div class="caption">
                          
                         <%=BicResource.GetValue("Mobile") %> <span style="color:red">*</span>
                        <asp:TextBox ID="txtTelephone" runat="server" CssClass="tbox tpos"></asp:TextBox>
                    </div>
                    <div class="caption">
                        Email <span style="color:red">*</span>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="tbox tpos"></asp:TextBox>
                    </div>
                </div>
                <asp:TextBox ID="txtRequire" runat="server" val='requirement' CssClass='type'
                    TextMode="MultiLine"></asp:TextBox>

                <div class="clear"></div>
          
                  
            </div>
        </div>
    </div>
                    </telerik:RadCodeBlock>
    <div id="wrapper_foot">
        <div class="reset rsbook">
            <asp:Button ID="Button1" runat="server" CssClass="btnreset" OnCommand="btnBook_Click" OnClientClick="clearinput();"
                CommandName="Cancel" onclick="Button1_Click" Text="Reset all"/>
   
            <asp:Button ID="btnBook" runat="server" OnCommand="btnBook_Click" ValidationGroup="contact"
                CommandName="Booking" />
            
            
        </div>
    </div>
                  
           </telerik:RadAjaxPanel>
             
        </telerik:RadCodeBlock>
</div>

   <script type="text/javascript">
           $(".type").each(function () {
               $(this).val($(this).attr("val"));
           }).live("focusin focusout", function (event) {
               if (event.type == "focusin") {
                   if ($(this).val() == $(this).attr("val")) {
                       $(this).val("");
                   }
               }
               if (event.type == "focusout") {
                   if ($(this).val() == "") {
                       $(this).val($(this).attr("val"));
                   }
               }
           });
                $(function () {
                    $("#ctl00_cphSubLeft_TourDetail1_TourDetailBooking_racSendMail_CaptchaTextBoxLabel").inFieldLabels({ fadeOpacity: 0 });
                });

          
</script>
