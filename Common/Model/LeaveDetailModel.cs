using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    public class LeaveDetailModel : basemodel
    { 
        //public string AssociateID { get; set; }
        public string UserName { get; set; }
       // public string ProjectID { get; set; }
        //public string ProjectName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Description { get; set; }
        //public double TotalDays { get; set; }
    }
}
