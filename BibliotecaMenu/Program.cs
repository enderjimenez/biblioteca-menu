using System;
using System.Collections.Generic;
using System.Linq;
using BibliotecaMen.Models;
using BibliotecaMenu.Models;
using BibliotecaMenu.Services;

namespace BibliotecaMenu
{
    internal class Program
    {
        // Instancias globales de la capa Services
        static LibroServices libroService = new LibroServices();
        static UsuarioService usuarioService = new UsuarioService();
        static PrestamoService prestamoService = new PrestamoService();

        static void Main(string[] args)
        {
            CargarDatosIniciales();

            bool ejecutando = true;
            while (ejecutando)
            {
                Console.Clear();
                Console.WriteLine("=======================================================");
                Console.WriteLine("         SISTEMA DE GESTIÓN DE BIBLIOTECA (POO)        ");
                Console.WriteLine("=======================================================");
                Console.WriteLine("1. Gestión de Libros");
                Console.WriteLine("2. Gestión de Usuarios");
                Console.WriteLine("3. Gestión de Préstamos y Devoluciones");
                Console.WriteLine("4. Reportes y KPIs del Sistema");
                Console.WriteLine("0. Salir");
                Console.WriteLine("-------------------------------------------------------");
                Console.Write("Seleccione una opción: ");

                string? opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        MenuLibros();
                        break;
                    case "2":
                        MenuUsuarios();
                        break;
                    case "3":
                        MenuPrestamos();
                        break;
                    case "4":
                        MostrarKpisGenerales();
                        break;
                    case "0":
                        ejecutando = false;
                        Console.WriteLine("\nSaliendo del sistema...");
                        break;
                    default:
                        Console.WriteLine("\nOpción no válida.");
                        Pausar();
                        break;
                }
            }
        }

        // Datos semilla para que el sistema arranque con registros listos para probar
        static void CargarDatosIniciales()
        {
            Libro l1 = new Libro(1, "978-0132350884", "Clean Code", "Robert C. Martin", "Ingeniería de Software", false);
            Libro l2 = new Libro(2, "978-0201616224", "The Pragmatic Programmer", "Andrew Hunt", "Desarrollo", true);
            Libro l3 = new Libro(3, "978-0131103627", "C Programming Language", "Kernighan & Ritchie", "Lenguajes", true);

            libroService.AgregarLibro(l1);
            libroService.AgregarLibro(l2);
            libroService.AgregarLibro(l3);

            Usuario u1 = new Usuario(101, "10203040", "Ender Jiménez", "enderst2019@gail.com", true);
            Usuario u2 = new Usuario(102, "50607080", "Sebastián Serna", "sebastian@email.com", true);
            Usuario u3 = new Usuario(103, "90102030", "Carlos Pérez", "carlos@email.com", false);

            usuarioService.AgregarUsuario(u1);
            usuarioService.AgregarUsuario(u2);
            usuarioService.AgregarUsuario(u3);

            // Préstamo activo asociado al libro 1 (por eso l1 nace con disponible = false)
            Prestamo p1 = new Prestamo(501, l1, u1, DateTime.Now.AddDays(-3), DateTime.Now.AddDays(4));
            prestamoService.AgregarPrestamo(p1);
        }

