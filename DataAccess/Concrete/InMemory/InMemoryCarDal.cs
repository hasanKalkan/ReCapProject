using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
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
            throw new NotImplementedException();
        }

        public void Delete(Car car)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            throw new NotImplementedException();
        }
    }
}
