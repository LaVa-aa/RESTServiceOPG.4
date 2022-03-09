using CarTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RESTService.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;


namespace RESTService.Managers.Tests
{

    [TestClass()]
    public class CarsManagerTests
    {
        private CarsManager _carsManager;
        

        [TestInitialize]
        public void Setup()
        {
            _carsManager = new CarsManager();
        }

        //[TestInitialize]
        //public void SetUp()
        //{
        //    carsManager = new CarsManager(2, "firee", 45678, "wkwo2");
        //}
        [TestMethod()]
        public void GetAllCarsTest()
        {
            List<Car> cars = _carsManager.GetAll(999999);
            foreach (Car c in cars)
            {
                Assert.IsTrue(c.Price <= 999999);
            }
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            //checking the first Car
            Assert.IsTrue(_carsManager.GetById(1).Model.Equals("DONKERVOORT X1"));
            //checking an ID that shouldn't exist
            Assert.IsNull(_carsManager.GetById(55));
        }

        [TestMethod()]
        public void AddCarTest()
        {
           
            int beforeAddCount = _carsManager.GetAll(999999).Count;
            int defaultId = 0;

            Car newCar = new Car(defaultId, "TestCar", 3456, "OL56806");
            Car addResult = _carsManager.AddCar(newCar);
            int newId = addResult.Id;



            Assert.AreNotEqual(defaultId,newId);
            Assert.AreEqual(beforeAddCount+1,_carsManager.GetAll(999999).Count);

            
        }

        [TestMethod()]
        public void DeleteCarTest()
        {
            int beforeAddCount = _carsManager.GetAll(999999).Count;
            int defaultId = 0;

            Car newCar = new Car(defaultId, "TestCar", 3456, "OL56806");
            Car addResult = _carsManager.AddCar(newCar);
            int newId = addResult.Id;

            

            Car remove = _carsManager.DeleteCar(newId);

            Assert.AreEqual(beforeAddCount, _carsManager.GetAll(999999).Count);
            Assert.IsNull((_carsManager.DeleteCar(66)));
        }
    }
}