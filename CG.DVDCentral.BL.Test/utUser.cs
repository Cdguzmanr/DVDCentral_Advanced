using CG.DVDCentral.BL.Models;

namespace CG.DVDCentral.BL.Test
{
    [TestClass]
    public class utUser
    {
        [TestMethod]
        public void LoginSucessfullTest()
        {
            Seed();
            Assert.IsTrue(UserManager.Login(new User {UserName="bfoote", Password="maple" }) );
            Assert.IsTrue(UserManager.Login(new User { UserName = "kfrog", Password = "misspiggy" }));
        }

        public void Seed()
        {
            UserManager.Seed();
        }


        [TestMethod]
        public void InsertTest()
        {
           
        }

        [TestMethod]
        public void LoginFailureNoUserName()
        {
            try
            {
                Seed();
                Assert.IsTrue(UserManager.Login(new User { UserName= "", Password="maple" }));
            }
            catch (LoginFailureException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);               
            }

        }

        [TestMethod]
        public void LoginFailureBadPassword()
        {
            try
            {
                Seed();
                Assert.IsTrue(UserManager.Login(new User { UserName = "bfoote", Password = "wrong" }));
            }
            catch (LoginFailureException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void LoginFailureBadUSerId()
        {
            try
            {
                Seed();
                Assert.IsTrue(UserManager.Login(new User { UserName = "wrong", Password = "maple" }));
            }
            catch (LoginFailureException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void LoginFailureNoPassword()
        {
            try
            {
                Seed();
                Assert.IsTrue(UserManager.Login(new User { UserName = "bfoote", Password = "" }));
            }
            catch (LoginFailureException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }
    }
}
