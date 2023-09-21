using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class LiquidacionCuotaModeradoraService
    {
        public List<Persona> FiltrarPersonasPorNombre(string filtro)
        {
            return repositorio.ObtenerPersonasPorFiltro(filtro);
        }
        
        private LiquidacionCuotaModeradoraRepository repositorio = null;
        private List<LiquidacionCuotaModeradora> liquidacionCuotaModeradoraList = null;
        public LiquidacionCuotaModeradoraService()
        {
            repositorio = new LiquidacionCuotaModeradoraRepository();
            liquidacionCuotaModeradoraList = repositorio.ConsultarTodoLiquidacion();

        }
        public string Guardar(LiquidacionCuotaModeradora liquidacionCuotaModeradora)
        {
            //validar
            if (liquidacionCuotaModeradora == null)
            {
                return "no se puede guardar una persona sin informacion";
            }

            if (BuscarID(liquidacionCuotaModeradora.IdPaciente) != null)
            {
                return "liquidacion ya existente";
            }
            var msg = repositorio.Guardar(liquidacionCuotaModeradora);
            liquidacionCuotaModeradoraList = repositorio.ConsultarTodoLiquidacion();
            return msg;
        }
        public LiquidacionCuotaModeradora BuscarID(int id)
        {
            try
            {
                if (liquidacionCuotaModeradoraList == null)
                {
                    return null;
                }
                foreach (var item in liquidacionCuotaModeradoraList)
                {
                    if (id == item.IdPaciente)
                    {
                        return item;
                    }
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }

        }
        public List<LiquidacionCuotaModeradora> ConsultarTodoLiquidacion()
        {
            return liquidacionCuotaModeradoraList;
        }
        public void RegContributivo()
        {
            //Console.Write("Ingrese el Nro de salario del paciente");
            //NroSalarios = int.Parse(Console.ReadLine());

            //if (NroSalarios < 2)
            //{
            //    Tarifa = 0.15;
            //}
            //else if (NroSalarios >= 2 && <= 5)
            //{
            //    Tarifa = 0.20;
            //}
            //else
            //{
            //    Tarifa = 0.25;
            //}

            //CuotaModeladora = ValorServicio * Tarifa;
        }
    }
    
}
