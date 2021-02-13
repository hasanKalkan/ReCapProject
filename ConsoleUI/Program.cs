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
            ListCars(carManager);

            Car newCar = new Car() { Id = 5, BrandId = 1, ColorId = 3, ModelYear = 1965, DailyPrice = 2000, Description = "Ford Galaxy" };
            Console.WriteLine("\n-----------------ARABA EKLENDİ--------------");
            carManager.Add(newCar);
            ListCars(carManager);

            Console.WriteLine("\n-----------------ARABA GÜNCELLENDİ--------------");
            newCar.DailyPrice = 2200;
            carManager.Update(newCar);
            ListCars(carManager);


            Console.WriteLine("\n-----------------ARABA SİLİNDİ--------------");
            carManager.Delete(newCar);
            ListCars(carManager);

            Console.WriteLine("\n-----------------RENKLER----------------");
            ListColors(colorManager);

            Color newColor = new Color() {Id=8, Name="Kahverengi" };
            colorManager.Add(newColor);
            Console.WriteLine("\n\n-----------------RENK EKLENDİ----------------");
            ListColors(colorManager);

            newColor.Name = "Lacivert";
            colorManager.Update(newColor);
            Console.WriteLine("\n\n------------------RENK GÜNCELLENDİ----------------");
            ListColors(colorManager);

            colorManager.Delete(newColor);
            Console.WriteLine("\n\n------------------RENK SİLİNDİ----------------");
            ListColors(colorManager);

            Console.WriteLine("\n\n----------------MARKALAR------------------");
            ListBrands(brandManager);

            Brand newBrand = new Brand() { Id = 6, Name = "Datsun" };
            brandManager.Add(newBrand);
            Console.WriteLine("\n\n-----------------MARKA EKLENDİ----------------");
            ListBrands(brandManager);

            newBrand.Name = "Plymouth";
            brandManager.Update(newBrand);
            Console.WriteLine("\n\n------------------MARKA GÜNCELLENDİ----------------");
            ListBrands(brandManager);


            brandManager.Delete(newBrand);
            Console.WriteLine("\n\n------------------MARKA SİLİNDİ----------------");
            ListBrands(brandManager);


        
        }

        private static void ListCars(CarManager carManager)
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
        private static void ListColors(ColorManager colorManager)
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
        private static void ListBrands(BrandManager brandManager)
        {
            var result = brandManager.GetAll();
            if (result.Success)
            {
                foreach (var brand in result.Data)
                {
                    Console.Write(brand.Name+", ");
                }
                Console.WriteLine(result.Message);
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
