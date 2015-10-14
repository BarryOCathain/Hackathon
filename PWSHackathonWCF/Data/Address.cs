using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PWSHackathonWCF
{
    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Address
    {
        string _name;
        string _line1;
        string _line2;
        string _line3;
        string _line4;
        string _post_code;
        string _telelphone;
        string _email;
        string _riskAssessmentSupplyRef;

        [DataMember]
        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }
        [DataMember]
        public String Line1
        {
            get { return _line1; }
            set { _line1 = value; }
        }
        [DataMember]
        public String Line2
        {
            get { return _line2; }
            set { _line2 = value; }
        }
        [DataMember]
        public String Line3
        {
            get { return _line3; }
            set { _line3 = value; }
        }
        [DataMember]
        public String Line4
        {
            get { return _line4; }
            set { _line4 = value; }
        }
        [DataMember]
        public String PostCode
        {
            get { return _post_code; }
            set { _post_code = value; }
        }
        [DataMember]
        public String TelephoneNumber
        {
            get { return _telelphone; }
            set { _telelphone = value; }
        }
        [DataMember]
        public String EMail
        {
            get { return _email; }
            set { _email = value; }
        }
        [DataMember]
        public string RiskAssessmentSupplyRef
        {
            get { return _riskAssessmentSupplyRef; }
            set { _riskAssessmentSupplyRef = value; }
        }
    }
}