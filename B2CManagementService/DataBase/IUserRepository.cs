namespace B2CManagementService.DataBase
{
    public interface IUserRepository
    {
        Task Create(UserModel userModel);
    }
}