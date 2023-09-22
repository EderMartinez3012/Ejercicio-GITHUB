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
                Console.SetCursorPosition(20, 2); Console.WriteLine("MENU PRINCIPAL");
                Console.SetCursorPosition(10, 5); Console.WriteLine("1. Agregar Paciente");
                Console.SetCursorPosition(10, 7); Console.WriteLine("2. Mostrar Paciente");
                Console.SetCursorPosition(10, 9); Console.WriteLine("3. Actualizar servicio");
                Console.SetCursorPosition(10, 11); Console.WriteLine("4. Eliminar Liquidacion por ID");
                Console.SetCursorPosition(10, 13); Console.WriteLine("5. BUscar Paciente por ID");
                Console.SetCursorPosition(10, 15); Console.WriteLine("6. Buscar Paciente por Nombre");
                Console.SetCursorPosition(10, 23); Console.WriteLine("9. Salir");
                Console.SetCursorPosition(20, 23); Console.Write("Seleccione una opción:");
                op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 1:
                        AgregarRegistro();
                        break;
                    case 2:
                        MostrarRegistros();
                        break;
                    case 3:
                        BuscarPorAfiliacion();
                        break;                    
                    case 5:
                        TotalCuotasModeradas();
                        break;
                    case 6:
                        BuscarPorFechaLiquidaciones();
                        break;
                    case 7:
                        BuscarPorNombre();
                        break;
                    case 8:
                        EliminarLiquidacion();
                        break;
                    case 9:
                        ActualizarServicio();
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            } while (op != 9);
        }

        private void AgregarRegistro()
        {
            Console.Clear();

            Console.WriteLine("REGISTRO");

            Console.WriteLine();

            Console.Write("Ingrese el número de liquidación: ");
            int nroLiquidacion = int.Parse(Console.ReadLine());

            Console.Write("Ingrese la fecha de liquidación (dd-MM-yyyy): ");
            DateTime fechaLiquidacion = DateTime.Parse(Console.ReadLine());

            Console.Write("Ingrese la identificación del paciente: ");
            int idPaciente = int.Parse(Console.ReadLine());

            Console.Write("Ingrese el nombre del paciente: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese el tipo de afiliación (Subsidiado o Contributivo): ");
            string tipoAfiliacion = Console.ReadLine();

            Console.Write("Ingrese el salario devengado por el paciente: ");
            int nroSalarios = int.Parse(Console.ReadLine());

            Console.Write("Ingrese el valor del servicio de hospitalización prestado: ");
            int valorServicio = int.Parse(Console.ReadLine());

            LiquidacionCuotaModeradora liquidacionCuotaModeradora = new LiquidacionCuotaModeradora
            (idPaciente, nombre, nroLiquidacion, fechaLiquidacion, tipoAfiliacion, nroSalarios, valorServicio);

            liquidacionCuotaModeradoraService.CalcularCuotaModeradora(tipoAfiliacion, nroSalarios, valorServicio);

            Console.Write(liquidacionCuotaModeradoraService.Guardar(liquidacionCuotaModeradora));
            Console.ReadKey();
        }

        private void MostrarRegistros()
        {
            var liquidacionCuotaModeradoraList = liquidacionCuotaModeradoraService.ConsultarTodoLiquidacion();
            Console.Clear();
            Console.SetCursorPosition(15, 2); Console.Write("Listado General");
            Console.SetCursorPosition(10, 4); Console.Write("Identificacion");
            Console.SetCursorPosition(28, 4); Console.Write("Nombre");
            Console.SetCursorPosition(40, 4); Console.Write("Num_liquid");
            Console.SetCursorPosition(50, 4); Console.Write("Fecha");
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
                Console.SetCursorPosition(48, 4 + posicion); Console.Write(item.FechaLiquidacion);
                Console.SetCursorPosition(59, 4 + posicion); Console.Write(item.TipoAfiliacion);
                Console.SetCursorPosition(69, 4 + posicion); Console.Write(item.NroSalarios);
                Console.SetCursorPosition(77, 4 + posicion); Console.Write(item.ValorServicio);
                posicion++;
            }
            Console.ReadKey();
        }

        private void BuscarPorAfiliacion()
        {
            Console.Clear();

            Console.WriteLine("BUSCAR POR AFILIACIÓN");

            Console.WriteLine();

            Console.Write("Ingrese el tipo de afiliación (Subsidiado o Contributivo): ");
            string tipoAfiliacion = Console.ReadLine();



            Console.ReadKey();
        }

        private void TotalCuotasModeradas()
        {
            Console.Clear();

            Console.ReadKey();
        }

        private void BuscarPorFechaLiquidaciones()
        {
            Console.Clear();

            Console.WriteLine("BUSCAR LIQUIDACIÓN POR FECHA");

            Console.WriteLine();

            Console.Write("Ingrese el mes (1-12): ");
            int mes = int.Parse(Console.ReadLine());

            Console.Write("Ingrese el año: ");
            int año = int.Parse(Console.ReadLine());

            Console.ReadKey();
        }

        private void BuscarPorNombre()
        {
            Console.Clear();

            Console.WriteLine("BUSCAR POR NOMBRE");

            Console.WriteLine();

            Console.Write("Ingrese nombre del paciente: ");
            string nombre = Console.ReadLine();



            Console.ReadKey();
        }

        private void EliminarLiquidacion()
        {
            Console.Clear();

            Console.WriteLine("ELIMINAR LIQUIDACIÓN");

            Console.WriteLine();

            Console.Write("Ingrese Nro liquidación: ");
            int nroLiquidacion = int.Parse(Console.ReadLine());

            Console.WriteLine();

            liquidacionCuotaModeradoraService.EliminarLiquidacionPorNumero(nroLiquidacion);
            Console.WriteLine("Liquidación eliminada con éxito.");

            Console.ReadKey();
        }

        private void ActualizarServicio()
        {
            Console.Clear();

            Console.ReadKey();
        }

        //private void BuscarPorId()
        //{
        //    Console.Clear();
        //    Console.SetCursorPosition(10, 2); Console.Write("Buscar Liquidacion ");
        //    Console.SetCursorPosition(10, 5); Console.Write("Ingrese la identificacion del Paciente: ");
        //    int IdPaciente = int.Parse(Console.ReadLine());
        //    var paciente = liquidacionCuotaModeradoraService.BuscarID(IdPaciente);
        //    VerPersona(paciente);
        //    //Console.ReadKey();
        //}
        //private void VerPersona(LiquidacionCuotaModeradora paciente)
        //{
        //    int posicion = 2;
        //    //Console.Clear();
        //    //Console.SetCursorPosition(15, 2 + posicion); Console.Write("Listado General");
        //    Console.SetCursorPosition(10, 4 + posicion); Console.Write("identificacion");
        //    Console.SetCursorPosition(28, 4 + posicion); Console.Write("Nombre");
        //    Console.SetCursorPosition(40, 4 + posicion); Console.Write("Nro liquidacion");
        //    //Console.SetCursorPosition(46, 4 + posicion); Console.Write("Fecha");
        //    Console.SetCursorPosition(52, 4 + posicion); Console.Write("Tipo afiliacion");
        //    Console.SetCursorPosition(60, 4 + posicion); Console.Write("Nro Salarios");
        //    Console.SetCursorPosition(70, 4 + posicion); Console.Write("Valor servicio");
        //    posicion = 4;
        //    Console.SetCursorPosition(15, 4 + posicion); Console.Write(paciente.IdPaciente);
        //    Console.SetCursorPosition(29, 4 + posicion); Console.Write(paciente.Nombre);
        //    Console.SetCursorPosition(42, 4 + posicion); Console.Write(paciente.NroLiquidacion);
        //    //Console.SetCursorPosition(48, 4 + posicion); Console.Write(paciente.FechaLiquidacion);
        //    Console.SetCursorPosition(59, 4 + posicion); Console.Write(paciente.TipoAfiliacion);
        //    Console.SetCursorPosition(69, 4 + posicion); Console.Write(paciente.NroSalarios);
        //    Console.SetCursorPosition(77, 4 + posicion); Console.Write(paciente.ValorServicio);
        //    Console.ReadKey();
        //}



    }
}
 