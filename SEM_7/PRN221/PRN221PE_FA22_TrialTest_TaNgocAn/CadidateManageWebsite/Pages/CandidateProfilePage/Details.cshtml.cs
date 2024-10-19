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
    public class DetailsModel : PageModel
    {
        private readonly ICandidateProfileService candidateProfileService;

        public DetailsModel(ICandidateProfileService candidate)
        {
            candidateProfileService = candidate;
        }

      public CandidateProfile CandidateProfile { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || candidateProfileService.GetCandidateProfiles == null)
            {
                return NotFound();
            }

            var candidateprofile = candidateProfileService.GetCandidateProfileById(id);
            if (candidateprofile == null)
            {
                return NotFound();
            }
            else 
            {
                CandidateProfile = candidateprofile;
            }
            return Page();
        }
    }
}
