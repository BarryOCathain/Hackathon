
namespace PWSHackathonDAL
{
    using System;
    using System.Collections.Generic;

    public partial class RiskAssessment
    {
        public int Id { get; set; }
        public string LocalAuthority { get; set; }
        public string SupplyReference { get; set; }
        public string SupplyName { get; set; }
    }
}
