using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using PWSHackathonClient.PWS_Service;


namespace PWSHackathonClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class AddressPage : Page
    {
        
        public AddressPage()
        {
            InitializeComponent();
        }

        private void CreateRiskAssessment()
        {
            using (PWSHackathonClient.PWS_Service.RiskAssessmentServiceClient proxy = new RiskAssessmentServiceClient())
            {
                RiskAssessment ra = new RiskAssessment();
                ra.LocalAuthority = "Daves Local Authority";
                ra.SupplyName = "Daves Supply Name";
                ra.SupplyReference = "Daves Supply Reference";

                RiskAssessment newRA = proxy.CreateRiskAssessment(ra);

              // CreateAddressForRiskAssessment(newRA.SupplyReference);
            }
        }

        private void CreateAddress()
        {
            using (PWSHackathonClient.PWS_Service.AddressServiceClient proxy = new AddressServiceClient())
            {
                Address addr = CreateAddressFromScreen();            

                Address newAddress = proxy.CreateAddress(addr);
                
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            CreateRiskAssessment();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private Address CreateAddressFromScreen()
        {
            Address ret = new Address();

            ret.Name = addNameTxt.Text;
            ret.Line1 = line1Txt.Text;
            ret.Line2 = line2Txt.Text;
            ret.Line3 = line3Txt.Text;
            ret.Line4 = line4Txt.Text;
            ret.PostCode = postCodeTxt.Text;
            ret.TelephoneNumber = telPhoneTxt.Text;
            ret.EMail = emailTxt.Text;

            return ret;
        }
    }
}
