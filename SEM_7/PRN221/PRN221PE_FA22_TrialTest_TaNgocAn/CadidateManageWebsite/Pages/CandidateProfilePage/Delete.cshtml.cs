﻿using System;
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
    public class DeleteModel : PageModel
    {
        private readonly ICandidateProfileService candidateProfileService;

        public DeleteModel(ICandidateProfileService candidate)
        {
            candidateProfileService = candidate;
        }

        [BindProperty]
      public CandidateProfile CandidateProfile { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || candidateProfileService.GetCandidateProfiles() == null)
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

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || candidateProfileService.GetCandidateProfiles() == null)
            {
                return NotFound();
            }
            var candidateprofile = candidateProfileService.GetCandidateProfileById(id);

            if (candidateprofile != null)
            {
                CandidateProfile = candidateprofile;
                candidateProfileService.DeleteCandidateProfile(CandidateProfile);
            }

            return RedirectToPage("./Index");
        }
    }
}