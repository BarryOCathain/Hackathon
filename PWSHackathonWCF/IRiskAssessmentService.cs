using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PWSHackathonWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IRiskAssessmentService
    {

        [OperationContract]
        RiskAssessment GetRiskAssessment(int riskAssessmentId);

        [OperationContract]
        RiskAssessment CreateRiskAssessment(RiskAssessment riskAssessment);

        [OperationContract]
        RiskAssessment DeleteRiskAssessment(RiskAssessment riskAssessment);

        [OperationContract]
        RiskAssessment UpdateRiskAssessment(RiskAssessment riskAssessment);

        [OperationContract]
        List<RiskAssessment> GetAllRiskAssessments();

    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class RiskAssessment
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public String LocalAuthority { get; set; }
     
        [DataMember]
        public String SupplyReference { get; set; }
      
        [DataMember]
        public String SupplyName { get; set; }           
       
    }
}
