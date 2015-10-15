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

using PWSHackathonClient.PSW_Service;


namespace PWSHackathonClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class AddressPage : Page
    {
        private string _supplyRef;
              
        public AddressPage()
        {
            InitializeComponent();
        }

        public AddressPage(string supplyRef)
        {
            InitializeComponent();
            _supplyRef = supplyRef;
        }

        private void CreateAddress()
        {
            using (PWSHackathonClient.PSW_Service.AddressServiceClient proxy = new AddressServiceClient())
            {
                Address addr = CreateAddressFromScreen();            

                Address newAddress = proxy.CreateAddress(addr);
                
            }
        }

        private void UpdateAddress()
        {
            using (PWSHackathonClient.PSW_Service.AddressServiceClient proxy = new AddressServiceClient())
            {
                Address addy = CreateAddressFromScreen();

                Address newAddy = proxy.UpdateAddress(addy);
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            CreateAddress();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            UpdateAddress();
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

        private List<Address> GetAddressesByRiskAssessment(string supplyRef)
        {
            List<Address> addresses;

            using (PWSHackathonClient.PSW_Service.AddressServiceClient proxy = new AddressServiceClient())
            {
                addresses = proxy.GetAddressesByRiskAssessment(supplyRef).ToList();
            }

            if (addresses != null)
            {
                return addresses;
            }
            else
            {
                return null;
            }
        }

        private void BindAddressesToDataGrid()
        {
            //TODO: Bind to the datagrid once created.
            //addressesDataGrid.DataSource
            List<Address> addys = GetAddressesByRiskAssessment(_supplyRef);
        }
    }
}
