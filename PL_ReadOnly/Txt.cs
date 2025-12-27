using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PL_ReadOnly
{
    public class Txt
    {
        public static void Mensaje()
        {
            // Ruta relativa -> Ruta partiendo de un directorio en especifico

            // Ruta absoluta -> Toda la ruta del archivo.

            string rutatxt = "C:\\Users\\digis\\Downloads\\5Datos.txt";

            using (StreamReader sr = File.OpenText(rutatxt)) //Leo mi archivo .txt
            {
                string linea = String.Empty; //Declaro mi variable vacia

                sr.ReadLine(); //Lee las cabeceras del txt.

                while ((linea = sr.ReadLine()) != null) //Mientras mi archivo tenga datos
                {
                    // arreglo de string
                    string[] array = [];

                    // Separar la linea por el simbolo "|"
                    array = linea.Split('|');

                    Console.WriteLine("-------------------");

                    //Validar mis Datos
                    string validacionCampos = ValidarFila(array);

                    //asignacion de valores
                    Console.WriteLine(array[0]); //UserName
                    Console.WriteLine(array[1]); //Nombre
                    Console.WriteLine(array[2]); //ApPaterno
                    Console.WriteLine(array[3]); //ApMaterno
                    Console.WriteLine(array[4]); //Email
                    Console.WriteLine(array[5]); //Passwrd
                    Console.WriteLine(array[6]); //Sexo
                    Console.WriteLine(array[7]); //Telefono
                    Console.WriteLine(array[8]); //Celular
                    Console.WriteLine(array[9]); //FechaNacimiento
                    Console.WriteLine(array[10]); //CURP
                    Console.WriteLine(array[11]); //IdRol
                    Console.WriteLine("-------------------");

                    //if (array.All(x => !string.IsNullOrWhiteSpace(x)))
                    //{
                        
                    //}
                }

                //while ((linea = sr.ReadLine()) != null)
                //{
                //    string[] array = linea.Split('|');

                //    if (array.All(x => !string.IsNullOrWhiteSpace(x)))
                //    {
                //        Console.WriteLine(" FOR-------------------");

                //        foreach (string dato in array)
                //        {
                //            Console.WriteLine(dato);
                //        }

                //        Console.WriteLine("-------------------");
                //    }
                //}
            }

            Console.ReadKey();
        }
        public static string ValidarFila(string[] lineaLeida)
        {
            string error = "";

            if (!Regex.IsMatch(lineaLeida[0], @"^[\S]+$")) //UserName
            {
                error = error + "No se aceptan espacios: " + lineaLeida[0] + " | ";
            }

            if (!Regex.IsMatch(lineaLeida[1], @"^[a-zA-Z ]+$")) //Nombre
            {
                error = error + "Solo se acepetan letras en: " + lineaLeida[1] + " | ";
            }

            if (!Regex.IsMatch(lineaLeida[2], @"^[a-zA-Z ]+$")) //ApPat
            {
                error = error + "Solo se acepetan letras en: " + lineaLeida[2] + " |";
            }

            if (!Regex.IsMatch(lineaLeida[3], @"^[a-zA-Z ]+$")) //ApMat
            {
                error = error + "Solo se acepetan letras en: " + lineaLeida[3] + " |";
            }

            if (!Regex.IsMatch(lineaLeida[4], @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$")) //Email
            {
                error = error + "El correo no es válido: " + lineaLeida[4] + " |";
            }

            if (!Regex.IsMatch(lineaLeida[5], @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$")) //Passwrd
            {
                error = error + "La contraseña no es válida: " + lineaLeida[5] + " |";
            }

            if (!Regex.IsMatch(lineaLeida[6], @"^[mf]+$", RegexOptions.IgnoreCase)) //Sexo
            {
                error = error + "El Sexo no es válido: " + lineaLeida[6] + " |";
            }

            if (!Regex.IsMatch(lineaLeida[7], @"^[0-9]+$")) //Telefono
            {
                error = error + "Solo se aceptan numeros en: " + lineaLeida[7] + " |";
            }

            if (!Regex.IsMatch(lineaLeida[8], @"^[0-9]+$")) //Celular
            {
                error = error + "Solo se aceptan numeros en: " + lineaLeida[8] + " |";
            }

            if (!Regex.IsMatch(lineaLeida[9], @"^(0[1-9]|[12][0-9]|3[01])-(0[1-9]|1[0-2])-\d{4}$")) //FechaNacimiento
            {
                error = error + "El formato de fecha no es válido [dd-mm-yyyy]: " + lineaLeida[9] + " |";
            }

            if (!Regex.IsMatch(lineaLeida[10], @"^[A-Z]{4}[0-9]{6}[H|M][A-Z]{2}[B|C|D|F|G|H|J|K|L|M|N|Ñ|P|Q|R|S|T|V|W|X|Y|Z]{3}[0-9|A-Z]{2}$")) //CURP
            {
                error = error + "El Formato del CURP no es válido: " + lineaLeida[10] + " |";
            }

            if (!Regex.IsMatch(lineaLeida[11], @"^[1-5]+$")) //IdRol
            {
                error = error + "Solo se aceptan numeros en: " + lineaLeida[11] + " |";
            }

            return error;

        }

    }
}
