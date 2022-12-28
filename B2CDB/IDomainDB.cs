
namespace B2CDB
{
    public interface IDomainDB
    {
        
        
        
    }

    public interface IBlackListDB : IDomainDB
    {
        bool IsBlackListed(string userEmail);
        ISet<string> GetBlackList();
        bool AddToBlackList(string domain);
    }
    public interface IWhiteListDB : IDomainDB
    {
        bool IsWhiteListed(string userEmail);
        ISet<string> GetWhiteList();
        bool AddToWhiteList(string domain);
    }
}
