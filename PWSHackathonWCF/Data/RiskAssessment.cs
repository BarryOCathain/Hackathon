using System;
using System.Runtime.Serialization;

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
