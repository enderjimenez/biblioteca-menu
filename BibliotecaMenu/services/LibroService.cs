using System;
using System.Collections.Generic;
using System.Linq;
using BibliotecaMenu.Models;

namespace BibliotecaMenu.Services
{
    public class LibroServices
    {
        private List<Libro> libros = new List<Libro>();

        // Operaciones Basicas

        // Operacion para agregar
        public void AgregarLibro(Libro libro)
        {
            libros.Add(libro);
        }

        // Operación para eliminar
        public bool EliminarLibro(int id)
        {
            Libro ? libroEncontrado = libros.FirstOrDefault(l => l.Id == id);
            if(libroEncontrado != null)
            {
                libros.Remove(libroEncontrado);
                return true;
            }
            return false;
        }

        // Operación obtener todo

        public List<Libro> ObtenerTodos()
        {
            return libros;
        }

        // Busquedas

        public Libro? BuscarPorIsbn(string isnb)
        {
            return libros.FirstOrDefault(l => l.Isbn.Equals(isnb,  StringComparison.OrdinalIgnoreCase));
        }

        public List<Libro> BuscarPorTitulo(string titulo)
        {
            return libros.Where(l => l.Titulo.Contains(titulo, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Libro> BuscarPorAutor(string autor)
        {
            return libros
                .Where(l => l.Autor.Contains(autor, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        // Ordenación
        public List<Libro> OrdenarPorTitulo()
        {
            return libros.OrderBy(l => l.Titulo).ToList();
        }
    }
}