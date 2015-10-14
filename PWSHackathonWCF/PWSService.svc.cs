using System;
using System.Collections.Generic;
using System.Linq;
using PWSHackathonDAL;

namespace PWSHackathonWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class PWSService : IAddressService, IRiskAssessmentService
    {
        PWS_DatabaseEntities _db;
        IAddressService _addressService;
        RiskAssessmentService _riskAssessmentService;
        
        public PWSService()
        {
            _db = new PWS_DatabaseEntities();
            _addressService = new AddressService(_db);
            _riskAssessmentService = new RiskAssessmentService(_db);
        }

        public Address CreateAddress(Address address)
        {
            return _addressService.CreateAddress(address);
        }

        public Address DeleteAddress(Address address)
        {
            return _addressService.DeleteAddress(address);
        }

        public Address GetAddress(string postcode)
        {
            return _addressService.GetAddress(postcode);
        }

        public List<Address> GetAllAddresses()
        {
            return _addressService.GetAllAddresses();
        }

        public Address UpdateAddress(Address address)
        {
            return _addressService.UpdateAddress(address);
        }


        public RiskAssessment CreateRiskAssessment(RiskAssessment riskAssessment)
        {
            return _riskAssessmentService.CreateRiskAssessment(riskAssessment);
        }

        public RiskAssessment DeleteRiskAssessment(RiskAssessment riskAssessment)
        {
            return _riskAssessmentService.DeleteRiskAssessment(riskAssessment);
        }

        public List<RiskAssessment> GetAllRiskAssessments()
        {
            return _riskAssessmentService.GetAllRiskAssessments();
        }

        public RiskAssessment GetRiskAssessment(int riskAssessmentId)
        {
            return _riskAssessmentService.GetRiskAssessment(riskAssessmentId);
        }

        public RiskAssessment UpdateRiskAssessment(RiskAssessment updatedRiskAssessment)
        {
            return _riskAssessmentService.UpdateRiskAssessment(updatedRiskAssessment);
        }
    }
}
