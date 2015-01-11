using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using @as.Data.Models;

namespace @as.Data.Test
{
    [TestClass]
    public class RepostoryTest
    {
        [TestMethod]
        public void InitalizeTest()
        {
            Repostory<Log> log = new Repostory<Log>();
        }
    }
}
