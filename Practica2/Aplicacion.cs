using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2
{
    class Aplicacion
    {
        #region Main
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Teclee los datos del empleado\n");
            bool control = false;
            string nombre;
            string nif1;
            int categoria;
            int numHijos;
            int numTrienios;
            DateTime fechaNomina;
            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Introduzca nombre de empleado: ");
                nombre = Console.ReadLine();
                if (nombre.Length > 25 || nombre.Length < 5)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Por favor introduzca entre 5 y 25 caracteres");
                }
                else
                {
                    if (ComprobarNombre(nombre) == false)
                    {
                        control = true;
                    }
                    else
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error al introducir el nombre");
                    }
                }
            }
            while (control == false);
            do
            {
                int nif = ControlarEntradaInt("\nIntroduzca DNI sin letra (Deben ser 8 números)");
                nif1 = nif.ToString();
                if (nif1.Length == 8)
                {
                    bool correcto = false;
                    int n = nif;
                    nif1 += CalcularLetra(n);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("El DNI con su letra es: " + nif1);
                    do
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\n¿Es correcto el DNI?");
                        string respuesta = Console.ReadLine();
                        if (respuesta.Equals("si"))
                        {
                            control = false;
                            correcto = true;
                        }
                        else if (respuesta.Equals("no"))
                        {
                            Console.Clear();
                            correcto = true;
                        }
                        else
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Error al introducir");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Por favor, introduzca 'si' o 'no'");
                        }
                    }
                    while (correcto == false);
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Longitud de DNI errónea errónea, por favor vuelve a introducirla");
                }
            }
            while (control == true);
            do
            {
                categoria = ControlarEntradaInt("\nIntroduzca la categoria (existe solo la categoria 1, 2 y 3)");
                if (categoria > 0 && categoria <= 3)
                {
                    control = true;
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Categoria errónea, por favor vuelve a introducirla");
                }
            }
            while (control == false);
            do
            {

                numTrienios = ControlarEntradaInt("\nIntroduzca número de trienios (máxmimo 12)");
                if (numTrienios < 0)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Introducido valor negativo, asignado por defecto 0");
                    numTrienios = 0;
                    control = false;
                }
                else if (numTrienios > 12)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Introducido valor mayor que 12, asignado por defecto 12");
                    numTrienios = 12;
                    control = false;
                }
                else
                {
                    control = false;
                }
            }
            while (control == true);
            do
            {
                numHijos = ControlarEntradaInt("\nIntroduzca número de hijos (máximo 10)");
                if (numHijos < 0)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Introducido valor negativo, asignado por defecto 0");
                    numHijos = 0;
                    control = true;
                }
                else if (numHijos > 10)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error al introducir el número de hijos (máximo 10)");
                }
                else
                {
                    control = true;
                }
            }
            while (control == false);
            Empleado empleado = new Empleado(categoria, nif1, nombre, numHijos, numTrienios);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Teclee los datos referentes a la nómina");
            do
            {
                fechaNomina = ControlarEntradaDateTime("\nIntroduzca la fecha de nómina con el formato 'dd/mm/yyyy'");
                if (fechaNomina > DateTime.Now|| fechaNomina.Year < 2016)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error al introducir la fecha");
                }
                else
                {
                    control = false;
                }
            }
            while (control == true);
            int numHorasExtras;
            do
            {
                numHorasExtras = ControlarEntradaInt("\nIntroduzca número de horas extras (máximo 80)");
                if (numHorasExtras < 0)
                {
                    Console.Clear();
                    Console.WriteLine("Introducido valor negativo, asignado por defecto 0");
                    numHorasExtras = 0;
                    control = true;
                }
                else if (numHorasExtras > 80)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error al introducir el número de horas extra (máximo 80)");
                }
                else
                {
                    control = true;
                }
            }
            while (control == false);
            Nomina nomina = new Nomina(empleado, fechaNomina, numHorasExtras);
            bool salir = false;
            while (!salir)
            {
                Console.ForegroundColor = ConsoleColor.White;
                nomina.HojaSalarial();
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    salir = !salir;
                }
            }  
        }
        #endregion
        #region Metodos
        #region ControlarEntradaInt
        static int ControlarEntradaInt(string texto)
        {
            int valor;
            bool esNumero;
            string variable;
            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(texto + "\n");
                variable = Console.ReadLine();
                esNumero = int.TryParse(variable, out valor);
                if (!esNumero)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error al introducir. ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Por favor vuelva a introducir\n");
                }
            }
            while (!esNumero);
            return int.Parse(variable);
        }
        #endregion
        #region ControlarEntradaDateTime
        static DateTime ControlarEntradaDateTime(string texto)
        {
            DateTime valor;
            bool esNumero;
            string variable;
            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(texto + "\n");
                variable = Console.ReadLine();
                esNumero = DateTime.TryParse(variable, out valor);
                if (!esNumero)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error al introducir. ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Por favor vuelva a introducir\n");
                }
            }
            while (!esNumero);
            return DateTime.Parse(variable);
        }
        #endregion
        #region CalcularLetra
        static char CalcularLetra(int n)
        {
            string cadena = "TRWAGMYFPDXBNJZSQVHLCKE";
            return (char)cadena[n % 23];
        }
        #endregion
        #region ComprobarNombre()
        static bool ComprobarNombre(string nombre)
        {
            bool checkChar = false;
            foreach(char c in nombre){
                if (!Char.IsLetter(c) && !Char.IsWhiteSpace(c))
                {
                    checkChar = true;
                }
            }
            return checkChar;
        }
        #endregion
        #endregion
    }
}
