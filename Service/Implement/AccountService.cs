using Dtos.Account;
using Microsoft.Extensions.Configuration;
using Repository.Interface;
using Service.Exception;
using Service.Interface;
using Service.Mail;
using Common;
using Service.Helper;
using Common.Enum;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;

namespace Service.Implement
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IConfiguration _configuration;
        private readonly IMailService _mailService;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        public AccountService(
           IConfiguration configuration,
           IAccountRepository accountRepository,
           IMailService mailService,
           ITokenService tokenService,
           IMapper mapper)
        {
            _accountRepository = accountRepository;
            _configuration = configuration;
            _mailService = mailService;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        public async Task CreateAccountStaff(NewEmployeeAccountDto newAccount)
        {

            bool isExist = await _accountRepository.CheckEmailExisted(newAccount.Email);

            if (isExist)
            {
                throw new ServiceException("Email đã tồn tại !");
            }


            await _accountRepository.AddAccountInFlatform(newAccount);

            //Send mail
            _mailService.SendMail(AuthenticationMail.SendWelcomeAndCredentialsToEmployee(newAccount.Email, newAccount.Name, GlobalConstant.DefaultPassword));

            return;
        }

        public async Task<IEnumerable<AccountBaseDto>> GetAllAccountInFlatform()
        {
            return await _accountRepository.GetAllAccountInFlatform();
        }

        private LoginAccountDto AdminLogin(LoginDto loginUsernameDto)
        {
            var adminUsername = ConfigurationHelper.config.GetSection("AdminAccount:Email").Value;
            var adminPassword = ConfigurationHelper.config.GetSection("AdminAccount:Password").Value;

            if (loginUsernameDto.Email.Equals(adminUsername) && loginUsernameDto.Password.Equals(adminPassword))
            {
                var accountDto = new LoginAccountDto
                {
                    AccountID = 0,
                    Name = "Hệ thống quản trị",
                    Role = 0,
                };
                accountDto.Token = _tokenService.CreateToken(accountDto);

                return accountDto;
            }

            return null;
        }

        private async Task<LoginAccountDto> Login(AccountDto accountDto, string password)
        {
            if (accountDto == null)
            {
                throw new ServiceException("Tài khoản không được tìm thấy");
            }

            using var hmac = new HMACSHA512(accountDto.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != accountDto.PasswordHash[i])
                {
                    throw new ServiceException("Sai mật khẩu");
                }
            }

            if (accountDto.Status?.Equals(AccountStatusEnum.Inactive.ToString()) ?? false)
            {
                throw new ServiceException("Tài khoản của bạn đang bị khóa!");
            }

            LoginAccountDto loginAccountDto = _mapper.Map<LoginAccountDto>(accountDto);

            loginAccountDto.Token = _tokenService.CreateToken(loginAccountDto);

            return loginAccountDto;
        }

        public async Task<LoginAccountDto> LoginSystem(LoginDto loginUsernameDto)
        {
            var adminAccount = AdminLogin(loginUsernameDto);
            if (adminAccount != null)
            {
                return adminAccount;
            }

            AccountDto accountDto = await _accountRepository.GetEmail(loginUsernameDto.Email);

            return await Login(accountDto, loginUsernameDto.Password);
        }

        public async Task<bool> ChangeAccountStatus(int accountId, string status)
        {
            await CheckAccountExist(accountId);

            if (!Enum.IsDefined(typeof(AccountStatusEnum), status))
            {
                throw new ServiceException("Trạng thái không hợp lệ !");
            }

            return await _accountRepository.ChangeAccountStatus(accountId, status);
        }

        private async Task<AccountBaseDto> CheckAccountExist(int accountId)
        {
            var account = await _accountRepository.GetAccountByID(accountId);
            if (account == null)
            {
                throw new ServiceException("Tài khoản không tìm thấy!");
            }

            return account;
        }

        public async Task CreateAccountSample(int numberAccount)
        {
            if(numberAccount < 1)
            {
                throw new ServiceException("Không thể tạo tài khoản sample với số lượng bé hơn 1 !");
            }
            await _accountRepository.AddAccountSample(numberAccount);

            return;
        }
    }
}
