using System;
using System.Collections.Generic;
using System.Text;

namespace Veterinaria.Entidades
{
    public class Mascota
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Especie { get; set; }
        public int Edad { get; set; }
    }
}