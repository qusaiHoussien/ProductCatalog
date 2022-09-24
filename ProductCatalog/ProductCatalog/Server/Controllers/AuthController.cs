using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProductCatalog.Server.IRepository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
namespace ProductCatalog.Server.Controllers
{
    [Route("api/[controller]")]
    public class AuthController: Microsoft.AspNetCore.Mvc.Controller
    {
        public IAuthRepository _authRepository { get; set; }

        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserForRegister user)
        {
         if(!ModelState.IsValid)
            return BadRequest(ModelState);

            user.UserName=user.UserName.ToLower();
            if(await _authRepository.UserExists(user.UserName))
            return BadRequest("user name is already taken");

            var userToCreate=new User{
                UserName=user.UserName
            };

            var createUser=await _authRepository.Register(userToCreate,user.Password);

            return StatusCode(201);

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserForRegister user)
        {
            if(!ModelState.IsValid)
            return BadRequest(ModelState);
            
            var userFromRepo=await _authRepository.Login(user.UserName.ToLower(),user.Password);

            if(userFromRepo==null)
            return Unauthorized();

            //generate token
            var tokenHandler=new JwtSecurityTokenHandler();
            var key= System.Text.Encoding.ASCII.GetBytes("qusaiHoussien secret key");
            var tokenDescriptor=new SecurityTokenDescriptor
            {
                Subject=new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier,userFromRepo.Id.ToString()),
                    new Claim(ClaimTypes.Name,userFromRepo.UserName),
                    new Claim(ClaimTypes.Role,"Admin")
                    
                }),

                Expires=DateTime.Now.AddDays(3),
                SigningCredentials=new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha512Signature)
            };

            var token=tokenHandler.CreateToken(tokenDescriptor);
            var tokenString=tokenHandler.WriteToken(token);

            return Ok(new{tokenString});
        }
    }
}