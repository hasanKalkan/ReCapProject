using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car { BrandId = 1, ColorId = 1, DailyPrice = 100, Description = "BMW", Id = 1, ModelYear = 2014 });
            foreach (var car in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine("Arabanın modeli " + car.Description + " Arabanın üretim yılı " + car.ModelYear + "Arabanın günlük ücreti " + car.DailyPrice);
            }
            Console.ReadLine();
            // OldCodes();

        }

        private static void OldCodes()
        {
            Console.WriteLine("------------Muscle Cars---------------");
            CarManager carManager = new CarManager(new InMemoryCarDal());
            GetAll(carManager);

            Car newCar = new Car()
            {
                Id = 5,
                BrandId = 3,
                ColorId = 2,
                ModelYear = 1978,
                DailyPrice = 140000,
                Description = "1978 Pontiac Firebird Trans Am"
            };

            AddNewCar(carManager, newCar);
            UpdateCar(carManager, newCar);
            DeleteCar(carManager, newCar);



            Car myCar = new Car();
            // myCar = carManager.GetById(1); //1 numaralı id si olan araç seçilerek updateCar nesnesine atanır.

            UpdateIdCar(carManager, myCar);
            DeleteIdCar(carManager, myCar);
        }

        private static void DeleteIdCar(CarManager carManager, Car myCar)
        {
            carManager.Delete(myCar);
            Console.WriteLine("\n-----------After Delete Car With Id----------------");
            GetAll(carManager);
        }

        private static void UpdateIdCar(CarManager carManager, Car myCar)
        {
            myCar.BrandId = 4;
            myCar.ColorId = 3;
            myCar.ModelYear = 1974;
            myCar.DailyPrice = 140000;
            myCar.Description = "1974 Dodge Challenger R/T 360 Four-Barrel";
            carManager.Update(myCar);
            Console.WriteLine("\n-----------After Update Car With Id------------------");
            GetAll(carManager);
        }

        private static void GetAll(CarManager carManager)
        {
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("{0} {1} {2}", car.Id, car.Description, car.DailyPrice);
            }
        }

        private static void DeleteCar(CarManager carManager, Car newCar)
        {
            Console.WriteLine("\n---------After Delete Car-------");
            carManager.Delete(newCar);
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("{0} {1} {2}", car.Id, car.Description, car.DailyPrice);
            }
        }

        private static void UpdateCar(CarManager carManager, Car newCar)
        {
            Console.WriteLine("\n---------After Update Car-------");
            
            newCar.Id = 15;
            newCar.DailyPrice = 150000;
            carManager.Update(newCar);
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("{0} {1} {2}", car.Id, car.Description, car.DailyPrice);
            }
        }

        private static void AddNewCar(CarManager carManager, Car newCar)
        {
            carManager.Add(newCar);
            Console.WriteLine("\n---------After Add New Car-------");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("{0} {1} {2}", car.Id, car.Description, car.DailyPrice);
            }
        }
    }
}
