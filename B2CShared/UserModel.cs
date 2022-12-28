namespace Shared
{
    public class UserModel
    {
        #region RegistrationInfo
        public string Name { get; set; }
        public string Email { get; set; }
        public string JobTitle { get; set; }
        public string Organization { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        #endregion

        #region AccountType
        public bool IsPartner { get; set; }

        /// <summary>
        /// string format:
        /// $"{JobTitle}, {Organization}"
        /// </summary>
        public string TopDivision { get; set; }

        /// <summary>
        /// NICE: "all active for now"
        /// Default = true
        /// </summary>
        public bool IsActive { get; set; }
        #endregion
    }
}
