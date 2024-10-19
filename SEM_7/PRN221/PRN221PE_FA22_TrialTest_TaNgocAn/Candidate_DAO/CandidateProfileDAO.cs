using Candidate_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_DAO
{
    public class CandidateProfileDAO
    {
        private CandidateManagementContext context;
        private static CandidateProfileDAO instance;

        public static CandidateProfileDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CandidateProfileDAO();
                } 
                return instance;
            }
        }

        public CandidateProfileDAO()
        {
            context = new CandidateManagementContext();
        }

        public List<CandidateProfile> GetCandidateProfiles()
        {
            return context.CandidateProfiles.ToList();
        }

        public CandidateProfile GetCandidate(string id)
        {
            return context.CandidateProfiles.SingleOrDefault(m => m.CandidateId.Equals(id));
        }

        public bool AddCandidateProfile(CandidateProfile candidateProfileNew)
        {
            bool result = false;
            CandidateProfile candidateProfile = GetCandidate(candidateProfileNew.CandidateId);
            try
            {
                if (candidateProfile == null)
                {
                    context.CandidateProfiles.Add(candidateProfileNew);
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
        public bool DeleteCandidateProfile(CandidateProfile candidateProfile)
        {
            bool result = false;
            CandidateProfile candidate = GetCandidate(candidateProfile.CandidateId);
            try
            {
                if (candidate != null)
                {
                    context.CandidateProfiles.Remove(candidateProfile);
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

        public bool UpdateCandidateProfile(CandidateProfile candidateProfile)
        {
            bool result = false;
            CandidateProfile candidate = GetCandidate(candidateProfile.CandidateId);
            try
            {
                if (candidate != null)
                {
                    candidate.Birthday = candidateProfile.Birthday;
                    candidate.Fullname = candidateProfile.Fullname;
                    candidate.ProfileShortDescription = candidateProfile.ProfileShortDescription;
                    candidate.ProfileUrl = candidateProfile.ProfileUrl;
                    candidate.PostingId = candidateProfile.PostingId;

                    context.Entry<CandidateProfile>(candidate).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
