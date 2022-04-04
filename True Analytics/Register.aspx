<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" Debug="true" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="True_Analytics._Register" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2>True Analytics</h2>

    <div class="form-horizontal">
        <h4>Створення нового акаунту</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Електронна пошта</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Пароль</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label">Підтвердження паролю</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" /> 
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="AnalyticsID" CssClass="col-md-2 control-label">Назва проекту Google Console</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="TextBox1" CssClass="form-control"/>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ServiceAccountEmail" CssClass="col-md-2 control-label">Адреса пошти сервісного акаунту Google</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ServiceAccountEmail" CssClass="form-control" TextMode="Email" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ServiceAccoutSecret" CssClass="col-md-2 control-label">Секрет сервісного акаунту Google</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ServiceAccoutSecret" CssClass="form-control"/>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="AnalyticsID" CssClass="col-md-2 control-label">Ідентифікатор Google Analytics</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="AnalyticsID" CssClass="form-control"/>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="SpreadsheetID" CssClass="col-md-2 control-label">Ідентифікатор Google Spreadsheet</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="SpreadsheetID" CssClass="form-control"/>
                <asp:Label runat="server" ID="Wrong" Visible="false" CssClass="text-danger">Введені невірні дані</asp:Label>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="CreateUser_Click" Text="Реєстрація" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>

