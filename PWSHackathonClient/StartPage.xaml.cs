using PWSHackathonClient.PSW_Service;
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
using System.Windows.Shapes;

namespace PWSHackathonClient
{

    /// <summary>
    /// Interaction logic for RiskWindow.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        Mode mode = Mode.Update;

        public StartPage()
        {
            InitializeComponent();
            mode = Mode.None;
            SetButtons();
        }

        private void SetButtons()
        {
            btnFind.IsEnabled = 
                mode == Mode.None &&
                !string.IsNullOrEmpty(supRefTxt.Text) &&
                string.IsNullOrEmpty(supNameTxt.Text) &&
                string.IsNullOrEmpty(laTxt.Text) &&
                !dteCreated.SelectedDate.HasValue;

            btnSave.IsEnabled = 
                mode != Mode.None && 
                !string.IsNullOrEmpty(supRefTxt.Text);
            btnSave.Visibility = btnSave.IsEnabled ? Visibility.Visible : Visibility.Hidden;
            btnNew.IsEnabled = 
                mode == Mode.None && 
                !btnSave.IsEnabled;
            btnNew.Visibility = btnNew.IsEnabled ? Visibility.Visible : Visibility.Hidden;

            risksLink.IsEnabled = btnSave.IsEnabled;
            addressesLink.IsEnabled = btnSave.IsEnabled;

        }

        private void BlankForm()
        {
            laTxt.Text = string.Empty;
            supNameTxt.Text = string.Empty;
            dteCreated.SelectedDate = null;
            supRefTxt.Text = string.Empty;
        }

        private void EnableTextBoxes()
        {
            laTxt.IsEnabled = true;
            supNameTxt.IsEnabled = true;
            dteCreated.IsEnabled = true;
            supRefTxt.IsEnabled = true;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string resultMessage = "Risk Assessment creation failed. Please validate data and try again";
            try
            {
                var riskAssessment = new RiskAssessment
                {
                    SupplyName = supNameTxt.Text,
                    SupplyReference = supRefTxt.Text,
                    LocalAuthority = laTxt.Text,
                    DateCreated = dteCreated.SelectedDate.Value
                };

                using (var riskAssessmentClient = new RiskAssessmentServiceClient())
                {
                    var result = riskAssessmentClient.CreateRiskAssessment(riskAssessment);
                    if (result != null)
                    {
                        resultMessage = "Risk Assessment created";
                        App.RiskAssessment = result;
                    }
                }
            }
            catch
            {
                // Do nothing. Perfect demo ;)            
            }
            finally
            {
                MessageBox.Show(resultMessage);
            }

        }

        private void btnFind_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var riskAssessmentClient = new RiskAssessmentServiceClient())
                {
                    var result = riskAssessmentClient.GetRiskAssessment(supRefTxt.Text);
                    if (result == null)
                    {
                        MessageBox.Show("Risk Assessment not found");
                        return;
                    }
                    laTxt.Text = result.LocalAuthority;
                    supNameTxt.Text = result.SupplyName;
                    dteCreated.SelectedDate = result.DateCreated;
                    EnableTextBoxes();
                    supRefTxt.IsEnabled = false;
                    mode = Mode.Update;
                    SetButtons();
                }

            }
            catch (Exception)
            {
                // Do nothing. Perfect demo ;)
            }
            finally
            {

            }
        }
        
        private void btnNew_click(object sender, RoutedEventArgs e)
        {
            mode = Mode.Create;
            EnableTextBoxes();
            BlankForm();
            SetButtons();
        }

        private void supRefTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetButtons();
        }

        private void dteCreated_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            SetButtons();
        }

        private void supNameTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetButtons();
        }

        private void laTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetButtons();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            btnSave_Click(sender, e);
        }

        private void Hyperlink_Click_1(object sender, RoutedEventArgs e)
        {
            btnSave_Click(sender, e);
        }
    }



}
