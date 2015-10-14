using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PWSHackathonWCF
{
    public static class MappingHelper
    {
        public static PWSHackathonDAL.RiskAssessment RiskAssessmentWCFToDAL(RiskAssessment riskAssessmentWCF)
        {
            if (riskAssessmentWCF == null) {
                return null;
            }

            return new PWSHackathonDAL.RiskAssessment
            {
                ID = riskAssessmentWCF.Id,
                LocalAuthority = riskAssessmentWCF.LocalAuthority,
                SupplyName = riskAssessmentWCF.SupplyName,
                SupplyReference = riskAssessmentWCF.SupplyReference
            };
        }

        public static RiskAssessment RiskAssessmentDALToWCF(PWSHackathonDAL.RiskAssessment riskAssessmentDAL)
        {
            if (riskAssessmentDAL == null)
            {
                return null;
            }

            return new RiskAssessment
            {
                Id = riskAssessmentDAL.ID,
                LocalAuthority = riskAssessmentDAL.LocalAuthority,
                SupplyName = riskAssessmentDAL.SupplyName,
                SupplyReference = riskAssessmentDAL.SupplyReference
            };
        }

        public static PWSHackathonDAL.Address WCFAddressToDALAddress(Address address)
        {
            if (address != null)
            {
                PWSHackathonDAL.Address output = new PWSHackathonDAL.Address();

                output.Name = address.Name;
                output.AddressLine1 = address.Line1;
                output.AddressLine2 = address.Line2;
                output.AddressLine3 = address.Line3;
                output.AddressLine4 = address.Line4;
                output.Email = address.EMail;
                output.Postcode = address.PostCode;
                output.Telephone = address.TelephoneNumber;

                return output;
            }
            else
            {
                return null;
            }
        }

        public static Address DALAddressToWCFAddress(PWSHackathonDAL.Address address)
        {
            if (address != null)
            {
                Address output = new Address();

                output.Name = address.Name;
                output.Line1 = address.AddressLine1;
                output.Line2 = address.AddressLine2;
                output.Line3 = address.AddressLine3;
                output.Line4 = address.AddressLine4;
                output.PostCode = address.Postcode;
                output.TelephoneNumber = address.Telephone;
                output.EMail = address.Email;

                return output;
            }
            else
            {
                return null;
            }
        }
    }
}