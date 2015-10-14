using PWSHackathonDAL;
using System.Collections.Generic;
using System.Linq;
using System;

namespace PWSHackathonWCF
{
    public class RiskQuestionService : IRiskQuestionService
    {
        PWS_DatabaseEntities _db;

        public RiskQuestionService(PWS_DatabaseEntities db)
        {
            _db = db;
        }

        public RiskQuestion CreateRiskQuestion(RiskQuestion riskQuestion)
        {
            if (riskQuestion == null)
            {
                return null;
            }
            var risk = MappingHelper.riskWCFToDAL(riskQuestion);
            if (_db.Risks.Any(r => 
                   r.RiskAssessment.SupplyReference == riskQuestion.RiskAssessmentRefSupplier &&
                   r.Question.RiskNumber == riskQuestion.RiskNumber))
            {
                return null;
            }
            risk = _db.Risks.Add(risk);
            _db.SaveChanges();
            return MappingHelper.riskDALToWCF(risk);
        }

        public RiskQuestionService UpdateRiskQuestion(RiskQuestion riskQuestion) {
            if (riskQuestion == null)
            {
                return null;
            }
            var riskAssessment = _db.RiskAssessments
                  .OrderByDescending(ra => ra.DateCreated)
                  .FirstOrDefault(ra => ra.SupplyReference == riskQuestion.RiskAssessmentSupplyReference);

            if (riskAssessment == null) {
                return null;
            }

            var risk = _db.Risks
                .FirstOrDefault(r => 
                r.RiskAssessmentID == riskAssessment.ID &&   
                r.Question.RiskNumber == riskQuestion.RiskNumber);

            risk.Likelihood = riskQuestion.Likelihood;
            risk.Response = riskQuestion.Response;
            _db.SaveChanges();
            return MappingHelper.riskDALToWCF(risk);    
        }

        public List<RiskQuestion> GetAllRiskQuestions()
        {
            List<RiskQuestion> riskQuestions = new List<RiskQuestion>();
            foreach (var question in _db.Questions)
            {
                riskQuestions.Add(MappingHelper.riskDALToWCF(question));
            }
            return riskQuestions;           
        }

        public List<RiskQuestion> GetRiskQuestionsForRiskAssessment(string riskAssessmentSupplierRef)
        {
            var result = new List<RiskQuestion>();
            var riskAssessment = _db.RiskAssessments
                   .OrderByDescending(ra => ra.DateCreated)
                   .FirstOrDefault(ra => ra.SupplyReference == riskAssessmentSupplierRef);

            if (riskAssessment == null)
            {
                return null;
            }

            var risks = _db.Risks
                .Where(rq => rq.RiskAssessmentID == riskAssessment.ID);

            foreach (var risk in risks)
            {
                result.Add(MappingHelper.riskDALToWCF(risk));
            }
            return result;
        }
    }
}