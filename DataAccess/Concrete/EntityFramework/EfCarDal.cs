using Core.Data_Access.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapProjectContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from c in context.Cars
                             join br in context.Brands
                             on c.BrandId equals br.Id
                             join co in context.Colors
                             on c.ColorId equals co.Id
                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 BrandName = br.Name,
                                 ColorName = co.Name,
                                 Description=c.Description,
                                 ModelYear=c.ModelYear,
                                 DailyPrice = c.DailyPrice                                
                                                               
                             };

                return result.ToList();
            }
        }
    }
}
