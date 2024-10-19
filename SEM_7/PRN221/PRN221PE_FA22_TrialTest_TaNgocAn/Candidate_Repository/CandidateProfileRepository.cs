using Candidate_BusinessObjects;
using Candidate_DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Repository
{
    public class CandidateProfileRepository : ICandidateProfileRepository
    {
        public List<CandidateProfile> GetCandidateProfiles() => CandidateProfileDAO.Instance.GetCandidateProfiles();
        public CandidateProfile GetCandidateProfileById(string id) => CandidateProfileDAO.Instance.GetCandidate(id);

        public bool AddCandidateProfile(CandidateProfile candidateProfile) => CandidateProfileDAO.Instance.AddCandidateProfile(candidateProfile);

        public bool DeleteCandidateProfile(CandidateProfile candidateProfile) => CandidateProfileDAO.Instance.DeleteCandidateProfile(candidateProfile);

        public bool UpdateCandidateProfile(CandidateProfile candidateProfile) => CandidateProfileDAO.Instance.UpdateCandidateProfile(candidateProfile);
    }
}
