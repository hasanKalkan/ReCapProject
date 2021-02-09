using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;
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
                        Console.WriteLine("\n{0} araç başarıyla sisteme eklendi.", car.Description);
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
            try
            {
                _carDal.Delete(car);
                Console.WriteLine("\n{0} araç başarıyla sistemden silindi.", car.Description);

            }
            catch (Exception e)
            {
                Console.WriteLine("Hata!. Kayıt eklenemedi.\n" + e.Message);
            }
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll(c=>c.DailyPrice>50);
        }

        public Car GetById(int Id)
        {
            return _carDal.GetById(c => c.Id == Id);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }



        //public List<Car> GetCarsByBrandId(int brandId)
        //{
        //    return _carDal.GetAll(c => c.BrandId == brandId);
        //}

        //public List<Car> GetCarsByColorId(int colorId)
        //{
        //    return _carDal.GetAll(c => c.ColorId == colorId);
        //}

        public void Update(Car car)
        {

            try
            {
                _carDal.Update(car);
                Console.WriteLine(" {0} olarak güncellendi.", car.Description);

            }
            catch (Exception e)
            {
                Console.WriteLine("Hata!. Kayıt eklenemedi.\n" + e.Message);
            }
        }
    }
}