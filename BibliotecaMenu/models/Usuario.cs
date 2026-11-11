namespace BibliotecaMen.Models
{
    public class Usuario
    {
        public int Id {get; set;}
        public string Documento {get; set;} = string.Empty;
        public string Nombre {get; set;} = string.Empty;
        public string Correo {get; set;} = string.Empty;
        public bool Activo {get; set;} = true;

        // Contructor vacio

        public Usuario()
        {
            Activo = true;
        }

        // Constructor Completo

        public Usuario(int id, string documento, string nombre, string correo, bool activo)
        {
            Id = id;
            Documento = documento;
            Nombre = nombre;
            Correo = correo;
            Activo = activo;

        }

        // Método: Resumen corto
        public string ResumenCorto()
        {
            string estado = Activo ? "Activo" : "Inactivo";
            return $"[{Id}] {Nombre} (Doc: {Documento}) - {estado}";
        }

        // Método: Detalle completo
        public string DetalleCompleto()
        {
            return $"ID: {Id}\nDocumento: {Documento}\nNombre: {Nombre}\nCorreo: {Correo}\nEstado: {(Activo ? "Activo" : "Inactivo")}";
        }

        // Sobrecarga de ToString
        public override string ToString()
        {
            return ResumenCorto();
        }
    }
}