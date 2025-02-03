using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Candidate_BusinessObjects;
using Candidate_Service;

namespace CadidateManageWebsite.Pages.CandidateProfilePage
{
    public class IndexModel : PageModel
    {
        private readonly ICandidateProfileService candidateProfileService;

        public IndexModel(ICandidateProfileService candidateProfile)
        {
            candidateProfileService = candidateProfile;
        }

        public IList<CandidateProfile> CandidateProfile { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (candidateProfileService.GetCandidateProfiles != null)
            {
                CandidateProfile = candidateProfileService.GetCandidateProfiles();
            }
        }
    }
}
