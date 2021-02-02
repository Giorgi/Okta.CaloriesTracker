<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CaloriesTracker.WebForms._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-md-12">
            <h1>Daily consumed and burned calories</h1>
            <br/>
            Showing data for:
            <asp:TextBox runat="server" TextMode="Date" Text='<%# DateTime.Today.ToString("yyyy-MM-dd") %>' ID="dateTextBox"></asp:TextBox>
            <asp:Button runat="server" Text="Show" OnCommand="ShowData"/>
            <br />
            <br />

            <asp:GridView runat="server" ItemType="CaloriesTracker.WebForms.Data.CalorieDiary" DataKeyNames="Id" CssClass="myGridClass"
                AutoGenerateColumns="False" ID="diaryGridView" OnRowDeleting="DiaryDeleting" BorderWidth="0">
                <EmptyDataRowStyle CssClass="empty" />
                <EmptyDataTemplate>
                    <h2>No records found for <asp:Label runat="server" Text='<%# dateTextBox.Text %>'></asp:Label></h2>
                </EmptyDataTemplate>
                <Columns>
                    <asp:TemplateField HeaderText="Description">
                        <ItemStyle Width="300px" HorizontalAlign="Left" />
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label ID="descriptionLabel" runat="server"
                                Text='<%# Item.Exercise?.Name ?? Item.Food?.Name %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Calories">
                        <ItemStyle Width="100px" HorizontalAlign="Center" />
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label ID="CaloriesLabel" runat="server"
                                Text='<%# -Item.Exercise?.Calories ?? Item.Food?.Calories %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowDeleteButton="True">
                        <ItemStyle Width="100px" HorizontalAlign="Center"></ItemStyle>
                    </asp:CommandField>
                </Columns>
            </asp:GridView>
            
            <h3>Total Consumed: <asp:Label runat="server" ID="totalConsumedLabel" ></asp:Label> Total Burned: <asp:Label runat="server" ID="totalBurnedLabel" ></asp:Label></h3>
        </div>
    </div>

    <div class="row">
        <div class="col-md-6">
            <h2>Add Food</h2>
            Select Food:
            <asp:DropDownList runat="server" ID="foodDropDown" ItemType="CaloriesTracker.WebForms.Data.Food"
                DataValueField="Id" DataTextField="Name" AppendDataBoundItems="True">
                <Items>
                    <asp:ListItem Selected="True" Value="-1" Text=""></asp:ListItem>
                </Items>
            </asp:DropDownList>
            <asp:Button runat="server" Text="Add" OnCommand="AddFoodClicked" />
        </div>
        <div class="col-md-6">
            <h2>Add Exercise</h2>
            Select Exercise:
            <asp:DropDownList runat="server" ID="exerciseDropDown" ItemType="CaloriesTracker.WebForms.Data.Exercise"
                DataValueField="Id" DataTextField="Name" AppendDataBoundItems="True">
                <Items>
                    <asp:ListItem Selected="True" Value="-1" Text=""></asp:ListItem>
                </Items>
            </asp:DropDownList>
            <asp:Button runat="server" Text="Add" OnCommand="AddExerciseClicked" />
        </div>
    </div>

</asp:Content>
