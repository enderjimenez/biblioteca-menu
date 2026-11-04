using System;
using System.ComponentModel;

class Program
{
    static void Main(String[] args)
    {
        ShowMainMenu();
    }

    // Menú principal de la biblioteca 

    static void ShowMainMenu()
    {
        bool exit = false;
        do
        {
            Console.WriteLine("=== MENU PRINCIPAL ===");
            Console.WriteLine("1. Libros");
            Console.WriteLine("2. Usuarios");
            Console.WriteLine("3. Prestamos");
            Console.WriteLine("4. Búsqueda y reportes");
            Console.WriteLine("5. Guardar / Cargar datos");
            Console.WriteLine("6. Salir");

            String input = Console.ReadLine()!;

            if (int.TryParse(input, out int opcion))
            {
                switch (opcion)
                {
                    case 1:
                        ShowBooksMenu();
                        break;
                    case 2:
                        ShowUsersMenu();
                        break;
                    case 3:
                        ShowLoansMenu();
                        break;
                    case 4:
                        ShowSearchReportsMenu();
                        break;
                    case 5:
                        Console.WriteLine("[Menú de Navegación de GUARDAR Y CARGAR DATOS]");
                        break;
                    case 6:
                        Console.WriteLine("[Menú de Navegación de SALIR]");
                        break;
                    default:
                        Console.WriteLine("[Error] Opción no valida. Por favor, ingrese un número entre 1 y 6.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("\n[Error] Entrada inválida. Debe ingresar un número entero.");
            }

        } while (!exit);
    }

    // MODULO DE LIBROS (feature/books-menu)
    static void ShowBooksMenu()
    {
        bool back = false;

        do
        {
            Console.WriteLine("=== GESTIÓN DE LIBROS ===");
            Console.WriteLine("1. Registrar libro");
            Console.WriteLine("2. Listar Libros");
            Console.WriteLine("3. Ver detalle (por ID/ISBN)");
            Console.WriteLine("4. Actualizar libro");
            Console.WriteLine("5. Eliminar libro");
            Console.WriteLine("0. Volver al menú principal");
            Console.WriteLine("============================");

            String input = Console.ReadLine()!;

            if (int.TryParse(input, out int opcion))
            {
                switch (opcion)
                {
                    case 1:
                        RegisterBook();
                        break;

                    case 2:
                        ListBooksMenu();
                        break;

                    case 3:
                        ViewBookDatail();
                        break;

                    case 4:
                        UpdateBookMenu();
                        break;

                    case 5:
                        DeleteBook();
                        break;

                    case 0:
                        back = true;
                        break;

                    default:
                        Console.WriteLine("[Error] Opción no valida en libros");
                        Pause();
                        break;
                }
            }
            else
            {
                Console.WriteLine("\n[Error] Entrada inválida. Ingrese un número.");
            }

        } while (!back);
    }

    // Suvfunciones de libros

    static void RegisterBook()
    {
        Console.WriteLine("\nEjecutando: Registrar libro...");
        Pause();
    }

    static void ListBooksMenu()
    {
        Console.WriteLine("\nListando libros (Todos / Disponilbles / Prestados)");
        Pause();
    }

    static void ViewBookDatail()
    {
        Console.WriteLine("\nEjecutando: Ver detaller del libro por ID/ISBN...");
        Pause();
    }

    static void UpdateBookMenu()
    {
        bool backUpdate = false;
        do
        {
            Console.Clear();
            Console.WriteLine("--- ACTUALIZAR LIBRO ---");
            Console.WriteLine("1. Editar título");
            Console.WriteLine("2. Editar autor");
            Console.WriteLine("3. Editar año o categoría");
            Console.WriteLine("0. Volver al menú de libros");
            Console.Write("Seleccione una opción: ");

            string input = Console.ReadLine()!;
            if (int.TryParse(input, out int opt))
            {
                if (opt == 1) 
                { 
                    Console.WriteLine("\n[Stub] Editando título del libro..."); 
                    Pause(); 
                }
                else if (opt == 2) 
                { 
                    Console.WriteLine("\n[Stub] Editando autor del libro..."); 
                    Pause(); 
                }
                else if (opt == 3) 
                { 
                    Console.WriteLine("\n[Stub] Editando año o categoría del libro..."); 
                    Pause(); 
                }
                else if (opt == 0) 
                { 
                    backUpdate = true; 
                }
                else 
                { 
                    Console.WriteLine("\n[Error] Opción inválida."); 
                    Pause(); 
                }
            }
            else 
            { 
                Console.WriteLine("\n[Error] Entrada inválida."); 
                Pause(); 
            }
        } while (!backUpdate);
    }

    static void DeleteBook()
    {
        Console.WriteLine("\n Validando: No permitir eliminar si el libro está prestado...");
        Pause();
    }

    static void Pause()
    {
        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    // MÓDULO DE USUARIOS (feature/users-menu)

    static void ShowUsersMenu()
    {
        bool back = false;

        do
        {
            Console.WriteLine(" === GESTIÓN DE USUARIOS ===");
            Console.WriteLine("1. Registrar usuario");
            Console.WriteLine("2. Listar usuarios");
            Console.WriteLine("3. Ver detalle (por ID/documento)");
            Console.WriteLine("4. Actualizar usuario");
            Console.WriteLine("5. Eliminar usuario");
            Console.WriteLine("0. Volver al menú principal");
            Console.WriteLine("============================");

            String input = Console.ReadLine()!;

            if (int.TryParse(input, out int opcion))
            {
                switch (opcion)
                {
                    case 1:
                        RegisterUser();
                        break;
                    case 2:
                        ListUsers();
                        break;
                    case 3:
                        ViewUserDetail();
                        break;
                    case 4:
                        UpdateUserMenu();
                        break;
                    case 5:
                        DeleteUser();
                        break;
                    case 0:
                        back = true; // Regresa al menú principal
                        break;
                    default:
                        Console.WriteLine("\n[Error] Opción no válida en Usuarios.");
                        Pause();
                        break;
                }
            }
            else
            {
                Console.WriteLine("\n[Error] Entrada inválida. Ingrese un número.");
                Pause();
            }
        } while (!back);
    }

    // Subfunciones de Usuarios (Stubs / Mensajes descriptivos)
    static void RegisterUser()
    {
        Console.WriteLine("\n[Stub] Ejecutando: Registrar usuario...");
        Pause();
    }

    static void ListUsers()
    {
        Console.WriteLine("\n[Stub] Ejecutando: Listar usuarios registrados...");
        Pause();
    }

    static void ViewUserDetail()
    {
        Console.WriteLine("\n[Stub] Ejecutando: Ver detalle de usuario por ID o documento...");
        Pause();
    }

    static void UpdateUserMenu()
    {
        bool backUpdate = false;
        do
        {

            Console.WriteLine("--- ACTUALIZAR USUARIO ---");
            Console.WriteLine("1. Editar nombre");
            Console.WriteLine("2. Editar contacto");
            Console.WriteLine("3. Activar / Desactivar usuario");
            Console.WriteLine("0. Volver al menú de usuarios");
            Console.Write("Seleccione una opción: ");

            string input = Console.ReadLine()!;
            if (int.TryParse(input, out int opt))
            {
                if (opt == 1)
                 { Console.WriteLine("\nEditando nombre de usuario..."); Pause(); }
                else if (opt == 2) 
                { Console.WriteLine("\nEditando contacto de usuario..."); Pause(); }
                else if (opt == 3) 
                { Console.WriteLine("\nCambiando estado activo/inactivo..."); Pause(); }
                else if (opt == 0) 
                { backUpdate = true; }
                else 
                { Console.WriteLine("\n[Error] Opción inválida."); Pause(); }
            }
            else { Console.WriteLine("\n[Error] Entrada inválida."); Pause(); }
        } while (!backUpdate);
    }

    static void DeleteUser()
    {
        Console.WriteLine("\n[Stub] Validando: No permitir eliminar si tiene préstamos activos...");
        Pause();
    }

    // MÓDULO DE PRÉSTAMOS (feature/loans-menu)

    static void ShowLoansMenu()
    {
        bool back = false;

        do
        {
            Console.WriteLine("==== MENU DE PRESTAMOS ===");
            Console.WriteLine("1. Crear préstamo");
            Console.WriteLine("2. Listar préstamos activos");
            Console.WriteLine("3. Ver detalles de prestamo (por ID)");
            Console.WriteLine("4. Registrar devolución");
            Console.WriteLine("5. ELiminar préstamo");
            Console.WriteLine("0. Volver al menú principal");
            Console.WriteLine("=============================");

            string input = Console.ReadLine()!;

            if (int.TryParse(input, out int option))
            {
                switch (option)
                {
                    case 1:
                        RegisterLoan();
                        break;
                    case 2:
                        ListLoansMenu();
                        break;
                    case 3:
                        ViewLoanDetail();
                        break;
                    case 4:
                        RegisterReturn();
                        break;
                    case 5:
                        DeleteLoan();
                        break;
                    case 0:
                        back = true; 
                        break;
                    default:
                        Console.WriteLine("\n[Error] Opción no válida en Préstamos.");
                        Pause();
                        break;
                }
            }
            else
            {
                Console.WriteLine("\n[Error] Entrada inválida. Ingrese un número.");
                Pause();
            }

        } while (!back);
    }

    static void RegisterLoan()
    {
        Console.WriteLine("\nValidando disponibilidad del libro y estado del usuario...");
        Console.WriteLine("\nEjecutando: Registro de Pretamo...");
        Pause();
    }

    static void ListLoansMenu()
    {
        bool backList = false;
        do
        {
            Console.Clear();
            Console.WriteLine(" === LISTAR PRÉSTAMO ===");
            Console.WriteLine("1. Todos los préstamos");
            Console.WriteLine("2. Préstamos activos");
            Console.WriteLine("3. Préstamos cerrados");
            Console.WriteLine("0. Volver al menú de préstamos");
            Console.WriteLine("===============================");
            

            string input = Console.ReadLine()!;
            if (int.TryParse(input, out int opt))
            {
                if (opt == 1)
                {
                    Console.WriteLine("\n[Stub] Listando TODOS los préstamos registrados...");
                    Pause();
                }
                else if (opt == 2)
                {
                    Console.WriteLine("\n[Stub] Listando únicamente préstamos ACTIVOS...");
                    Pause();
                }
                else if (opt == 3)
                {
                    Console.WriteLine("\n[Stub] Listando préstamos CERRADOS / Devueltos...");
                    Pause();
                }
                else if (opt == 0)
                {
                    backList = true;
                }
                else
                {
                    Console.WriteLine("\n[Error] Opción no válida en el listado de préstamos.");
                    Pause();
                }
            }
            else
            {
                Console.WriteLine("\n[Error] Entrada inválida. Debe ingresar un número entero.");
                Pause();
            }
        } while (!backList);
    }

    static void ViewLoanDetail()
    {
        Console.WriteLine("\nEjecutando: Ver detalle de préstamo por ID...");
        Pause();
    }

    static void RegisterReturn()
    {
        Console.WriteLine("\nEjecutando: Registrar devolución de libro y actualizar estado...");
        Pause();
    }

    static void DeleteLoan()
    {
        Console.WriteLine("\nValidando reglas de negocio:");
        Console.WriteLine("- No se permite eliminar un préstamo activo sin registrar la devolución.");
        Console.WriteLine("- Solo se permite anular/eliminar registros creados por error sin historial de sanciones.");
        Pause();
    }

    // MÓDULO DE BÚSQUEDA Y REPORTES (feature/search-reports-menu)

    static void ShowSearchReportsMenu()
    {
        bool back = false;
        do
        {
            Console.WriteLine(" === BÚSQUEDA Y REPORTES ===");
            Console.WriteLine("1. Buscar libro");
            Console.WriteLine("2. Buscar usuario ");
            Console.WriteLine("3. Reportes");
            Console.WriteLine("0. Volver al menú principal");
            

            string input = Console.ReadLine()!;

            if (int.TryParse(input, out int option))
            {
                switch (option)
                {
                    case 1:
                        SearchBooksMenu();
                        break;
                    case 2:
                        SearchUsersMenu();
                        break;
                    case 3:
                        ReportsMenu();
                        break;
                    case 0:
                        back = true;
                        break;
                    default:
                        Console.WriteLine("\n[Error] Opción no válida en Búsqueda y Reportes.");
                        Pause();
                        break;
                }
            }
            else
            {
                Console.WriteLine("\n[Error] Entrada inválida. Ingrese un número entero.");
                Pause();
            }

        } while (!back);
    }
    static void SearchBooksMenu()
    {
        bool back = false;
        do
        {
            Console.Clear();
            Console.WriteLine(" === BUSCAR LIBRO ===");
            Console.WriteLine("1. Buscar por título");
            Console.WriteLine("2. Buscar por autor");
            Console.WriteLine("3. Buscar por ID / ISBN");
            Console.WriteLine("4. Buscar por categoría");
            Console.WriteLine("0. Volver al menú anterior");
            Console.WriteLine("============================");

            string input = Console.ReadLine()!;
            if (int.TryParse(input, out int opt))
            {
                if (opt >= 1 && opt <= 4)
                {
                    Console.WriteLine($"\nEjecutando búsqueda de libros por criterio {opt}...");
                    Pause();
                }
                else if (opt == 0)
                {
                    back = true;
                }
                else
                {
                    Console.WriteLine("\n[Error] Opción no válida.");
                    Pause();
                }
            }
            else
            {
                Console.WriteLine("\n[Error] Entrada inválida.");
                Pause();
            }
        } while (!back);
    }

    // --- 4.2 SUBMENÚ: BUSCAR USUARIO ---
    static void SearchUsersMenu()
    {
        bool back = false;
        do
        {
            Console.Clear();
            Console.WriteLine(" === BUSCAR USUARIO ===");
            Console.WriteLine("1. Buscar por nombre");
            Console.WriteLine("2. Buscar por ID / documento");
            Console.WriteLine("0. Volver al menú anterior");
            Console.WriteLine("=============================");
            Console.Write("Seleccione una opción: ");

            string input = Console.ReadLine()!;
            if (int.TryParse(input, out int opt))
            {
                if (opt == 1 || opt == 2)
                {
                    Console.WriteLine($"\nEjecutando búsqueda de usuarios por criterio {opt}...");
                    Pause();
                }
                else if (opt == 0)
                {
                    back = true;
                }
                else
                {
                    Console.WriteLine("\n[Error] Opción no válida.");
                    Pause();
                }
            }
            else
            {
                Console.WriteLine("\n[Error] Entrada inválida.");
                Pause();
            }
        } while (!back);
    }

    // --- 4.3 SUBMENÚ: REPORTES ---
    static void ReportsMenu()
    {
        bool back = false;
        do
        {
            Console.Clear();
            Console.WriteLine(" === REPORTES ===");
            Console.WriteLine("1. Reporte por usuario");
            Console.WriteLine("2. Reporte por libro");
            Console.WriteLine("3. Reporte de préstamos vencidos");
            Console.WriteLine("4. Reporte resumen general");
            Console.WriteLine("0. Volver al menú anterior");
            Console.WriteLine("===============================");
            Console.Write("Seleccione una opción: ");

            string input = Console.ReadLine()!;
            if (int.TryParse(input, out int opt))
            {
                if (opt >= 1 && opt <= 4)
                {
                    Console.WriteLine($"\nGenerando reporte opción {opt}...");
                    Pause();
                }
                else if (opt == 0)
                {
                    back = true;
                }
                else
                {
                    Console.WriteLine("\n[Error] Opción no válida.");
                    Pause();
                }
            }
            else
            {
                Console.WriteLine("\n[Error] Entrada inválida.");
                Pause();
            }
        } while (!back);
    }

}
