//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PWSHackathonDAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Risk
    {
        public int ID { get; set; }
        public int RiskAssessmentID { get; set; }
        public int QuestionID { get; set; }
        public int Likelihood { get; set; }
        public int Response { get; set; }
    
        public virtual RiskAssessment RiskAssessment { get; set; }
        public virtual Question Question { get; set; }
    }
}
