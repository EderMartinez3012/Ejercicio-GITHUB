using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Paciente
    {
        public Paciente()
        {
        }

        public Paciente(int idPaciente, string nombre)
        {
            IdPaciente = idPaciente;
            Nombre = nombre;
        }
        public int IdPaciente { get; set; }
        public string Nombre { get; set; }
    }
}
