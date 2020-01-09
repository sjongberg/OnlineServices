using AttendanceServices.BusinessLayer.UseCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace AttendanceServices.BusinessLayer.Tests
{
    [TestClass]
    public class AttendeeBL_Tests
    {
        [TestMethod]
        public void SetPresence_Throws_AttendeeNotInFormation()
        {
            var presenceRepositoryMOCK = new Mock<IPresenceRepository>();
            presenceRepositoryMOCK.Setup(homer => homer.Insert(It.IsAny<AttendeePresentEF>())).Returns(true);

            var userServicesMOCK = new Mock<IUserServicesTemp>();
            userServicesMOCK.Setup(marge => marge.GetFormationAttendes(It.IsAny<int>())).Returns(new List<int> { 1, 2, 3, 4 });

            var eleve = new AttendeeRole(presenceRepositoryMOCK.Object, userServicesMOCK.Object);

            Assert.ThrowsException<Exception>(() => eleve.SetPresence(9999999, 53));
        }

        [TestMethod]
        public void SetPresence_Throws_DataTimeNowNotInFormation()
        {
            var presenceRepositoryMOCK = new Mock<IPresenceRepository>();
            presenceRepositoryMOCK.Setup(homer => homer.Insert(It.IsAny<AttendeePresentEF>())).Returns(true);

            var userServicesMOCK = new Mock<IUserServicesTemp>();
            userServicesMOCK.Setup(marge => marge.GetFormationAttendes(It.IsAny<int>())).Returns(new List<int> { 1, 2, 3, 4 });
            userServicesMOCK.Setup(marge => marge.GetFormation(It.IsAny<int>())).Returns(new formationTemp { Id = 12, Jours = new List<DateTime> {DateTime.Now.AddDays(2) } });


            var eleve = new AttendeeRole(presenceRepositoryMOCK.Object, userServicesMOCK.Object);            

            Assert.ThrowsException<Exception>(() => eleve.SetPresence(9999999, 3));
        }


        [TestMethod]
        public void SetPresence_True_CorrectInputs()
        {
            var presenceRepositoryMOCK = new Mock<IPresenceRepository>();
            presenceRepositoryMOCK.Setup(homer => homer.Insert(It.IsAny<AttendeePresentEF>())).Returns(true);

            var userServicesMOCK = new Mock<IUserServicesTemp>();
            userServicesMOCK.Setup(marge => marge.GetFormationAttendes(It.IsAny<int>())).Returns(new List<int> {1,2,3,4});
            userServicesMOCK.Setup(marge => marge.GetFormation(It.IsAny<int>())).Returns(new formationTemp { Id = 12, Jours = new List<DateTime> { DateTime.Now } });


            var eleve = new AttendeeRole(presenceRepositoryMOCK.Object,userServicesMOCK.Object);
            var valueToAssert = eleve.SetPresence(2, 3);
            Assert.IsTrue(valueToAssert);
        }
    }
}
