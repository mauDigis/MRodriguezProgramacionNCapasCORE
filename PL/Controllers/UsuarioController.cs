using DL;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;

namespace PL.Controllers
{

    public class UsuarioController : Controller
    {

        #region Usuario

        //Obtengo acceso a la información del entorno de la aplicación. 
        //Obtener la ruta de la carpeta raíz de la aplicación, que es la ubicación física de los archivos del proyecto en el servidor.

        //Con esto puedo obtener la ruta raiz de wwwroot.
        private readonly IWebHostEnvironment _webHostEnvironment;  //Delcaro mi variable privada.

        public UsuarioController(IWebHostEnvironment webHostEnvironment) //Creo mi constructor
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            ML.Usuario usuario = new ML.Usuario(); //Instancia de mi modelo Usuario

            //Inicializo mis variables para no enviar null si no vacios.

            usuario.Nombre = "";
            usuario.ApellidoPaterno = "";
            usuario.ApellidoMaterno = "";

            usuario.Rol = new ML.Rol();
            usuario.Rol.IdRol = 0;

            //Inicializo mis listas
            usuario.Errores = new List<object>();
            usuario.Correctos = new List<object>();

            ML.Result resultGetAll = BL.Usuario.GetAllSPFilter(usuario);

            if (resultGetAll.Correct)
            {
                usuario.Usuarios = resultGetAll.Objects;
            }
            else
            {

            }

            #region Roles
            ML.Result resultRoles = new ML.Result(); //Instancia de resultado
            resultRoles = BL.Rol.GetAllRolsLINQ(); // Invoco mi metodo RolGetAll

            if (resultRoles.Correct)
            {
                usuario.Rol = new ML.Rol();
                usuario.Rol.Roles = resultRoles.Objects;
            }
            #endregion

            return View(usuario);
        }//GetAll [GET]

