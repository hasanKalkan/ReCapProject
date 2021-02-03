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
                Console.WriteLine("{0}", car.Description);
            }


            Car newCar= new Car(){
                Id = 5,
                BrandId = 3,
                ColorId=2,
                ModelYear = 1978,
                DailyPrice = 140000,                
                Description = "1978 Pontiac Firebird Trans Am"
            };

            carManager.Add(newCar);
            

            Console.WriteLine("\n---------Add metodundan sonra-------");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("{0}", car.Description);
            }

            Console.WriteLine("\n---------Delete metodundan sonra-------");
            carManager.Delete(newCar);
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("{0}", car.Description);
            }

        }
    }
}
