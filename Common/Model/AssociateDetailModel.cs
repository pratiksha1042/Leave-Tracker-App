using Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Leave_App.Common.Model
{
    public class AssociateDetailModel : basemodel
    { 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string EmailID { get; set; }
        public string Phone { get; set; }
        public string ProjectName { get; set; }

        public string ProjectID { get; set; }
       
    }
}