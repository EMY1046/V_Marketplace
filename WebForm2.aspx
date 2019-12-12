<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Web_Vindeed.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
    <br />
&nbsp;&nbsp;
    <table style="width:100%;">
        <tr>
            <td style="width: 227px; height: 22px;">&nbsp;&nbsp;
                <asp:Label ID="lblUserName" runat="server" Text="UserName"></asp:Label>
            </td>
            <td style="height: 22px">
                <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
            </td>
            <td style="height: 22px"></td>
        </tr>
        <tr>
            <td style="width: 227px; height: 22px">&nbsp;&nbsp;
                <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
            </td>
            <td style="height: 22px">
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            </td>
            <td style="height: 22px"></td>
        </tr>
        <tr>
            <td style="width: 227px; height: 20px"></td>
            <td style="height: 20px">
                &nbsp;<asp:Label ID="lblmessage" runat="server"></asp:Label>
            </td>
            <td style="height: 20px"></td>
        </tr>
        <tr>
            <td style="width: 227px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
            </td>
            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" style="height: 26px" />
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 227px">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 227px">&nbsp;&nbsp;&nbsp;
                <asp:HyperLink ID="HyperLink1" runat="server">Forget password</asp:HyperLink>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</p>
<p>
&nbsp;&nbsp;&nbsp;
    <asp:HyperLink ID="HlkSignUp" runat="server" NavigateUrl="~/About.aspx">Sign Up</asp:HyperLink>
</p>
</asp:Content>
