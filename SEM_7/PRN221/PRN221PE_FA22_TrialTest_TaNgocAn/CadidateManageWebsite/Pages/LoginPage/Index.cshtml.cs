using Candidate_BusinessObjects;
using Candidate_Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CadidateManageWebsite.Pages.LoginPage
{
    public class IndexModel : PageModel
    {
        private readonly IHRAccountService hRAccountService;
        public IndexModel (IHRAccountService haraccountService)
        {
            hRAccountService = haraccountService;
        }
        public void OnGet()
        {
        }

        public void OnPost()
        {
            string email = Request.Form["txtEmail"];
            string password = Request.Form["txtPassword"];
            Hraccount hraccount = hRAccountService.GetHraccountByEmail(email);
            if (hraccount != null && hraccount.Password.Equals(password))
            {
                String RoleId = hraccount.MemberRole.ToString();
                HttpContext.Session.SetString("RoleID", RoleId);
                Response.Redirect("/CandidateProfilePage");
            }
            else
            {
                Response.Redirect("/Error");
            }

        }
    }
}
