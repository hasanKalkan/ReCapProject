using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------------Muscle Cars---------------");
            CarManager carManager = new CarManager(new InMemoryCarDal());

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("{0} {1} {2}", car.Id, car.Description, car.DailyPrice);
            }
            
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
