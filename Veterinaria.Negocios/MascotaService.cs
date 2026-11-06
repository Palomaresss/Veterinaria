using System;
using System.Collections.Generic;
using System.Linq;
using Veterinaria.Datos;
using Veterinaria.Entidades;

namespace Veterinaria.Negocios
{
    public class MascotaService
    {
        private readonly VeterinariaContext _context;

        public MascotaService(VeterinariaContext context)
        {
            _context = context;
        }

        public void RegistrarMascota(Mascota mascota)
        {
            if (string.IsNullOrWhiteSpace(mascota.Nombre))
            {
                throw new Exception("Error: La mascota debe tener un nombre.");
            }

            if (mascota.Edad < 0)
            {
                throw new Exception("Error: La edad no puede ser negativa.");
            }

            _context.Mascotas.Add(mascota);
            _context.SaveChanges();
        }

        public List<Mascota> ObtenerTodas()
        {
            return _context.Mascotas.ToList();
        }
    }
}