using System;

namespace PLANAZO_POO_CSharp.Modelos
{
    public class Taller : Evento
    {
        public string Categoria { get; set; }

        public Taller(int id, string nombre, DateTime fecha, decimal precioBase, int capacidadMaxima, string categoria)
            : base(id, nombre, fecha, precioBase, capacidadMaxima)
        {
            Categoria = categoria;
        }

        public override decimal CalcularPrecioFinal()
        {
            return PrecioBase * 0.90m;
        }
    }
}