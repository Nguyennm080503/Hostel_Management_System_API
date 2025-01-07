using Microsoft.EntityFrameworkCore;
using Models;

namespace Dao
{
    public class AccountDao : BaseDAO<Account>
    {
        private static AccountDao instance = null;
        private static readonly object instacelock = new object();

        private AccountDao()
        {

        }

        public static AccountDao Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AccountDao();
                }
                return instance;
            }
        }

        public override async Task<IEnumerable<Account>> GetAllAsync()
        {
            using (var context = new HostelManagementContext())
            {
                return await context.Accounts.Where(x => x.Role != 3).OrderByDescending(x => x.AccountID).ToListAsync();
            }
        }

        public async Task<IEnumerable<Account>> GetTotalAccountsInFlatform()
        {
            using (var context = new HostelManagementContext())
            {
                return await context.Accounts.Where(x => x.Role == 2 && x.Status == "Active").ToListAsync();
            }
        }



        public async Task<Account> GetAccountById(int id)
        {
            using (var context = new HostelManagementContext())
            {
                return await context.Accounts.FirstOrDefaultAsync(x => x.AccountID.Equals(id));
            }
        }

        public async Task<Account?> GetAccountByEmail(string email)
        {
            using (var context = new HostelManagementContext())
            {
                return await context.Accounts
                    .FirstOrDefaultAsync(a => !string.IsNullOrEmpty(a.Email) && a.Email == email);
            }
        }

    }
}
