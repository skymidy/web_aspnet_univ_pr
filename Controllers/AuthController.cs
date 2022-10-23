using System.Security.Claims;
using ASPnetWebApp.Enums;
using ASPnetWebApp.Objects;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace ASPnetWebApp.Controllers;

/// <summary>
/// Controller for users Authentication
///
/// It can take user's data from http post-request and check it and
/// process authentication. Also it can end users session.
/// 
/// It's using cookies for saving information about
/// user's identity and also can show it by using special rout.
///
/// Now it's just mocking database using if-clause!!! 
/// </summary>
public class AuthController : Controller
{
    /// <summary>
    /// Api-route for user's authentication process 
    /// </summary>
    /// <param name="input">Login data</param>
    /// <returns>AuthInfo object with user's login information</returns>
    [HttpPost]
    [Route("auth/login")]
    public async Task<AuthInfo> Login(AuthInput input)
    {
        if (input.Login == "test" && input.Password == "admin")
        {
            await SetCookies(input.Login, RoleType.Admin);
            return AuthInfo.Success(RoleType.Admin);
        }

        return AuthInfo.Fail();
    }

    /// <summary>
    /// Api-route for user's logout process 
    /// </summary>
    /// <returns>AuthInfo object with user's login information</returns>
    [HttpGet]
    [Route("auth/logout")]
    public async Task<AuthInfo> Loguut()
    {
        await RemoveCookies();
        return GetInfo();
    }

    /// <summary>
    /// Api-route for getting user's login information  
    /// </summary>
    /// <returns>AuthInfo object with user's login information</returns>
    [HttpGet]
    [Route("auth/getInfo")]
    public AuthInfo GetInfo()
    {
        if (User?.Identity?.IsAuthenticated ?? false)
        {
            var role = User.FindFirstValue(ClaimsIdentity.DefaultRoleClaimType);
            RoleType roleType = Role.FromString(role);
            return AuthInfo.Success(roleType);
        }

        return AuthInfo.Fail();
    }

    #region private
    
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
            new Claim(ClaimsIdentity.DefaultNameClaimType, role.ToString())
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
}