using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace LogManager.Tests
{
    [TestClass()]
    public class ProgramTests
    {


        [TestMethod()]
        public void LogokSzureseUresTest(List<string> szuresek)
        {
            var elvart = new List<Szurve>();
            var aktualis = Program.LogokSzurese([], [""]);
            Assert.AreEqual(elvart.Count, aktualis.Count);
        }

    }
}