using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class LiquidacionCuotaModeradora
    {
        public int NroLiquidacion { get; set; }
        public int IdPaciente { get; set; }
        public string TipoAfiliacion { get; set; }
        public int NroSalarios { get; set; }
        public int ValorServicio { get; set; }

        public LiquidacionCuotaModeradora(int nroliquidacion, int idpaciente, string tipoafiliacion, int nrosalarios, int valorservicio) 
        {
            NroLiquidacion = nroliquidacion;
            IdPaciente = idpaciente;
            TipoAfiliacion = tipoafiliacion;
            NroSalarios = nrosalarios;
            ValorServicio = valorservicio;
        }

        public override string ToString()
        {
            return $"{NroLiquidacion};{IdPaciente};{TipoAfiliacion};{NroSalarios};{ValorServicio}";
        }
    }
}
