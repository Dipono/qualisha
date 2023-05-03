using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Qualisha.iCommunity.Data.Models;
using Qualisha.iCommunity.AccountService;
using Qualisha.iCommunity.Data.Models.Dtos;
using Qualisha.iCommunity.EmailService;
using Qualisha.iCommunity.LoginService;
using Qualisha.iCommunity.RegistrationAPI.Model;
using Qualisha.iCommunity.RegistrationService;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Qualisha.iCommunity.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [EnableCors("ReactPolicy")]
    public class UserManagementController : ControllerBase
    {
        private readonly IRegisterService _registerService;
        private readonly ILoginService _loginService;
        private readonly IMapper _mapper;
        private readonly IAccountService _account;
        private readonly IMailService _mailService;
        private readonly ILogger<UserManagementController> _logger;

        /// <summary>
        /// Innitialse the User managenent controller dependencies
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="registerService"></param>
        /// <param name="loginService"></param>
        /// 
        public UserManagementController(IMapper mapper, IRegisterService registerService, ILoginService loginService,
            IAccountService account, IMailService mailService, ILogger<UserManagementController> logger)
        {
            _mapper = mapper;
            _registerService = registerService;
            _loginService = loginService;
            _account = account;
            _mailService = mailService;
            _logger = logger;
        }

        /// <summary>
        /// Post: UserManagement/Register
        /// </summary>
        /// <param name="userReg"></param>
        /// <returns></returns>
        /// 

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserRegistraionDto userReg)
        {
            UserOTP userOTP = new UserOTP();
            var responseWrapper = new ResponseWrapper();

            if (!ModelState.IsValid)
            {
                _logger.LogInformation("Make sure your fields are valid");
                responseWrapper = new ResponseWrapper
                {
                    Message = "Make sure your fields are valid",
                    Results = userReg
                };
                return Ok(responseWrapper);
            }

            if (!_registerService.ValidateEmail(userReg.EmailAddress))
            {
                responseWrapper = new ResponseWrapper
                {
                    Message = "Provide valid email address.",
                    Results = userReg
                };
                return Ok(responseWrapper);
            }

            if (_registerService.CheckExistingEmail(userReg.EmailAddress))
            {
                responseWrapper = new ResponseWrapper
                {
                    Message = "The email already exist.",
                    Results = userReg
                };
                return Ok(responseWrapper);
            }

            var user = _mapper.Map<User>(userReg);
           
            var registered = await _registerService.RegisterAsync(user, user.Address);
            bool emailSent = _mailService.SendEmail(user.EmailAddress, user.Id);
            if (!emailSent)
            {
                responseWrapper = new ResponseWrapper
                {
                    Message = "Registered Successfully but could not sent email",
                    Results = registered,
                    Success = true
                };
                return Ok(responseWrapper);
            }

            responseWrapper = new ResponseWrapper
            {
                Message = "Registered Successfully and sent email",
                Results = registered,
                Success = true
            };

            return Ok(responseWrapper);
        }

        /// <summary>
        /// Post: UserManagement/Login
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto login)
        {
            var responseWrapper = new ResponseWrapper();
            
            if (!ModelState.IsValid)
            {
                responseWrapper = new ResponseWrapper
                {
                    Message = "Email address or password is incorrect.",
                    Results = login
                };
                return Ok(responseWrapper);
            }

            if (!_registerService.CheckExistingEmail(login.EmailAddress))
            {
                responseWrapper = new ResponseWrapper
                {
                    Message = "Email address or password is incorrect.",
                    Results = login
                };
                return Ok(responseWrapper);
            }

            var results = await _loginService.LoginAsync(login.EmailAddress, login.Password);
            if (results.Id == 0)
            {
                responseWrapper = new ResponseWrapper
                {
                    Message = "Email address or password is incorrect.",
                    Results = login
                };
                return Ok(responseWrapper);
            }

            if (!results.Active) 
            { 
                responseWrapper = new ResponseWrapper
                {
                    Message = "This account is not active.",
                    Results = login
                };
                return Ok(responseWrapper);
            }

            responseWrapper.Message = "Successfully logged in";
            responseWrapper.Success = true;
            responseWrapper.Results = results;

            return Ok(responseWrapper);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="active"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult ActivateAccount([FromBody] ActiveAccountDto active)
        {
            var responseWrapper = new ResponseWrapper();
            
            responseWrapper.Message = _account.VerifyOTP(active.UserId, active.OTP);
            if (responseWrapper.Message == "success")
            {
                responseWrapper.Success = _account.ActivateAcoount(active.UserId);
            }
            return Ok(responseWrapper);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="forgotPass"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult ForgotPassword([FromBody] ForgotPasswordDto forgotPass)
        {
            var responseWrapper = new ResponseWrapper();

            responseWrapper.Message = _account.ForgotPassword(forgotPass.EmailAddress);

            var userId = _account.UserDetails(forgotPass.EmailAddress);
            if(userId != 0)
            {
                responseWrapper = new ResponseWrapper
                {
                    Results = userId,
                    Success = true
                };
            }
            return Ok(responseWrapper);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="active"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult VerifyOTP([FromBody] ActiveAccountDto active)
        {
            var responseWrapper = new ResponseWrapper();

            responseWrapper.Message = _account.VerifyOTP(active.UserId, active.OTP);
            if (responseWrapper.Message == "success")
            {
                responseWrapper.Success = true;
            }

            return Ok(responseWrapper);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="updatePassword"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult UpdatePassword([FromBody] UpdatePasswordDto updatePassword)
        {
            var responseWrapper = new ResponseWrapper();

            if (!ModelState.IsValid)
            {
                responseWrapper.Message = "Make sure your fields are valid and requirement are met";
                return Ok(responseWrapper);
            }

            responseWrapper.Success = _account.UpdatePassword(updatePassword.UserId, updatePassword.Password);

            return Ok(responseWrapper);
        }
    } 
}