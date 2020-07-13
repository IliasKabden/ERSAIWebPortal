using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataModels;
using System.Data.Entity;
using System.Linq;

namespace DataModelsTest
{
    [TestClass]
    public class ContextTest
    {
        Context db = new Context(); 
        [TestMethod]
        public void TestMethod1()
        {
            var a = db.Accounts.Take(15).ToList();
        }
    }
}