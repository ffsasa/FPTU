using Candidate_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_DAO
{
    public class HRAccountDAO
    {
        private CandidateManagementContext dbContext;
        private static HRAccountDAO instance;

        public static HRAccountDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HRAccountDAO();
                }
                return instance;
            }
        }

        public Hraccount GetHraccountByEmail(string email)
        {
            return dbContext.Hraccounts.SingleOrDefault(x => x.Email.Equals(email));
        }

        public List<Hraccount> GetHraccounts()
        {
            return dbContext.Hraccounts.ToList();
        }
        public HRAccountDAO()
        {
            dbContext = new CandidateManagementContext();
        }
    }
}
