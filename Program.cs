using System;
using PLANAZO_POO_CSharp.Servicios;

namespace PLANAZO_POO_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            GestorReservas gestor = new GestorReservas();
            int opcion = -1;

            while (opcion != 0)
            {
                Console.Clear();
                Console.WriteLine("================================");
                Console.WriteLine("        PLANAZO - EVENTOS       ");
                Console.WriteLine("================================");
                Console.WriteLine("1. Ver eventos disponibles");
                Console.WriteLine("2. Consultar evento");
                Console.WriteLine("3. Reservar entradas");
                Console.WriteLine("4. Ver reservas realizadas");
                Console.WriteLine("5. Cancelar una reserva");
                Console.WriteLine("6. Ver resumen de reservas");
                Console.WriteLine("0. Salir");
                Console.WriteLine("================================");
                Console.Write("Seleccione una opción: ");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    try
                    {
                        switch (opcion)
                        {
                            case 1:
                                MostrarEventos(gestor);
                                break;
                            case 2:
                                ConsultarEventoPorId(gestor);
                                break;
                            case 3:
                                RealizarReservaPrompt(gestor);
                                break;
                            case 4:
                                VerReservas(gestor);
                                break;
                            case 5:
                                CancelarReservaPrompt(gestor);
                                break;
                            case 6:
                                gestor.MostrarResumen();
                                break;
                            case 0:
                                Console.WriteLine("\n¡Gracias por usar PLANAZO!");
                                break;
                            default:
                                Console.WriteLine("\nOpción inválida.");
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"\n[Error Controlado]: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("\nPor favor, ingrese un número válido.");
                }

                if (opcion != 0)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }

        private static void MostrarEventos(GestorReservas gestor)
        {
            Console.WriteLine("\n--- EVENTOS DISPONIBLES ---");
            foreach (var ev in gestor.ObtenerEventos())
            {
                Console.WriteLine(ev);
            }
        }

        private static void ConsultarEventoPorId(GestorReservas gestor)
        {
            Console.Write("\nIngrese el ID del evento: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var ev = gestor.BuscarEventoPorId(id);
                if (ev != null)
                {
                    Console.WriteLine("\n--- DETALLES ---");
                    Console.WriteLine(ev);
                }
                else
                {
                    Console.WriteLine("\nEl evento no existe.");
                }
            }
            else
            {
                Console.WriteLine("\nID no válido.");
            }
        }

        private static void RealizarReservaPrompt(GestorReservas gestor)
        {
            MostrarEventos(gestor);
            Console.Write("\nIngrese el ID del evento a reservar: ");
            if (!int.TryParse(Console.ReadLine(), out int eventoId)) return;

            Console.Write("Ingrese su nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese la cantidad de entradas: ");
            if (!int.TryParse(Console.ReadLine(), out int cantidad)) return;

            gestor.RealizarReserva(nombre, eventoId, cantidad);
        }

        private static void VerReservas(GestorReservas gestor)
        {
            Console.WriteLine("\n--- LISTA DE RESERVAS ---");
            var reservas = gestor.ObtenerReservas();
            if (reservas.Count == 0)
            {
                Console.WriteLine("No hay reservas registradas.");
                return;
            }
            foreach (var r in reservas)
            {
                Console.WriteLine(r);
            }
        }

        private static void CancelarReservaPrompt(GestorReservas gestor)
        {
            VerReservas(gestor);
            Console.Write("\nIngrese el ID de la reserva a cancelar: ");
            if (int.TryParse(Console.ReadLine(), out int idReserva))
            {
                gestor.CancelarReserva(idReserva);
            }
        }
    }
}