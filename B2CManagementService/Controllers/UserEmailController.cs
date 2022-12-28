using Microsoft.AspNetCore.Mvc;

namespace B2CManagementService.Controllers
{
    public class DomainList
    {
        public string CSV { get; set; }
        //public string l2 { get; set; }
        //public string l3 { get; set; }
        //public string l4 { get; set; }
        //public string l5 { get; set; }
    }



    [Route("api/[controller]")]
    [ApiController]
    public class UserEmailController : ControllerBase
    {
        private readonly IB2CDB _db;
        public UserEmailController(IB2CDB db)
        {
            _db = db;
        }


        #region WhiteList
        [HttpGet("/whitelist")]
        public ISet<string> GetWhightList()
        {
            return _db.GetWhiteList();
        }

        [HttpPost("/addToWhiteList")]
        public List<string> AddToWhiteList([FromBody] DomainList domains)
        {
            try
            {
                var failedList = _db.AddToWhiteList(domains.CSV);
                if (failedList.Count == 0)
                    return new List<string> { "All added OK!" };

                var res = new List<string> { "Failed adding the flowing domains: " };
                res.AddRange(failedList);
                return res;
            }
            catch (Exception e)
            {
                return new List<string> { e.ToString() };
            }
        }


        [HttpDelete("removeFromWhiteList/{email}")]
        public string DeleteEmailFromWhiteList(string email)
        {
            return $"Removing email: '{email}'";
        }
        #endregion

        #region BlackList
        [HttpGet("/blaklist")]
        public ISet<string> GetBlackList()
        {
            return _db.GetBlackList();
        }

        [HttpPost("/addToBlackList")]
        public List<string> AddToBlackList([FromBody] DomainList domains)
        {
            try
            {
                var failedList = _db.AddToBlackList(domains.CSV);
                if (failedList.Count == 0)
                    return new List<string> { "All added OK!" };

                var res = new List<string> { "Failed adding the flowing domains: " };
                res.AddRange(failedList);
                return res;
            }
            catch (Exception e)
            {
                return new List<string> { e.ToString() };
            }
        }

        [HttpDelete("removeFromBlackList/{email}")]
        public string DeleteEmailFromBlackList(string email)
        {
            return $"Removing email: '{email}'";
        }
        #endregion
    }
}
