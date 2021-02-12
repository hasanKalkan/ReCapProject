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
            ColorManager colorManager = new ColorManager(new EfColorDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            Console.WriteLine("-----------------ARABALAR--------------");
            //carManager.Add(new Car { Id = 5,BrandId=1, ColorId=9,ModelYear=1965,DailyPrice=200,Description="Ford Galaxy" });
            //carManager.Update(new Car { Id = 3002,BrandId = 5, ColorId = 8, ModelYear = 1978, DailyPrice = 105, Description = "Doğan SLX" });
            //carManager.Delete(new Car { Id = 3002 });
            CarListed(carManager);

            Console.WriteLine("\n-----------------RENKLER----------------");
            //colorManager.Add(new Color { ColorName = "Dark Red" });
            //colorManager.Update(new Color { ColorId = 1013, ColorName = "Dark Yellow" });
            //colorManager.Delete(new Color { ColorId = 12 });
            ColorListed(colorManager);

            Console.WriteLine("\n----------------MARKALAR------------------");
            //brandManager.Add(new Brand { BrandName = "Ş" });
            //brandManager.Update(new Brand { BrandId = 7, BrandName = "Doğan" });
            //brandManager.Delete(new Brand { BrandId = 1006 });
            BrandListed(brandManager);



            //  OldCodes2();

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

            // OldCodes();
        }

        private static void CarListed(CarManager carManager)
        {
            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("Id: {0}, {1}, Renk: {2}, Marka: {3}, Model Yılı: {4}, Günlük Kiralama Bedeli: {5} TL.",car.Id,car.Description,car.ColorName,car.BrandName,car.ModelYear,car.DailyPrice);
                }

            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
        private static void ColorListed(ColorManager colorManager)
        {
            var result = colorManager.GetAll();
            if (result.Success)
            {
                foreach (var color in result.Data)
                {
                    Console.Write(color.Name+", ");
                }

            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
        private static void BrandListed(BrandManager brandManager)
        {
            var result = brandManager.GetAll();
            if (result.Success)
            {
                foreach (var brand in result.Data)
                {
                    Console.Write(brand.Name+", ");
                }

            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        /* private static void OldCodes2()
         {
             CarManager carManager = new CarManager(new EfCarDal());
             Car newCar = new Car()
             {
                 BrandId = 1,
                 ColorId = 2,
                 DailyPrice = 1800,
                 Description = "Ford Torino",
                 Id = 6,
                 ModelYear = 1965
             };

             carManager.Add(newCar);

             Console.WriteLine("\n-------------Araçlar-----------");
             foreach (var car in carManager.GetAll())
             {
                 Console.WriteLine("Model:  " + car.Description + ", Üretim Yılı: " + car.ModelYear + ", Günlük Ücreti:  " + car.DailyPrice + " TL");
             }

             Console.WriteLine("\nGetById Metoduyla Listeleme: Araç Id = {0}, Araç: {1}", carManager.GetById(4).Id, carManager.GetById(4).Description);


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
         }*/

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

        /*  private static void DeleteIdCar(CarManager carManager, Car myCar)
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
          }*/
    }
}
