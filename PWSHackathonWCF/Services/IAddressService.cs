using System.Collections.Generic;
using System.ServiceModel;

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

        [OperationContract]
        List<Address> GetAddressesByRiskAssessment(string riskAssessmentSupplyRef);
    }
}
