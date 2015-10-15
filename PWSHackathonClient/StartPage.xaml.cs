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
        public StartPage()
        {
            InitializeComponent();
            SetButtons();
            if (App.Mode != Mode.None)
            {
                EnableTextBoxes();
                supRefTxt.IsEnabled = false;
                dteCreated.SelectedDate = App.RiskAssessment.DateCreated;
            }
        }

        private void SetButtons()
        {
            btnFind.IsEnabled =
                App.Mode == Mode.None &&
                !string.IsNullOrEmpty(supRefTxt.Text) &&
                string.IsNullOrEmpty(supNameTxt.Text) &&
                string.IsNullOrEmpty(laTxt.Text) &&
                !dteCreated.SelectedDate.HasValue;

            btnSave.IsEnabled =
                App.Mode != Mode.None &&
                !string.IsNullOrEmpty(supRefTxt.Text);
            btnSave.Visibility = btnSave.IsEnabled ? Visibility.Visible : Visibility.Hidden;
            btnNew.IsEnabled =
                App.Mode == Mode.None &&
                !btnSave.IsEnabled;
            btnNew.Visibility = btnNew.IsEnabled ? Visibility.Visible : Visibility.Hidden;

            risksLink.Visibility = btnSave.IsEnabled ? Visibility.Visible : Visibility.Hidden;
            addressesLink.Visibility = btnSave.IsEnabled ? Visibility.Visible : Visibility.Hidden;
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
            string resultMessage = "Action failed. Please validate data and try again";
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
                    RiskAssessment result = null;
                    switch (App.Mode)
                    {
                        case Mode.Create:
                            result = riskAssessmentClient.CreateRiskAssessment(riskAssessment);
                            break;
                        case Mode.Update:
                            result = riskAssessmentClient.UpdateRiskAssessment(riskAssessment);
                            break;
                        default:
                            break;
                    }
                    
                    if (result != null)
                    {
                        resultMessage = "Risk Assessment saved";
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
                    App.Mode = Mode.Update;
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
            App.Mode = Mode.Create;
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
