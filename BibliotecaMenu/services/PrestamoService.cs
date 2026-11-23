using System;
using System.Collections.Generic;
using System.Linq;
using BibliotecaMenu.Models;

namespace BibliotecaMenu.Services
{
    public class PrestamoService
    {
        //coleccion dinamica 
        private List<Prestamo> prestamos = new List<Prestamo>();

        // Operaciones basicas
        public void AgregarPrestamo(Prestamo prestamo)
        {
            prestamos.Add(prestamo);
        }

        public bool EliminarPrestamo(int id)
        {
            Prestamo? prestamoEncontrado = prestamos.FirstOrDefault(p => p.Id == id);
            if (prestamoEncontrado != null)
            {
                prestamos.Remove(prestamoEncontrado);
                return true;
            }
            return false;
        }

        // Búsquedas (por ID o estado)

        public Prestamo? BusquedaPorId(int id)
        {
            return prestamos.FirstOrDefault(p => p.Id == id);
        }

        public List<Prestamo> BuscarPorEstado(EstadoPrestamo estado)
        {
            return prestamos
                .Where(p => p.Estado == estado)
                .ToList();
        }

        // Ordenación (por fecha límite)
        public List<Prestamo> OrdenarPorFechaLimite()
        {
            return prestamos.OrderBy(p => p.FechaLimite).ToList();
        }
    }
}