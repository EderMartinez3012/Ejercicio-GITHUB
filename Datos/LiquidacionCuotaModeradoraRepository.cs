using Entidades;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class LiquidacionCuotaModeradoraRepository
    {
        string fileName = "";

        public string Guardar(LiquidacionCuotaModeradora liquidacionCuotaModeradora)
        {
            var escritor = new StreamWriter(fileName, true);

            escritor.WriteLine(liquidacionCuotaModeradora.ToString());

            escritor.Close();

            return $"Se agrego la liquidación con Nro ¨{liquidacionCuotaModeradora.NroLiquidacion}";
        }

        public List<LiquidacionCuotaModeradora> ConsultarTodos()
        {
            try
            {
                List<LiquidacionCuotaModeradora> personas = new List<LiquidacionCuotaModeradora>();
                var lector = new StreamReader(fileName);
                while (!lector.EndOfStream)
                {
                    personas.Add(Map(lector.ReadLine()));
                }
                lector.Close();
                return personas;
            }
            catch (Exception)
            {
                return null;
            }
        }

        LiquidacionCuotaModeradora Map(string linea)
        {
            var paciente = new Paciente();
            var datos = linea.Split('-');

            paciente.IdPaciente = int.Parse(datos[0]);
            paciente.Nombre = datos[1];
            paciente.
        }
    }
}
