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
            carManager.Add(new Car { BrandId = 1, ColorId = 2, DailyPrice = 1800, Description = "Ford Torino", Id = 6, ModelYear = 1965 });
            Console.WriteLine("\nAraçlar-----------");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Model:  " + car.Description + ", Üretim Yılı: " + car.ModelYear + ", Günlük Ücreti:  " + car.DailyPrice + " TL");
            }




            //  BrandManager brandManager = new BrandManager(new EfBrandDal());
            ////  brandManager.Add(new Brand { BrandId = 2, BrandName = "Dodge" });
            //  Console.WriteLine("Markalar--------------");
            //  foreach (var brand in brandManager.GetAll())
            //  {
            //      Console.WriteLine("Marka İsmi: " + brand.Name);
            //  }


            //ColorManager colorManager = new ColorManager(new EfColorDal());
            //colorManager.Add(new Color { Id = 5, Name = "Siyah" });
            //Console.WriteLine("\nRenkler--------------");
            //foreach (var color in colorManager.GetAll())
            //{
            //    Console.WriteLine("Renk Adı: " + color.Name);
            //}





            //Console.WriteLine("\nMarka Id No 2 Olan Araçlar ");
            //foreach (var car in carManager.GetCarsByBrandId(2))
            //{
            //    Console.WriteLine("Marka Id: "+car.BrandId+", model: " + car.Description + ", üretim Yılı. " + car.ModelYear + ", Günlük Ücreti: " + car.DailyPrice + "TL");
            //}

            //Console.WriteLine("\nColor Id No 5 Olan Araçlar ");
            //foreach (var car in carManager.GetCarsByColorId(5))
            //{
            //    Console.WriteLine("Color Id: " + car.ColorId + ", model: " + car.Description + ", üretim Yılı. " + car.ModelYear + ", Günlük Ücreti: " + car.DailyPrice + "TL");
            //}


            //Car silinecekAraba = new Car { Id = 2 };
            // carManager.Delete(silinecekAraba); 

            // OldCodes();
        }

      /*  private static void OldCodes()
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
        }*/

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
