using Xunit;
using LibraryConsole_IE;
using Common;

namespace Testing
{
    public class UnitTest1
    {
        [Fact]
        public void TestConsole()
        {
            var console = new ConsoleApp();
            console.StartConsole(-1);

            //tests



        }

        [Fact]
        public void TestCRUD()
        {
            var crud = new CRUD();
            var readLength = crud.ReadLength();

            //test that database array initialized with 3 entries.
            Assert.Equal(3, readLength);

            //test update & read by username
            crud.Update("rsmith", "name", "ray");
            var user = crud.ReadUsername("rsmith");
            Assert.True(user.Name == "ray");

            //test read by id
            var user2 = crud.Read(2);
            Assert.True(user2.Name == "ray");

            //delete a user and check that user list length is 1 shorter.
            crud.Delete("rsmith");
            var readLength2 = crud.ReadLength();
            Assert.Equal(2, readLength2);
        }
        [Fact]
        public void TestCRUD2()
        {
            //test create
            var crud = new CRUD();
            crud.Create(4, "jim", new Database.RoleDTO { RoleId = 2, RoleName = "admin" }, "jimster", "pass123");
            var readLength = crud.ReadLength();
            Assert.Equal(4, readLength);

            //verify accuracy of create
            var user = crud.ReadUsername("jimster");
            Assert.True(user.Name == "jim" && user.Username == "jimster" && user.Password == "pass123");
        }
        [Fact]
        public void TestCommon()
        {
            var com = new CommonLibrary();

            //verify sha256 password hash
            var pass = com.Hash("pass123");
            Assert.True(pass == "1df665af68e057171a7077a17309569bd74311df28c3259dcfc6f9a5a45d9e09");

            //verify admin check, using ID 1, an admin user
            bool ad = com.adminCheck(1);
            Assert.True(ad == true);
        }

    }
}