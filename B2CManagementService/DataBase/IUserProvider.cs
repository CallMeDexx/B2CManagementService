namespace B2CManagementService.DataBase
{
    public interface IUserProvider
    {
        Task<IEnumerable<UserModel>> Get();
    }
}