        // =======================================================
        // SUBMENÚ 1: LIBROS
        // =======================================================
        static void MenuLibros()
        {
            bool volver = false;
            while (!volver)
            {
                Console.Clear();
                Console.WriteLine("=== GESTIÓN DE LIBROS ===");
                Console.WriteLine("1. Registrar nuevo libro");
                Console.WriteLine("2. Listar todos los libros");
                Console.WriteLine("3. Listar libros ordenados por título");
                Console.WriteLine("4. Buscar libro por ISBN");
                Console.WriteLine("5. Buscar libros por título o autor");
                Console.WriteLine("6. Eliminar libro por ID");
                Console.WriteLine("0. Volver al menú principal");
                Console.Write("\nSeleccione una opción: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        RegistrarLibro();
                        break;
                    case "2":
                        MostrarListaLibros(libroService.ObtenerTodos(), "LISTADO DE LIBROS");
                        break;
                    case "3":
                        MostrarListaLibros(libroService.OrdenarPorTitulo(), "LIBROS ORDENADOS POR TÍTULO");
                        break;
                    case "4":
                        Console.Write("\nIngrese ISBN a buscar: ");
                        string isbn = Console.ReadLine() ?? "";
                        Libro? encontrado = libroService.BuscarPorIsbn(isbn);
                        Console.WriteLine(encontrado != null ? $"\n{encontrado.DetalleCompleto()}" : "\nLibro no encontrado.");
                        Pausar();
                        break;
                    case "5":
                        Console.Write("\nIngrese término de búsqueda (título o autor): ");
                        string texto = Console.ReadLine() ?? "";
                        var porTitulo = libroService.BuscarPorTitulo(texto);
                        var porAutor = libroService.BuscarPorAutor(texto);
                        var combinados = porTitulo.Union(porAutor).ToList();
                        MostrarListaLibros(combinados, $"RESULTADOS PARA '{texto}'");
                        break;
                    case "6":
                        Console.Write("\nIngrese ID del libro a eliminar: ");
                        if (int.TryParse(Console.ReadLine(), out int idEliminar))
                        {
                            bool eliminado = libroService.EliminarLibro(idEliminar);
                            Console.WriteLine(eliminado ? "Libro eliminado correctamente." : "No se encontró un libro con ese ID.");
                        }
                        else
                        {
                            Console.WriteLine("ID inválido.");
                        }
                        Pausar();
                        break;
                    case "0":
                        volver = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        Pausar();
                        break;
                }
            }
        }

        static void RegistrarLibro()
        {
            Console.WriteLine("\n--- REGISTRAR LIBRO ---");
            Console.Write("ID numérico: ");
            if (!int.TryParse(Console.ReadLine(), out int id) || libroService.ObtenerTodos().Any(l => l.Id == id))
            {
                Console.WriteLine("ID inválido o ya existente.");
                Pausar();
                return;
            }

            Console.Write("ISBN: ");
            string isbn = Console.ReadLine() ?? "";
            Console.Write("Título: ");
            string titulo = Console.ReadLine() ?? "";
            Console.Write("Autor: ");
            string autor = Console.ReadLine() ?? "";
            Console.Write("Categoría: ");
            string categoria = Console.ReadLine() ?? "";

            Libro nuevo = new Libro(id, isbn, titulo, autor, categoria, true);
            libroService.AgregarLibro(nuevo);
            Console.WriteLine("\nLibro registrado exitosamente.");
            Pausar();
        }

        static void MostrarListaLibros(List<Libro> lista, string tituloEncabezado)
        {
            Console.WriteLine($"\n--- {tituloEncabezado} ({lista.Count}) ---");
            if (lista.Count == 0)
            {
                Console.WriteLine("No hay libros para mostrar.");
            }
            else
            {
                foreach (var libro in lista)
                {
                    Console.WriteLine($"  * {libro.ResumenCorto()}");
                }
            }
            Pausar();
        }

