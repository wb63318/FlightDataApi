using FlightDataApi.Models;
using FlightDataApi.Repos;
using Microsoft.AspNetCore.Mvc;

namespace FlightDataApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly ITokenHandler tokenHandler;

        public AuthController(IUserRepository userRepository,ITokenHandler tokenHandler)
        {
            this.userRepository = userRepository;
            this.tokenHandler = tokenHandler;
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync(LoginRequest loginRequest)
        {
            //Validate the incoming request
            if (!ValidateLoginAsync(loginRequest))
            {
                return BadRequest(ModelState);
            }
            //check if User is Authenticated 


            //check email and password
            var user = await userRepository.AuthenticateAsync(loginRequest.Username, loginRequest.Password);

            if (user != null)
            {
                //generate a JWT Token
                var token = await tokenHandler.CreateTokenAsync(user);
                return Ok(token);
            }
            return BadRequest("Email or Password is incorrect. ");
        }

        #region Private methods
        private bool ValidateLoginAsync(LoginRequest loginRequest)
        {
            if (loginRequest == null)
            {
                ModelState.AddModelError(nameof(loginRequest), $"Enter login details.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(loginRequest.Username))
            {
                ModelState.AddModelError(nameof(loginRequest.Username), $"{nameof(loginRequest.Username)} Cannot be empty or null");

            }
            if (string.IsNullOrWhiteSpace(loginRequest.Password))
            {
                ModelState.AddModelError(nameof(loginRequest.Password
                    ), $"{nameof(loginRequest.Password)} Cannot be empty or null");

            }

            if (ModelState.ErrorCount > 0)
            {
                return false;
            }
            return true;
        }
        #endregion
    }
}
