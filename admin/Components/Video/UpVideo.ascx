<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UpVideo.ascx.cs" Inherits="Admin_Components_Video_UpVideo" %>
<%@ Import Namespace="BIC.Utils" %>
<%@ Register Src="~/admin/Components/ImageGallery/ImageSelectorForVideo.ascx" TagName="ImageSelectorForVideo" TagPrefix="bic" %>
<%--<script src='<%=Page.ResolveUrl("~/admin/Components/Video/AddVideoImg.js") %>'></script>--%>
<div class="form-tool">
    <bic:ToolBar ID="tbTop" runat="server" />
    <asp:LinkButton ID="lbtnSave" CssClass="btn-save" Style="padding-right: 20px;" runat="server" OnCommand="Save" CommandName="AddNew">
        <telerik:RadCodeBlock ID="RadCodeBlock31" runat="server">
            <%=BicResource.GetValue("Admin","Admin_Save") %>
        </telerik:RadCodeBlock>
    </asp:LinkButton>
</div>
<div class="form-view">
    <asp:HiddenField ID="hdfLangManager" runat="server" />
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock4" runat="server">
                    <%=BicResource.GetValue("Admin","Admin_Video_TenVideo") %>
                </telerik:RadCodeBlock>


                <span class="validate">*</span>
            </div>
            <div class="input">
                <asp:TextBox ID="txtName" CssClass="input-text" Width="440" runat="server" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
                    <%=BicResource.GetValue("Admin","Admin_Video_Anhmota") %>
                </telerik:RadCodeBlock>

            </div>
            <div class="input">
                <%-- <img src="../../Styles/img/no_image.gif" id="videoimg" />--%>
                <bic:ImageSelectorForVideo ID="isImageID" runat="server" />
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock2" runat="server">
                    <%=BicResource.GetValue("Admin","Admin_Video_Danhmucvideo") %>
                </telerik:RadCodeBlock>

            </div>
            <div class="input">
                <bic:MenuRecursion ID="ddlTypeOfVideoID" CssClass="input-select" TypeOfControl="video" runat="server" />
            </div>
        </div>
    </div>
    <div class="frow hidden">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock3" runat="server">
                    <%=BicResource.GetValue("Admin","Admin_XML_Config_Category") %>
                </telerik:RadCodeBlock>
            </div>
            <div class="input">
                <asp:DropDownList ID="ddlVideoType" CssClass="input-select" Width="75" runat="server">
                    <asp:ListItem Value="video">video</asp:ListItem>
                    <asp:ListItem Value="music">music</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
    </div>
    <div class="frow">
        <div class="frow-wrapp">
            <div class="label">
                Url
            </div>
            <div class="input">
                <asp:TextBox ID="txtUrl" CssClass="input-text" Width="430" runat="server" />
            </div>
        </div>
    </div>
    <div class="frow hidden">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock5" runat="server">
                    <%=BicResource.GetValue("Admin","Admin_Video_uploadVideo") %>
                </telerik:RadCodeBlock>

            </div>
            <div class="input">
                <div class="upload-control">
                    <telerik:RadAsyncUpload HttpHandlerUrl="~/CustomHandler.ashx" Skin="Vista" TemporaryFolder="~/FileUpload/Temp" runat="server" ID="ruMedia" OnFileUploaded="rauUpload_FileUploaded" MaxFileSize="1048576000" MultipleFileSelection="Disabled" MaxFileInputsCount="1" TargetFolder="~/FileUpload/Medias" AllowedFileExtensions="mp4,flv,mov,3gp,mp3,acc,wav">
                        <FileFilters>
                            <telerik:FileFilter Description="Videos(mp4, flv, mov, 3gp, mp3, acc, wav)" Extensions="mp4,flv,mov,3gp,mp3,acc,wav" />
                        </FileFilters>
                    </telerik:RadAsyncUpload>
                    <div class="note_upload">
                        <telerik:RadCodeBlock ID="RadCodeBlock6" runat="server">
                            <%=BicResource.GetValue("Admin","Admin_Video_Dinhdangchophep") %>
                        </telerik:RadCodeBlock>
                        : mp4, flv, mov, 3gp, mp3, acc, wav
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="frow hidden">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock7" runat="server">
                    <%=BicResource.GetValue("Admin","System_Description") %>
                </telerik:RadCodeBlock>
            </div>
            <div class="input">
                <bic:Editor Height="300px" Skin="Office2007" Width="98%" ID="reDescription" ToolbarMode="ShowOnFocus" ToolsFile="~/admin/XMLData/Editor/SmallSetOfTools.xml" runat="server" StripFormattingOnPaste="All" />
            </div>
        </div>
    </div>
    <div class="frow hidden">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock8" runat="server">
                    <%=BicResource.GetValue("Admin","Admin_Adv_Views") %>
                </telerik:RadCodeBlock>

            </div>
            <div class="input">
                <asp:TextBox ID="txtViewed" CssClass="input-text" Width="100" runat="server" />
            </div>
        </div>
    </div>
    <div class="frow hidden">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock9" runat="server">
                    <%=BicResource.GetValue("Admin","System_New") %>
                </telerik:RadCodeBlock>

            </div>
            <div class="input">
                <asp:CheckBox ID="chkIsNew" CssClass="" Width="" runat="server" />
            </div>
        </div>
    </div>
    <div class="frow hidden">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock10" runat="server">
                    <%=BicResource.GetValue("Admin","Admin_FrameView_Home") %>
                </telerik:RadCodeBlock>

            </div>
            <div class="input">
                <asp:CheckBox ID="chkIsHome" CssClass="" Width="" runat="server" />
            </div>
        </div>
    </div>
    <div class="frow hidden">
        <div class="frow-wrapp">
            <div class="label">
                <telerik:RadCodeBlock ID="RadCodeBlock11" runat="server">
                    <%=BicResource.GetValue("Admin","System_Browse") %>
                </telerik:RadCodeBlock>

            </div>
            <div class="input">
                <asp:CheckBox ID="chkIsActive" CssClass="" Width="" runat="server" Checked="true" />
            </div>
        </div>
    </div>
</div>
<div class="form-tool-bottom">
    <bic:ToolBar ID="tbBottom" runat="server" />
    <asp:LinkButton ID="lbtnSave2" CssClass="btn-save" runat="server" OnCommand="Save" Style="padding-right: 20px;" CommandName="AddNew">
        <telerik:RadCodeBlock ID="RadCodeBlock12" runat="server">
            <%=BicResource.GetValue("Admin","Admin_Save") %>
        </telerik:RadCodeBlock>
    </asp:LinkButton>
</div>
<telerik:RadInputManager runat="server" ID="rimBICCMS" EnableEmbeddedSkins="false" Skin="BICCMS">
    <telerik:TextBoxSetting BehaviorID="bhName" EmptyMessage="Nhập tên video" Validation-IsRequired="true">
        <TargetControls>
            <telerik:TargetInput ControlID="txtName" />
        </TargetControls>
    </telerik:TextBoxSetting>
    <telerik:NumericTextBoxSetting BehaviorID="bhViewed" DecimalDigits="0">
        <TargetControls>
            <telerik:TargetInput ControlID="txtViewed" />
        </TargetControls>
    </telerik:NumericTextBoxSetting>
</telerik:RadInputManager>
