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
                        Console.WriteLine("[Menú de Navegación de PRESTAMOS]");
                        break;
                    case 4:
                        Console.WriteLine("[Menú de Navegación de BUSQUE Y REPORTES]");
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

}

