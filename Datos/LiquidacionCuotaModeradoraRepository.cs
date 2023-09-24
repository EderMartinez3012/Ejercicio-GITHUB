using Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD
{
    public class LiquidacionCuotaModeradoraRepository
    {
        string fileName = "liquidacionCuotaModeradora.txt";
        public string Guardar(LiquidacionCuotaModeradora liquidacionCuotaModeradora)
        {
            //1 abrir el archivo
            var escritor = new StreamWriter(fileName, true);
            //2 operaciones 
            escritor.WriteLine(liquidacionCuotaModeradora.ToString());

            //3 cerrar el flujo
            escritor.Close();

            return $"Se agrego la liquidacion {liquidacionCuotaModeradora.NroLiquidacion}";
        }
        public List<LiquidacionCuotaModeradora> ConsultarTodoLiquidacion()
        {

            List<LiquidacionCuotaModeradora> liquidacionCuotaModeradora = new List<LiquidacionCuotaModeradora>();
            try
            {
                var lector = new StreamReader(fileName);
                while (!lector.EndOfStream)
                {
                    liquidacionCuotaModeradora.Add(Map2(lector.ReadLine()));
                }
                lector.Close();
                return liquidacionCuotaModeradora;
            }
            catch (Exception)
            {
                return null;
            }

        }
        //LiquidacionCuotaModeradora Map(string linea)
        //{
        //    var liquidacionCuotaModeradora = new LiquidacionCuotaModeradora();
        //    liquidacionCuotaModeradora.IdPaciente = int.Parse(linea.Split(';')[0]);
        //    liquidacionCuotaModeradora.Nombre = linea.Split(';')[1];
        //    liquidacionCuotaModeradora.NroLiquidacion = int.Parse(linea.Split(';')[2]);
        //    liquidacionCuotaModeradora.FechaLiquidacion = DateTime.Parse(linea.Split(';')[3]);
        //    liquidacionCuotaModeradora.TipoAfiliacion = linea.Split(';')[4];
        //    liquidacionCuotaModeradora.NroSalarios = int.Parse(linea.Split(';')[5]);
        //    liquidacionCuotaModeradora.ValorServicio = int.Parse(linea.Split(';')[6]);
        //    return liquidacionCuotaModeradora;
        //}
        LiquidacionCuotaModeradora Map2(string linea)
        {
            var liquidacionCuotaModeradora = new LiquidacionCuotaModeradora();
            var datos = linea.Split(';');

            liquidacionCuotaModeradora.IdPaciente = int.Parse(datos[0]);
            liquidacionCuotaModeradora.Nombre = datos[1];
            liquidacionCuotaModeradora.NroLiquidacion = int.Parse(datos[2]);
            liquidacionCuotaModeradora.TipoAfiliacion = datos[3];
            liquidacionCuotaModeradora.FechaLiquidacion = DateTime.Parse(datos[4]);
            liquidacionCuotaModeradora.NroSalarios = int.Parse(datos[5]);
            liquidacionCuotaModeradora.ValorServicio = int.Parse(datos[6]);
            return liquidacionCuotaModeradora;
        }

        public void ModificarValorServicioHospitalizacion(int numeroLiquidacion, decimal nuevoValorServicio)
        {
            List<LiquidacionCuotaModeradora> liquidaciones = ConsultarTodoLiquidacion();
            LiquidacionCuotaModeradora liquidacionAModificar = liquidaciones.FirstOrDefault(l => l.NroLiquidacion == numeroLiquidacion);

            if (liquidacionAModificar != null)
            {
                liquidacionAModificar.ValorServicio = (int)nuevoValorServicio;

                // Luego, recalcular la cuota moderadora para la liquidación modificada.
                CalcularCuotaModeradora(liquidacionAModificar);

                // Guarda la lista actualizada en el archivo de texto o en el repositorio de datos.
                // Implementa la lógica de escritura de archivos o almacenamiento en base de datos aquí.
            }
        }

        public void EliminarLiquidacionPorNumero(int numeroLiquidacion)
        {
            List<LiquidacionCuotaModeradora> liquidaciones = ConsultarTodoLiquidacion();
            LiquidacionCuotaModeradora liquidacionAEliminar = liquidaciones.FirstOrDefault(l => l.NroLiquidacion == numeroLiquidacion);

            if (liquidacionAEliminar != null)
            {
                liquidaciones.Remove(liquidacionAEliminar);
            }
        }


        //public void Eliminar(int NroLiquidacion)
        //{
        //    var tasks = ConsultarTodoLiquidacion();
        //    var updatedTasks = tasks.Where(task => task.Id != taskId).ToList();
        //    File.WriteAllLines(filePath, updatedTasks.Select(task => $"{task.Id},{task.Description}"));
        //}
    }
}
