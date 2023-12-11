using E.ApplicationCore.Domain;
using E.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.ApplicationCore.Services
{
    internal class ServiceChauffeur : Service<Chauffeur>, IServiceChauffeur
    {
        public ServiceChauffeur(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        public int BenificeTotal(DateTime date)
        {
            return GetAll().SelectMany(c => c.Voiture.Courses)
                .Where(c => c.PaiementEnligne.Equals(true))
                .Where(c=>c.DateCourse.Equals(date))
                .Count();
        }
        

    }
}
