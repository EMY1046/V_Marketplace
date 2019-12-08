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
                <asp:TextBox ID="txtUserName" runat="server" MaxLength="40"></asp:TextBox>
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
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox>
            </td>
            <td style="height: 22px"></td>
        </tr>
        <tr>
            <td style="width: 227px; height: 22px">&nbsp;&nbsp;
                <asp:Label ID="lblPasswordConfirm" runat="server" Text="Confirm Password"></asp:Label>
                &nbsp;</td>
            <td style="height: 22px">
                <asp:TextBox ID="txtPasswordConfirm" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox>
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
            <td colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblActivation" runat="server"></asp:Label>
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 227px">&nbsp;<asp:Label ID="Label1" runat="server" Text="Email"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtNameActivation" runat="server" MaxLength="40"></asp:TextBox>
                </td>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Activation code"></asp:Label>
&nbsp;<asp:TextBox ID="txtCode" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnActivate" runat="server" OnClick="btnActivate_Click" Text="Activate" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">&nbsp;&nbsp;
                <asp:Label ID="lblMessageAct" runat="server"></asp:Label>
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
<p>&nbsp;</p>
    <br />
</asp:Content>
