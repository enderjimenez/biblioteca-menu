using BibliotecaMen.Models;
namespace BibliotecaMenu.Models
{
    public class Prestamo
    {
        // Propiedades de la entidad Prestamo
        public int Id { get; set; }
        public Libro LibroPrestado { get; set; } = null!;
        public Usuario UsuarioLector { get; set; } = null!;
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaLimite { get; set; }
        public DateTime? FechaDevolucion { get; set; } = null; 
        public EstadoPrestamo Estado { get; set; } = EstadoPrestamo.Activo; 

        // Constructor vacío
        public Prestamo()
        {
            Estado = EstadoPrestamo.Activo;
            FechaDevolucion = null;
        }

        // Constructor completo
        public Prestamo(int id, Libro libro, Usuario usuario, DateTime fechaPrestamo, DateTime fechaLimite)
        {
            Id = id;
            LibroPrestado = libro;
            UsuarioLector = usuario;
            FechaPrestamo = fechaPrestamo;
            FechaLimite = fechaLimite;
            FechaDevolucion = null;
            Estado = EstadoPrestamo.Activo;
        }

        //  Métodos EstaVencido

       // Método: Evalúa si la fecha actual ya superó la fecha límite sin haberse devuelto
        public bool EstaVencido()
        {
            if (Estado == EstadoPrestamo.Devuelto) return false;
            return DateTime.Now > FechaLimite;
        }

        // Método: Calcula los días transcurridos desde que se prestó
        public int DiasTranscurridos()
        {
            DateTime fechaFin = FechaDevolucion ?? DateTime.Now;
            return (fechaFin - FechaPrestamo).Days;
        }

        // Método: Resumen corto
        public string ResumenCorto()
        {
            return $"Préstamo #{Id} | Libro: \"{LibroPrestado?.Titulo}\" | Usuario: {UsuarioLector?.Nombre} | Estado: {Estado}";
        }

        // Método: Detalle completo
        public string DetalleCompleto()
        {
            string dev = FechaDevolucion.HasValue ? FechaDevolucion.Value.ToString("yyyy-MM-dd") : "Pendiente";
            return $"--- DETALLE PRÉSTAMO #{Id} ---\n" +
                   $"Libro: {LibroPrestado?.Titulo} (ID Libro: {LibroPrestado?.Id})\n" +
                   $"Usuario: {UsuarioLector?.Nombre} (Doc: {UsuarioLector?.Documento})\n" +
                   $"Fecha Préstamo: {FechaPrestamo:yyyy-MM-dd}\n" +
                   $"Fecha Límite: {FechaLimite:yyyy-MM-dd}\n" +
                   $"Fecha Devolución: {dev}\n" +
                   $"Estado: {Estado}\n" +
                   $"¿Está Vencido?: {(EstaVencido() ? "Sí" : "No")}\n" +
                   $"Días Transcurridos: {DiasTranscurridos()} días";
        }

        // Sobrecarga de ToString
        public override string ToString()
        {
            return ResumenCorto();
        }
    }
}