using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PWSHackathonWCF
{
    [DataContract]
    public class RiskAssessment
    {
        [DataMember]
        public String LocalAuthority { get; set; }

        [DataMember]
        public String SupplyReference { get; set; }

        [DataMember]
        public String SupplyName { get; set; }

        [DataMember]
        public string DateCreated { get; internal set; }
    }
}
