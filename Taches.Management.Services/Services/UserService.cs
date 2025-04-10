
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using Taches.Management.DAL.Models;
using Taches.Management.Services.Interfaces;
using Taches.Management.Services.Models.DTO;
using AutoMapper;

namespace Taches.Management.Services.Services
{
    public class UserService(UserManager<ApplicationUser> userManager
        , RoleManager<IdentityRole> roleManager,
        IMapper _mapper
        ) : IUser
    {
        private readonly PasswordHasher<ApplicationUser> _passwordHasher = new PasswordHasher<ApplicationUser>();
        private const string JwtKey = "abderrazzakkhouyabderrazzakkhouyabderrazzakkhouyabderrazzakkhouyabderrazzakkhouy";

   
        public async Task<User?> authenticate(UserDto user)
        {
      
            var existingUser = await userManager.FindByNameAsync(user.Username);
            if (existingUser == null || _passwordHasher.VerifyHashedPassword(existingUser, existingUser.PasswordHash, user.PasswordHash) == PasswordVerificationResult.Failed)
            {
                return null;
            }
         
            existingUser.Tocken = await CreateJwtToken(existingUser);


            return _mapper.Map<User>(existingUser);
        }

        public async Task<User?> RegisterUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null.");
            }

            try
            {


                //
                user.Username = user.FirstName.Substring(0, 1).ToUpper() + user.LastName;
                user.PasswordHash = user.Username + "123@";

               
                var appUser = new ApplicationUser { UserName = user.Username , Email = user.Email, FirstName = user.FirstName, LastName = user.LastName, PhoneNumber = user.PhoneNumber };
                var result = await userManager.CreateAsync(appUser, user.PasswordHash);
                if (result.Succeeded)
                {
                    var userId = await userManager.GetUserIdAsync(appUser);

                    // Generate email confirmation token if necessary
                    var code = await userManager.GenerateEmailConfirmationTokenAsync(appUser);

                    // Optionally, send the confirmation email here
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = userId, code = code }, protocol: Request.Scheme);

                    return user;
                }

                // Return null or error details based on registration failure
                return null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public async Task<ICollection<User>> GetAllUsers()
        {
            var users = await userManager.Users.Select(us => _mapper.Map<User>(us) ).ToListAsync();
            return users;
        }
        public async Task<bool> CheckUserName(string username)
        {
            return await userManager.Users.AnyAsync(p => p.UserName == username);
        }

        public async Task<bool> CheckUserEmail(string email)
        {
            return await userManager.Users.AnyAsync(p => p.Email == email);
        }

        public string CheckPasswordString(string password)
        {
            StringBuilder strb = new StringBuilder();
            if (password.Length < 6)
                strb.Append("- Password length must be greater than 6\n");
            if (!(Regex.IsMatch(password, "[a-z]") && Regex.IsMatch(password, "[A-Z]") && Regex.IsMatch(password, "[0-9]")))
            {
                strb.Append("- Password must contain alphanumeric characters\n");
            }
            if (!Regex.IsMatch(password, "['/@#$%*!']"))
            {
                strb.Append("- Password must contain special characters\n");
            }
            return strb.ToString();
        }

        private async Task<string> CreateJwtToken(ApplicationUser user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(JwtKey);

            //var userPermissions = user.UserRoles.Select(ur => ur.Role).SelectMany(r => r.RolePermissions).Select(rp => rp.Permission);

            var roles = await userManager.GetRolesAsync(user);

            var claims = roles.Select(pr => new Claim(ClaimTypes.Role, pr)).ToList();

            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
           
            var identity = new ClaimsIdentity(
                claims     
            );

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddDays(10),
                SigningCredentials = credentials
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);

            return jwtTokenHandler.WriteToken(token);
        }


        public async Task<User> GetUserById(string id)
        {
            var user = await userManager.Users.FirstOrDefaultAsync(us =>  us.Id == id);
            return  _mapper.Map<User>(user);
        }

    }
}
