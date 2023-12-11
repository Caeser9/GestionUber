using E.ApplicationCore.Domain;
using E.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.ApplicationCore.Services
{
    public class ServiceCourse : Service<Course>, IServiceCourse
    {
        public ServiceCourse(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public IEnumerable<Course> GetCoursesPayeeByDate(DateTime date, Chauffeur chauffeur)
        {
            return GetAll().SelectMany(chauffer => chauffeur.Voiture.Courses)
                .Where(c => c.PaiementEnligne.Equals(true))
                .Where(c => c.DateCourse.Equals(date));
        }
    }
}
