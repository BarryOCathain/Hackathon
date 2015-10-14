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
    }
}