using PWSHackathonDAL;
using System.Collections.Generic;
using System.Linq;

namespace PWSHackathonWCF
{
    public class RiskAssessmentService : IRiskAssessmentService
    {
        PWS_DatabaseEntities _db;

        public RiskAssessmentService(PWS_DatabaseEntities db)
        {
            _db = db;
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
            return result;
        }

        public RiskAssessment GetRiskAssessment(string supplyReference)
        {
            var riskAssessment = _db.RiskAssessments.FirstOrDefault(ra => ra.SupplyReference == supplyReference);
            return MappingHelper.RiskAssessmentDALToWCF(riskAssessment);
        }

        public RiskAssessment UpdateRiskAssessment(RiskAssessment updatedRiskAssessment)
        {
            var riskAssessment = _db.RiskAssessments
                //TODO .OrderByDescending(ra => ra.DateCreated)
                .FirstOrDefault(ra => ra.SupplyReference == updatedRiskAssessment.SupplyReference);
            riskAssessment.LocalAuthority = updatedRiskAssessment.LocalAuthority;
            riskAssessment.SupplyName = updatedRiskAssessment.SupplyName;
            riskAssessment.SupplyReference = updatedRiskAssessment.SupplyReference;
            _db.SaveChanges();
            return MappingHelper.RiskAssessmentDALToWCF(riskAssessment);
        }
    }
}