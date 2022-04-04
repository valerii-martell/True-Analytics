using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using True_Analytics.Models;

namespace True_Analytics
{
    public partial class _Summary : System.Web.UI.Page
    {
        private List<Campaign> campaignsDetails = new List<Campaign>();
        private List<CampaignByDate> campaignsByDate = new List<CampaignByDate>();

        private DateTime startDate = new DateTime();
        private DateTime endDate = new DateTime();


        protected void Page_Load(object sender, EventArgs e)
        {
            //projectTitle.InnerText = "Проект " + Requests.SERVICE_PROJECT_NAME;
            projectTitle.InnerText = "Проект Baellerry Business";
            UpdateSummary();
        }

        private void UpdateSummary()
        {
            startDate = DateTime.Now.AddYears(-2);
            endDate = DateTime.Now;
            campaignsDetails = Requests.DetailAnalyticsRequest(startDate, endDate);

            SortedList<double, string> topRoi = new SortedList<double, string>(new DuplicateKeyComparer<double>());
            SortedList<int, string> topSales = new SortedList<int, string>(new DuplicateKeyComparer<int>());
            SortedList<double, string> topIncome = new SortedList<double, string>(new DuplicateKeyComparer<double>());
            foreach (Campaign campaign in campaignsDetails)
            {
                topRoi.Add(campaign.Roi, campaign.Name);
                topSales.Add(campaign.Sales, campaign.Name);
                topIncome.Add(campaign.Income, campaign.Name);
            }
            top1roi.InnerText = "1. " + topRoi.Values[0] + "  :  " + topRoi.Keys[0].ToString("p");
            top2roi.InnerText = "2. " + topRoi.Values[1] + "  :  " + topRoi.Keys[1].ToString("p");
            top3roi.InnerText = "3. " + topRoi.Values[2] + "  :  " + topRoi.Keys[2].ToString("p");

            top1sales.InnerText = "1. " + topSales.Values[0] + "  :  " + topSales.Keys[0].ToString();
            top2sales.InnerText = "2. " + topSales.Values[1] + "  :  " + topSales.Keys[1].ToString();
            top3sales.InnerText = "3. " + topSales.Values[2] + "  :  " + topSales.Keys[2].ToString();

            top1income.InnerText = "1. " + topIncome.Values[0] + "  :  " + topIncome.Keys[0].ToString();
            top2income.InnerText = "2. " + topIncome.Values[1] + "  :  " + topIncome.Keys[1].ToString();
            top3income.InnerText = "3. " + topIncome.Values[2] + "  :  " + topIncome.Keys[2].ToString();
        }

        protected void ButtonDetails_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Details.aspx");
        }
    }
}