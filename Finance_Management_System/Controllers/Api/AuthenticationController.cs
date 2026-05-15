using AutoMapper;
using Finance_Management_System.Helpers;
using Finance_Management_System.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Finance_Management_System.Controllers.Api
{
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
      private static  AuthenticationHelpers _authenticationHelpers;
        private readonly FinanceDbContext _context;
        private readonly IMapper _mapper;
        AuthenticationController(AuthenticationHelpers authenticationHelpers, FinanceDbContext context, IMapper mapper)
        {
            _authenticationHelpers = authenticationHelpers;
            _context = context;
            _mapper = mapper;
        }   
        public class UserDTO
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        [HttpGet]
        [Route("User")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _context.Users.ToListAsync();

            var result = _mapper.Map<List<UserDTO>>(users);

            return Ok(result);
        }
    }
}
