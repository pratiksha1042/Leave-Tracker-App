using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    public class DashboardModel
    {
        public string ClientName { get; set; }
        public string UserName { get; set; }
        public string ProjectName { get; set; }
        public string Jan { get; set; }
        public string Feb { get; set; }
        public string Mar { get; set; }
        public string Apr { get; set; }
        public string May { get; set; }
        public string Jun { get; set; }
        public string Jul { get; set; }
        public string Aug { get; set; }

        public string Sep { get; set; }
        public string Oct { get; set; }
        public string Nov { get; set; }
        public string Dec { get; set; }
        public string AllowedLeaves { get; set; }
        public string Total_Leaves_Taken_Q1 { get; set; }
        public string Total_Leaves_Taken_Q2 { get; set; }
        public string Total_Leaves_Taken_Q3 { get; set; }
        public string Total_Leaves_Taken_Q4 { get; set; }
        public string Adjustment_Leaves_Q1 { get; set; }
        public string Adjustment_Leaves_Q2 { get; set; }
        public string Adjustment_Leaves_Q3 { get; set; }
        public string Adjustment_Leaves_Q4 { get; set; }
    }
}
