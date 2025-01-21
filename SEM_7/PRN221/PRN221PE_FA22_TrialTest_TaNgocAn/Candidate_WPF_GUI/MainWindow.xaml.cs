using Candidate_BusinessObjects;
using Candidate_Service;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Candidate_WPF_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IHRAccountService iHRAccountService;
        public MainWindow()
        {
            InitializeComponent();
            iHRAccountService = new HRAccountService();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Hraccount hraccount = iHRAccountService.GetHraccountByEmail(txtEmail.Text);
            if(hraccount != null && hraccount.Password.Equals(txtPassword.Password))
            {
                JobPostingWindow cadidate = new JobPostingWindow();
                cadidate.Show();
            } else
            {
                MessageBox.Show("Your email or password is incorrect");
            }
                
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
                this.Close();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
    }
}