        // =======================================================
        // SUBMENÚ 2: USUARIOS
        // =======================================================
        static void MenuUsuarios()
        {
            bool volver = false;
            while (!volver)
            {
                Console.Clear();
                Console.WriteLine("=== GESTIÓN DE USUARIOS ===");
                Console.WriteLine("1. Registrar nuevo usuario");
                Console.WriteLine("2. Listar todos los usuarios");
                Console.WriteLine("3. Listar usuarios ordenados por nombre");
                Console.WriteLine("4. Buscar usuario por documento");
                Console.WriteLine("5. Buscar usuarios por nombre");
                Console.WriteLine("6. Eliminar usuario por ID");
                Console.WriteLine("0. Volver al menú principal");
                Console.Write("\nSeleccione una opción: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        RegistrarUsuario();
                        break;
                    case "2":
                        MostrarListaUsuarios(usuarioService.ObtenerTodos(), "LISTADO DE USUARIOS");
                        break;
                    case "3":
                        MostrarListaUsuarios(usuarioService.OrdenarPorNombre(), "USUARIOS ORDENADOS POR NOMBRE");
                        break;
                    case "4":
                        Console.Write("\nIngrese documento a buscar: ");
                        string doc = Console.ReadLine() ?? "";
                        Usuario? encontrado = usuarioService.BuscarPorDocumento(doc);
                        Console.WriteLine(encontrado != null ? $"\n{encontrado.DetalleCompleto()}" : "\nUsuario no encontrado.");
                        Pausar();
                        break;
                    case "5":
                        Console.Write("\nIngrese nombre a buscar: ");
                        string nombre = Console.ReadLine() ?? "";
                        MostrarListaUsuarios(usuarioService.BuscarPorNombre(nombre), $"RESULTADOS PARA '{nombre}'");
                        break;
                    case "6":
                        Console.Write("\nIngrese ID del usuario a eliminar: ");
                        if (int.TryParse(Console.ReadLine(), out int idEliminar))
                        {
                            bool eliminado = usuarioService.EliminarUsuario(idEliminar);
                            Console.WriteLine(eliminado ? "Usuario eliminado correctamente." : "No se encontró un usuario con ese ID.");
                        }
                        else
                        {
                            Console.WriteLine("ID inválido.");
                        }
                        Pausar();
                        break;
                    case "0":
                        volver = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        Pausar();
                        break;
                }
            }
        }

        static void RegistrarUsuario()
        {
            Console.WriteLine("\n--- REGISTRAR USUARIO ---");
            Console.Write("ID numérico: ");
            if (!int.TryParse(Console.ReadLine(), out int id) || usuarioService.ObtenerTodos().Any(u => u.Id == id))
            {
                Console.WriteLine("ID inválido o ya existente.");
                Pausar();
                return;
            }

            Console.Write("Documento: ");
            string documento = Console.ReadLine() ?? "";
            Console.Write("Nombre completo: ");
            string nombre = Console.ReadLine() ?? "";
            Console.Write("Correo electrónico: ");
            string correo = Console.ReadLine() ?? "";

            Usuario nuevo = new Usuario(id, documento, nombre, correo, true);
            usuarioService.AgregarUsuario(nuevo);
            Console.WriteLine("\nUsuario registrado exitosamente.");
            Pausar();
        }

        static void MostrarListaUsuarios(List<Usuario> lista, string tituloEncabezado)
        {
            Console.WriteLine($"\n--- {tituloEncabezado} ({lista.Count}) ---");
            if (lista.Count == 0)
            {
                Console.WriteLine("No hay usuarios para mostrar.");
            }
            else
            {
                foreach (var usuario in lista)
                {
                    Console.WriteLine($"  * {usuario.ResumenCorto()}");
                }
            }
            Pausar();
        }

        // =======================================================
        // SUBMENÚ 3: PRÉSTAMOS Y DEVOLUCIONES
        // =======================================================
        static void MenuPrestamos()
        {
            bool volver = false;
            while (!volver)
            {
                Console.Clear();
                Console.WriteLine("=== GESTIÓN DE PRÉSTAMOS Y DEVOLUCIONES ===");
                Console.WriteLine("1. Registrar nuevo préstamo");
                Console.WriteLine("2. Registrar devolución de libro");
                Console.WriteLine("3. Listar todos los préstamos");
                Console.WriteLine("4. Listar préstamos ordenados por fecha límite");
                Console.WriteLine("5. Buscar préstamo por ID");
                Console.WriteLine("6. Filtrar préstamos por estado");
                Console.WriteLine("0. Volver al menú principal");
                Console.Write("\nSeleccione una opción: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        RegistrarPrestamo();
                        break;
                    case "2":
                        RegistrarDevolucion();
                        break;
                    case "3":
                        MostrarListaPrestamos(prestamoService.ObtenerTodos(), "LISTADO DE PRÉSTAMOS");
                        break;
                    case "4":
                        MostrarListaPrestamos(prestamoService.OrdenarPorFechaLimite(), "PRÉSTAMOS ORDENADOS POR FECHA LÍMITE");
                        break;
                    case "5":
                        Console.Write("\nIngrese ID del préstamo: ");
                        if (int.TryParse(Console.ReadLine(), out int idBuscar))
                        {
                            Prestamo? p = prestamoService.BuscarPorId(idBuscar);
                            Console.WriteLine(p != null ? $"\n{p.DetalleCompleto()}" : "\nPréstamo no encontrado.");
                        }
                        else
                        {
                            Console.WriteLine("ID inválido.");
                        }
                        Pausar();
                        break;
                    case "6":
                        FiltrarPrestamosPorEstado();
                        break;
                    case "0":
                        volver = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        Pausar();
                        break;
                }
            }
        }

