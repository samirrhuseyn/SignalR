using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstarct;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class TestimoialManager : ITestimonialService
    {
        private readonly ITestimonialDal _testimodialDal;

        public TestimoialManager(ITestimonialDal testimodialDal)
        {
            _testimodialDal = testimodialDal;
        }

        public void TAdd(Testimonial entity)
        {
            _testimodialDal.Add(entity);
        }

        public void TDelete(Testimonial entity)
        {
            _testimodialDal.Delete(entity);
        }

        public Testimonial TGetByID(int id)
        {
            return _testimodialDal.GetByID(id);
        }

        public List<Testimonial> TGetListAll()
        {
            return _testimodialDal.GetListAll();
        }

        public void TUpdate(Testimonial entity)
        {
            _testimodialDal.Update(entity);
        }
    }
}
