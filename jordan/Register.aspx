<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Web_Vindeed.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <p>&nbsp;</p>
<p>&nbsp;</p>
    <table style="width:100%;">
        <tr>
            <td style="width: 227px; height: 22px;">&nbsp;&nbsp;
                <asp:Label ID="lblUserName" runat="server" Text="Email"></asp:Label>
            </td>
            <td style="height: 22px">
                <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
            </td>
            <td style="height: 22px"></td>
        </tr>
        <tr>
            <td style="width: 227px; height: 22px;">&nbsp;&nbsp; Role&nbsp;</td>
            <td style="height: 22px">
                <asp:DropDownList ID="ddlRole" runat="server">
                    <asp:ListItem>Select a Role</asp:ListItem>
                    <asp:ListItem>Volunteer</asp:ListItem>
                    <asp:ListItem>Organization</asp:ListItem>
                    <asp:ListItem>Administrator</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="height: 22px">&nbsp;</td>
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
            <td style="width: 227px; height: 22px">&nbsp;&nbsp;
                <asp:Label ID="lblPasswordConfirm" runat="server" Text="Confirm Password"></asp:Label>
                &nbsp;</td>
            <td style="height: 22px">
                <asp:TextBox ID="txtPasswordConfirm" runat="server" TextMode="Password"></asp:TextBox>
            </td>
            <td style="height: 22px">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 227px; height: 20px"></td>
            <td style="height: 20px">
                &nbsp;<asp:Label ID="lblmessage" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
            </td>
            <td style="height: 20px"></td>
        </tr>
        <tr>
            <td style="width: 227px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
            </td>
            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;<asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 227px">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 227px">&nbsp;&nbsp;&nbsp;
                </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
<p>&nbsp;</p>
    <p>Use this area to provide additional information.</p>
</asp:Content>
