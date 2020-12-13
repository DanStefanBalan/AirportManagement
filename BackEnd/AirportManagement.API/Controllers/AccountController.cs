using System.Linq;
using AirportManagement.API.Models;
using AirportManagement.Data;
using AirportManagement.Service.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AirportManagement.API.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public AccountController(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult CreateAccount([FromBody] AccountModel accountModel)
        {

            var duplicateAccount = _accountService.Find(a => a.UserName == accountModel.UserName && a.Email == accountModel.Email);
            if (duplicateAccount.Any())
            {
                return BadRequest("Duplicate user");
            }
            else
            {
                var newAccount = Account.Create(accountModel.UserName, accountModel.Password, accountModel.Email);
                _accountService.Add(newAccount);
                return Ok("Account created");
            }

        }

    }
}
