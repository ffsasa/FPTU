using Candidate_BusinessObjects;
using Candidate_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Service
{
    public class JobPostingService : IJobPostingService
    {
        private IJobPostingRepository _repository;
        public JobPostingService()
        {
            _repository = new JobPostingRepository();
        }
        public bool AddJobPosting(JobPosting jobPosting)
        {
            return _repository.AddJobPosting(jobPosting);
        }

        public bool DeleteJobPosting(JobPosting jobPosting)
        {
            return _repository.DeleteJobPosting(jobPosting);
        }

        public JobPosting GetJobPosting(string jobId)
        {
            return _repository.GetJobPosting(jobId);
        }

        public List<JobPosting> GetJobPostings()
        {
            return _repository.GetJobPostings();
        }

        public bool UpdateJobPosting(JobPosting jobPosting)
        {
            return _repository.UpdateJobPosting(jobPosting);
        }
    }
}
