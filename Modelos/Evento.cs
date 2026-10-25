using System;

namespace PLANAZO_POO_CSharp.Modelos
{
    public abstract class Evento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public decimal PrecioBase { get; set; }
        public int CapacidadMaxima { get; set; }
        public int CuposDisponibles { get; set; }

        protected Evento(int id, string nombre, DateTime fecha, decimal precioBase, int capacidadMaxima)
        {
            Id = id;
            Nombre = nombre;
            Fecha = fecha;
            PrecioBase = precioBase;
            CapacidadMaxima = capacidadMaxima;
            CuposDisponibles = capacidadMaxima;
        }

        public abstract decimal CalcularPrecioFinal();

        public override string ToString()
        {
            return $"[{Id}] {Nombre} | Fecha: {Fecha:yyyy-MM-dd} | Precio Base: ${PrecioBase:N0} | Precio Final: ${CalcularPrecioFinal():N0} | Cupos: {CuposDisponibles}/{CapacidadMaxima}";
        }
    }
}