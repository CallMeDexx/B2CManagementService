
namespace Shared
{
    public interface IB2CDB
    {
        ISet<string> GetWhiteList();
        ISet<string> GetBlackList();
        List<string> AddToWhiteList(string emailDomain);
        List<string> AddToBlackList(string emailDomain);
        bool ValidateUser(UserModel user);
        IEnumerable<UserModel> GetAllUsers();
        UserModel? GetUser(string email);
        UserModel? CreateUser(UserModel user);
        UserModel? UpdateUser(UserModel user);
    }
}