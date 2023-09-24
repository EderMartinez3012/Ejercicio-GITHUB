using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class LiquidacionCuotaModeradora : Paciente
    {
        public int NroLiquidacion { get; set; }
        public DateTime FechaLiquidacion { get; set; }
        public string TipoAfiliacion { get; set; }
        public int NroSalarios { get; set; }
        public int ValorServicio { get; set; }

        public int NuevoValorServicio { get; set; }

        public double CuotaModeladora = 0;
        public double Tarifa = 0;
        public LiquidacionCuotaModeradora()
        {
        }

        public LiquidacionCuotaModeradora(int idPaciente, string nombre, int nroLiquidacion, DateTime fechaLiquidacion, string tipoAfiliacion, int nroSalarios, int valorServicio)
        {
            IdPaciente = idPaciente;
            Nombre = nombre;
            NroLiquidacion = nroLiquidacion;
            FechaLiquidacion = fechaLiquidacion;
            TipoAfiliacion = tipoAfiliacion;
            NroSalarios = nroSalarios;
            ValorServicio = valorServicio;
            NuevoValorServicio = NuevoValorServicio;
        }

        public LiquidacionCuotaModeradora(int idPaciente, string nombre, int nroLiquidacion, string tipoAfiliacion, int nroSalarios, int valorServicio) : base(idPaciente, nombre)
        {
        }

        public override string ToString()
        {
            return $"{IdPaciente};{Nombre};{NroLiquidacion};{FechaLiquidacion};{TipoAfiliacion};{NroSalarios};{ValorServicio}";
        }
    }
}