        static void RegistrarPrestamo()
        {
            Console.WriteLine("\n--- REGISTRAR PRÉSTAMO ---");
            Console.Write("ID del préstamo: ");
            if (!int.TryParse(Console.ReadLine(), out int idPrestamo) || prestamoService.BuscarPorId(idPrestamo) != null)
            {
                Console.WriteLine("ID de préstamo inválido o ya existente.");
                Pausar();
                return;
            }

            Console.Write("ID del libro a prestar: ");
            if (!int.TryParse(Console.ReadLine(), out int idLibro))
            {
                Console.WriteLine("ID de libro inválido.");
                Pausar();
                return;
            }

            Libro? libro = libroService.ObtenerTodos().FirstOrDefault(l => l.Id == idLibro);
            if (libro == null || !libro.Disponible)
            {
                Console.WriteLine("El libro no existe o no se encuentra disponible.");
                Pausar();
                return;
            }

            Console.Write("Documento del usuario lector: ");
            string docUsuario = Console.ReadLine() ?? "";
            Usuario? usuario = usuarioService.BuscarPorDocumento(docUsuario);
            if (usuario == null || !usuario.Activo)
            {
                Console.WriteLine("El usuario no existe o está inactivo.");
                Pausar();
                return;
            }

            Console.Write("Días de plazo para devolución (ej. 7): ");
            if (!int.TryParse(Console.ReadLine(), out int diasPlazo) || diasPlazo <= 0)
            {
                diasPlazo = 7;
            }

            Prestamo nuevoPrestamo = new Prestamo(idPrestamo, libro, usuario, DateTime.Now, DateTime.Now.AddDays(diasPlazo));
            prestamoService.AgregarPrestamo(nuevoPrestamo);

            // Actualizamos disponibilidad del libro
            libro.Disponible = false;

            Console.WriteLine("\nPréstamo registrado correctamente. El libro quedó marcado como no disponible.");
            Pausar();
        }

        static void RegistrarDevolucion()
        {
            Console.WriteLine("\n--- REGISTRAR DEVOLUCIÓN ---");
            Console.Write("Ingrese ID del préstamo a devolver: ");
            if (!int.TryParse(Console.ReadLine(), out int idPrestamo))
            {
                Console.WriteLine("ID inválido.");
                Pausar();
                return;
            }

            Prestamo? prestamo = prestamoService.BuscarPorId(idPrestamo);
            if (prestamo == null)
            {
                Console.WriteLine("Préstamo no encontrado.");
                Pausar();
                return;
            }

            if (prestamo.Estado == EstadoPrestamo.Devuelto)
            {
                Console.WriteLine("Este préstamo ya había sido devuelto previamente.");
                Pausar();
                return;
            }

            prestamo.FechaDevolucion = DateTime.Now;
            prestamo.Estado = EstadoPrestamo.Devuelto;
            if (prestamo.LibroPrestado != null)
            {
                prestamo.LibroPrestado.Disponible = true;
            }

            Console.WriteLine("\nDevolución procesada. El libro vuelve a estar disponible.");
            Pausar();
        }

        static void FiltrarPrestamosPorEstado()
        {
            Console.WriteLine("\nSeleccione el estado: 1. Activo | 2. Devuelto | 3. Vencido");
            string? op = Console.ReadLine();
            EstadoPrestamo estado = op switch
            {
                "2" => EstadoPrestamo.Devuelto,
                "3" => EstadoPrestamo.Vencido,
                _ => EstadoPrestamo.Activo
            };

            var filtrados = prestamoService.BuscarPorEstado(estado);
            MostrarListaPrestamos(filtrados, $"PRÉSTAMOS EN ESTADO: {estado}");
        }

