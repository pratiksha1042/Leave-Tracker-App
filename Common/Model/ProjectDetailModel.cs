using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    public class ProjectDetailModel : basemodel
    { 
        public string ProjectName { get; set; }
        public string ProjectID { get; set; }

        public string ClientName { get; set; }
        public string MonthlyLeaves { get; set; }
    }
}
