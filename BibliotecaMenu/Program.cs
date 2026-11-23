using System;
using System.Collections.Generic;
using BibliotecaMen.Models;
using BibliotecaMenu.Models;
using BibliotecaMenu.Services;

namespace BibliotecaMenu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CompararArrayVsList();
            ProbarCapaServicios();

            Console.WriteLine("\n=======================================================");
            Console.WriteLine("Pruebas de EV08 finalizadas. Presione una tecla...");
            Console.ReadKey();
        }

        // PUNTO 7: Comparación obligatoria entre Array y List<T>
        static void CompararArrayVsList()
        {
            Console.Clear();
            Console.WriteLine("=======================================================");
            Console.WriteLine("       1. COMPARACIÓN: ARRAY VS. LIST<T>               ");
            Console.WriteLine("=======================================================\n");

            // EJEMPLO CON ARRAY (Tamaño fijo)

            // Un array exige definir su capacidad exacta desde el inicio (en este caso, 2 espacios).
            // No tiene métodos .Add() ni .Remove(); si queremos un tercer libro, toca crear otro array nuevo.

            Libro[] arregloLibros = new Libro[2];
            arregloLibros[0] = new Libro(1, "978-0131103627", "C Programming Language", "Kernighan & Ritchie", "Programación", true);
            arregloLibros[1] = new Libro(2, "978-0321765723", "The C++ Programming Language", "Bjarne Stroustrup", "Programación", true);

            Console.WriteLine($"[Array] Capacidad fija: {arregloLibros.Length} elementos.");

            foreach (var libro in arregloLibros)
            {
                Console.WriteLine($"  - {libro.ResumenCorto()}");
            }

            // MISMO EJEMPLO CON LIST<T> (Tamaño dinámico)

            // Una List<T> nace vacía y crece o se reduce dinámicamente en tiempo de ejecución.
            // Ofrece métodos integrados como .Add(), .Remove(), .Count y consultas con LINQ.

            List<Libro> listaLibros = new List<Libro>();
            listaLibros.Add(new Libro(1, "978-0131103627", "C Programming Language", "Kernighan & Ritchie", "Programación", true));
            listaLibros.Add(new Libro(2, "978-0321765723", "The C++ Programming Language", "Bjarne Stroustrup", "Programación", true));
            listaLibros.Add(new Libro(3, "978-0132350884", "Clean Code", "Robert C. Martin", "Ingeniería de Software", true));

            Console.WriteLine($"\n[List<T>] Tamaño dinámico actual: {listaLibros.Count} elementos (creció sin límite fijo).");
            foreach (var libro in listaLibros)
            {
                Console.WriteLine($"  - {libro.ResumenCorto()}");
            }

            Console.WriteLine("\nDiferencia clave: El Array tiene longitud inmutable en memoria (Length), " +
                              "mientras que List<T> redimensiona su capacidad automáticamente y facilita búsquedas/filtros.");
        }

        // PUNTO 8: Prueba completa de los servicios, búsquedas, ordenaciones y KPIs
        static void ProbarCapaServicios()
        {
            Console.WriteLine("\n=======================================================");
            Console.WriteLine("       2. PRUEBA DE CAPA SERVICES Y KPIS (EV08)        ");
            Console.WriteLine("=======================================================\n");

            // 1. Instanciar los tres servicios

            LibroServices libroService = new LibroServices();
            UsuarioService usuarioService = new UsuarioService();
            PrestamoService prestamoService = new PrestamoService();

            // 2. Agregar datos de prueba a cada servicio

            Libro l1 = new Libro(1, "978-0132350884", "Clean Code", "Robert C. Martin", "Arquitectura", false);
            Libro l2 = new Libro(2, "978-0201616224", "The Pragmatic Programmer", "Andrew Hunt", "Desarrollo", true);
            Libro l3 = new Libro(3, "978-0131103627", "C Programming Language", "Dennis Ritchie", "Lenguajes", false);
            Libro l4 = new Libro(4, "978-1491950357", "Designing Data-Intensive Applications", "Martin Kleppmann", "Bases de Datos", true);

            libroService.AgregarLibro(l1);
            libroService.AgregarLibro(l2);
            libroService.AgregarLibro(l3);
            libroService.AgregarLibro(l4);

            Usuario u1 = new Usuario(101, "10203040", "Ender Jiménez", "enderst2019@gail.com", true);
            Usuario u2 = new Usuario(102, "50607080", "Sebastián Serna", "sebastian@email.com", true);
            Usuario u3 = new Usuario(103, "90102030", "Carlos Pérez", "carlos@email.com", false);

            usuarioService.AgregarUsuario(u1);
            usuarioService.AgregarUsuario(u2);
            usuarioService.AgregarUsuario(u3);

            // Préstamo 1: Activo (prestado hace 3 días, vence en 4 días)
            Prestamo p1 = new Prestamo(501, l1, u1, DateTime.Now.AddDays(-3), DateTime.Now.AddDays(4));

            // Préstamo 2: Vencido por fecha límite (prestado hace 12 días, venció hace 2 días)
            Prestamo p2 = new Prestamo(502, l3, u2, DateTime.Now.AddDays(-12), DateTime.Now.AddDays(-2));

            // Préstamo 3: Devuelto (prestado hace 8 días, devuelto hace 2 días -> 6 días de uso)
            Prestamo p3 = new Prestamo(503, l2, u1, DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-1));
            p3.FechaDevolucion = DateTime.Now.AddDays(-2);
            p3.Estado = EstadoPrestamo.Devuelto;

            prestamoService.AgregarPrestamo(p1);
            prestamoService.AgregarPrestamo(p2);
            prestamoService.AgregarPrestamo(p3);

            // 3. Ejecutar Búsquedas
            Console.WriteLine("--- BÚSQUEDAS ---");
            Libro? busqIsbn = libroService.BuscarPorIsbn("978-0201616224");
            Console.WriteLine($"Libro por ISBN (978-0201616224): {busqIsbn?.ResumenCorto() ?? "No encontrado"}");

            Usuario? busqDoc = usuarioService.BuscarPorDocumento("10203040");
            Console.WriteLine($"Usuario por Documento (10203040): {busqDoc?.ResumenCorto() ?? "No encontrado"}");

            var prestamosDevueltos = prestamoService.BuscarPorEstado(EstadoPrestamo.Devuelto);
            Console.WriteLine($"Préstamos encontrados en estado Devuelto: {prestamosDevueltos.Count}");

            // 4. Ejecutar Ordenaciones
            Console.WriteLine("\n--- ORDENACIONES ---");
            Console.WriteLine("Libros ordenados alfabéticamente por título:");
            foreach (var libro in libroService.OrdenarPorTitulo())
            {
                Console.WriteLine($"  * {libro.ResumenCorto()}");
            }

            Console.WriteLine("\nUsuarios ordenados alfabéticamente por nombre:");
            foreach (var usuario in usuarioService.OrdenarPorNombre())
            {
                Console.WriteLine($"  * {usuario.ResumenCorto()}");
            }

            Console.WriteLine("\nPréstamos ordenados por fecha límite (más próxima primero):");
            foreach (var prestamo in prestamoService.OrdenarPorFechaLimite())
            {
                Console.WriteLine($"  * {prestamo.ResumenCorto()} | Límite: {prestamo.FechaLimite:yyyy-MM-dd}");
            }

            // 5. Ejecutar KPIs y Estadísticas
            Console.WriteLine("\n--- KPIS Y ESTADÍSTICAS ---");
            Console.WriteLine($"[Libros] Total: {libroService.ObtenerTotalLibros()} | " +
                              $"Disponibles: {libroService.ObtenerLibrosDisponibles()} | " +
                              $"Prestados: {libroService.ObtenerLibrosPrestados()}");

            Console.WriteLine($"[Usuarios] Total: {usuarioService.ObtenerTotalUsuarios()} | " +
                              $"Activos: {usuarioService.ObtenerUsuariosActivos()} | " +
                              $"Inactivos: {usuarioService.ObtenerUsuariosInactivos()}");

            Console.WriteLine($"[Préstamos] Total: {prestamoService.ObtenerTotalPrestamos()} | " +
                              $"Activos: {prestamoService.ObtenerPrestamosActivos()} | " +
                              $"Vencidos: {prestamoService.ObtenerPrestamosVencidos()} | " +
                              $"Devueltos: {prestamoService.ObtenerPrestamosDevueltos()} | " +
                              $"Promedio días: {prestamoService.ObtenerPromedioDiasPrestamo():F1} días");
        }
    }
}