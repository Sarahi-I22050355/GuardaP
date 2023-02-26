using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GuardaP
{
    internal class Program
    {
        /// <summary>
        /// metodo para validar correo
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool Valido(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Utilizamos una expresión regular para validar el formato del correo electrónico
                // Si el correo electrónico tiene un formato válido, entonces la función devuelve true
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
        static void Main(string[] args)
        {
            bool continuar = true;
            do
            {
                Console.WriteLine("Por favor ingresa el numero de personas a almacenar");
                int lector = int.Parse(Console.ReadLine());
                Contacto[] contactos = new Contacto[lector];
                Console.Clear();
                for (int i = 0; i < lector; i++)
                {
                contactos[i] = new Contacto();
                Console.Write("Nombre: "); contactos[i].Nombre = Console.ReadLine();
                Console.Write("Apellido Paterno: "); contactos[i].ApellidoPaterno = Console.ReadLine(); 
                Console.Write("Apellido Materno: "); contactos[i].ApellidoMaterno= Console.ReadLine();
                Console.Write("Fecha de nacimiento (DD/MM/AAAA): ");
                while (true)
                {
                    try
                    {
                        contactos[i].FechaNacimiento = DateTime.Parse(Console.ReadLine());
                        break;
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                Console.Write("Correo: ");
                while (true)
                {
                    string correo = Console.ReadLine();
                    if (Valido(correo))
                    {
                        contactos[i].Correo = correo;
                        break;
                    }
                    else
                        Console.WriteLine("El correo electrónico ingresado no es válido, por favor inténtalo nuevamente.");}
                    Console.Write("Telefono: "); contactos[i].Telefono = Console.ReadLine();
                    Console.Clear();
                }
                for (int i = 0; i < lector; i++)
                {
                    Console.WriteLine("Nombre: {0} \t Apellido Paterno: {1} \t Apellido Materno: {2} \t Fecha de Nacimiento: {3:dd/MM/yyyy} \t Edad: {4} \t Correo: {5} \t Telefono: {6}", contactos[i].Nombre.ToUpper(), contactos[i].ApellidoPaterno.ToUpper(), contactos[i].ApellidoMaterno.ToUpper(), contactos[i].FechaNacimiento.ToString("dd/MM/yyyy"), contactos[i].Edad, contactos[i].Correo, contactos[i].Telefono);
                }
                Console.WriteLine("¿Deseas continuar? (S/N)");
                string respuesta = Console.ReadLine();
                if (respuesta.ToLower() == "n")
                {
                    continuar = false;
                }
                Console.Clear();
            } while (continuar);
            Console.WriteLine("Fin del programa.");
            Console.ReadKey();
        }
    }
}
