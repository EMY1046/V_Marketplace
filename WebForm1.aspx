<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Web_Vindeed.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
    <br />
</p>
<p>
</p>
<p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </p>
<p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    &nbsp;&nbsp;&nbsp;
</p>
    <table class="nav-justified">
        <tr>
            <td style="width: 438px" class="modal-sm">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label1" runat="server" Text="Job type"></asp:Label>
            </td>
            <td style="width: 470px">
                &nbsp;&nbsp;
                <asp:RadioButtonList ID="rdbtnLocation" runat="server" EnableTheming="True" RepeatDirection="Horizontal">
                    <asp:ListItem Value="ZipCode">Zip Code  </asp:ListItem>
                    <asp:ListItem Value="City">City  </asp:ListItem>
                    <asp:ListItem>All location</asp:ListItem>
                </asp:RadioButtonList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 438px; height: 22px">&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="ddlJobtype" runat="server">
                    <asp:ListItem>Please select a job type</asp:ListItem>
                    <asp:ListItem>Administratif</asp:ListItem>
                    <asp:ListItem>Arts</asp:ListItem>
                    <asp:ListItem>Education</asp:ListItem>
                    <asp:ListItem>Health</asp:ListItem>
                    <asp:ListItem>Hospitality</asp:ListItem>
                    <asp:ListItem>Logistic</asp:ListItem>
                    <asp:ListItem>Manufacturing</asp:ListItem>
                    <asp:ListItem>Marketing</asp:ListItem>
                    <asp:ListItem>Science</asp:ListItem>
                    <asp:ListItem>Technical</asp:ListItem>
                    <asp:ListItem>Technology</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="height: 22px; width: 470px;">
    <asp:TextBox ID="txtLocation" runat="server" Width="314px" MaxLength="40" ToolTip="Search by zip code or city or get all"></asp:TextBox>
            </td>
            <td style="height: 22px">
    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
            </td>
        </tr>
        </table>
<p>
    &nbsp;<asp:GridView ID="grdViewJobs" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateSelectButton="True" Height="118px" OnSelectedIndexChanged="grdViewJobs_SelectedIndexChanged" Width="1018px">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:HyperLinkField />
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
    </p>
<p>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</p>
<p>
    &nbsp;</p>
<p>
    
    </p>
    <p>
        &nbsp;</p>
    <!--
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="Panl1" TargetControlID="grdViewJobs"  
    CancelControlID="Button2" BackgroundCssClass="Background">
    </ajaxToolkit:ModalPopupExtender>
<asp:Panel ID="Panl1" runat="server" CssClass="Popup" align="center" style = "display:none">  
    <iframe style=" width: 680px; height: 560px;" id="irm1" src="Job_Application.aspx" runat="server"></iframe>  
   <br/>
    <asp:Button ID="Button2" runat="server" Text="Close" />  
</asp:Panel>
    -->
<p>
</p>
</asp:Content>
