using System;

class Program
{
    static void Main(String [] args)
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

            if(int.TryParse(input, out int opcion))
            {
                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("[Menú de Navegación de LIBRO aqui]");
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

        } while(!exit);
    }
}