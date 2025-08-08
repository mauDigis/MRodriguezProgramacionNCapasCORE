using DL;
using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{

    public class UsuarioController : Controller
    {

        #region Usuario
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
        public IActionResult GetAll(ML.Usuario usuario)
        {
            //Le paso mis datos del FORM.

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
