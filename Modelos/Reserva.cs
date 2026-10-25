using System;

namespace PLANAZO_POO_CSharp.Modelos
{
    public class Reserva
    {
        public int IdReserva { get; set; }
        public string NombrePersona { get; set; }
        public Evento EventoReservado { get; set; }
        public int CantidadeEntradas { get; set; }
        public decimal ValorTotal { get; set; }
        public bool Activa { get; set; }

        public Reserva(int idReserva, string nombrePersona, Evento eventoReservado, int cantidadEntradas)
        {
            IdReserva = idReserva;
            NombrePersona = nombrePersona;
            EventoReservado = eventoReservado;
            CantidadeEntradas = cantidadEntradas;
            ValorTotal = eventoReservado.CalcularPrecioFinal() * cantidadEntradas;
            Activa = true;
        }

        public override string ToString()
        {
            string estado = Activa ? "Activa" : "Cancelada";
            return $"Reserva #{IdReserva} | Persona: {NombrePersona} | Evento: {EventoReservado.Nombre} | Entradas: {CantidadeEntradas} | Total: ${ValorTotal:N0} | Estado: {estado}";
        }
    }
}