using System.Security.Claims;
using ASPnetWebApp.Database;
using ASPnetWebApp.Enums;
using ASPnetWebApp.Models;
using ASPnetWebApp.Objects;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPnetWebApp.Controllers;

/// <summary>
/// Controller for users Authentication
///
/// It can take user's data from http post-request and check it and
/// process authentication. Also it can end users session.
/// 
/// It's using cookies for saving information about
/// user's identity and also can show it by using special rout.
/// </summary>
public class AuthController : Controller
{
    #region private

    private ApplicationContext db;

    /// <summary>
    /// Cookies baker
    /// </summary>
    /// <param name="login">User's login</param>
    /// <param name="role">User's role</param>
    private async Task SetCookies(string login, RoleType role)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimsIdentity.DefaultNameClaimType, login),
            new Claim(ClaimsIdentity.DefaultRoleClaimType, role.ToString())
        };

        ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
            ClaimsIdentity.DefaultRoleClaimType);
        await AuthenticationHttpContextExtensions.SignInAsync(HttpContext, new ClaimsPrincipal(id));
    }

    /// <summary>
    /// Cookies remover
    /// </summary>
    private async Task RemoveCookies()
    {
        await AuthenticationHttpContextExtensions.SignOutAsync(HttpContext);
    }

    #endregion

    public AuthController(ApplicationContext context)
    {
        db = context;
    }
    
    /// <summary>
    /// Api-route for user's registration process 
    /// </summary>
    /// <param name="input">Registration data</param>
    /// <returns>RegInfo object with user's registartion information</returns>
    [HttpPost]
    [Route("api/auth/reg")]
    public async Task<AuthInfo> Registration([FromBody] AuthInput input)
    {
        var loginUppercase = input.login.ToUpper();
        var passwordHasher = new PasswordHasher<string>();
        var hashedPassword = passwordHasher.HashPassword(loginUppercase, input.password);

        var newUser = new User
        {
            LoginName = input.login, LoginNameUppercase = loginUppercase, PasswordHash = hashedPassword,
            Role = RoleType.User.ToString()
        };

        await db.Users.AddAsync(newUser);

        try
        {
            await db.SaveChangesAsync();
        }
        catch (DbUpdateException e)
        {
            return AuthInfo.Fail(e.Message);
        }
        
        await SetCookies(loginUppercase, RoleType.User);
        return AuthInfo.Success(loginUppercase, RoleType.User);
    }

    /// <summary>
    /// Api-route for user's authentication process 
    /// </summary>
    /// <param name="input">Login data</param>
    /// <returns>AuthInfo object with user's login information</returns>
    [HttpPost]
    [Route("api/auth/login")]
    public async Task<AuthInfo> Login([FromBody] AuthInput input)
    {
        var loginUppercase = input.login.ToUpper();
        var passwordHasher = new PasswordHasher<string>();
        var users = db.Users.Where(p => p.LoginNameUppercase == loginUppercase);
        User user;
        try
        {
            user = users.First();
        }catch(InvalidOperationException e)
        {
            return AuthInfo.Fail("Incorrect login or password");
        }
        
        var hashedPassword = user.PasswordHash;

        var result = passwordHasher.VerifyHashedPassword(loginUppercase, hashedPassword, input.password);
        

        if (result.Equals(PasswordVerificationResult.Success))
        {
            await SetCookies(loginUppercase, Role.FromString(user.Role));
            return AuthInfo.Success(loginUppercase, Role.FromString(user.Role));
        }

        return AuthInfo.Fail("Incorrect login or password");
    }

    /// <summary>
    /// Api-route for user's logout process 
    /// </summary>
    /// <returns>AuthInfo object with user's login information</returns>
    [HttpGet]
    [Route("api/auth/logout")]
    public async Task<AuthInfo> Logout()
    {
        await RemoveCookies();
        return GetInfo();
    }

    /// <summary>
    /// Api-route for getting user's login information  
    /// </summary>
    /// <returns>AuthInfo object with user's login information</returns>
    [HttpGet]
    [Route("api/auth/getInfo")]
    public AuthInfo GetInfo()
    {
        if (User?.Identity?.IsAuthenticated ?? false)
        {
            var role = User.FindFirstValue(ClaimsIdentity.DefaultRoleClaimType);
            RoleType roleType = Role.FromString(role);
            var loginName = User.FindFirstValue(ClaimsIdentity.DefaultNameClaimType);
            return AuthInfo.Success(loginName, roleType);
        }

        return AuthInfo.Fail("");
    }
}