using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace PWSHackathonWCF
{
    public class RiskQuestion
    {
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public Boolean IsHazard { get; set; }
        [DataMember]
        public int Severity { get; set; }
        [DataMember]
        public string RiskNumber { get; set; }
        [DataMember]
        public int Likelihood { get; set; }
        [DataMember]
        public int Response { get; set; }
        [DataMember]
        public string RiskAssessmentSupplyReference { get; set; }

    }
}
