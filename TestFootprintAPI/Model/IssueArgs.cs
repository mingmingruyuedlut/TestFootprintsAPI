using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFootprintAPI.Model
{
    [System.Xml.Serialization.SoapTypeAttribute("ProjFields", "Interactive.Footprints")]
    public class ProjFields
    {
        public string Custom__bField__bOne;
        public string Custom__bField__bTwo;
    }

    [System.Xml.Serialization.SoapTypeAttribute("CreateIssueArgs", "Interactive.Footprints")]
    public class IssueArgs
    {
        public string projectID;
        public string title;
        public string[] assignees;
        public string priorityNumber;
        public string status;
        public string description;
        public string selectContact;
        public ProjFields projfields;
    }
}
