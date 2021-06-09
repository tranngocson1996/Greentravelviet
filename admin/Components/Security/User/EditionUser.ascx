<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditionUser.ascx.cs" Inherits="Admin_EditUser" %>
<%@ Import Namespace="BIC.Utils" %>
<div class="form-tool">
    <bic:ToolBar ID="tbTop" runat="server" />
    <asp:LinkButton ID="lbtnSave" CssClass="btn-save" runat="server" OnCommand="Save" CommandName="Update"><%=BicResource.GetValue("Admin","Admin_Security_User_Save")%></asp:LinkButton>
</div>
<div class="form-caption">
   <%=BicResource.GetValue("Admin","Admin_Security_User_AcuontInfomation")%>
</div>
<div class="form-view f4">
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
              <%=BicResource.GetValue("Admin","Admin_Security_User_AcountName") %>n
            </div>
            <div class="input">
                <asp:Literal ID="lblUserName" runat="server"></asp:Literal>
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
               <%=BicResource.GetValue("Admin","Admin_Security_User_RegistrationDate")%> 
            </div>
            <div class="input">
                <asp:Literal ID="lblRegistered" runat="server"></asp:Literal>
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
              <%=BicResource.GetValue("Admin","Admin_Security_User_LastVisitn")%>  
            </div>
            <div class="input">
                <asp:Literal ID="lblLastLogin" runat="server"></asp:Literal>
            </div>
        </div>
    </div>
    <%--    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
               Trạng thái
            </div>
            <div class="input">
                <asp:label runat="server" id="lblOnline" />
            </div>
        </div>
    </div>--%>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                <%=BicResource.GetValue("Admin","Admin_Security_Browser")%>
            </div>
            <div class="input">
                <asp:CheckBox ID="chkApproved" runat="server" Text="<%$Resources:Admin,Admin_Security_User_TickToApproveOrDenyTheAccount%>" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
               <%=BicResource.GetValue("Admin","System_Locks")%>
            </div>
            <div class="input">
                <asp:CheckBox ID="chkLookOut" runat="server" Text="<%$Resources:Admin,Admin_Security_User_UnlockForAccount%>" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
              <%=BicResource.GetValue("Admin","Admin_Security_User_GroupPermissions")%> 
            </div>
            <div class="input">
                <asp:CheckBoxList ID="chklRoles" runat="server" />
               <%=BicResource.GetValue("Admin","Admin_Security_User_IntegrationIntoGroupsTheRightToSetOrRemoveUsersFromTheGroup")%> 
            </div>
        </div>
    </div>
</div>
<div class="form-caption">
  <%=BicResource.GetValue("Admin","Admin_Security_User_PersonalInformation")%><span class="note"><em>*</em>  <%=BicResource.GetValue("Admin","Admin_Security_User_FieldRequiredToEnterContent")%> </span>
</div>
<div class="form-view f4">
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
              <%=BicResource.GetValue("Admin","Admin_Security_User_FullName")%> <span class="validate">*</span>
            </div>
            <div class="input">
                <input type="text" name="FullName" runat="server" id="txtFullName" style="width:300px" class="input-text" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
               <%=BicResource.GetValue("Admin","Admin_Security_User_Address")%>
            </div>
            <div class="input">
                <input type="text" runat="server" name="Address" id="txtAddress" style="width:300px" class="input-text" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
               <%=BicResource.GetValue("Admin","Admin_Security_User_Email")%> <span class="validate">*</span>
            </div>
            <div class="input">
                <asp:TextBox runat="server" ID="Email" CssClass="input-text" Style="width:300px" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
              <%=BicResource.GetValue("Admin","Admin_Security_User_TitleCompanyName")%>
            </div>
            <div class="input">
                <asp:TextBox runat="server" ID="txtCompany" CssClass="input-text" Style="width:300px" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
              <%=BicResource.GetValue("Admin","Admin_Security_User_HomePhone")%>
            </div>
            <div class="input">
                <input type="text" runat="server" id="txtPhone" class="input-text" style="width:300px" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
              <%=BicResource.GetValue("Admin","Admin_Security_User_Mobile")%>
            </div>
            <div class="input">
                <input type="text" runat="server" id="txtMobile" class="input-text" style="width:300px" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
             <%=BicResource.GetValue("Admin","Admin_Security_User_GroupPermissions")%>
            </div>
            <div class="input">
                <asp:DropDownList runat="server" ID="ddlTypeOfUser" CssClass="input-select">
                    <asp:ListItem Selected="True" Value="System" Text="<%$Resources:Admin,Admin_Security_User_System%>"></asp:ListItem>
                    <asp:ListItem Value="User" Text="<%$Resources:Admin,Admin_Security_User_Member%>"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
            <%=BicResource.GetValue("Admin","System_Description") %>
            </div>
            <div class="input">
                <div class="input-area w2">
                    <asp:TextBox runat="server" ID="txtDescription" TextMode="MultiLine" />
                </div>
            </div>
        </div>
    </div>
</div>
<div class="form-tool-bottom">
    <bic:ToolBar ID="tbTop2" runat="server" />
    <asp:LinkButton ID="lbtnSave2" CssClass="btn-save" runat="server" OnCommand="Save" CommandName="Update"><%=BicResource.GetValue("Admin","Admin_Security_User_Save")%></asp:LinkButton>
</div>