        static void MostrarListaPrestamos(List<Prestamo> lista, string tituloEncabezado)
        {
            Console.WriteLine($"\n--- {tituloEncabezado} ({lista.Count}) ---");
            if (lista.Count == 0)
            {
                Console.WriteLine("No hay préstamos para mostrar.");
            }
            else
            {
                foreach (var p in lista)
                {
                    Console.WriteLine($"  * {p.ResumenCorto()} | Límite: {p.FechaLimite:yyyy-MM-dd} | Vencido: {(p.EstaVencido() ? "Sí" : "No")}");
                }
            }
            Pausar();
        }

        // =======================================================
        // OPCIÓN 4: REPORTES Y KPIS
        // =======================================================
        static void MostrarKpisGenerales()
        {
            Console.Clear();
            Console.WriteLine("=======================================================");
            Console.WriteLine("            REPORTES Y KPIS DEL SISTEMA                ");
            Console.WriteLine("=======================================================\n");

            Console.WriteLine("[INVENTARIO DE LIBROS]");
            Console.WriteLine($"  * Total de libros:       {libroService.ObtenerTotalLibros()}");
            Console.WriteLine($"  * Libros disponibles:    {libroService.ObtenerLibrosDisponibles()}");
            Console.WriteLine($"  * Libros prestados:      {libroService.ObtenerLibrosPrestados()}\n");

            Console.WriteLine("[COMUNIDAD DE USUARIOS]");
            Console.WriteLine($"  * Total de usuarios:     {usuarioService.ObtenerTotalUsuarios()}");
            Console.WriteLine($"  * Usuarios activos:      {usuarioService.ObtenerUsuariosActivos()}");
            Console.WriteLine($"  * Usuarios inactivos:    {usuarioService.ObtenerUsuariosInactivos()}\n");

            Console.WriteLine("[MOVIMIENTO DE PRÉSTAMOS]");
            Console.WriteLine($"  * Total de préstamos:    {prestamoService.ObtenerTotalPrestamos()}");
            Console.WriteLine($"  * Préstamos activos:     {prestamoService.ObtenerPrestamosActivos()}");
            Console.WriteLine($"  * Préstamos vencidos:    {prestamoService.ObtenerPrestamosVencidos()}");
            Console.WriteLine($"  * Préstamos devueltos:   {prestamoService.ObtenerPrestamosDevueltos()}");
            Console.WriteLine($"  * Promedio de días:      {prestamoService.ObtenerPromedioDiasPrestamo():F1} días\n");

            // Comparación obligatoria Array vs List<T> integrada como diagnóstico del sistema
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("[DIAGNÓSTICO DE ESTRUCTURAS: ARRAY VS. LIST<T>]");

            // 1. Ejemplo con Array (capacidad estática fija)
            Libro[] muestraArray = new Libro[2];
            muestraArray[0] = new Libro(901, "978-0131103627", "C Programming Language", "Kernighan & Ritchie", "Lenguajes", true);
            muestraArray[1] = new Libro(902, "978-0321765723", "The C++ Programming Language", "Bjarne Stroustrup", "Lenguajes", true);

            // 2. Mismo ejemplo con List<T> (colección dinámica utilizada en los Services)
            List<Libro> muestraLista = new List<Libro>(muestraArray);
            muestraLista.Add(new Libro(903, "978-0132350884", "Clean Code", "Robert C. Martin", "Arquitectura", true));

            Console.WriteLine($"  * Array fijo (Libro[]):      Capacidad estática de {muestraArray.Length} espacios (no admite .Add ni .Remove).");
            Console.WriteLine($"  * Lista dinámica (List<T>):  Creció dinámicamente a {muestraLista.Count} elementos y soporta consultas LINQ.");
            Console.WriteLine("  * Conclusión técnica:        Los Services usan List<T> porque el catálogo crece en tiempo de ejecución.\n");

            Pausar();
        }
        static void Pausar()
        {
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}