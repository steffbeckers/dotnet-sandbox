using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sandbox.Testing
{
    [TestClass]
    public class DateTimeTests
    {
        [TestMethod]
        public void FormatDateTime1()
        {
            Console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy"));
        }
    }
}
