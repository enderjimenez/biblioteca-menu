using System;
using System.Collections.Generic;
using System.Linq;
using BibliotecaMen.Models;
using BibliotecaMenu.Models;

namespace BibliotecaMenu.Services
{
    public class UsuarioService
    {
        // Colección dinámica que almacena los usuarios en memoria
        private List<Usuario> usuarios = new List<Usuario>();

        // Operaciones básicas
        public void AgregarUsuario(Usuario usuario)
        {
            usuarios.Add(usuario);
        }

        public bool EliminarUsuario(int id)
        {
            Usuario? usuarioEncontrado = usuarios.FirstOrDefault(u => u.Id == id);
            if (usuarioEncontrado != null)
            {
                usuarios.Remove(usuarioEncontrado);
                return true;
            }
            return false;
        }

        public List<Usuario> ObtenerTodos()
        {
            return usuarios;
        }

        // Búsquedas (por documento o nombre)
        public Usuario? BuscarPorDocumento(string documento)
        {
            return usuarios.FirstOrDefault(u => u.Documento.Equals(documento, StringComparison.OrdinalIgnoreCase));
        }

        public List<Usuario> BuscarPorNombre(string nombre)
        {
            return usuarios
                .Where(u => u.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        // Ordenación (por nombre)
        public List<Usuario> OrdenarPorNombre()
        {
            return usuarios.OrderBy(u => u.Nombre).ToList();
        }
    }
}