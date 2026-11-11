using System;
using BibliotecaMen.Models;
using BibliotecaMenu.Models;

namespace BibliotecaMenu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProbarModelosObjetos();
        }

        static void ProbarModelosObjetos()
        {
            Console.Clear();
            Console.WriteLine("=================================================");
            Console.WriteLine("    PRUEBA DE CLASES Y OBJETOS BASE (EV07)       ");
            Console.WriteLine("=================================================\n");

            // 1 Instanción de 2 libros
            Libro libro1 = new Libro(1, "978-0131103627", "C Programming Language", "Kernighan & Ritchie", "Programación", true);
            Libro libro2 = new Libro(2, "978-0321765723", "The C++ Programming Language", "Bjarne Stroustrup", "Programación", false);

            // 2. Instanciación de 2 Usuarios
            Usuario usuario1 = new Usuario(1, "10203040", "Ender Jiménez", "enderst2019@gail.com", true);
            Usuario usuario2 = new Usuario(2, "50607080", "Carlos Pérez", "carlos.perez@email.com", false);

            // 3. Instanciación de 1 Préstamo cruzando el libro 1 y el usuario 1
            // Simulamos que se prestó hace 5 días y vence en 2 días a partir de hoy
            Prestamo prestamo1 = new Prestamo(5001, libro1, usuario1, DateTime.Now.AddDays(-5), DateTime.Now.AddDays(2));

            // Resumen - Mostrar

            Console.WriteLine("--- RESUMEN ---");
            Console.WriteLine(libro1.ResumenCorto());
            Console.WriteLine(libro2.ResumenCorto());
            Console.WriteLine(usuario1.ResumenCorto());
            Console.WriteLine(usuario2.ResumenCorto());
            Console.WriteLine(prestamo1.ResumenCorto());
            
            // Mostrar Detalles Completos
            Console.WriteLine("\n--- DETALLES COMPLETOS ---");
            Console.WriteLine(libro1.DetalleCompleto());
            Console.WriteLine();
            Console.WriteLine(usuario1.DetalleCompleto());
            Console.WriteLine();
            Console.WriteLine(prestamo1.DetalleCompleto());

            // Validaciones Obligatorias
            Console.WriteLine("\n--- VALIDACIONES DE ESTADOS Y MÉTODOS ---");
            Console.WriteLine($"Libro 1 Disponible: {libro1.Disponible}");
            Console.WriteLine($"Usuario 1 Activo: {usuario1.Activo}");
            Console.WriteLine($"Estado Préstamo 1: {prestamo1.Estado}");
            Console.WriteLine($"¿Préstamo 1 Vencido?: {prestamo1.EstaVencido()}");
            Console.WriteLine($"Días transcurridos Préstamo 1: {prestamo1.DiasTranscurridos()} días");
            
            Console.WriteLine("\n=================================================");
            Console.WriteLine("Presione cualquier tecla para finalizar la prueba...");
            Console.ReadKey();
        }
    }
}