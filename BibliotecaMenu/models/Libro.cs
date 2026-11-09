namespace BibliotecaMenu.Models
{
    public class Libro
    {
        // 1. Propiedades automáticas - ATRIBUTOS
        public int Id {get; set;}
        public string Isbn { get; set;} = string.Empty;
        public string Titulo {get; set;} = string.Empty;
        public string Autor {get; set;} = string.Empty;
        public string Categoria {get; set;} = string.Empty;
        public bool Disponible {get; set;} = true;

        // Constructo vacio

        public Libro()
        {
            Disponible = true;
        }

        // Constructo Completo

        public Libro(int id, string isbn, string titulo, string autor, string categoria, bool disponible)
        {
            Id = id;
            Isbn = isbn;
            Titulo = titulo;
            Autor = autor;
            Categoria = categoria;
            Disponible = disponible;
        }

        // Metodo - Resumen 

        public string ResumenCorto()
        {
            string estado = Disponible ? "Disponible" : "Prestado";
            return $"[{Id}] \"{Titulo}\" -{Autor} ({estado})";
        }

        // Metodo - Detalle Completo

        public string DetalleCompleto()
        {
            return $"ID: {Id}\nISBN: {Isbn}\nTítulo: {Titulo}\nAutor: {Autor}\nCategoría: {Categoria}\nEstado: {(Disponible ? "Disponible" : "Prestado")}";
        }

        // Sobrecarga de ToString
        public override string ToString()
        {
            return ResumenCorto();
        }
    }
}