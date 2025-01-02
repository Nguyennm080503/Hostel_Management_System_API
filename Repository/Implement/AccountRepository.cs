using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using Common;
using Common.Enum;
using Dao;
using Dtos.Account;
using Microsoft.Identity.Client;
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

        public async Task AddAccountStaffInFlatform(NewEmployeeAccountDto accountDto)
        {
            var account = _mapper.Map<Account>(accountDto);

            using var hmac = new HMACSHA512();
            account.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(GlobalConstant.DefaultPassword));
            account.PasswordSalt = hmac.Key;
            account.CreatedDate = DateTime.Now;
            account.Status = AccountStatusEnum.Active.ToString();
            account.Role = 1;

            await AccountDao.Instance.CreateAsync(account);

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
