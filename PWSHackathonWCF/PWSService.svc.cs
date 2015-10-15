using PWSHackathonDAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PWSHackathonWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class PWSService : IAddressService, IRiskAssessmentService, IRiskQuestionService
    {
        PWS_DatabaseEntities _db;
        IAddressService _addressService;
        IRiskAssessmentService _riskAssessmentService;
        IRiskQuestionService _riskQuestionsService;

        public PWSService()
        {
            _db = new PWS_DatabaseEntities();
            _addressService = new AddressService(_db);
            _riskAssessmentService = new RiskAssessmentService(_db);
            _riskQuestionsService = new RiskQuestionService(_db);
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

        public List<Address> GetAddressesByRiskAssessment(string riskAssessmentSupplyRef)
        {
            return _addressService.GetAddressesByRiskAssessment(riskAssessmentSupplyRef);
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

        public RiskAssessment GetRiskAssessment(string supplyReference)
        {
            return _riskAssessmentService.GetRiskAssessment(supplyReference);
        }

        public RiskAssessment UpdateRiskAssessment(RiskAssessment updatedRiskAssessment)
        {
            return _riskAssessmentService.UpdateRiskAssessment(updatedRiskAssessment);
        }

        public List<RiskQuestion> CreateBlankRisks(string riskAssessmentSupplyReference)
        {
            return _riskQuestionsService.CreateBlankRisks(riskAssessmentSupplyReference);
        }

        public RiskQuestion UpdateRiskQuestion(RiskQuestion riskQuestion)
        {
            return _riskQuestionsService.UpdateRiskQuestion(riskQuestion);
        }

        public List<RiskQuestion> GetRiskQuestionsForRiskAssessment(string riskAssessmentSupplierRefId)
        {
            return _riskQuestionsService.GetRiskQuestionsForRiskAssessment(riskAssessmentSupplierRefId);
        }
    }
}