        [HttpPost]
        public IActionResult GetAll(ML.Usuario usuario, string rdbtnArchivo, IFormFile inputArchivo)
        {
            //Inicializo mis listas
            usuario.Errores = new List<object>();
            usuario.Correctos = new List<object>();

            #region Consulta de Usuarios
            //Inicializo mis variables para no enviar null si no vacios.
            usuario.Nombre = "";
            usuario.ApellidoPaterno = "";
            usuario.ApellidoMaterno = "";

            usuario.Rol = new ML.Rol();
            usuario.Rol.IdRol = 0;

            ML.Result resultGetAllUsers = BL.Usuario.GetAllSPFilter(usuario);

            if (resultGetAllUsers.Correct)
            {
                usuario.Usuarios = resultGetAllUsers.Objects;
            }
            else
            {

            }
            #endregion

            #region Roles
            ML.Result resultRoles = new ML.Result(); //Instancia de resultado
            resultRoles = BL.Rol.GetAllRolsLINQ(); // Invoco mi metodo RolGetAll

            if (resultRoles.Correct)
            {
                usuario.Rol = new ML.Rol();
                usuario.Rol.Roles = resultRoles.Objects;
            }
            #endregion

            if (rdbtnArchivo == null) //Si mi rdbtn es null consulto mis usuarios
            {
                // Todo el codigo de busqueda abierta

                //Le paso mis datos del FORM.
                ML.Result resultGetAll = BL.Usuario.GetAllSPFilter(usuario);

                if (resultGetAll.Correct)
                {
                    usuario.Usuarios = resultGetAll.Objects;
                }
                else
                {

                }

            }

            if (rdbtnArchivo == "txt") //Mi rdbtn es de tipo txt
            {
                //string extension = Path.GetExtension(inptArchivo.FileName);

                //Obtengo el nombre de mi archivo.
                if (inputArchivo.FileName.Split(".")[1] == "txt") //Separo mi filename de la extension y mi extension debe ser igual a .txt
                {
                    using (StreamReader sr = new StreamReader(inputArchivo.OpenReadStream())) //Leo los datos de mi archivo
                    {
                        string linea = String.Empty; //Inicializo mi variable a vacia.
                        sr.ReadLine(); //Lee las cabeceras del txt. La primera linea

                        int numeroLinea = 2; //Inicializo el valor de mi linea

                        while ((linea = sr.ReadLine()) != null) //Mientras mi archivo tenga datos los lee.
                        {
                            string[] lineaLeida = linea.Split("|"); //Declaro un arreglo para separar las lineas leidas por "|". 

                            string validacionCampos = ValidarFila(lineaLeida); //Invoco mi funcion para validar si la linea leida es correcta o tiene errores.

                            if (validacionCampos.Contains("es correcto")) //Si la linea leida esta bien, lo guardo en la lista correctos.
                            {
                                // agregar a la lista de correctos
                                // usuario.Correctos.Add(validacionCampos);

                                string mensajeCorrectoConLinea = $"Línea {numeroLinea} : {validacionCampos}";
                                usuario.Correctos.Add(mensajeCorrectoConLinea);
                            }
                            else                                          //Si la linea leida tiene errores, lo guardo en la lista errores.
                            {
                                // agregar a la lista de errores
                                //usuario.Errores.Add(validacionCampos);

                                // Aquí agregas el número de línea al mensaje de error
                                string mensajeErrorConLinea = $"Línea {numeroLinea} : {validacionCampos}";
                                usuario.Errores.Add(mensajeErrorConLinea);
                            }

                            numeroLinea++; //Incremento el numero de mi linea
                        }

                    }

                    string webRootPath = _webHostEnvironment.WebRootPath; //Obtengo la ruta de mi proyecto wwwroot

                    //Le agrego al nombre del archivo la fecha y hora actual más su extension .txt
                    string nombreCompleto = Path.GetFileNameWithoutExtension(inputArchivo.FileName) + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";

                    if (usuario.Errores.Count > 0) //Si mi lista de errores es mayor a 0
                    {
                        // Creo mi archivo con errores en la ruta webRootPath/Txt/Errores/mi archivo
                        string rutaCompleta = Path.Combine(webRootPath, "Txt", "Errores", nombreCompleto);

                        //Creo una session para validar si mi archivo tiene errores 
                        HttpContext.Session.SetString("rutaErrores", rutaCompleta);

                        //Operador de negacion ! -> Invierte el valor booleano
                        if (!System.IO.File.Exists(rutaCompleta)) //verifica si un archivo no existe en una ruta específica.
                        {

                            //StreamWriter trabaja con texto
                            using (StreamWriter streamWriter = new StreamWriter(rutaCompleta)) //Me ayuda a escribir en una ruta especifica
                            {
                                foreach (var linea in usuario.Errores) //Itero por cada error de mi lista
                                {
                                    streamWriter.WriteLine(linea); //Escribo las lineas de error en mi ruta especifica.
                                }
                            }
                        }
                    }
                    else //Si no tiene errores Todos deben ser correctos
                    {
                        // archivo sin errores
                        // Session["rutaCorrectos"] = rutaCompleta;

                        //Creo mi archivo con las lineas correctas en la ruta webRootPath/Txt/Correctos/mi archivo
                        string rutaCompleta = Path.Combine(webRootPath, "Txt", "Correctos", nombreCompleto);

                        //Creo mi session para validar si es correcto y guardar en la base
                        HttpContext.Session.SetString("rutaCorrectos", rutaCompleta);

                        //Obtengo el valor de una variable de sesión y lo guardo en mi var sesion
                        var sesion = HttpContext.Session.GetString("rutaCorrectos");

                        if (!System.IO.File.Exists(rutaCompleta)) //Si no existe mi archivo en la ruta
                        {
                            //FileStream trabaja directamente con los bytes del archivo. Manipula archivos binarios como imágenes, videos, archivos.
                            using (FileStream source = new FileStream(rutaCompleta, FileMode.Create)) //FileMode.Create crea o sobrescribe un archivo en la ruta especificada

                            {
                                inputArchivo.CopyTo(source); //Copia el contenido de un archivo a otro.
                            }
                        }
                    }
                }
            }
            else
            {
                //Archivo excel
            }

            return View(usuario);
        }//GetAll [GET]

