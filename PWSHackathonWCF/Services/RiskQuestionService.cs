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

        public List<RiskQuestion> CreateBlankRisks(string riskAssessmentSupplyReference) {
            var result = new List<RiskQuestion>();
            var riskAssessment = _db.RiskAssessments
                  .OrderByDescending(ra => ra.DateCreated)
                  .FirstOrDefault(ra => ra.SupplyReference == riskAssessmentSupplyReference);

            if (riskAssessment == null)
            {
                return result;
            }
            foreach (var question in _db.Questions.ToList())
            {
                var risk = new Risk
                {
                    QuestionID = question.ID,
                    RiskAssessmentID = riskAssessment.ID,
                };
                risk = _db.Risks.Add(risk);
                _db.SaveChanges();
                var riskQuestion = MappingHelper.DALRiskToWCFRiskQuestion(risk);
                result.Add(riskQuestion);
            }
            return result;
        }

        public RiskQuestion UpdateRiskQuestion(RiskQuestion riskQuestion) {
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
            return MappingHelper.DALRiskToWCFRiskQuestion(risk);    
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
                .Where(rq => rq.RiskAssessmentID == riskAssessment.ID)
                .ToList();

            foreach (var risk in risks)
            {
                result.Add(MappingHelper.DALRiskToWCFRiskQuestion(risk));
            }
            return result;
        }
    }
}