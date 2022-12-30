using System.Security.Claims;
using ASPnetWebApp.Database;
using ASPnetWebApp.Models;
using ASPnetWebApp.Objects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPnetWebApp.Controllers;

/// <summary>
/// Controller for users Pairs
/// </summary>
public class PairController : Controller
{
    #region private
    
    private User? GetUser(string? loginName)
    {
        if(string.IsNullOrEmpty(loginName))
        {
            if (!(User?.Identity?.IsAuthenticated ?? false)) return null;

            loginName = User.FindFirstValue(ClaimsIdentity.DefaultNameClaimType).ToUpper();
        }    
        var users = db.Users.Where(p => p.LoginNameUppercase == loginName).Include(u => u.PairRecords);
        User user;
        try
        {
            user = users.First();
        }catch(InvalidOperationException e)
        {
            return null;
        }

        return user;

    }
    
    private ApplicationContext db;

    #endregion

    public PairController(ApplicationContext context)
    {
        db = context;
    }
    
    [HttpGet]
    [Route("api/pairs")]
    public async Task<PairsInfo> GetUserProfile()
    {
        var user = GetUser(string.Empty);

        if(user == null) return PairsInfo.Fail("No such a user");

        return PairsInfo.Success(user.PairRecords, db);
    }
    
    [HttpGet]
    [Route("api/pairs/random")]
    public async Task<PairsInfo> Random()
    {
        var user = GetUser(string.Empty);

        var users = db.Users.ToList();

        if(user == null) return PairsInfo.Fail("No such a user");
        
        foreach (var u in users)
        {
            db.PairRecords.Add(new PairRecord
                {UserId = user.Id, PairedUserId = u.Id, Rating = 9.9f, RatingDescription = "yeeees", Type = "123"});
        }
        
        try
        {
            await db.SaveChangesAsync();
        }
        catch (DbUpdateException e)
        {
            return PairsInfo.Fail(e.Message);
        }
        
        return PairsInfo.Success(user.PairRecords, db);
    }
    
    
    
}