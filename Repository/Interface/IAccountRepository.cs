using Dtos.Account;

namespace Repository.Interface
{
    public interface IAccountRepository
    {
        Task<IEnumerable<AccountBaseDto>> GetAllAccountInFlatform();
        Task AddAccountStaffInFlatform(NewEmployeeAccountDto account);
        Task<bool> CheckEmailExisted(string email);
        Task<AccountDto> GetEmail(string email);
        Task<AccountBaseDto> GetAccountByID(int accountId);
        Task<bool> ChangeAccountStatus(int accountId, string status);
    }
}
