using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion
{
    public class Menu
    {
        public void MenuPrincipal()
        {
            int op;
            do
            {
                Console.Clear();

                Console.WriteLine("IPS MAS SALUD Y VIDA");

                Console.WriteLine();

                Console.WriteLine("1. Registrar");

                Console.WriteLine();

                Console.WriteLine("2. Listado");

                Console.WriteLine();

                Console.WriteLine("3. Busqueda por afiliación");

                Console.WriteLine();

                Console.WriteLine("4. Busqueda por valor de cuotas moderadas");

                Console.WriteLine();

                Console.WriteLine("5. Busqueda por liquidaciones");

                Console.WriteLine();

                Console.WriteLine("6. Busqueda por nombre");

                Console.WriteLine();

                Console.WriteLine("7. Eliminar liquidación");

                Console.WriteLine();

                Console.WriteLine("8. Modificar valor del servicio");

                Console.Write("Digite una opción: ");
                op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 1: Registrar();
                        break;

                    case 2: Listado();
                        break;

                    case 3: BuscarPorAfiliacion();
                        break;

                    case 4: BuscarPorCuotas();
                        break;

                    case 5: BuscarPorLiquidaciones();
                        break;

                    case 6: BuscarPorNombre();
                        break;

                    case 7: EliminarLiquidacion();
                        break;

                    case 8: ModificarValorServicio();
                        break;

                    default:
                        break;
                }

            } while (op != 9);
        }

        private void Registrar()
        {
            Console.Clear();

            Console.WriteLine("REGISTRO");

            Console.Write("Digite nro liquidación: ");
            int NroLiquidacion = int.Parse(Console.ReadLine());

            Console.WriteLine();

            Console.Write("Digite id paciente: ");
            int IdPaciente = int.Parse(Console.ReadLine());

            Console.WriteLine();

            Console.Write("Digite el nombre: ");
            string Nombre = Console.ReadLine();

            Console.WriteLine();

            Console.Write("Digite la fecha de liquidación (dd-mm-yyyy): ");

            Console.WriteLine();

            Console.Write("Digite tipo de afiliación (contributivo o subsidiado): ");
            string TipoAfiliacion = Console.ReadLine();

            Console.WriteLine();

            Console.Write("Digite el nro salarios: ");
            int NroSalario = int.Parse(Console.ReadLine());

            Console.WriteLine();

            Console.Write("Digite el valor de servicio hospitalario: ");
            int ValorServicio = int.Parse(Console.ReadLine());

            Console.ReadKey();
        }

        private void Listado()
        {
            throw new NotImplementedException();
        }

        private void BuscarPorAfiliacion()
        {
            throw new NotImplementedException();
        }

        private void BuscarPorCuotas()
        {
            throw new NotImplementedException();
        }

        private void BuscarPorLiquidaciones()
        {
            throw new NotImplementedException();
        }

        private void BuscarPorNombre()
        {
            Console.Clear();

            Console.WriteLine("BUSQUEDA POR NOMBRE");

            Console.WriteLine();

            Console.Write("Digite un nombre: ");

            Console.WriteLine();

            //if (personaList == null)
            //{
            //    Console.WriteLine("Archivo sin datos.");
            //    Console.ReadKey();
            //    return;
            //}
            //foreach (var item in personaList)
            //{
            //    Console.WriteLine("Nombre -- Id paciente -- Sexo -- Edad -- Pulsación");
            //    Console.WriteLine();
            //    Console.WriteLine($"{item.Nombre} -- {item.IdPaciente} -- {item.Sexo} -- {item.Edad} -- {item.Pulsacion}");
            //}

            Console.ReadKey();
        }

        private void EliminarLiquidacion()
        {
            throw new NotImplementedException();
        }

        private void ModificarValorServicio()
        {
            throw new NotImplementedException();
        }
    }
}
