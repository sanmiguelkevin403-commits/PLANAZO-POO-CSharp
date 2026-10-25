using System;

namespace PLANAZO_POO_CSharp.Modelos
{
    public class Concierto : Evento
    {
        public string Artista { get; set; }

        public Concierto(int id, string nombre, DateTime fecha, decimal precioBase, int capacidadMaxima, string artista)
            : base(id, nombre, fecha, precioBase, capacidadMaxima)
        {
            Artista = artista;
        }

        public override decimal CalcularPrecioFinal()
        {
            return PrecioBase * 1.15m;
        }
    }
}