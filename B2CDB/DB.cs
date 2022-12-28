using Shared;
namespace B2CDB
{
    public class DB : IB2CDB
    {
        #region Members
        

        private readonly IWhiteListDB _whiteListDB;
        private readonly IBlackListDB _blackListDB;

        private readonly IUserDB _usersDB;

        #endregion

        public DB(IBlackListDB blackListDB, IWhiteListDB whiteListDB, IUserDB userDB)
        {
            _whiteListDB = whiteListDB;
            _blackListDB = blackListDB;
            _usersDB = userDB;
        }


        public ISet<string> GetWhiteList()
        {
            return _whiteListDB.GetWhiteList();
        }
        public ISet<string> GetBlackList()
        {
            return _blackListDB.GetBlackList();
        }

        public List<string> AddToWhiteList(string emailDomains)
        {            
            var splitted = emailDomains.Split(',');
            return splitted.Where(domain => AddOneToWhiteList(domain) == false).ToList();
        }

        public List<string> AddToBlackList(string emailDomains)
        {
            var splitted = emailDomains.Split(',');
            return splitted.Where(domain => AddOneToBlackList(domain) == false).ToList();
        }



        public bool ValidateUser(UserModel user)
        {

            var userMailDomain = Utils.ParsEmailDomain(user.Email);
            if (userMailDomain == null) 
                return false;

            var isWhitelisted = _whiteListDB.IsWhiteListed(userMailDomain);
            var isBlacklisted = _blackListDB.IsBlackListed(userMailDomain);

            //Should be?
            return isWhitelisted && !isBlacklisted;
                
        }

        public IEnumerable<UserModel> GetAllUsers()
        {
            return _usersDB.GetAllUsers();
        }

        public UserModel? GetUser(string email)
        {
            return _usersDB.GetUser(email.ToLower());
        }

        public UserModel? CreateUser(UserModel user)
        {
            return _usersDB.CreateUser(user);

        }

        public UserModel? UpdateUser(UserModel user)
        {
            return _usersDB.UpdateUser(user);
        }

        private bool AddOneToWhiteList(string domain)
        {
            try
            {

                return _whiteListDB.AddToWhiteList(domain);
            }
            catch
            {
                return false;
            }
        }

        private bool AddOneToBlackList(string domain)
        {
            try
            {
                return _blackListDB.AddToBlackList(domain);
            }
            catch
            {
                return false;
            }
        }
    }
}
