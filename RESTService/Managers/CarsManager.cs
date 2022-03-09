using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CarTest;

namespace RESTService.Managers
{
    public class CarsManager
    {
        //Keeps track of ids, in order for all Cars to have a unique ID
        public static int nextId = 1;
        private static readonly List<Car> data = new List<Car>
        {
            new Car{Id = nextId++, Model = "DONKERVOORT X1", Price = 900, LicensePlate = "OL17080"},
            new Car{Id = nextId++, Model = "ACURA X2", Price = 8754, LicensePlate = "OL21233"},
            new Car{Id = nextId++, Model = "Skoda X3", Price = 1111, LicensePlate = "OL22454"},
            new Car{Id = nextId++, Model = "AUdI X4", Price = 6800, LicensePlate = "OL30286"},
            new Car{Id = nextId++, Model = "AUDI X5", Price = 1954, LicensePlate = "OL32588"},
            new Car{Id = nextId++, Model = "MAYBACH X6", Price = 900, LicensePlate = "OL34567"},
            new Car{Id = nextId++, Model = "TASLA X7", Price = 1000, LicensePlate = "OL95609"},
            new Car{Id = nextId++, Model = "Volkswagen X8", Price = 1990, LicensePlate = "OL57595"},
            new Car{Id = nextId++, Model = "Audi X9", Price = 999999, LicensePlate = "OL57648"},
            new Car{Id = nextId++, Model = "Volkswagen X10", Price = 40, LicensePlate = "OL52143"},
            new Car{Id = nextId++, Model = "Volkswagen X11", Price = 550, LicensePlate = "OL52003"}
        };

        public List<Car> GetAll( int? maximumPrice)
        {
            List<Car> result = new List<Car>(data);
            if (maximumPrice != 0)
            {
                result = result.FindAll(car => car.Price <= maximumPrice);
            }

            return result;
        }

        //Returns a specific Car from the list
        //return null if the id is not found
        public Car GetById(int id)
        {
            return data.Find(car => car.Id == id);
        }
        //Adds a new Car to the list, and assigns it the next id
        //returns the newly added Car
        public Car AddCar(Car newCar)
        {
            newCar.Id = nextId++;
            data.Add(newCar);
            return newCar;
        }
        //Deletes the Car from the list with the specific Id
        //Returns null of no Item has the Id
        public Car DeleteCar(int id)
        {
            Car car = data.Find(car1 => car1.Id == id);
            if (car == null) return null;
            data.Remove(car);
            return car;
        }


    }
}
