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
        
        public AddressPage()
        {
            InitializeComponent();
            BindAddressesToDataGrid();
        }
        
        private void CreateAddress()
        {
            using (PWSHackathonClient.PSW_Service.AddressServiceClient proxy = new AddressServiceClient())
            {
                Address addr = CreateAddressFromScreen();            

                Address newAddress = proxy.CreateAddress(addr);
                if (newAddress != null)
                {
                    MessageBox.Show("Address saved");
                }
                
            }
        }

        private void UpdateAddress()
        {
            using (PWSHackathonClient.PSW_Service.AddressServiceClient proxy = new AddressServiceClient())
            {
                Address addy = CreateAddressFromScreen();

                Address newAddy = proxy.UpdateAddress(addy);
                if (newAddy != null)
                {
                    MessageBox.Show("Address saved");
                }
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
            ret.RiskAssessmentSupplyRef = App.RiskAssessment.SupplyReference;
            return ret;
        }

        private List<Address> GetAddressesByRiskAssessment(string supplyRef)
        {
            List<Address> addresses;

            using (PWSHackathonClient.PSW_Service.AddressServiceClient proxy = new AddressServiceClient())
            {
                addresses = proxy.GetAddressesByRiskAssessment(supplyRef).ToList();
            }

            return addresses;
        }

        private void BindAddressesToDataGrid()
        {
            //TODO: Bind to the datagrid once created.
            List<Address> addys = GetAddressesByRiskAssessment(App.RiskAssessment.SupplyReference);

            // construct the dataset
            //System.Data.DataSet dataset = new System.Data.DataSet();

            //// use a table adapter to populate the Customers table
            //CustomersTableAdapter adapter = new CustomersTableAdapter();
            //adapter.Fill(dataset.Customers);

            // use the Customer table as the DataContext for this Window
            addressDataGrid.DataContext = addys;
        }
    }
}
