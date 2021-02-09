using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car newCar = new Car() 
            { 
                BrandId = 1, 
                ColorId = 2, 
                DailyPrice = 1800, 
                Description = "Ford Torino", 
                Id = 6, ModelYear = 1965 
            };

            carManager.Add(newCar);
            
            Console.WriteLine("\n-------------Araçlar-----------");           
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Model:  " + car.Description + ", Üretim Yılı: " + car.ModelYear + ", Günlük Ücreti:  " + car.DailyPrice + " TL");
            }

           Console.WriteLine("\nGetById Metoduyla Listeleme: Araç Id = {0}, Araç: {1}", carManager.GetById(4).Id,carManager.GetById(4).Description);


            Console.WriteLine("\n-------------GetCarDetails Metodu-----------");
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine("Id = {0}, BrandName = {1}, ColorName = {2}, DailyPrice = {3}", car.CarId, car.BrandName, car.ColorName, car.CarDailyPrice);
            }

            Console.Write("\n{0} aracımız,", newCar.Description);
            newCar.Description = "Ford Galaxy";
            newCar.ModelYear = 1967;
            newCar.DailyPrice = 2000;
            carManager.Update(newCar);
            Console.WriteLine("\n-----------Araç Güncellendikten Sonra----------------");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Model:  " + car.Description + ", Üretim Yılı: " + car.ModelYear + ", Günlük Ücreti:  " + car.DailyPrice + " TL");
            }

            carManager.Delete(new Car { BrandId = 1, ColorId = 2, DailyPrice = 1800, Description = "Ford Galaxy", Id = 6, ModelYear = 1965 });
            Console.WriteLine("\n-----------Araç Silindikten Sonra----------------");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Model:  " + car.Description + ", Üretim Yılı: " + car.ModelYear + ", Günlük Ücreti:  " + car.DailyPrice + " TL");
            }

           
        }

     
    }
}
