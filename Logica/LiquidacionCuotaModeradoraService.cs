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

        public decimal CalcularCuotaModeradora(LiquidacionCuotaModeradora liquidacion)
        {
            decimal cuotaModeradora = 0;

            if (liquidacion.TipoAfiliacion == "Contributivo")
            {
                if (liquidacion.NroSalarios < 2 * SalarioMinimo)
                {
                    cuotaModeradora = liquidacion.ValorServicio * 0.15m;
                    cuotaModeradora = Math.Min(cuotaModeradora, TopeMaximoContributivo);
                }
                else if (liquidacion.NroSalarios >= 2 * SalarioMinimo && liquidacion.NroSalarios <= 5 * SalarioMinimo)
                {
                    cuotaModeradora = liquidacion.ValorServicio * 0.20m;
                    cuotaModeradora = Math.Min(cuotaModeradora, TopeMaximoContributivo);
                }
                else
                {
                    cuotaModeradora = liquidacion.ValorServicio * 0.25m;
                    cuotaModeradora = Math.Min(cuotaModeradora, TopeMaximoContributivo);
                }
            }
            else if (liquidacion.TipoAfiliacion == "Subsidiado")
            {
                cuotaModeradora = liquidacion.ValorServicio * 0.05m;
                cuotaModeradora = Math.Min(cuotaModeradora, TopeMaximoSubsidiado);
            }

            liquidacion.CuotaModeladora = cuotaModeradora;
            return cuotaModeradora;
        }

        private const decimal SalarioMinimo = 1000000; // Ejemplo de salario mínimo
        private const decimal TopeMaximoContributivo = 1500000;
        private const decimal TopeMaximoSubsidiado = 200000;
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

        public Dictionary<string, int> TotalizarLiquidacionesPorAfiliacion()
        {
            Dictionary<string, int> totalLiquidacionesPorAfiliacion = new Dictionary<string, int>();

            List<LiquidacionCuotaModeradora> liquidaciones = repositorio.ConsultarTodoLiquidacion();

            foreach (LiquidacionCuotaModeradora liquidacion in liquidaciones)
            {
                string tipoAfiliacion = liquidacion.TipoAfiliacion;

                if (totalLiquidacionesPorAfiliacion.ContainsKey(tipoAfiliacion))
                {
                    totalLiquidacionesPorAfiliacion[tipoAfiliacion]++;
                }
                else
                {
                    totalLiquidacionesPorAfiliacion[tipoAfiliacion] = 1;
                }
            }

            return totalLiquidacionesPorAfiliacion;
        }

        public Dictionary<string, decimal> CalcularValorTotalCuotasPorAfiliacion()
        {
            Dictionary<string, decimal> valorTotalCuotasPorAfiliacion = new Dictionary<string, decimal>();

            List<LiquidacionCuotaModeradora> liquidaciones = repositorio.ConsultarTodoLiquidacion();

            foreach (LiquidacionCuotaModeradora liquidacion in liquidaciones)
            {
                string tipoAfiliacion = liquidacion.TipoAfiliacion;
                decimal cuotaModeradora = liquidacion.CuotaModeladora;

                if (valorTotalCuotasPorAfiliacion.ContainsKey(tipoAfiliacion))
                {
                    valorTotalCuotasPorAfiliacion[tipoAfiliacion] += cuotaModeradora;
                }
                else
                {
                    valorTotalCuotasPorAfiliacion[tipoAfiliacion] = cuotaModeradora;
                }
            }

            return valorTotalCuotasPorAfiliacion;
        }

        public Dictionary<string, decimal> CalcularValorTotalCuotasPorAfiliacionEnFecha(int year, int month)
        {
            Dictionary<string, decimal> valorTotalCuotasPorAfiliacion = new Dictionary<string, decimal>();

            List<LiquidacionCuotaModeradora> liquidaciones = repositorio.ConsultarTodoLiquidacion();

            foreach (LiquidacionCuotaModeradora liquidacion in liquidaciones)
            {
                if (liquidacion.FechaLiquidacion.Year == year && liquidacion.FechaLiquidacion.Month == month)
                {
                    string tipoAfiliacion = liquidacion.TipoAfiliacion;
                    decimal cuotaModeradora = liquidacion.CuotaModeradora;

                    if (valorTotalCuotasPorAfiliacion.ContainsKey(tipoAfiliacion))
                    {
                        valorTotalCuotasPorAfiliacion[tipoAfiliacion] += cuotaModeradora;
                    }
                    else
                    {
                        valorTotalCuotasPorAfiliacion[tipoAfiliacion] = cuotaModeradora;
                    }
                }
            }

            return valorTotalCuotasPorAfiliacion;
        }

        public LiquidacionCuotaModeradora BuscarPorNombre(string nombre)
        {
            try
            {
                if (liquidacionCuotaModeradoraList == null)
                {
                    return null;
                }
                foreach (var item in liquidacionCuotaModeradoraList)
                {
                    if (nombre == item.Nombre)
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

        public void ModificarValorServicioHospitalizacion(int numeroLiquidacion, decimal nuevoValorServicio)
        {
            repositorio.ModificarValorServicioHospitalizacion(numeroLiquidacion, nuevoValorServicio);
        }

        public void EliminarLiquidacionPorNumero(int numeroLiquidacion)
        {
            repositorio.EliminarLiquidacionPorNumero(numeroLiquidacion);
        }

        //public void EliminarLiquidacionPorNumero(int numeroLiquidacion)
        //{
        //    List<LiquidacionCuotaModeradora> liquidaciones = repositorio.ConsultarTodoLiquidacion();

        //    // Buscar la liquidación por número de liquidación y eliminarla
        //    LiquidacionCuotaModeradora liquidacionAEliminar = liquidaciones.FirstOrDefault(l => l.NroLiquidacion == numeroLiquidacion);

        //    if (liquidacionAEliminar != null)
        //    {
        //        liquidaciones.Remove(liquidacionAEliminar);
        //        repositorio.Guardar(liquidacionCuotaModeradora); // Guardar la lista actualizada en el archivo de texto
        //    }
        //    else
        //    {
        //        Console.WriteLine("No se encontró una liquidación con el número especificado.");
        //    }
        //}

    }
}
