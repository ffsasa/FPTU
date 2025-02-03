using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Candidate_BusinessObjects;
using Candidate_Service;

namespace CadidateManageWebsite.Pages.CandidateProfilePage
{
    public class CreateModel : PageModel
    {
        private readonly ICandidateProfileService candidateProfileService;
        private readonly IJobPostingService jobPostingService;

        public CreateModel(IJobPostingService jobPosting, ICandidateProfileService candidateProfile)
        {
            candidateProfileService = candidateProfile;
            jobPostingService = jobPosting;
        }

        public IActionResult OnGet()
        {
        ViewData["PostingId"] = new SelectList(jobPostingService.GetJobPostings(), "PostingId", "JobPostingTitle");
            return Page();
        }

        [BindProperty]
        public CandidateProfile CandidateProfile { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || candidateProfileService.GetCandidateProfiles() == null || CandidateProfile == null)
            {
                return Page();
            }

            candidateProfileService.AddCandidateProfile(CandidateProfile);

            return RedirectToPage("./Index");
        }
    }
}
