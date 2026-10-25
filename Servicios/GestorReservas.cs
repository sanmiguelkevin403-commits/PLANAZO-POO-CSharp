using System;
using System.Collections.Generic;
using System.Linq;
using PLANAZO_POO_CSharp.Modelos;

namespace PLANAZO_POO_CSharp.Servicios
{
    public class GestorReservas
    {
        private List<Evento> eventos;
        private List<Reserva> reservas;
        private int contadorReservas = 1;

        public GestorReservas()
        {
            eventos = new List<Evento>();
            reservas = new List<Reserva>();
            InicializarEventos();
        }

        private void InicializarEventos()
        {
            eventos.Add(new Cine(1, "Interestelar - IMAX", DateTime.Now.AddDays(5), 25000m, 50, "Christopher Nolan"));
            eventos.Add(new Cine(2, "El Señor de los Anillos: La Comunidad", DateTime.Now.AddDays(7), 20000m, 40, "Peter Jackson"));

            eventos.Add(new Concierto(3, "Concierto Rock Sinfónico", DateTime.Now.AddDays(10), 60000m, 100, "Orquesta Filarmónica"));
            eventos.Add(new Concierto(4, "Festival Afrobeat & Jazz", DateTime.Now.AddDays(15), 50000m, 80, "BandLab Live"));

            eventos.Add(new Taller(5, "Taller de C# y POO Avanzado", DateTime.Now.AddDays(3), 40000m, 25, "Desarrollo de Software"));
            eventos.Add(new Taller(6, "Taller de Motores Térmicos", DateTime.Now.AddDays(12), 35000m, 20, "Ingeniería Mecánica"));
        }

        public List<Evento> ObtenerEventos() => eventos;

        public Evento BuscarEventoPorId(int id)
        {
            return eventos.FirstOrDefault(e => e.Id == id);
        }

        public void RealizarReserva(string nombrePersona, int eventoId, int cantidadEntradas)
        {
            if (cantidadEntradas <= 0)
            {
                throw new ArgumentException("La cantidad de entradas debe ser mayor a cero.");
            }

            Evento evento = BuscarEventoPorId(eventoId);
            if (evento == null)
            {
                throw new KeyNotFoundException("El evento seleccionado no existe.");
            }

            if (cantidadEntradas > evento.CuposDisponibles)
            {
                throw new InvalidOperationException($"No hay suficientes cupos disponibles. Cupos actuales: {evento.CuposDisponibles}");
            }

            evento.CuposDisponibles -= cantidadEntradas;
            Reserva nuevaReserva = new Reserva(contadorReservas++, nombrePersona, evento, cantidadEntradas);
            reservas.Add(nuevaReserva);

            Console.WriteLine($"\n¡Reserva #{nuevaReserva.IdReserva} realizada con éxito para {nombrePersona}!");
        }

        public List<Reserva> ObtenerReservas() => reservas;

        public void CancelarReserva(int idReserva)
        {
            Reserva reserva = reservas.FirstOrDefault(r => r.IdReserva == idReserva);
            if (reserva == null)
            {
                throw new KeyNotFoundException("La reserva especificada no existe.");
            }

            if (!reserva.Activa)
            {
                throw new InvalidOperationException("Esta reserva ya había sido cancelada previamente.");
            }

            reserva.Activa = false;
            reserva.EventoReservado.CuposDisponibles += reserva.CantidadeEntradas;

            Console.WriteLine($"\nReserva #{idReserva} cancelada exitosamente. Se han devuelto {reserva.CantidadeEntradas} cupos.");
        }

        public void MostrarResumen()
        {
            var activas = reservas.Where(r => r.Activa).ToList();
            int cantidadActivas = activas.Count;
            int totalEntradas = activas.Sum(r => r.CantidadeEntradas);
            decimal valorTotal = activas.Sum(r => r.ValorTotal);

            Console.WriteLine("\n================================");
            Console.WriteLine("     RESUMEN DE RESERVAS        ");
            Console.WriteLine("================================");
            Console.WriteLine($"* Reservas activas: {cantidadActivas}");
            Console.WriteLine($"* Entradas reservadas: {totalEntradas}");
            Console.WriteLine($"* Valor total recaudado: ${valorTotal:N0}");
            Console.WriteLine("================================");
        }
    }
}