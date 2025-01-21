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
    /// Interaction logic for JobPostingWindow.xaml
    /// </summary>
    public partial class JobPostingWindow : Window
    {
        private IJobPostingService jobPostingService;
        public JobPostingWindow()
        {
            InitializeComponent();
            jobPostingService = new JobPostingService();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to quit?", "Quit", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void dtgJobPost_Loaded(object sender, RoutedEventArgs e)
        {
            dtgJobPost.ItemsSource = jobPostingService.GetJobPostings();
        }

        private void LoadData()
        {
            this.dtgJobPost.ItemsSource = null;
            this.dtgJobPost.ItemsSource = jobPostingService.GetJobPostings().Select(x => new
            {
                x.PostingId,
                x.Description,
                x.PostedDate,
                x.JobPostingTitle,
            });
        }

        private void ResetForm()
        {
            txtDescription.Text = string.Empty;
            txtTitle.Text = string.Empty;
            txtPostId.Text = string.Empty;
            dtgPostDate.Text = string.Empty;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            JobPosting job = new JobPosting();
            job.PostingId = txtPostId.Text;
            job.JobPostingTitle = txtTitle.Text;
            job.Description = txtDescription.Text;
            job.PostedDate = DateTime.Parse(dtgPostDate.Text);

            if (jobPostingService.AddJobPosting(job))
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

        private void dtgJobPost_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataGridRow row = (DataGridRow)dg.ItemContainerGenerator.ContainerFromIndex(dg.SelectedIndex);
            if (row != null)
            {
                DataGridCell rowColumn = dg.Columns[0].GetCellContent(row).Parent as DataGridCell;
                string id = ((TextBlock)rowColumn.Content).Text;
                JobPosting jobPosting = jobPostingService.GetJobPosting(id);
                if (jobPosting != null)
                {
                    txtPostId.Text = jobPosting.PostingId;
                    txtTitle.Text = jobPosting.JobPostingTitle;
                    txtDescription.Text = jobPosting.Description;
                    dtgPostDate.Text = jobPosting.PostedDate.ToString();
                }
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            JobPosting job = jobPostingService.GetJobPosting(txtPostId.Text);
            if (job != null)
            {
                job.Description = txtDescription.Text;
                job.JobPostingTitle = txtTitle.Text;
                job.PostedDate = DateTime.Parse(dtgPostDate.Text);
                if (jobPostingService.UpdateJobPosting(job))
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
                MessageBox.Show("Something wrong, please select a certain Job Postings to edit!", "Update", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                JobPosting job = jobPostingService.GetJobPosting(txtPostId.Text);
                if (job != null)
                {
                    if (jobPostingService.DeleteJobPosting(job))
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
                    MessageBox.Show("Something wrong, please select a certain Job Posting to delete!", "Delete", MessageBoxButton.OK, MessageBoxImage.Warning);
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CadidateProfileWindow cadidateProfileWindow = new CadidateProfileWindow();
            cadidateProfileWindow.Show();
            this.Close();
        }
    }
}
