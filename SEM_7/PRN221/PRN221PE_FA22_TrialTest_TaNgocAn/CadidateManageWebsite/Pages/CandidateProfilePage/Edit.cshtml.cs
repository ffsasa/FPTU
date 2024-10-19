using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Candidate_BusinessObjects;
using Candidate_Service;

namespace CadidateManageWebsite.Pages.CandidateProfilePage
{
    public class EditModel : PageModel
    {
        private readonly ICandidateProfileService candidateProfileService;
        private readonly IJobPostingService jobPostingService;

        public EditModel(IJobPostingService jobPosting, ICandidateProfileService candidateProfile)
        {
            candidateProfileService = candidateProfile;
            jobPostingService = jobPosting;
        }

        [BindProperty]
        public CandidateProfile CandidateProfile { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || candidateProfileService.GetCandidateProfiles() == null)
            {
                return NotFound();
            }

            var candidateprofile =  candidateProfileService.GetCandidateProfileById(id);
            if (candidateprofile == null)
            {
                return NotFound();
            }
            CandidateProfile = candidateprofile;
           ViewData["PostingId"] = new SelectList(jobPostingService.GetJobPostings(), "PostingId", "PostingId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Gọi service để cập nhật CandidateProfile
            bool updateSuccess = candidateProfileService.UpdateCandidateProfile(CandidateProfile);

            if (!updateSuccess)
            {
                // Kiểm tra nếu CandidateProfile không tồn tại
                if (!CandidateProfileExists(CandidateProfile.CandidateId))
                {
                    return NotFound();
                }
                else
                {
                    // Throw exception hoặc ghi log nếu cần thiết
                    throw new DbUpdateConcurrencyException();
                }
            }

            return RedirectToPage("./Index");
        }


        private bool CandidateProfileExists(string id)
        {
          return candidateProfileService.GetCandidateProfileById(id) != null;
        }
    }
}
