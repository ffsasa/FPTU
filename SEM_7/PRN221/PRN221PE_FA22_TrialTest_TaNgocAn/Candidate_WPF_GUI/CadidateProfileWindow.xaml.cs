using Candidate_BusinessObjects;
using Candidate_Service;
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

namespace Candidate_WPF_GUI
{
    /// <summary>
    /// Interaction logic for CadidateProfileWindow.xaml
    /// </summary>
    public partial class CadidateProfileWindow : Window
    {
        private int? roleId = 0;
        private ICandidateProfileService _candidateProfileService;
        private IJobPostingService _jobPostingService;
        public CadidateProfileWindow()
        {
            InitializeComponent();
            _candidateProfileService = new CandidateProfileService();
            _jobPostingService = new JobPostingService();
        }

        public CadidateProfileWindow(int? roleId)
        {
            InitializeComponent();
            _candidateProfileService = new CandidateProfileService();
            _jobPostingService = new JobPostingService();
            this.roleId = roleId;
            switch (roleId)
            {
                case 1:
                    break;
                case 2:
                    this.btnAdd.IsEnabled = false;
                    break;
                default:
                    break;
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to quit?", "Quit", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void dtgCandidate_Loaded(object sender, RoutedEventArgs e)
        {
            dtgCandidateProfile.ItemsSource = _candidateProfileService.GetCandidateProfiles();
            cbxJobPosting.ItemsSource = _jobPostingService.GetJobPostings();
            cbxJobPosting.DisplayMemberPath = "JobPostingTitle";
            cbxJobPosting.SelectedValuePath = "PostingId";
        }

        private void LoadData()
        {
            this.dtgCandidateProfile.ItemsSource = null;
            this.dtgCandidateProfile.ItemsSource = _candidateProfileService.GetCandidateProfiles().Select(x => new
            {
                x.CandidateId,
                x.Fullname,
                x.Birthday,
                x.ProfileShortDescription,
                x.ProfileUrl
            });
            cbxJobPosting.ItemsSource = _jobPostingService.GetJobPostings();
            cbxJobPosting.DisplayMemberPath = "JobPostingTitle";
            cbxJobPosting.SelectedValuePath = "PostingId";
        }

        private void ResetForm()
        {
            txtCandidateId.Text = string.Empty;
            txtFullName.Text = string.Empty;
            txtImageUrl.Text = string.Empty;
            txtCandidateDescription.Text = string.Empty;
            dtgBirthDay.Text = string.Empty;
            cbxJobPosting.ItemsSource = _jobPostingService.GetJobPostings();
            cbxJobPosting.DisplayMemberPath = "JobPostingTitle";
            cbxJobPosting.SelectedValuePath = "PostingId";
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            CandidateProfile candidateProfile = new CandidateProfile();
            candidateProfile.CandidateId = txtCandidateId.Text;
            candidateProfile.Fullname = txtFullName.Text;
            candidateProfile.ProfileShortDescription = txtCandidateDescription.Text;
            candidateProfile.ProfileUrl = txtImageUrl.Text;
            candidateProfile.Birthday = DateTime.Parse(dtgBirthDay.Text);
            candidateProfile.PostingId = cbxJobPosting.SelectedValue.ToString();

            if (_candidateProfileService.AddCandidateProfile(candidateProfile))
            {
                this.LoadData();
                this.ResetForm();
                MessageBox.Show("Add Successful!", "Add", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Something wrong!", "Add", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            CandidateProfile candidateProfile = _candidateProfileService.GetCandidateProfileById(txtCandidateId.Text);
            if (candidateProfile != null)
            {
                candidateProfile.Fullname = txtFullName.Text;
                candidateProfile.ProfileShortDescription = txtCandidateDescription.Text;
                candidateProfile.ProfileUrl = txtImageUrl.Text;
                candidateProfile.Birthday = DateTime.Parse(dtgBirthDay.Text);
                candidateProfile.PostingId = cbxJobPosting.SelectedValue.ToString();
                if (_candidateProfileService.UpdateCandidateProfile(candidateProfile))
                {
                    this.LoadData();
                    this.ResetForm();
                    MessageBox.Show("Update Successful!", "Update", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Something wrong!", "Update", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Something wrong, please select a certain Candidate Profile to edit!", "Update", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                CandidateProfile candidate = _candidateProfileService.GetCandidateProfileById(txtCandidateId.Text);
                if (candidate != null)
                {
                    if (_candidateProfileService.DeleteCandidateProfile(candidate))
                    {
                        this.LoadData();
                        this.ResetForm();
                        MessageBox.Show("Delete Successful!", "Delete", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Something wrong!", "Delete", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Something wrong, please select a certain Candidate Profile to delete!", "Delete", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void dtgCandidateProfile_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataGridRow row = (DataGridRow)dg.ItemContainerGenerator.ContainerFromIndex(dg.SelectedIndex);
            if (row != null)
            {
                DataGridCell rowColumn = dg.Columns[0].GetCellContent(row).Parent as DataGridCell;
                string id = ((TextBlock)rowColumn.Content).Text;
                CandidateProfile candidateProfile = _candidateProfileService.GetCandidateProfileById(id);
                if (candidateProfile != null)
                {
                    txtCandidateId.Text = candidateProfile.CandidateId;
                    txtFullName.Text = candidateProfile.Fullname;
                    txtImageUrl.Text = candidateProfile.ProfileUrl;
                    txtCandidateDescription.Text = candidateProfile.ProfileShortDescription;
                    dtgBirthDay.Text = candidateProfile.Birthday.ToString();
                    cbxJobPosting.SelectedValue = candidateProfile.PostingId;
                }
            }
        }

         private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
    }
}
