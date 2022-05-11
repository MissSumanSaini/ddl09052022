<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1ddl.aspx.cs" Inherits="ddl09052022.WebForm1ddl" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table >
                <tr>
                    <td> Name: </td>
                     <td> <asp:TextBox id="txtName" runat="server"> </asp:TextBox> </td>
                </tr>

                <tr>
                    <td> Age: </td>
                     <td> <asp:TextBox id="TxtAge" runat="server"> </asp:TextBox> </td>
                </tr>

                 <tr>
                    <td> Blood Group: </td>
                     <td> <asp:RadioButtonList ID="rblbg" RepeatColumns="6" runat ="server"></asp:RadioButtonList> </td>
                </tr>

                 <tr>
                    <td> Country: </td>
                     <td> <asp:DropDownList id="DdlCountry" runat="server" ></asp:DropDownList> </td>
                </tr>

                 <tr>
                    <td> </td>

                    <td> <asp:Button id="btnsave" Text ="Save" OnClick="btnsave_Click" runat="server"> </asp:Button> </td>
                </tr>

                   <tr>  
                    <td> </td>
                   <td> <asp:GridView id="grdview" runat="server" AutoGenerateColumns="false" OnRowCommand ="grdview_RowCommand">
                        <Columns> 
                        <asp:TemplateField HeaderText="Userid">
                        <ItemTemplate>
                         <%#Eval("Userid") %>
                        </ItemTemplate>
                        </asp:TemplateField>

                    <asp:TemplateField HeaderText="UserName">
                        <ItemTemplate>
                         <%#Eval("UserName") %>
                        </ItemTemplate>
                        </asp:TemplateField>

                            <asp:TemplateField HeaderText="UserAge">
                        <ItemTemplate>
                         <%#Eval("UserAge") %>
                        </ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="User Blood Group">
                        <ItemTemplate>
                         <%#Eval("bgname") %>
                        </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="User Country">
                        <ItemTemplate>
                         <%#Eval("Cname") %>
                        </ItemTemplate>
                        </asp:TemplateField>

             <asp:TemplateField >
             <ItemTemplate>
             <asp:Button id="BtnDelete" runat="server" Text="Delete" CommandArgument='<%#Eval("Userid") %>'  CommandName="A" />
             </ItemTemplate>
             </asp:TemplateField>

             <asp:TemplateField>
             <ItemTemplate>
             <asp:Button id="BtnEdit" runat="server" Text="Edit" CommandArgument='<%#Eval("Userid") %>'  CommandName="B" />
             </ItemTemplate>
             </asp:TemplateField>
             </Columns> 

             </asp:GridView> </td>
             </tr>
            </table>
        </div>
    </form>
</body>
</html>
