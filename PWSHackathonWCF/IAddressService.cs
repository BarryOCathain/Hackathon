using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PWSHackathonWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IAddressService
    {

        [OperationContract]
        Address GetAddress(string postcode);

        [OperationContract]
        Address CreateAddress(Address address);

        [OperationContract]
        Address DeleteAddress(Address address);

        [OperationContract]
        Address UpdateAddress(Address address);

        [OperationContract]
        List<Address> GetAllAddresses();

    }


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
        int _riskAssessmentId;

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
        public int RiskAssessmentId
        {
            get { return _riskAssessmentId; }
            set { _riskAssessmentId = value; }
        }
    }
}
