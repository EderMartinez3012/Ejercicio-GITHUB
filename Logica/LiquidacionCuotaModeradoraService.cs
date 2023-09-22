using BDD;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    public class LiquidacionCuotaModeradoraService
    {
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

        public decimal CalcularCuotaModeradora(string tipoAfiliacion, decimal salarioDevengado, decimal valorServicio)
        {
            decimal cuotaModeradora = 0;

            if (tipoAfiliacion == "Contributivo")
            {
                if (salarioDevengado < 2)
                {
                    cuotaModeradora = valorServicio * 0.15m;
                    if (cuotaModeradora > 250000)
                        cuotaModeradora = 250000;
                }
                else if (salarioDevengado >= 2 && salarioDevengado <= 5)
                {
                    cuotaModeradora = valorServicio * 0.20m;
                    if (cuotaModeradora > 900000)
                        cuotaModeradora = 900000;
                }
                else if (salarioDevengado > 5)
                {
                    cuotaModeradora = valorServicio * 0.25m;
                    if (cuotaModeradora > 1500000)
                        cuotaModeradora = 1500000;
                }
            }
            else if (tipoAfiliacion == "Subsidiado")
            {
                cuotaModeradora = valorServicio * 0.05m;
                if (cuotaModeradora > 200000)
                    cuotaModeradora = 200000;
            }

            return cuotaModeradora;
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

        public void EliminarLiquidacionPorNumero(int numeroLiquidacion)
        {
            List<LiquidacionCuotaModeradora> liquidaciones = repositorio.ConsultarTodoLiquidacion();

            // Buscar la liquidación por número de liquidación y eliminarla
            LiquidacionCuotaModeradora liquidacionAEliminar = liquidaciones.FirstOrDefault(l => l.NroLiquidacion == numeroLiquidacion);

            if (liquidacionAEliminar != null)
            {
                liquidaciones.Remove(liquidacionAEliminar);
                repositorio.Guardar(liquidacionCuotaModeradora); // Guardar la lista actualizada en el archivo de texto
            }
            else
            {
                Console.WriteLine("No se encontró una liquidación con el número especificado.");
            }
        }

    }
}
