using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        private IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }
        public void Add(Color color)
        {
            try
            {
                _colorDal.Add(color);
                Console.WriteLine(color.Name+" renk sisteme başarıyla eklendi.") ;
                    
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata!. Kayıt eklenemedi.\n"+e.Message);
            }


          
        }

        public void Delete(Color color)
        {
            _colorDal.Delete(color);
        }

        public List<Color> GetAll()
        {
            return _colorDal.GetAll();
        }

        public Color GetById(int Id)
        {
            return _colorDal.GetById(c => c.Id == Id);

        }

        public void Update(Color color)
        {
            _colorDal.Update(color);
        }
    }
}