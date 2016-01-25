<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Countries.Default" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:EntityDataSource ID="ContinentsDataSource" runat="server" ConnectionString="name=CountriesEntities" DefaultContainerName="CountriesEntities" EnableFlattening="False" EntitySetName="Continents" EntityTypeFilter="Continent" EnableDelete="True" EnableInsert="True" EnableUpdate="True">
            </asp:EntityDataSource>
            <asp:ListView ID="lvContinents" runat="server" DataKeyNames="Id" DataSourceID="ContinentsDataSource" GroupItemCount="3" InsertItemPosition="LastItem">
                <AlternatingItemTemplate>
                    <td runat="server" style="background-color: #FFFFFF; color: #284775;">Id:
                    <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                        <br />
                        Name:
                    <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                        <br />
                        Population:
                    <asp:Label ID="PopulationLabel" runat="server" Text='<%# Eval("Population") %>' />
                        <br />
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                        <br />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                        <br />
                    </td>
                </AlternatingItemTemplate>
                <EditItemTemplate>
                    <td runat="server" style="background-color: #999999;">Id:
                    <asp:Label ID="IdLabel1" runat="server" Text='<%# Eval("Id") %>' />
                        <br />
                        Name:
                    <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
                        <br />
                        Population:
                    <asp:TextBox ID="PopulationTextBox" runat="server" Text='<%# Bind("Population") %>' />
                        <br />
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                        <br />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                        <br />
                    </td>
                </EditItemTemplate>
                <EmptyDataTemplate>
                    <table runat="server" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
                        <tr>
                            <td>No data was returned.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <EmptyItemTemplate>
                    <td runat="server" />
                </EmptyItemTemplate>
                <GroupTemplate>
                    <tr id="itemPlaceholderContainer" runat="server">
                        <td id="itemPlaceholder" runat="server"></td>
                    </tr>
                </GroupTemplate>
                <InsertItemTemplate>
                    <td runat="server" style="">Id:
                    <asp:TextBox ID="IdTextBox" runat="server" Text='<%# Bind("Id") %>' />
                        <br />
                        Name:
                    <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
                        <br />
                        Population:
                    <asp:TextBox ID="PopulationTextBox" runat="server" Text='<%# Bind("Population") %>' />
                        <br />
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                        <br />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                        <br />
                    </td>
                </InsertItemTemplate>
                <ItemTemplate>
                    <td runat="server" style="background-color: #E0FFFF; color: #333333;">Id:
                    <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                        <br />
                        Name:
                    <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                        <br />
                        Population:
                    <asp:Label ID="PopulationLabel" runat="server" Text='<%# Eval("Population") %>' />
                        <br />
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                        <br />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                        <br />
                    </td>
                </ItemTemplate>
                <LayoutTemplate>
                    <table runat="server">
                        <tr runat="server">
                            <td runat="server">
                                <table id="groupPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;">
                                    <tr id="groupPlaceholder" runat="server">
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr runat="server">
                            <td runat="server" style="text-align: center; background-color: #5D7B9D; font-family: Verdana, Arial, Helvetica, sans-serif; color: #FFFFFF">
                                <asp:DataPager ID="DataPager1" runat="server" PageSize="12">
                                    <Fields>
                                        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                                    </Fields>
                                </asp:DataPager>
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>
                <SelectedItemTemplate>
                    <td runat="server" style="background-color: #E2DED6; font-weight: bold; color: #333333;">Id:
                    <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                        <br />
                        Name:
                    <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                        <br />
                        Population:
                    <asp:Label ID="PopulationLabel" runat="server" Text='<%# Eval("Population") %>' />
                        <br />
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                        <br />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                        <br />
                    </td>
                </SelectedItemTemplate>
            </asp:ListView>
            <h4>Continents:</h4>
            <asp:ListBox ID="lbContinents" runat="server" DataSourceID="ContinentsDataSource" DataTextField="Name" DataValueField="Id" OnSelectedIndexChanged="lbContinents_SelectedIndexChanged" AutoPostBack="true"></asp:ListBox>
            <asp:EntityDataSource ID="dsCountries" runat="server" ConnectionString="name=CountriesEntities" DefaultContainerName="CountriesEntities" EnableFlattening="False" EntitySetName="Countries" EnableInsert="true" EnableDelete="true" EnableUpdate="true"/>
            <h4>Countries:</h4>
            <asp:GridView ID="gvCountries" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataKeyNames="Id" DataSourceID="dsCountries" ForeColor="Black" GridLines="None" OnRowCommand="gvCountries_RowCommand" OnSelectedIndexChanged="gvCountries_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="PaleGoldenrod" />
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" ShowInsertButton="true" />
                    <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Language" HeaderText="Language" SortExpression="Language" />
                    <asp:BoundField DataField="Population" HeaderText="Population" SortExpression="Population" />
                    <asp:BoundField DataField="ContinentId" HeaderText="ContinentId" SortExpression="ContinentId" />
                    <asp:ImageField HeaderText="Flag" DataImageUrlField="Id" DataImageUrlFormatString="~/flag.ashx?id={0}" ReadOnly="true" />
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
            <asp:Label runat="server" ID="StatusLabel" Text="Choose Flag image" />
            <asp:FileUpload ID="fuFlag" runat="server"  />
            <asp:Button runat="server" ID="UploadButton" Text="Upload" OnClick="UploadButton_Click" />
            <asp:EntityDataSource ID="dsTowns" runat="server" ConnectionString="name=CountriesEntities" DefaultContainerName="CountriesEntities" EnableDelete="True" EnableFlattening="False" EnableInsert="True" EnableUpdate="True" EntitySetName="Towns">
            </asp:EntityDataSource>
            <h4>Towns:</h4>
            <asp:ListView ID="lvTowns" runat="server" DataKeyNames="Id" DataSourceID="dsTowns" GroupItemCount="5" InsertItemPosition="LastItem" EnablePersistedSelection="true">
                <EditItemTemplate>
                    <td runat="server" style="background-color: #008A8C; color: #FFFFFF;">Id:
                        <asp:Label ID="IdLabel1" runat="server" Text='<%# Eval("Id") %>' />
                        <br />
                        Name:
                        <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
                        <br />
                        Population:
                        <asp:TextBox ID="PopulationTextBox" runat="server" Text='<%# Bind("Population") %>' />
                        <br />
                        CountryId:
                        <asp:TextBox ID="CountryIdTextBox" runat="server" Text='<%# Bind("CountryId") %>' />
                        <br />
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                        <br />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                        <br />
                    </td>
                </EditItemTemplate>
                <EmptyDataTemplate>
                    <table runat="server" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
                        <tr>
                            <td>No data was returned.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <EmptyItemTemplate>
                    <td runat="server" />
                </EmptyItemTemplate>
                <GroupTemplate>
                    <tr id="itemPlaceholderContainer" runat="server">
                        <td id="itemPlaceholder" runat="server"></td>
                    </tr>
                </GroupTemplate>
                <InsertItemTemplate>
                    <td runat="server" style="">Id:
                        <asp:TextBox ID="IdTextBox" runat="server" Text='<%#: Bind("Id") %>' />
                        <br />
                        Name:
                        <asp:TextBox ID="NameTextBox" runat="server" Text='<%#: Bind("Name") %>' />
                        <br />
                        Population:
                        <asp:TextBox ID="PopulationTextBox" runat="server" Text='<%#: Bind("Population") %>' />
                        <br />
                        CountryId:
                        <asp:TextBox ID="CountryIdTextBox" runat="server" Text='<%#: Bind("CountryId") %>' />
                        <br />
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                        <br />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                        <br />
                    </td>
                </InsertItemTemplate>
                <ItemTemplate>
                    <td runat="server" style="background-color: #DCDCDC; color: #000000;">Id:
                        <asp:Label ID="IdLabel" runat="server" Text='<%#: Eval("Id") %>' />
                        <br />
                        Name:
                        <asp:Label ID="NameLabel" runat="server" Text='<%#: Eval("Name") %>' />
                        <br />
                        Population:
                        <asp:Label ID="PopulationLabel" runat="server" Text='<%#: Eval("Population") %>' />
                        <br />
                        CountryId:
                        <asp:Label ID="CountryIdLabel" runat="server" Text='<%#: Eval("CountryId") %>' />
                        <br />
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                        <br />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                        <br />
                        <asp:Button ID="SelectButton" runat="server" CommandName="Select" Text="Select" />
                        <br />
                    </td>
                </ItemTemplate>
                <LayoutTemplate>
                    <table runat="server">
                        <tr runat="server">
                            <td runat="server">
                                <table id="groupPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;">
                                    <tr id="groupPlaceholder" runat="server">
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr runat="server">
                            <td runat="server" style="text-align: center; background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000;">
                                <asp:DataPager ID="DataPager1" runat="server" PageSize="12">
                                    <Fields>
                                        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                                    </Fields>
                                </asp:DataPager>
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>
                <SelectedItemTemplate>
                    <td runat="server" style="background-color: #008A8C; font-weight: bold; color: #FFFFFF;">Id:
                        <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                        <br />
                        Name:
                        <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                        <br />
                        Population:
                        <asp:Label ID="PopulationLabel" runat="server" Text='<%# Eval("Population") %>' />
                        <br />
                        CountryId:
                        <asp:Label ID="CountryIdLabel" runat="server" Text='<%# Eval("CountryId") %>' />
                        <br />
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                        <br />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                        <br />
                    </td>
                </SelectedItemTemplate>
            </asp:ListView>
        </div>
    </form>
</body>
</html>
