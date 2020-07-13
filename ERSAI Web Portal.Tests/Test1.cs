using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using DataModels;

namespace ERSAI_Web_Portal.Tests
{
    [TestClass]
    public class Test1
    {
        ERSAIContext db = new ERSAIContext();
        IMSContext db2 = new IMSContext();
        PayslipContext db3 = new PayslipContext();

        [TestMethod]
        public void TestMethod1()
        {
            foreach (var user in db.PersonalAccountUsers)
            {
                if (user.AppUser == null)
                    db.Users.Add(new AppUser()
                    {
                        Id = user.Badge,
                        UserName = user.Badge,
                        SecurityStamp = Guid.NewGuid().ToString()
                    });
            }
            db.SaveChanges();
        }
        [TestMethod]
        public void TestMethod2()
        {
            var a = db2.Employees.ToList();
            var b = db2.Banks.ToList();
            var c = db2.EmployeesContractAmendments.ToList();
        }
    }
}