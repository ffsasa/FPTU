using Candidate_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_DAO
{
    public class JobPostDAO
    {
        private CandidateManagementContext context;
        private static JobPostDAO instance;

        public static JobPostDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JobPostDAO();
                }
                return instance;
            }
        }
        public JobPostDAO()
        {
            context = new CandidateManagementContext();
        }
        public JobPosting GetJobPosting(string jobId)
        {
            return context.JobPostings.SingleOrDefault(m => m.PostingId.Equals(jobId));
        }
        public List<JobPosting> GetJobPostings()
        {
            return context.JobPostings.ToList();
        }
        public bool AddJobPosting(JobPosting jobPosting)
        {
            bool result = false;
            JobPosting job = GetJobPosting(jobPosting.PostingId);
            try
            {
                if(job == null)
                {
                    context.JobPostings.Add(jobPosting);
                    context.SaveChanges();
                    result = true;
                }
            } catch (Exception ex)
            {
                //Log
            }
            return result;
        }
        public bool DeleteJobPosting(JobPosting jobPosting)
        {
            bool result = false;
            JobPosting job = GetJobPosting(jobPosting.PostingId);
            try
            {
                if (job != null)
                {
                    context.JobPostings.Remove(jobPosting);
                    context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                //Log
            }
            return result;
        }

        public bool UpdateJobPosting(JobPosting jobPosting)
        {
            bool result = false;
            JobPosting job = GetJobPosting(jobPosting.PostingId);
            try
            {
                if (job != null)
                {
                    context.Entry<JobPosting>(jobPosting).State = Microsoft.EntityFrameworkCore.EntityState.Modified; ;
                    context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                //Log
            }
            return result;
        }
    }
}
