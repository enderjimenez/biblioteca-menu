using System;
using System.Collections.Generic;
using System.Linq;
using BibliotecaMenu.Models;

namespace BibliotecaMenu.Services
{
    public class PrestamoService
    {
        // Colección dinámica
        private List<Prestamo> prestamos = new List<Prestamo>();

        // Operaciones básicas
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

        public List<Prestamo> ObtenerTodos()
        {
            return prestamos;
        }

        // Búsquedas (por ID o estado)
        public Prestamo? BuscarPorId(int id)
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

        // KPIs y estadísticas
        public int ObtenerTotalPrestamos()
        {
            return prestamos.Count;
        }

        public int ObtenerPrestamosActivos()
        {
            return prestamos.Count(p => p.Estado == EstadoPrestamo.Activo && !p.EstaVencido());
        }

        public int ObtenerPrestamosVencidos()
        {
            return prestamos.Count(p => p.Estado == EstadoPrestamo.Vencido || p.EstaVencido());
        }

        public int ObtenerPrestamosDevueltos()
        {
            return prestamos.Count(p => p.Estado == EstadoPrestamo.Devuelto);
        }

        public double ObtenerPromedioDiasPrestamo()
        {
            if (prestamos.Count == 0) return 0;
            return prestamos.Average(p => p.DiasTranscurridos());
        }
    }
}