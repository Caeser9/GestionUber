using E.ApplicationCore.Domain;
using E.ApplicationCore.Interfaces;
using E.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.ApplicationCore.Services
{
    internal class ServiceVoiture : Service<Voiture>, IServiceVoiture
    {
        public ServiceVoiture(Interfaces.IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public Voiture GetMostDemandeVoiture()
        {
            return null;
        }

    }
}
