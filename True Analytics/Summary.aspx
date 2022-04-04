<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" Debug="true" AutoEventWireup="true" CodeBehind="Summary.aspx.cs" Inherits="True_Analytics._Summary" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <div class="jumbotron">
        <h1 runat="server" id="projectTitle" style="text-align:center"></h1>
        <p class="lead">ТОП-канали:</p>
        <div class="row">
            <div class="col-md-4">
                <h3">ROI:</h3>
                <p>
                    <h4 runat="server" id="top1roi"></h4>
                </p>
                <p>
                    <h4 runat="server" id="top2roi"></h4>
                </p>
                <p>
                    <h4 runat="server" id="top3roi"></h4>
                </p>
            </div>
            <div class="col-md-4">
                <h3">Продажі:</h3>
                <p>
                    <h4 runat="server" id="top1sales"></h4>
                </p>
                <p>
                    <h4 runat="server" id="top2sales"></h4>
                </p>
                <p>
                    <h4 runat="server" id="top3sales"></h4>
                </p>
            </div>
            <div class="col-md-4">
                <h3">Дохід:</h3>
                <p>
                    <h4 runat="server" id="top1income"></h4>
                </p>
                <p>
                    <h4 runat="server" id="top2income"></h4>
                </p>
                <p>
                    <h4 runat="server" id="top3income"></h4>
                </p>
            </div>
        </div>
        <div>
        <p>
            <h2 style="color:white; opacity:0.0">
                .
            </h2>
        </p>
        </div>
        <div style="text-align:right;">
            <p><a runat="server" id="buttonDetails" onserverclick="ButtonDetails_Click" class="btn btn-primary btn-lg">Перейти до деталей &raquo;</a></p>
        </div>
    </div>

    <div>
        <p>
            <h2>
                
            </h2>
        </p>
    </div>


</asp:Content>


