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
                        Console.WriteLine("[Menú de Navegación de USUARIOS aquí]");
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
        Console.WriteLine("\n Ejecutando: Actualizando libro (Editar títular / Editar autor / Editar año - categoría )");
        Pause();
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
}