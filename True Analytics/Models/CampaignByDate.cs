using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace True_Analytics.Models
{
    public class CampaignByDate
    {
        private string name;

        private List<DateTime> dates;
        private List<int> sessions;
        private List<double> costs;
        private List<int> goals;

        public List<DateTime> Dates
        {
            get
            {
                return dates;
            }

            set
            {
                dates = value;
            }
        }

        public List<int> Sessions
        {
            get
            {
                return sessions;
            }

            set
            {
                sessions = value;
            }
        }

        public List<double> Costs
        {
            get
            {
                return costs;
            }

            set
            {
                costs = value;
            }
        }

        public List<int> Goals
        {
            get
            {
                return goals;
            }

            set
            {
                goals = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public CampaignByDate(string name)
        {
            this.Name = name;
            Dates = new List<DateTime>();
            Sessions = new List<int>();
            Costs = new List<double>();
            Goals = new List<int>();
        }

        public CampaignByDate()
        {
            name = " ";
        }
    }
}