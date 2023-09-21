using DLL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPC__
{
    public class LiquidacionGUI
    {
        private LiquidacionCuotaModeradoraService liquidacionCuotaModeradoraService = new LiquidacionCuotaModeradoraService();
        public void Menu()
        {
            int op = 0;
            do
            {
                Console.Clear();
                Console.SetCursorPosition(20, 2); Console.Write("MENU PRINCIPAL");
                Console.SetCursorPosition(10, 5); Console.Write("1. Agregar Paciente");
                Console.SetCursorPosition(10, 7); Console.Write("2. Mostrar Paciente");
                Console.SetCursorPosition(10, 9); Console.Write("3. Actualizar servicio");
                Console.SetCursorPosition(10, 11); Console.Write("4. Eliminar Liquidacion por ID");
                Console.SetCursorPosition(10, 13); Console.Write("5. BUscar Paciente por ID");
                Console.SetCursorPosition(10, 23); Console.Write("9. Salir");
                Console.SetCursorPosition(20, 23); Console.Write("Seleccione una opción:");
                op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 1:
                        AgregarUsuario();
                        break;
                    case 2:
                        MostrarUsuarios();
                        break;
                    case 3:
                        ActualizarUsuario();
                        break;
                    case 4:
                        EliminarUsuario();
                        break;
                    case 5:
                        BuscarPorId();
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            } while (op != 9);
        }
        private void BuscarPorId()
        {
            Console.Clear();
            Console.SetCursorPosition(10, 2); Console.Write("Buscar Liquidacion ");
            Console.SetCursorPosition(10, 4); Console.Write("Ingrese la identificacion del Paciente: ");
            int IdPaciente = int.Parse(Console.ReadLine());
            var paciente = liquidacionCuotaModeradoraService.BuscarID(IdPaciente);
            VerPersona(paciente);
            //Console.ReadKey();
        }
        private void VerPersona(LiquidacionCuotaModeradora paciente)
        {
            int posicion = 2;
            //Console.Clear();
            //Console.SetCursorPosition(15, 2 + posicion); Console.Write("Listado General");
            Console.SetCursorPosition(10, 4 + posicion); Console.Write("identificacion");
            Console.SetCursorPosition(28, 4 + posicion); Console.Write("Nombre");
            Console.SetCursorPosition(40, 4 + posicion); Console.Write("Nro liquidacion");
            //Console.SetCursorPosition(46, 4 + posicion); Console.Write("Fecha");
            Console.SetCursorPosition(52, 4 + posicion); Console.Write("Tipo afiliacion");
            Console.SetCursorPosition(60, 4 + posicion); Console.Write("Nro Salarios");
            Console.SetCursorPosition(70, 4 + posicion); Console.Write("Valor servicio");
            posicion = 4;
            Console.SetCursorPosition(15, 4 + posicion); Console.Write(paciente.IdPaciente);
            Console.SetCursorPosition(29, 4 + posicion); Console.Write(paciente.Nombre);
            Console.SetCursorPosition(42, 4 + posicion); Console.Write(paciente.NroLiquidacion);
            //Console.SetCursorPosition(48, 4 + posicion); Console.Write(paciente.FechaLiquidacion);
            Console.SetCursorPosition(59, 4 + posicion); Console.Write(paciente.TipoAfiliacion);
            Console.SetCursorPosition(69, 4 + posicion); Console.Write(paciente.NroSalarios);
            Console.SetCursorPosition(77, 4 + posicion); Console.Write(paciente.ValorServicio);
            Console.ReadKey();
        }
        private void EliminarUsuario()
        {
            throw new NotImplementedException();
        }

        private void ActualizarUsuario()
        {
            throw new NotImplementedException();
        }
        private void MostrarUsuarios()
        {
            var liquidacionCuotaModeradoraList = liquidacionCuotaModeradoraService.ConsultarTodoLiquidacion();
            Console.Clear();
            Console.SetCursorPosition(15, 2); Console.Write("Listado General");
            Console.SetCursorPosition(10, 4); Console.Write("identificacion");
            Console.SetCursorPosition(28, 4); Console.Write("Nombre");
            Console.SetCursorPosition(40, 4); Console.Write("Num_liquid");
            //Console.SetCursorPosition(50, 4); Console.Write("Fecha");
            Console.SetCursorPosition(56, 4); Console.Write("Tip_Afili");
            Console.SetCursorPosition(65, 4); Console.Write("Nro_sal");
            Console.SetCursorPosition(72, 4); Console.Write("Val_Serv");
            int posicion = 2;
            if (liquidacionCuotaModeradoraList == null)
            {
                Console.Clear();
                Console.SetCursorPosition(40, 20); Console.WriteLine("archivo sin datos ");
                Console.ReadKey();
                return;
            }
            foreach (var item in liquidacionCuotaModeradoraList)
            {

                Console.SetCursorPosition(15, 4 + posicion); Console.Write(item.IdPaciente);
                Console.SetCursorPosition(29, 4 + posicion); Console.Write(item.Nombre);
                Console.SetCursorPosition(42, 4 + posicion); Console.Write(item.NroLiquidacion);
                //Console.SetCursorPosition(48, 4 + posicion); Console.Write(item.FechaLiquidacion);
                Console.SetCursorPosition(59, 4 + posicion); Console.Write(item.TipoAfiliacion);
                Console.SetCursorPosition(69, 4 + posicion); Console.Write(item.NroSalarios);
                Console.SetCursorPosition(77, 4 + posicion); Console.Write(item.ValorServicio);
                posicion++;
            }
            Console.ReadKey();
        }
        private void AgregarUsuario()
        {
            Console.Clear();
            Console.WriteLine("Ingrese la identificacion del paciente:");
            int idPaciente = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el nombre del paciente:");
            string nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el numero de liquidacion:");
            int nroLiquidacion = int.Parse(Console.ReadLine());

            //Console.WriteLine("Ingrese la fecha:");
            //DateTime fechaLiquidacion = Console.ReadLine();

            Console.WriteLine("Ingrese el tipo afiliacion:");
            string tipoAfiliacion = Console.ReadLine();

            Console.WriteLine("Ingrese el Num salarios:");
            int nroSalarios = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el valor del servicio:");
            int valorServicio = int.Parse(Console.ReadLine());

            LiquidacionCuotaModeradora liquidacionCuotaModeradora = new LiquidacionCuotaModeradora
                (idPaciente, nombre, nroLiquidacion, /*fechaLiquidacion,*/ tipoAfiliacion, nroSalarios, valorServicio);

            Console.Write(liquidacionCuotaModeradoraService.Guardar(liquidacionCuotaModeradora));
            Console.ReadKey();
        }

    }
}
 