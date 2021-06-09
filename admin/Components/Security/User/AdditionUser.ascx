<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdditionUser.ascx.cs" Inherits="Components_CreateUser" %>
<%@ Import Namespace="BIC.Utils" %>
<div class="form-tool">
    <bic:ToolBar ID="tbTop" runat="server" />
    <asp:LinkButton ID="lbtnSave" CssClass="btn-save" runat="server" OnCommand="Save" CommandName="Insert"><%=BicResource.GetValue("Admin","Admin_Security_User_Save") %></asp:LinkButton>
</div>
<div class="form-caption">
   <%=BicResource.GetValue("Admin","Admin_Security_User_PersonalInformation") %><span class="note"><em>*</em> <%=BicResource.GetValue("Admin","Admin_Security_User_PersonalInformation") %> </span>
</div>
<div class="form-view f4">
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                 <%=BicResource.GetValue("Admin","Admin_Security_User_AcountName") %> <span class="validate">*</span>
            </div>
            <div class="input">
                <asp:TextBox runat="server" ID="UserName" CssClass="input-text" Width="300px" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
               <%=BicResource.GetValue("Admin","Admin_Security_User_FullName") %> <span class="validate">*</span>
            </div>
            <div class="input">
                <asp:TextBox runat="server" ID="txtFullName" CssClass="input-text" Width="300px" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                <%=BicResource.GetValue("Admin","Admin_Security_User_Password") %> <span class="validate">*</span>
            </div>
            <div class="input">
                <asp:TextBox runat="server" ID="Password" CssClass="input-text" Width="300px" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
               <%=BicResource.GetValue("Admin","Admin_Security_User_Address") %>
            </div>
            <div class="input">
                <asp:TextBox runat="server" ID="txtAddress" class="input-text" Width="300px" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                 <%=BicResource.GetValue("Admin","Admin_Security_User_Email") %> <span class="validate">*</span>
            </div>
            <div class="input">
                <asp:TextBox runat="server" ID="Email" CssClass="input-text" Width="300px" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
              <%=BicResource.GetValue("Admin","Admin_Security_User_TitleCompanyName") %>
            </div>
            <div class="input">
                <asp:TextBox runat="server" ID="txtCompany" CssClass="input-text" Width="300px" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                <%=BicResource.GetValue("Admin","Admin_Security_User_HomePhone") %>
            </div>
            <div class="input">
                <asp:TextBox runat="server" ID="txtPhone" CssClass="input-text" Width="300px" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
               <%=BicResource.GetValue("Admin","Admin_Security_User_Mobile") %>
            </div>
            <div class="input">
                <asp:TextBox runat="server" ID="txtMobile" CssClass="input-text" Width="300px" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
               <%=BicResource.GetValue("Admin","Admin_Security_User_GroupPermissions") %> 
            </div>
            <div class="input">
                <asp:DropDownList runat="server" ID="ddlTypeOfUser" CssClass="input-select">
                    <asp:ListItem Value="System" Text="<%$Resources:Admin,Admin_Security_User_System%>"></asp:ListItem>
                    <asp:ListItem Selected="True" Value="User"  Text="<%$Resources:Admin,Admin_Security_User_Member%>"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
              <%=BicResource.GetValue("Admin","Admin_Security_User_GroupPermissions") %>
            </div>
            <div class="input">
                <asp:CheckBoxList ID="chklRoles" runat="server" />
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
    <asp:LinkButton ID="lbtnSave2" CssClass="btn-save" runat="server" OnCommand="Save" CommandName="Insert"><%=BicResource.GetValue("Admin","Admin_Security_User_Save") %></asp:LinkButton>
</div>