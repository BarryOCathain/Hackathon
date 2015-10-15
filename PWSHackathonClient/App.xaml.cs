using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;


namespace PWSHackathonClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static PSW_Service.RiskAssessment RiskAssessment { get; set; }
        public static Mode Mode = Mode.None;
    }
}
