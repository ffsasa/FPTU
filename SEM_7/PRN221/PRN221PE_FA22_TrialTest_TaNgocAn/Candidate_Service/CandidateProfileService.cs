using Candidate_BusinessObjects;
using Candidate_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Service
{
    public class CandidateProfileService : ICandidateProfileService
    {
        private ICandidateProfileRepository iCandidateProfileRepository;
        public CandidateProfileService()
        {
            iCandidateProfileRepository = new CandidateProfileRepository();
        }

        public bool AddCandidateProfile(CandidateProfile candidateProfile)
        {
            return iCandidateProfileRepository.AddCandidateProfile(candidateProfile);
        }

        public bool DeleteCandidateProfile(CandidateProfile candidateProfile)
        {
            return iCandidateProfileRepository.DeleteCandidateProfile(candidateProfile);
        }

        public CandidateProfile GetCandidateProfileById(string id)
        {
            return iCandidateProfileRepository.GetCandidateProfileById(id);
        }

        public List<CandidateProfile> GetCandidateProfiles()
        {
            return iCandidateProfileRepository.GetCandidateProfiles();
        }

        public bool UpdateCandidateProfile(CandidateProfile candidateProfile)
        {
            return iCandidateProfileRepository.UpdateCandidateProfile(candidateProfile);
        }
    }
}
