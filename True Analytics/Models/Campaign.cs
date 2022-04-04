using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace True_Analytics.Models
{
    public class Campaign
    {
        private string name;
        private int sessions;
        private double cost;
        private int goals;
        private double conversion;
        private int sales;
        private double income;
        private double profit;
        private double roi;

        public Campaign(string name)
        {
            this.name = name;
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

        public int Sessions
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

        public double Cost
        {
            get
            {
                return cost;
            }

            set
            {
                cost = value;
            }
        }

        public int Goals
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

        public double Conversion
        {
            get
            {
                return conversion;
            }

            set
            {
                conversion = value;
            }
        }

        public int Sales
        {
            get
            {
                return sales;
            }

            set
            {
                sales = value;
            }
        }

        public double Income
        {
            get
            {
                return income;
            }

            set
            {
                income = value;
            }
        }

        public double Profit
        {
            get
            {
                return profit;
            }

            set
            {
                profit = value;
            }
        }

        public double Roi
        {
            get
            {
                return roi;
            }

            set
            {
                roi = value;
            }
        }
    }
}