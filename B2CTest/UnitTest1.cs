
//namespace B2CTest
//{
//    public class UnitTest1
//    {
//        [Fact]
//        public void UserIsWhiteAndBlackShouldFail()
//        {
//            var db = new DB();
//            db.CreateUser(new UserModel { Email = "a123@google.com" });
//            db.CreateUser(new UserModel { Email = "b333@google.com" });
//            db.CreateUser(new UserModel { Email = "c555@walla.co.il" });

//            db.AddToBlackList("walla.co.il,google.com");
//            db.AddToWhiteList("google.com");

//            var isValid = db.ValidateUser(new UserModel { Email = "b333@google.com" });
//            Assert.False(isValid);
//        }
//        [Fact]
//        public void UserAllreadyExistShouldFailtoLogIn()
//        {
//            //var db = new DB();
//            db.CreateUser(new UserModel { Email = "a123@google.com" });
//            var addingExisting = db.CreateUser(new UserModel { Email = "a123@google.com" });
//            Assert.Null(addingExisting);
//        }

//    }
//}