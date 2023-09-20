using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class LiquidacionCuotaModeradora : Paciente
    {
        public int NroLiquidacion { get; set; }
        public string TipoAfiliacion { get; set; }
        public int NroSalarios { get; set; }
        public int ValorServicio { get; set; }

        public LiquidacionCuotaModeradora(int idpaciente, string nombre, int nroliquidacion, string tipoafiliacion, int nrosalarios, int valorservicio) 
        {
            IdPaciente = idpaciente;
            Nombre = nombre;
            NroLiquidacion = nroliquidacion;
            TipoAfiliacion = tipoafiliacion;
            NroSalarios = nrosalarios;
            ValorServicio = valorservicio;
        }

        public override string ToString()
        {
            return $"{IdPaciente};{Nombre};{NroLiquidacion};{TipoAfiliacion};{NroSalarios};{ValorServicio}";
        }
    }
}
