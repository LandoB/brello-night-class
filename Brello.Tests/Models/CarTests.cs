using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Brello.Models;
using Moq;

namespace Brello.Tests.Models
{
    [TestClass]
    public class CarTests
    {
        [TestMethod]
        public void CarEnsureICanCreateInstance()
        {
            Car myCar = new Car();
            Assert.IsNotNull(myCar);
        }

        [TestMethod]
        public void CarEnsureMyCarCanHonk()
        {
            Car myCar = new Car();
            Assert.AreEqual("HONK!", myCar.Horn());
        }

        [TestMethod]
        public void CarEnsureICanMockMyCarHorn()
        {
            Mock<Car> mock_car = new Mock<Car>();
            mock_car.Setup(x => x.Horn()).Returns("BEEP!");
            Assert.AreEqual("BEEP!",mock_car.Object.Horn());
        }

        [TestMethod]
        public void CarEnsureICanMockInterface()
        {
            Mock<ICar> mock_car = new Mock<ICar>();
            // This is invalid: car myVar - new ICar();
            // However you can create a Mock class that can recreate the behavior of an Interface.
            // We inject the behavior we want the Interface to have:
            mock_car.Setup(x => x.Honk()).Returns("BEEP!");
            Assert.AreEqual("BEEP!", mock_car.Object.Honk());
            mock_car.Verify(x => x.Honk(), Times.Once);
        }


        //[TestMethod]
        //public void CarEnsureReadyEngineIsCalled()
        //{
        //    Mock<Car> mock_car = new Mock<Car>();
        //    mock_car.Setup(x => x.ReadyEngines());
        //    mock_car.Object.Horn();
        //    //mock_car.Setup(x => x.Horn()).Returns("BEEP!");
        //    //Assert.AreEqual("BEEP!", mock_car.Object.Horn());
        //    mock_car.Verify(x => x.ReadyEngines(), Times.Once);
        //}
    }
}
