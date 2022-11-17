using TestAPIs.CustomerDb.Interfaces;
using TestAPIs.Tests.Fakes;

namespace TestAPIs.Tests
{
    [TestClass]
    public class CustomerContextFake
    {
        [TestMethod]
        public void Can_I_Create_an_InMemory_DB_For_Tests_And_Save_a_Record()
        {
            //Setup
            ICustomerContext context;

            //Test
            try
            {
                var result = ConnectionFactory.CreateContextForSQLite();
                if (result == null)
                {
                    Assert.Fail("context returned as null");
                    return;
                }
                else
                {
                    context = result;
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(string.Format("Exception creating in memory database for tests: {0}", ex.ToString()));
                return;
            }

            context.Customers.Add(new Domain.Customer { ID = 1, FirstName = "TestFirst", LastName = "TestLast" });
            context.SaveChanges();

            //Further Asserts
            Assert.IsTrue(context.Customers.Count() == 1, "Unexpected number of customers in memory DB");
        }
    }
}