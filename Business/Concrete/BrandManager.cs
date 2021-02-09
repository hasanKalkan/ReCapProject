﻿using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        public void Add(Brand brand)
        {
            try
            {
                _brandDal.Add(brand);
                Console.WriteLine(brand.Name + " markası sisteme başarıyla eklendi.");

            }
            catch (Exception e)
            {
                Console.WriteLine("Hata!. Kayıt eklenemedi.\n" + e.Message);
            }
        }

        public void Delete(Brand brand)
        {
            _brandDal.Delete(brand);
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll(b=>b.Name.Length>4);
        }

        public Brand GetById(int Id)
        {
            return _brandDal.GetById(b => b.Id == Id);
        }

        public void Update(Brand brand)
        {
            _brandDal.Update(brand);
        }
    }
}