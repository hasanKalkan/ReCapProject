using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal:ICarDal
    {
        List<Car> _car;

        public InMemoryCarDal()
        {
            _car = new List<Car>()
            {
                new Car(){Id=1, BrandId=1,ColorId=1,ModelYear=1966,DailyPrice=100000,Description="1966 Playmouth Barracuda"},
                new Car(){Id=2, BrandId=2,ColorId=2,ModelYear=1968,DailyPrice=120000,Description="1968 Ford Mustang Shelby GT500"},
                new Car(){Id=3, BrandId=2,ColorId=3,ModelYear=1969,DailyPrice=200000,Description="1969 Ford Mustang Boss 429"},
                new Car(){Id=4, BrandId=3,ColorId=4,ModelYear=1969,DailyPrice=220000,Description="1969 Pontiac GTO Judge"},
            };
        }

        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Delete(Car car)
        {
            Car deleteCar = _car.SingleOrDefault(c => c.Id == car.Id);
            _car.Remove(deleteCar);
        }

        public List<Car> GetAll()
        {
            return _car;
        }


        public Car GetById(int id)
        {
            return _car.SingleOrDefault(c => c.Id == id);
        }

      

        public void Update(Car car)
        {
            Car updateCar = _car.SingleOrDefault(c => c.Id == car.Id);
            updateCar.BrandId = car.BrandId;
            updateCar.ColorId = car.ColorId;
            updateCar.DailyPrice = car.DailyPrice;
            updateCar.ModelYear = car.ModelYear;
            updateCar.Description = car.Description;
        }

       
    }
}