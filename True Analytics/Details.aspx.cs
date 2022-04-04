using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using True_Analytics.Models;

namespace True_Analytics
{
    public partial class _Details : System.Web.UI.Page
    {
        private List<Campaign> campaignsDetails = new List<Campaign>();
        private List<CampaignByDate> campaignsByDate = new List<CampaignByDate>();

        private DateTime startDate = new DateTime();
        private DateTime endDate = new DateTime();

        private string buffer;
        protected void Page_Load(object sender, EventArgs e)
        {
            //projectTitle.InnerText = "Проект " + Requests.SERVICE_PROJECT_NAME;
            projectTitle.InnerText = "Проект Baellerry Business";
            startDate = DateTime.Now.AddDays(-7);
            endDate = DateTime.Now;
            UpdateTable();
            DateChart.Width = new Unit((double)((Request.Browser.ScreenPixelsWidth) * 2 - 100));
            UpdateChart();
        }

        private void UpdateTable()
        {            
            while (campaignsDetailsTable.Rows.Count > 1) campaignsDetailsTable.Rows.RemoveAt(1);
            campaignsDetails = Requests.DetailAnalyticsRequest(startDate, endDate);

            foreach (Campaign campaign in campaignsDetails)
            {
                TableRow row = new TableRow();
                row.Font.Size = new FontUnit(FontSize.Larger);
                TableCell cell = new TableCell() { Text = " " + campaign.Name };
                row.Cells.Add(cell);
                cell = new TableCell() { Text = " "+campaign.Sessions.ToString() };
                row.Cells.Add(cell);
                cell = new TableCell() { Text = " " + Math.Round(campaign.Cost, 2, MidpointRounding.AwayFromZero).ToString() };
                row.Cells.Add(cell);
                cell = new TableCell() { Text = " " + campaign.Goals.ToString() };
                row.Cells.Add(cell);
                cell = new TableCell() { Text = " " + Math.Round(campaign.Conversion, 4, MidpointRounding.AwayFromZero).ToString("P") };
                row.Cells.Add(cell);
                cell = new TableCell() { Text = " " + campaign.Sales.ToString() };
                row.Cells.Add(cell);
                cell = new TableCell() { Text = " " + Math.Round(campaign.Income, 2, MidpointRounding.AwayFromZero).ToString() };
                row.Cells.Add(cell);
                cell = new TableCell() { Text = " " + Math.Round(campaign.Profit, 2, MidpointRounding.AwayFromZero).ToString() };
                row.Cells.Add(cell);
                cell = new TableCell() { Text = " " + Math.Round(campaign.Roi, 4, MidpointRounding.AwayFromZero).ToString("P") };
                row.Cells.Add(cell);
                campaignsDetailsTable.Rows.Add(row);
            }

            TableTitle.InnerText = "Сумарні показники каналів за період із " + startDate.ToString("dd.MM.yyyy") + " по " + endDate.ToString("dd.MM.yyyy");
        }

