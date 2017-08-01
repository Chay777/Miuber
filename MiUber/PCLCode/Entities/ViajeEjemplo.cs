using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCLCode.Entities
{
  public  class ViajeEjemplo
    {
        public long id { get; set; }
        public string idCliente { get; set; }
        public string idConductor { get; set; }
        public string fechaInicio { get; set; }
        public string fechaFin { get; set; }
        public string costo { get; set; }
        public string modeloAuto { get; set; }
        public string origen { get; set; }
        public string destino { get; set; } 
        public string tiempoViaje { get; set; }


        ///Asiganr id a los elementos de la lissta y crear al actividad donde se msotrara.

    }
}
