using Dtos.Account;

namespace Service.Interface
{
    public interface IAccountService
    {
        Task<IEnumerable<AccountBaseDto>> GetAllAccountInFlatform();
        Task CreateAccountStaff(NewEmployeeAccountDto account);
        Task<LoginAccountDto> LoginSystem(LoginDto loginUsernameDto);
        Task<bool> ChangeAccountStatus(int accountId, string status);
        Task CreateAccountSample(int numberAccount);
    }
}
