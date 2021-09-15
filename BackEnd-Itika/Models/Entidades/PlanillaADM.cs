using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Itika.Models.Entidades
{
    public class PlanillaADM
    {

        public int Idempleado { get; set; }       
        public DateTime FechaEntrada { get; set; }   
        public DateTime EntradaMañana { get; set; }
        public DateTime RetrasoMañana { get; set; }
        //public int PermisoMañana { get; set; }
        public DateTime SalidaMañana { get; set; }
        public DateTime EntradaTarde { get; set; }
        public DateTime SalidaTarde { get; set; }
        public DateTime RetrasoTarde { get; set; }
        //public int Permisotarde { get; set; }
        public bool EstadoFalta { get; set; }
     
        public bool? Estado { get; set; }
    }
}
