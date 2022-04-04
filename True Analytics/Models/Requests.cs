using Google.Apis.AnalyticsReporting.v4;
using Google.Apis.AnalyticsReporting.v4.Data;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace True_Analytics.Models
{
    public static class Requests
    {
        public static string SERVICE_PROJECT_NAME = "true-analytics";
        public static string SERVICE_PROJECT_EMAIL = "true-analytics-1@true-analytics.iam.gserviceaccount.com";
        public static string SERVICE_PROJECT_KEY = "-----BEGIN PRIVATE KEY-----\nMIIEvQIBADANBgkqhkiG9w0BAQEFAASCBKcwggSjAgEAAoIBAQCzpvogmTC190m5\nDxLnevcg0srWHIMe6J2HhI+tA7RmN623BMxfGfK636u/eBoSNuuifuk01U5nNs6q\n5NRQWjxU0V6j/rS7xOdqJRZLfvEWn9J2v5X3S4dAOtJv+6+i1o3Kk7s3OGmF6mwP\nPDsCsr/Queq7JNImVYeEjEL0yeCo+nk4Kb43cKKoCu/OwU/IyKatMU9OYDLow+Tu\nW1uOi/cEOiv+OjZ4kvjU+2n3HnQ5gS/gHOkPgtI1XjzlBX0ATcIYWL/7QYr67Pdl\nZ2Uus1niJ21GyKhC+vKjGquroa2B3gThCpBblWuOjBZCj2jIcocJDwx/C036VoEo\nCs8ZjM23AgMBAAECggEAPATyFcf4LSLjv27Yyvsa6x1hZKz75WyjjG3uLkhJkcjS\nQY3Z1X/uxx4I3Bv84c71ZEFwGhWVbwgxfYibogizlUapjrJ+oSjEg4LGcwyC8SMO\nBlw1dvwFwKCmQ4FbiVSS5HX8mxM+td2+okxmDp23Vb13PXSsvN/gOZk+mVeEtg8A\nR17nUiORnQH90nzt4Yv+s5XdGH/4fxTuT/eoOKRDh1PpFPkhnVXsugwr+4MIHTyk\nLe12zklzWIijNc+D0YgwjoNu75YMfLaNwecL5wheeB6nEuL+RBzmpkypDVZq4no+\nF8wDfx58T5SkYsZQI/I4V/iJ9BFgNPR3GlX4Ro7zsQKBgQDswXgWRtxH0pTCJvCS\nCkeHxnCuJw1ReLShfxRZ+ZS33s1WpOaUA7USmJnUrSQQ4wnxO/3k956rtAYZ7ujr\n03FFl4BozlVl6u2U3xugnHYhsNbmgpn3Xy30ujX/HnwyfB+QrZCPD1wYw8XbCsZ+\nSflzrscCUy9bEzjE28MQD28rjwKBgQDCQUUz/PB980sAS8cORjSCvuYhSKhHvlto\n7sHmfNbVgCO3rPJTVIUbulSUxDswvhuns0RFNb0CY2mbj5MSUI6vhQrtYnALEtab\n2JB5KuOO32XWx/5FnOu+uRGUXDuKhAqQMREWe37dBx5AFrMTddoDEDCEFxQObBtQ\niJlrqw5HWQKBgEDHvx/5S5SrXeCx3ulWvrO77GD6dn5wVJxLtTnZPIQDBpRKkny1\ndvobnxu+NDwao0HKdHIN/vBkVbcK09iTBk9QYOZMbrlwSomNcnXD2d7mECcKXS5+\ncIih2txvbvQxWkGv+/no7f4osx54GE+91e99Rx6vvCljXQkgSINAdd6pAoGBAK9C\n5mYeavioHl4ZAHJvgwcHp2gWPsXkCGMnL0h+D/K21wLsBgKK+kFnHtLOLT0v+JGY\nmxr6fhp+iRTyN9ZJWkMf/RjqPH6xM3GOteKsgH0yL5bWACLcjpIYNbUudgXmVgV8\nT5eCOpa+yls2X8FKDjW/UJaMn+rXPNmvNQTAY3SZAoGAMh9c7yRX1j+6n2bpqnN1\nz6Wo2s9X9kr2m6Si6TcCIy3euW+UL+7Bqqjeclv0O8CGDO6jw3ac+qxiuLooQ7a/\nzFoNLX1ARKsSVnkfXN+f6O9+BrLYS/5xMngE2YZVkcZN4bUzg+WSP5ahHYR7e/w5\nkpsaSsBwSUoJp+PGYzncn+U=\n-----END PRIVATE KEY-----\n";
        public static string GOOGLE_ANALYTICS_VIEW_ID = "168525707";
        public static string GOOGLE_SPREADSHEET_SHEET_ID = "1fmFtxM29wkGOliaY53ZDBBo47ORlbgIvAo6Aw3UXMmo";

        public static List<CampaignByDate> DateAnalyticsRequest(DateTime startDate, DateTime endDate)
        {
            List<CampaignByDate> result = new List<CampaignByDate>();

            var credential = new ServiceAccountCredential(new ServiceAccountCredential.Initializer(SERVICE_PROJECT_EMAIL)
            {
                Scopes = new[] { AnalyticsReportingService.Scope.Analytics }
            }.FromPrivateKey(SERVICE_PROJECT_KEY));

            using (var svc = new AnalyticsReportingService(
                new BaseClientService.Initializer
                {
                    HttpClientInitializer = credential,
                    ApplicationName = SERVICE_PROJECT_NAME
                })
            )
            {
                if (svc == null)
                {
                    result.Add(new CampaignByDate("Google Analytics Autorization Error"));
                    return result;
                }

                // Create the DateRange object.
                Google.Apis.AnalyticsReporting.v4.Data.DateRange dateRange =
                    new Google.Apis.AnalyticsReporting.v4.Data.DateRange() { StartDate = startDate.ToString("yyyy-MM-dd"), EndDate = endDate.ToString("yyyy-MM-dd") };

                // Create the Metric objects.
                Metric sessions = new Metric() { Expression = "ga:sessions", Alias = "sessions" };
                Metric adCost = new Metric() { Expression = "ga:adCost", Alias = "Cost" };
                Metric goals = new Metric() { Expression = "ga:goal6Completions", Alias = "Goal 6 Completions" };

                // Create the Dimension objects.
                Dimension sourceMedium = new Dimension() { Name = "ga:sourceMedium" };

                // Create the Dimension objects.
                Dimension date = new Dimension();
                if ((endDate-startDate).TotalDays > 3)
                {
                    date.Name = "ga:date";
                }
                else
                {
                    date.Name = "ga:dateHour";
                }
                
                // Create the Pivot object.
                Pivot pivot = new Pivot() { Dimensions = new List<Dimension> { sourceMedium, date }, MaxGroupCount = 3, StartGroup = 0, Metrics = new List<Metric> { sessions, adCost, goals } };

                // Create the ReportRequest object.
                ReportRequest request = new ReportRequest()
                {
                    ViewId = GOOGLE_ANALYTICS_VIEW_ID,
                    DateRanges = new List<Google.Apis.AnalyticsReporting.v4.Data.DateRange> { dateRange },
                    Dimensions = new List<Dimension> { sourceMedium, date },
                    Pivots = new List<Pivot> { pivot },
                    Metrics = new List<Metric> { sessions, adCost, goals }
                };

                // Create the GetReportsRequest object.
                GetReportsRequest getReport = new GetReportsRequest() { ReportRequests = new List<ReportRequest> { request } };

                // Call the batchGet method.
                GetReportsResponse response = svc.Reports.BatchGet(getReport).Execute();

                foreach (Report report in (List<Report>)response.Reports)
                {
                    ColumnHeader header = report.ColumnHeader;
                    List<string> dimensionHeaders = (List<string>)header.Dimensions;

                    List<MetricHeaderEntry> metricHeaders = (List<MetricHeaderEntry>)header.MetricHeader.MetricHeaderEntries;
                    List<ReportRow> rows = (List<ReportRow>)report.Data.Rows;

                    CampaignByDate campaign = new CampaignByDate();
                    foreach (ReportRow row in rows)
                    {
                        List<string> dimensions = (List<string>)row.Dimensions;
                        List<DateRangeValues> metrics = (List<DateRangeValues>)row.Metrics;

                        if (row.Dimensions[0].Contains("cpc"))
                        {
                            if (campaign.Name != row.Dimensions[0])
                            {
                                result.Add(campaign);
                                campaign = new CampaignByDate(row.Dimensions[0]);
                            }
                            if ((endDate - startDate).TotalDays > 3)
                            {
                                campaign.Dates.Add(StringToDate(row.Dimensions[1], "yyyyMMdd"));
                            }
                            else
                            {
                                campaign.Dates.Add(StringToDate(row.Dimensions[1], "yyyyMMddHH"));
                            }
                            DateRangeValues values = metrics[0];
                            campaign.Sessions.Add(Int32.Parse(values.Values[0]));
                            campaign.Costs.Add(Double.Parse(values.Values[1], NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo));
                            campaign.Goals.Add(Int32.Parse(values.Values[2]));
                        }
                    }
                    result[0] = campaign;
                }
            }

            return result;
        }


        public static List<Campaign> DetailAnalyticsRequest(DateTime startDate, DateTime endDate)
        {
            List<Campaign> result = new List<Campaign>();

            var credential = new ServiceAccountCredential(new ServiceAccountCredential.Initializer(SERVICE_PROJECT_EMAIL)
            {
                Scopes = new[] { AnalyticsReportingService.Scope.Analytics }
            }.FromPrivateKey(SERVICE_PROJECT_KEY));

            using (var svc = new AnalyticsReportingService(
                new BaseClientService.Initializer
                {
                    HttpClientInitializer = credential,
                    ApplicationName = SERVICE_PROJECT_NAME
                })
            )
            {
                if (svc == null)
                {
                    result.Add(new Campaign("Google Analytics Autorization Error"));
                    return result;
                }
                
                // Create the DateRange object.
                Google.Apis.AnalyticsReporting.v4.Data.DateRange dateRange = 
                    new Google.Apis.AnalyticsReporting.v4.Data.DateRange() {
                        StartDate = startDate.ToString("yyyy-MM-dd"),
                        EndDate = endDate.ToString("yyyy-MM-dd")
                    };

                // Create the Metric objects.
                Metric sessions = new Metric() { Expression = "ga:sessions", Alias = "sessions" };
                Metric adCost = new Metric() { Expression = "ga:adCost", Alias = "Cost" };
                Metric goals = new Metric() { Expression = "ga:goal6Completions", Alias = "Goal 6 Completions" };

                // Create the Dimension objects.
                Dimension sourceMedium = new Dimension() { Name = "ga:sourceMedium" };

                // Create the Dimension objects.
                Dimension channel = new Dimension() { Name = "ga:channelGrouping" };

                // Create the Pivot object.
                Pivot pivot = new Pivot() { Dimensions = new List<Dimension> { sourceMedium }, MaxGroupCount = 3, StartGroup = 0, Metrics = new List<Metric> { sessions, adCost, goals } };

                // Create the ReportRequest object.
                ReportRequest request = new ReportRequest()
                {
                    ViewId = GOOGLE_ANALYTICS_VIEW_ID,
                    DateRanges = new List<Google.Apis.AnalyticsReporting.v4.Data.DateRange> { dateRange },
                    Dimensions = new List<Dimension> { sourceMedium },
                    Pivots = new List<Pivot> { pivot },
                    Metrics = new List<Metric> { sessions, adCost, goals }
                };

                // Create the GetReportsRequest object.
                GetReportsRequest getReport = new GetReportsRequest() { ReportRequests = new List<ReportRequest> { request } };

                // Call the batchGet method.
                GetReportsResponse response = svc.Reports.BatchGet(getReport).Execute();

                foreach (Report report in (List<Report>)response.Reports)
                {
                    ColumnHeader header = report.ColumnHeader;
                    List<string> dimensionHeaders = (List<string>)header.Dimensions;

                    List<MetricHeaderEntry> metricHeaders = (List<MetricHeaderEntry>)header.MetricHeader.MetricHeaderEntries;
                    List<ReportRow> rows = (List<ReportRow>)report.Data.Rows;

                    foreach (ReportRow row in rows)
                    {
                        List<string> dimensions = (List<string>)row.Dimensions;
                        List<DateRangeValues> metrics = (List<DateRangeValues>)row.Metrics;

                        if (row.Dimensions[0].Contains("cpc"))
                        {
                            Campaign campaign = new Campaign(row.Dimensions[0]);
                            DateRangeValues values = metrics[0];
                            campaign.Sessions = Int32.Parse(values.Values[0]);
                            campaign.Cost = Double.Parse(values.Values[1], NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo);
                            campaign.Goals = Int32.Parse(values.Values[2]);                         
                            result.Add(campaign);
                        }
                    }
                }
            }

            DetailSpreadsheetRequest(result, startDate, endDate);

            foreach(Campaign campaign in result)
            {
                campaign.Conversion = (double)campaign.Sales / (double)campaign.Goals;
                campaign.Roi = (campaign.Profit - campaign.Cost) / campaign.Cost;
            }

            return result;
        }

        private static void DetailSpreadsheetRequest(List<Campaign> analyticsResult, DateTime startDate, DateTime endDate)
        {
            DateRange dateRange = new DateRange(startDate, endDate);

            var credential = new ServiceAccountCredential(new ServiceAccountCredential.Initializer(SERVICE_PROJECT_EMAIL)
            {
                Scopes = new[] { SheetsService.Scope.SpreadsheetsReadonly }
            }.FromPrivateKey(SERVICE_PROJECT_KEY));

            using (var svc = new SheetsService(
                new BaseClientService.Initializer
                {
                    HttpClientInitializer = credential,
                    ApplicationName = SERVICE_PROJECT_NAME
                })
            )
            {
                String spreadsheetId = GOOGLE_SPREADSHEET_SHEET_ID;
                String range = GetRange(svc);

                SpreadsheetsResource.ValuesResource.GetRequest request =
                    svc.Spreadsheets.Values.Get(spreadsheetId, range);

                ValueRange response = request.Execute();
                IList<IList<Object>> values = response.Values;
                if (values != null && values.Count > 0)
                {
                    foreach (var row in values)
                    {
                        if (dateRange.Includes(StringToDate(row[6].ToString(), "dd.MM.yyyy")) &&
                            row[4].ToString().Contains("Деньги в кассе!"))
                        {
                            foreach(Campaign campaign in analyticsResult)
                            {
                                if (campaign.Name.Contains(row[1].ToString().ToLower()))
                                {
                                    if (row[3].ToString().Contains("Звонок")) { campaign.Goals++; }
                                    campaign.Sales += Int32.Parse(row[7].ToString());
                                    campaign.Income += Double.Parse(row[9].ToString(), NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo);
                                    campaign.Profit += Double.Parse(row[10].ToString(), NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo);
                                }
                            }
                        }
                    }
                }
            }
        }

        private static DateTime StringToDate(string parsedDate, string pattern)
        {
            DateTime result;
            DateTime.TryParseExact(parsedDate, pattern, null,DateTimeStyles.None, out result);
            return result;
        }

        private static string GetRange(SheetsService service)
        {
            // Define request parameters.
            String spreadsheetId = GOOGLE_SPREADSHEET_SHEET_ID;
            String range = "A:A";

            SpreadsheetsResource.ValuesResource.GetRequest getRequest =
                       service.Spreadsheets.Values.Get(spreadsheetId, range);

            ValueRange getResponse = getRequest.Execute();
            IList<IList<Object>> getValues = getResponse.Values;

            int currentCount = getValues.Count();

            String newRange = "B4" + ":L" + currentCount;

            return newRange;
        }
    }
}