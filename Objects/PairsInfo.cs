using ASPnetWebApp.Database;
using ASPnetWebApp.Models;

namespace ASPnetWebApp.Objects;

public class PairsInfo
{
    public List<PairInfo> List { get; set; } = new();
    
    public string ErrorMessage { get; private set; } = string.Empty;
    
    public static PairsInfo Success(List<PairRecord> list, ApplicationContext db)
    {
        List<PairInfo> newList = new();
        foreach (var record in list)
        {
            newList.Add(PairInfo.FromModelTPairInfo(record, db));
        }
        
        return new PairsInfo
        {
            List = newList
        };
    }

    public static PairsInfo Fail(string errorMessage)
    {
        return new PairsInfo
        {
            ErrorMessage = errorMessage
        };
    }
}