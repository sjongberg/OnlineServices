using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceServices.BusinessLayer.Tests
{
    [TestClass]
    public class AssistantRole_SendPresenceRapport
    {
        [TestMethod]
        public void Send_Throw_EndDateIsEarlierThanStartDate()
        {
            var sut = new AssistantRole();

            var returnValue = sut.SendPresenceRapport(Email: "test@gmail.com", StartDate: DateTime.Now, EndDate: DateTime.Now.AddDays(-5));

            Assert.IsTrue(returnValue);

        }
    }
}
