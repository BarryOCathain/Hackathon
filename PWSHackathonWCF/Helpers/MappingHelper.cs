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
                LocalAuthority = riskAssessmentWCF.LocalAuthority,
                SupplyName = riskAssessmentWCF.SupplyName,
                SupplyReference = riskAssessmentWCF.SupplyReference,
                //TODO DateCreated = riskAssessmentWCF.DateCreated
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
                LocalAuthority = riskAssessmentDAL.LocalAuthority,
                SupplyName = riskAssessmentDAL.SupplyName,
                SupplyReference = riskAssessmentDAL.SupplyReference,
                //TODO DateCreated = riskAssessmentDAL.DateCreated
            };
        }
    }
}