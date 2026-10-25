using System;

namespace PLANAZO_POO_CSharp.Modelos
{
    public class Cine : Evento
    {
        public string Director { get; set; }

        public Cine(int id, string nombre, DateTime fecha, decimal precioBase, int capacidadMaxima, string director)
            : base(id, nombre, fecha, precioBase, capacidadMaxima)
        {
            Director = director;
        }

        public override decimal CalcularPrecioFinal()
        {
            return PrecioBase;
        }
    }
}