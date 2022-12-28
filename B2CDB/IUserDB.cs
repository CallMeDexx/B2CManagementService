using Shared;

namespace B2CDB
{
    public interface IUserDB
    {
        bool ValidateUser(UserModel user);
        IEnumerable<UserModel> GetAllUsers();
        UserModel? GetUser(string email);
        UserModel? CreateUser(UserModel user);
        UserModel? UpdateUser(UserModel user);
    }
}