        public ActionResult GuardarCargaMasiva()
        {
            // Extraer la ruta del archivo correcto de la sesion
            string ruta = "";

            // Obtén el valor de la sesión y asignalo a la variable 'ruta'
            var sesion = HttpContext.Session.GetString("rutaCorrectos");

            // Valido si mi sesion no es nula
            if (sesion != null)
            {
                ruta = sesion;
            }

            using (StreamReader sr = new StreamReader(ruta))
            {
                string linea = String.Empty;

                sr.ReadLine();

                while ((linea = sr.ReadLine()) != null)
                {
                    string[] lineaLeida = linea.Split("|");
                    ML.Usuario usuario = new ML.Usuario();

                    usuario.UserName = lineaLeida[0];
                    usuario.Nombre = lineaLeida[1];
                    usuario.ApellidoPaterno = lineaLeida[2];
                    usuario.ApellidoMaterno = lineaLeida[3];
                    usuario.Email = lineaLeida[4];
                    usuario.Passwrd = lineaLeida[5];
                    usuario.Sexo = lineaLeida[6];
                    usuario.Telefono = lineaLeida[7];
                    usuario.Celular = lineaLeida[8];
                    usuario.FechaNacimiento = lineaLeida[9];
                    usuario.CURP = lineaLeida[10];

                    usuario.Rol = new ML.Rol();
                    usuario.Rol.IdRol = Convert.ToInt32(lineaLeida[11]);

                    ML.Result resultAddCargaMasiva = BL.Usuario.AddSP(usuario);

                }

            }

            //Limpiar sesion
            //HttpContext.Session.Remove("rutaCorrectos");

            return RedirectToAction("GetAll");
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
                error = error + "Solo se aceptan letras en: " + lineaLeida[1] + " | ";
            }

            if (!Regex.IsMatch(lineaLeida[2], @"^[a-zA-Z ]+$")) //ApPat
            {
                error = error + "Solo se aceptan letras en: " + lineaLeida[2] + " |";
            }

            if (!Regex.IsMatch(lineaLeida[3], @"^[a-zA-Z ]+$")) //ApMat
            {
                error = error + "Solo se aceptan letras en: " + lineaLeida[3] + " |";
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

            if (error != "")
            {
                return error;
            }
            else
            {
                return error += "El registro " + lineaLeida[0] + " es correcto";
            }
        }

        [HttpGet] //obtener mostrar datos.
        public IActionResult Form(int? IdUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();

            #region Roles
            ML.Result resultRoles = new ML.Result(); //Instancia de resultado
            resultRoles = BL.Rol.GetAllRolsLINQ(); // Invoco mi metodo RolGetAll

            if (resultRoles.Correct)
            {
                usuario.Rol = new ML.Rol();
                usuario.Rol.Roles = resultRoles.Objects;  //unboxing lleno mi lista
            }

            #endregion

            if (IdUsuario > 0) //Si mi IdUsuario es mayor a 0, lo consulto.
            {
                ML.Result resultGetUserById = BL.Usuario.GetByIdSP(IdUsuario.Value);

                if (resultGetUserById.Correct)
                {
                    usuario = (ML.Usuario)resultGetUserById.Object;//Unboxing
                    usuario.Rol.Roles = resultRoles.Objects;  //resultRoles.Objects trae mi lista y se lo asigna a usuario.Rol.Roles //Unboxing

                }

            }
            else //Si no, retorno mi vista
            {

            }

            return View(usuario);
        }

        [HttpPost] //Enviar y recibir 
        public IActionResult Form(ML.Usuario usuario)
        {

            //Propiedad que verifica si el modelo enviado al controlador ha pasado todas las validaciones especificadas
            bool formCorrect = ModelState.IsValid;

            if (formCorrect == true)
            {
                if (usuario.IdUsuario == 0) //Si IdUsuario == 0 AGREGA
                {
                    ML.Result resultAddUser = BL.Usuario.AddSP(usuario);

                    if (resultAddUser.Correct)
                    {
                        return RedirectToAction("GetAll");
                    }
                }
                else //IdUsuario > 0 ACTUALIZA
                {
                    ML.Result resultUpdateUser = BL.Usuario.UpdateSP(usuario);

                    return RedirectToAction("Form", new { IdUsuario = usuario.IdUsuario });

                }
            }
            else
            {
                #region Roles
                ML.Result resultRoles = new ML.Result(); //Instancia de resultado
                resultRoles = BL.Rol.GetAllRolsLINQ(); // Invoco mi metodo RolGetAll

                if (resultRoles.Correct)
                {
                    usuario.Rol = new ML.Rol();
                    usuario.Rol.Roles = resultRoles.Objects;  //unboxing lleno mi lista
                }
                #endregion

                return View(usuario);
            }

            return RedirectToAction("GetAll");

        }

        public IActionResult Delete(int IdUsuario)
        {

            ML.Result resultDeleteUser = BL.Usuario.DeleteSP(IdUsuario);

            if (resultDeleteUser.Correct)
            {

            }
            else
            {

            }

            return RedirectToAction("GetAll");

        }

        #endregion

    }//class
}//namespace
