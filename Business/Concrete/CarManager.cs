using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public void Add(Car car)
        {
            try
            {
                if (car.Description.Length < 2)
                {
                    Console.WriteLine("Araç tanımı iki karakterden küçük olmamalı!");

                }
                else
                {
                    if (car.DailyPrice <= 0)
                    {
                        Console.WriteLine("Araç günlük kiralama bedeli 0 dan büyük olmalı!");
                    }
                    else
                    {
                        _carDal.Add(car);
                        Console.WriteLine("Araç başarıyla sisteme eklendi." + car.Description);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata!. Kayıt eklenemedi.\n"+e.Message);
            }


          
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDal.GetAll(c => c.BrandId == brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetAll(c => c.ColorId == colorId);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}