        private void UpdateChart()
        {
            DateChart.Series.Clear();
            DateChart.Legends.Clear();
            buffer = DropDownListChannels.SelectedItem.Text;
            while (DropDownListChannels.Items.Count > 1) DropDownListChannels.Items.RemoveAt(1);
            for (int i = 1; i < campaignsDetailsTable.Rows.Count; i++)
            {
                DropDownListChannels.Items.Add(new ListItem(campaignsDetailsTable.Rows[i].Cells[0].Text, (i).ToString()));
                if (campaignsDetailsTable.Rows[i].Cells[0].Text == buffer) DropDownListChannels.Items[i].Selected = true;
            }
            campaignsByDate = Requests.DateAnalyticsRequest(startDate, endDate);
            double biggestMetric = 0;
            foreach (CampaignByDate campaign in campaignsByDate)
            {
                if (DropDownListChannels.SelectedItem.Value.Contains("0") ||
                    DropDownListChannels.SelectedItem.Text.Contains(campaign.Name))
                {
                    string seriesName = campaign.Name;
                    DateChart.Series.Add(seriesName);
                    DateChart.Series[seriesName].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
                    DateChart.Series[seriesName].BorderWidth = 2;
                    if ((endDate - startDate).TotalDays > 3)
                    {
                        DateChart.Series[seriesName].XValueType = System.Web.UI.DataVisualization.Charting.ChartValueType.Date;
                    }
                    else
                    {
                        DateChart.Series[seriesName].XValueType = System.Web.UI.DataVisualization.Charting.ChartValueType.DateTime;
                    }
                    DateChart.Series[seriesName].IsValueShownAsLabel = true;
                    DateChart.Series[seriesName].MarkerStyle = System.Web.UI.DataVisualization.Charting.MarkerStyle.Square;
                    DateChart.ChartAreas[0].AxisX.Minimum = campaign.Dates[0].AddDays(-1).Date.ToOADate();
                    DateChart.ChartAreas[0].AxisX.Maximum = campaign.Dates[campaign.Dates.Count - 1].AddDays(1).Date.ToOADate();
                    DateChart.Legends.Add(new System.Web.UI.DataVisualization.Charting.Legend(campaign.Name) { Docking = System.Web.UI.DataVisualization.Charting.Docking.Bottom });

                    if (DropDownListMetrics.SelectedValue.Contains("0"))
                    {
                        DateChart.Series[seriesName].YValueType = System.Web.UI.DataVisualization.Charting.ChartValueType.Int32;
                        DateChart.Series[seriesName].Points.DataBindXY(campaign.Dates, campaign.Sessions);
                        DateChart.Series[seriesName].ChartArea = "ChartArea1";
                        DateChart.DataBind();
                    }
                    else if(DropDownListMetrics.SelectedValue.Contains("1"))
                    {
                        DateChart.Series[seriesName].YValueType = System.Web.UI.DataVisualization.Charting.ChartValueType.Int32;
                        DateChart.Series[seriesName].Points.DataBindXY(campaign.Dates, campaign.Costs);
                        DateChart.Series[seriesName].ChartArea = "ChartArea1";
                        DateChart.DataBind();
                    }
                    else if (DropDownListMetrics.SelectedValue.Contains("2"))
                    {
                        DateChart.Series[seriesName].YValueType = System.Web.UI.DataVisualization.Charting.ChartValueType.Int32;
                        DateChart.Series[seriesName].Points.DataBindXY(campaign.Dates, campaign.Goals);
                        DateChart.Series[seriesName].ChartArea = "ChartArea1";
                        DateChart.DataBind();
                    }
                }
            }
            ChartTitle.InnerText = DropDownListMetrics.SelectedItem.Text + " за період із " + startDate.ToString("dd.MM.yyyy") + " по " + endDate.ToString("dd.MM.yyyy");
        }

        protected void ButtonShow_Click(object sender, EventArgs e)
        {
            startDate = DateTime.ParseExact(inp1.Value, "yyyy/MM/dd",
                                       System.Globalization.CultureInfo.InvariantCulture);
            endDate = DateTime.ParseExact(inp2.Value, "yyyy/MM/dd",
                                       System.Globalization.CultureInfo.InvariantCulture);
            UpdateTable();
            UpdateChart();
        }

        /*protected void ButtonChooseRange_Click(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                CalendarStart.SelectedDate = startDate;
            if (!Page.IsPostBack)
                CalendarEnd.SelectedDate = endDate;
        }

        protected void ButtonChooseMounth_Click(object sender, EventArgs e)
        {
            startDate = DateTime.Now.Date.AddMonths(-1);
            endDate = DateTime.Now.Date;
            UpdateTable();
            UpdateChart();
        }

        protected void ButtonChooseWeek_Click(object sender, EventArgs e)
        {
            startDate = DateTime.Now.Date.AddDays(-7);
            endDate = DateTime.Now.Date;
            UpdateTable();
            UpdateChart();
        }

        protected void ButtonChooseDay_Click(object sender, EventArgs e)
        {
            startDate = DateTime.Now.Date;
            endDate = DateTime.Now.Date;
            UpdateTable();
            UpdateChart();
        }*/
    

        protected void DropDownListMetrics_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}