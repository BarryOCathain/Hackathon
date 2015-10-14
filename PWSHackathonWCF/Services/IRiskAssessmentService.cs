using System.Collections.Generic;
using System.ServiceModel;

namespace PWSHackathonWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IRiskAssessmentService
    {

        [OperationContract]
        RiskAssessment GetRiskAssessment(string supplyReference);

        [OperationContract]
        RiskAssessment CreateRiskAssessment(RiskAssessment riskAssessment);

        [OperationContract]
        RiskAssessment DeleteRiskAssessment(RiskAssessment riskAssessment);

        [OperationContract]
        RiskAssessment UpdateRiskAssessment(RiskAssessment riskAssessment);

        [OperationContract]
        List<RiskAssessment> GetAllRiskAssessments();
    }
}


