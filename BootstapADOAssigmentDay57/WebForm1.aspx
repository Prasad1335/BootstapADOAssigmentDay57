<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="BootstapADOAssigmentDay57.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            
        </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataKeyNames="Id" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="None">
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
            <Columns>
                <asp:CommandField ShowDeleteButton="True" />
                <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="empNumber" HeaderText="empNumber" SortExpression="empNumber" />
                <asp:BoundField DataField="empName" HeaderText="empName" SortExpression="empName" />
                <asp:BoundField DataField="empGender" HeaderText="empGender" SortExpression="empGender" />
                <asp:BoundField DataField="empAddress" HeaderText="empAddress" SortExpression="empAddress" />
                <asp:BoundField DataField="empDepartment" HeaderText="empDepartment" SortExpression="empDepartment" />
                <asp:BoundField DataField="empPosition" HeaderText="empPosition" SortExpression="empPosition" />
                <asp:BoundField DataField="empDOJ" HeaderText="empDOJ" SortExpression="empDOJ" />
                <asp:BoundField DataField="empEmail" HeaderText="empEmail" SortExpression="empEmail" />
            </Columns>
            <FooterStyle BackColor="Tan" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <SortedAscendingCellStyle BackColor="#FAFAE7" />
            <SortedAscendingHeaderStyle BackColor="#DAC09E" />
            <SortedDescendingCellStyle BackColor="#E1DB9C" />
            <SortedDescendingHeaderStyle BackColor="#C2A47B" />

        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:WaiManagement %>" DeleteCommand="DELETE FROM [Employee] WHERE [Id] = @Id" InsertCommand="INSERT INTO [Employee] ([empNumber], [empName], [empGender], [empAddress], [empDepartment], [empPosition], [empDOJ], [empEmail]) VALUES (@empNumber, @empName, @empGender, @empAddress, @empDepartment, @empPosition, @empDOJ, @empEmail)" SelectCommand="SELECT * FROM [Employee]" UpdateCommand="UPDATE [Employee] SET [empNumber] = @empNumber, [empName] = @empName, [empGender] = @empGender, [empAddress] = @empAddress, [empDepartment] = @empDepartment, [empPosition] = @empPosition, [empDOJ] = @empDOJ, [empEmail] = @empEmail WHERE [Id] = @Id">
            <DeleteParameters>
                <asp:Parameter Name="Id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="empNumber" Type="Int32" />
                <asp:Parameter Name="empName" Type="String" />
                <asp:Parameter Name="empGender" Type="String" />
                <asp:Parameter Name="empAddress" Type="String" />
                <asp:Parameter Name="empDepartment" Type="String" />
                <asp:Parameter Name="empPosition" Type="String" />
                <asp:Parameter DbType="Date" Name="empDOJ" />
                <asp:Parameter Name="empEmail" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="empNumber" Type="Int32" />
                <asp:Parameter Name="empName" Type="String" />
                <asp:Parameter Name="empGender" Type="String" />
                <asp:Parameter Name="empAddress" Type="String" />
                <asp:Parameter Name="empDepartment" Type="String" />
                <asp:Parameter Name="empPosition" Type="String" />
                <asp:Parameter DbType="Date" Name="empDOJ" />
                <asp:Parameter Name="empEmail" Type="String" />
                <asp:Parameter Name="Id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>
