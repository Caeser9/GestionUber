using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.ApplicationCore.Domain
{
    public class Course
    {
        public DateTime DateCourse { get; set; }
        public string LieuDepart { get; set; }
        public string LieuArrive { get; set; }
        public double Montant { get; set; }
        public bool PaiementEnligne { get; set; }
        public Etat Etat { get; set; }

        public string VoitreFk { get; set; }
        public string ClientFk { get; set; }

        public virtual Voiture Voiture { get; set; }
        public virtual Client Client { get; set; }

    }
}
