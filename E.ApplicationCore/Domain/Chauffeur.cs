using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.ApplicationCore.Domain
{
    public class Chauffeur
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public float TauxBenifice { get; set; }

        public virtual Voiture Voiture { get; set; }

        public virtual IList<Client> Clients { get; set; }


    }
}
