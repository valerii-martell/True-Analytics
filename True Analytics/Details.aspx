<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" Debug="true" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="True_Analytics._Details" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">

        <h1 runat="server" id="projectTitle" style="text-align:center"></h1>
            <div runat="server">     
            <div class="row">
                <div class="col-md-4">
                    <h3>Метрика</h3>
                    <p>
                        <asp:DropDownList ID="DropDownListMetrics" runat="server" OnSelectedIndexChanged="DropDownListMetrics_SelectedIndexChanged">
                            <asp:ListItem Text="Сеанси" Selected="true" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Вартість" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Заявки" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Конверсія" Value="3"></asp:ListItem>
                            <asp:ListItem Text="Продажі" Value="4"></asp:ListItem>
                            <asp:ListItem Text="Дохід" Value="5"></asp:ListItem>
                            <asp:ListItem Text="Прибуток" Value="6"></asp:ListItem>
                            <asp:ListItem Text="ROI" Value="7"></asp:ListItem>
                        </asp:DropDownList>
                    </p>
                </div>
                <div class="col-md-4">
                    <h3>Канали</h3>
                    <p>
                        <asp:DropDownList ID="DropDownListChannels" runat="server">
                            <asp:ListItem Text="Показати все" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    </p>
                </div>
                <div class="col-md-4">
                    <h3>Часовий проміжок</h3>
                    <p>
                        <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
                        <script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.9.0/moment-with-locales.js"></script>
                        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
                        <script src="http://cdn.rawgit.com/Eonasdan/bootstrap-datetimepicker/a549aa8780dbda16f6cff545aeabc3d71073911e/src/js/bootstrap-datetimepicker.js"></script>
                        <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" rel="stylesheet"/>
                        <link href="http://cdn.rawgit.com/Eonasdan/bootstrap-datetimepicker/a549aa8780dbda16f6cff545aeabc3d71073911e/build/css/bootstrap-datetimepicker.css" rel="stylesheet"/>

                        <div class="container">                           
                                <div class="form-group" >
                                    <div class='input-group date' id='datetimepicker1'>
                                        <input runat="server" id="inp1" data-format="YYYY/MM/DD" type='text' class="form-control"/>
                                        <span class="input-group-addon">
                                            <span class="glyphicon glyphicon-calendar"></span>
                                        </span>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class='input-group date' id='datetimepicker2'>
                                        <input runat="server" id="inp2" data-format="YYYY/MM/DD" type='text' class="form-control" />
                                        <span class="input-group-addon">
                                            <span class="glyphicon glyphicon-calendar"></span>
                                        </span>
                                    </div>
                                </div>
                    </div>

                    <script type="text/javascript">
                        $(function () {
                            var date = new Date();
                            date.setDate(date.getDate() - 7); 
                            $('#datetimepicker1').datetimepicker({
                                defaultDate: date,
                                format: 'YYYY/MM/DD'
                            });
                            
                            date.setDate(date.getDate() + 7);
                            $('#datetimepicker2').datetimepicker({
                                format: 'YYYY/MM/DD',
                                defaultDate: date,
                                useCurrent: false
                            });
                            
                            $("#datetimepicker1").on("dp.change", function (e) {
                                $('#datetimepicker2').data("DateTimePicker").minDate(e.date);
                            });
                            $("#datetimepicker2").on("dp.change", function (e) {
                                $('#datetimepicker1').data("DateTimePicker").maxDate(e.date);
                            });
                        });
                    </script>                     
                                     
                    </p>
                </div>
            </div>
        </div>
        <div style="text-align:right">
            <a ID="ButtonShow" runat="server" class="btn btn-primary btn-lg btn-block" role="button" aria-pressed="true" onserverclick="ButtonShow_Click">Показати &raquo;</a>
         </div>
    </div>


        <asp:UpdatePanel runat="server" >
        <ContentTemplate>

    <div> 
        <p>
            <h2 runat="server" id="ChartTitle" style="text-align:center"></h2>
            <p>
                <asp:Chart ID="DateChart" runat="server" Width="1150px">
                    <chartareas>
                        <asp:ChartArea Name="ChartArea1">
                            <AxisX LineColor="LightGray">
                                <MajorGrid LineColor="LightGray" />
                            </AxisX>
                            <AxisY LineColor="LightGray">
                                <MajorGrid LineColor="LightGray" />
                            </AxisY>
                        </asp:ChartArea>
                    </chartareas>
                </asp:Chart>
        </p>   
    </div>
   
    <div>
        <p>
            <h2 runat="server" id="TableTitle" style="text-align:center"></h2>
            <p>
                <asp:Table ID="campaignsDetailsTable" runat="server" CellPadding="3" CellSpacing="3" Gridlines="both" Width="100%">
                    <asp:TableRow Font-Bold="true" Font-Size="Larger">
                        <asp:TableCell> Канал</asp:TableCell>
                        <asp:TableCell> Сеанси</asp:TableCell>
                        <asp:TableCell> Вартість</asp:TableCell>
                        <asp:TableCell> Заявки</asp:TableCell>
                        <asp:TableCell> Конверсія</asp:TableCell>
                        <asp:TableCell> Продажі</asp:TableCell>
                        <asp:TableCell> Дохід</asp:TableCell>
                        <asp:TableCell> Прибуток</asp:TableCell>
                        <asp:TableCell> ROI</asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
        </p>    
    </div>

    </ContentTemplate>

   </asp:UpdatePanel>

</asp:Content>

