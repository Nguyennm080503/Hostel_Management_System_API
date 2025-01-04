using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using Common;
using Common.Enum;
using Dao;
using Dtos.Account;
using Models;
using Repository.Interface;

namespace Repository.Implement
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IMapper _mapper;

        public AccountRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task AddAccountInFlatform(NewEmployeeAccountDto accountDto)
        {
            var account = _mapper.Map<Account>(accountDto);

            using var hmac = new HMACSHA512();
            account.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(GlobalConstant.DefaultPassword));
            account.PasswordSalt = hmac.Key;
            account.CreatedDate = DateTime.Now;
            account.Status = AccountStatusEnum.Active.ToString();
            account.Role = 2;

            await AccountDao.Instance.CreateAsync(account);

            return;
        }

        public async Task AddAccountSample(int numberAccount)
        {
            for (int i = 1; i <= numberAccount; i++)
            {
                var random = new Random();
                var usedCitizenCards = new HashSet<string>();
                var usedPhone = new HashSet<string>();
                var account = new Account();

                using var hmac = new HMACSHA512();
                string email;
                int attempt = 0;
                do
                {
                    email = $"account{i + attempt}@gmail.com";
                    attempt++;
                } while (await CheckEmailExisted(email)); 

                account.Email = email;
                account.Address = "TP.HCM";
                string citizenCard;
                do
                {
                    citizenCard = $"{random.Next(100000, 999999)}{random.Next(100000, 999999)}";
                } while (usedCitizenCards.Contains(citizenCard));
                usedCitizenCards.Add(citizenCard);

                string phone;
                do
                {
                    phone = $"{random.Next(10000, 99999)}{random.Next(10000, 99999)}";
                } while (usedPhone.Contains(phone));
                usedPhone.Add(phone);

                account.CitizenCard = citizenCard;
                account.Phone = phone;
                account.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(GlobalConstant.DefaultPassword));
                account.PasswordSalt = hmac.Key;
                account.CreatedDate = DateTime.Now;
                account.Status = AccountStatusEnum.Active.ToString();
                account.Role = 2;
                account.Gender = 1;
                account.Name = $"Account{i + attempt}";

                await AccountDao.Instance.CreateAsync(account);
            } 

            return;
        }

        public async Task<bool> ChangeAccountStatus(int accountId, string status)
        {
            var currentAccount = await AccountDao.Instance.GetAccountById(accountId);
            if (currentAccount != null)
            {
                currentAccount.Status = status;
                await AccountDao.Instance.UpdateAsync(currentAccount);

                return true;
            }

            return false;
        }

        public async Task<bool> CheckEmailExisted(string email)
        {
            var account = await AccountDao.Instance.GetAccountByEmail(email);
            if (account == null)
            {
                return false;
            }
            return true;
        }

        public async Task<AccountBaseDto> GetAccountByID(int accountId)
        {
            var account = await AccountDao.Instance.GetAccountById(accountId);
            return _mapper.Map<AccountBaseDto>(account);
        }

        public async Task<IEnumerable<AccountBaseDto>> GetAllAccountInFlatform()
        {
            var accounts = await AccountDao.Instance.GetAllAsync();

            return _mapper.Map<IEnumerable<AccountBaseDto>>(accounts);
        }

        public async Task<AccountDto> GetEmail(string email)
        {
            var account = await AccountDao.Instance.GetAccountByEmail(email);
            return _mapper.Map<AccountDto>(account);
        }
    }
}
