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
        PWS_DatabaseEntities _db = new PWS_DatabaseEntities();
        IAddressService addressService = new AddressService();

        public Address CreateAddress(Address address)
        {
            return addressService.CreateAddress(address);
        }

        public Address DeleteAddress(Address address)
        {
            return null;
        }

        public Address GetAddress(string postcode)
        {
            PWSHackathonDAL.Address ret = _db.Addresses
                .Where(a => a.Postcode == postcode)
                .FirstOrDefault();

            if (ret != null)
            {
                return DALAddressToWCFAddress(ret); 
            }
            else
            {
                return null;
            }
        }

        public List<Address> GetAllAddresses()
        {
            List<PWSHackathonDAL.Address> dalAdd = _db.Addresses.ToList();
            List<Address> ret = new List<Address>();

            foreach (PWSHackathonDAL.Address address in dalAdd)
            {
                ret.Add(DALAddressToWCFAddress(address));
            }

            if (ret != null)
            {
                return ret;
            }
            else
            {
                return null;
            }
        }

        public Address UpdateAddress(Address address)
        {
            string wcfPostcode = address.PostCode;

            PWSHackathonDAL.Address tempAddress = _db.Addresses
                .Where(a => a.Postcode == wcfPostcode)
                .FirstOrDefault();

            if(tempAddress != null)
            {
                tempAddress.Name = address.Name;
                tempAddress.AddressLine1 = address.Line1;
                tempAddress.AddressLine2 = address.Line1;
                tempAddress.AddressLine3 = address.Line3;
                tempAddress.AddressLine4 = address.Line4;
                tempAddress.Email = address.EMail;
                tempAddress.Telephone = address.TelephoneNumber;

                _db.SaveChanges();

                return DALAddressToWCFAddress(tempAddress);
            }
            else
            {
                return null;
            }
        }


        public RiskAssessment CreateRiskAssessment(RiskAssessment riskAssessment)
        {
            var newRiskAssessment = MappingHelper.RiskAssessmentWCFToDAL(riskAssessment);
            if (newRiskAssessment != null)
            {
                newRiskAssessment = _db.RiskAssessments.Add(newRiskAssessment);
            }
            _db.SaveChanges();
            return MappingHelper.RiskAssessmentDALToWCF(newRiskAssessment);
        }

        public RiskAssessment DeleteRiskAssessment(RiskAssessment riskAssessment)
        {
            var riskAssessmentDAL = MappingHelper.RiskAssessmentWCFToDAL(riskAssessment);
            if (riskAssessmentDAL != null)
            {
                riskAssessmentDAL = _db.RiskAssessments.Remove(riskAssessmentDAL);
            }
            _db.SaveChanges();
            return MappingHelper.RiskAssessmentDALToWCF(riskAssessmentDAL);
        }

        public List<RiskAssessment> GetAllRiskAssessments()
        {
            var result = new List<RiskAssessment>();
            foreach (var riskAssessment in _db.RiskAssessments)
            {
                result.Add(MappingHelper.RiskAssessmentDALToWCF(riskAssessment));
            }
            _db.SaveChanges();
            return result;
        }

        public RiskAssessment GetRiskAssessment(int riskAssessmentId)
        {
            var riskAssessment = _db.RiskAssessments.FirstOrDefault(ra => ra.Id == riskAssessmentId);
            _db.SaveChanges();
            return MappingHelper.RiskAssessmentDALToWCF(riskAssessment);
        }

        public RiskAssessment UpdateRiskAssessment(RiskAssessment updatedRiskAssessment)
        {
            var riskAssessment = _db.RiskAssessments.FirstOrDefault(ra => ra.Id == updatedRiskAssessment.Id);
            riskAssessment.LocalAuthority = updatedRiskAssessment.LocalAuthority;
            riskAssessment.SupplyName = updatedRiskAssessment.SupplyName;
            riskAssessment.SupplyReference = updatedRiskAssessment.SupplyReference;
            _db.SaveChanges();
            return MappingHelper.RiskAssessmentDALToWCF(riskAssessment);
        }
    }
}
