using Microsoft.EntityFrameworkCore;

namespace BL
{
    public class Usuario
    {
        ////Inyeccion de dependencia _context
        ////_context almacena una instancia del DbContext que uso para acceder a la base de datos.
        //private readonly DL.MrodriguezProgramacionNcapasContext _context;  

        ////Constructor 
        ////Recibe una instancia del DL.Context y lo guardo en _context.
        //public Usuario(DL.MrodriguezProgramacionNcapasContext context) 
        //{
        //    this._context = context;
        //}

        public static ML.Result GetAllSPFilter(ML.Usuario usuario)
        {
            ML.Result resultGetUserByFilter = new ML.Result();

            try
            {
                using (DL.MrodriguezProgramacionNcapasContext context = new DL.MrodriguezProgramacionNcapasContext())
                {
                    #region Operaciones Ternarias
                    usuario.Nombre = usuario.Nombre == null ? "" : usuario.Nombre;
                    usuario.ApellidoPaterno = usuario.ApellidoPaterno == null ? "" : usuario.ApellidoPaterno;
                    usuario.ApellidoMaterno = usuario.ApellidoMaterno == null ? "" : usuario.ApellidoMaterno;
                    string IdRol = usuario.Rol.IdRol == 0 ? "" : usuario.Rol.IdRol.ToString();
                    #endregion

                    /* #region Operador Nulleable
                    usuario.Nombre = usuario.Nombre ?? ""; //Si es nullo lo inicializa a vacio
                    usuario.ApellidoPaterno = usuario.ApellidoPaterno ?? "";
                    usuario.ApellidoMaterno = usuario.ApellidoMaterno ?? "";
                    #endregion 
                    */

                    // conexion [context.], en donde voy a guardar la informacion [UsuarioGetAllDTOs], ejecutar el SP4 [UsuarioGetAll]

                    //#region Stored Procedure
                    //var queryUsersList = context.
                    //    UsuarioGetAllDTOs.
                    //    FromSqlInterpolated(
                    //    $"EXECUTE UsuarioGetAll @Nombre={usuario.Nombre}, @ApellidoPaterno={usuario.ApellidoPaterno}, @ApellidoMaterno={usuario.ApellidoMaterno}, @IdRol={IdRol}")
                    //    .ToList();
                    //#endregion

                    #region Query Dynamic
                    var queryUsersList = context.
                        UsuarioGetAllDTOs.
                        FromSqlInterpolated(
                        $"EXECUTE UsuarioGetAllDynamic @Nombre={usuario.Nombre}, @ApellidoPaterno={usuario.ApellidoPaterno}, @ApellidoMaterno={usuario.ApellidoMaterno}, @IdRol={IdRol}")
                        .ToList();
                    #endregion

                    //#region Stored Procedure with View
                    //var queryUsersList = context.
                    //    UsuarioGetAllDTOs.
                    //    FromSqlInterpolated(
                    //    $"EXECUTE UsuarioGetAllView @Nombre={usuario.Nombre}, @ApellidoPaterno={usuario.ApellidoPaterno}, @ApellidoMaterno={usuario.ApellidoMaterno}, @IdRol={IdRol}")
                    //    .ToList();
                    //#endregion 
                    // FromSqlRaw - SELECT 

                    // ExecuteSqlRaw   -INSERT UPDATE Y DELETE 

                    if (queryUsersList.Count > 0)
                    {
                        resultGetUserByFilter.Objects = new List<object>();

                        foreach (var usuarioDB in queryUsersList)
                        {
                            ML.Usuario usuarioML = new ML.Usuario();

                            usuarioML.IdUsuario = usuarioDB.IdUsuario;
                            usuarioML.UserName = usuarioDB.UserName;
                            usuarioML.Nombre = usuarioDB.UsuarioNombre;
                            usuarioML.ApellidoPaterno = usuarioDB.ApellidoPaterno;
                            usuarioML.ApellidoMaterno = usuarioDB.ApellidoMaterno;
                            usuarioML.Email = usuarioDB.Email;
                            usuarioML.Passwrd = usuarioDB.Passwrd;
                            usuarioML.Sexo = usuarioDB.Sexo;
                            usuarioML.Telefono = usuarioDB.Telefono;
                            usuarioML.Celular = usuarioDB.Celular;
                            usuarioML.FechaNacimiento = usuarioDB.FechaNacimiento;
                            usuarioML.CURP = usuarioDB.CURP;

                            usuarioML.Rol = new ML.Rol();
                            usuarioML.Rol.IdRol = usuarioDB.IdRol;
                            usuarioML.Rol.Nombre = usuarioDB.RolNombre;

                            resultGetUserByFilter.Objects.Add(usuarioML);
                        }

                        resultGetUserByFilter.Correct = true;
                    }
                    else
                    {
                        resultGetUserByFilter.Correct = false;
                    }
               
                }
            }
            catch (Exception ex)
            {
                resultGetUserByFilter.ErrorMessage = ex.Message;
                resultGetUserByFilter.Ex = ex;
                resultGetUserByFilter.Correct = false;
            }

            return resultGetUserByFilter;
        }


        #region MÉTODOS CON LINQ
        public static ML.Result GetAllLINQ()
        {
            ML.Result resultGetAllUsers = new ML.Result();

            try
            {
                using (DL.MrodriguezProgramacionNcapasContext context = new DL.MrodriguezProgramacionNcapasContext())
                {
                    var queryResult = (from usuarioDB in context.Usuarios
                                       join rolDB in context.Rols on usuarioDB.IdRol equals rolDB.IdRol
                                       select new
                                       {
                                           usuarioDB.IdUsuario,
                                           usuarioDB.UserName,
                                           NombreUsuario = usuarioDB.Nombre,
                                           usuarioDB.ApellidoPaterno,
                                           usuarioDB.ApellidoMaterno,
                                           usuarioDB.Email,
                                           usuarioDB.Passwrd,
                                           usuarioDB.Sexo,
                                           usuarioDB.Telefono,
                                           usuarioDB.Celular,
                                           usuarioDB.FechaNacimiento,
                                           usuarioDB.Curp,
                                           rolDB.IdRol,
                                           NombreRol = rolDB.Nombre
                                       }).ToList();

                    if (queryResult.Count > 0)
                    {
                        resultGetAllUsers.Objects = new List<object>();

                        foreach (var usuarioOBJ in queryResult)
                        {
                            ML.Usuario usuario = new ML.Usuario();

                            usuario.IdUsuario = usuarioOBJ.IdUsuario;
                            usuario.UserName = usuarioOBJ.UserName;
                            usuario.Nombre = usuarioOBJ.NombreUsuario;
                            usuario.ApellidoPaterno = usuarioOBJ.ApellidoPaterno;
                            usuario.ApellidoMaterno = usuarioOBJ.ApellidoMaterno;
                            usuario.Email = usuarioOBJ.Email;
                            usuario.Passwrd = usuarioOBJ.Passwrd;
                            usuario.Sexo = usuarioOBJ.Sexo;
                            usuario.Telefono = usuarioOBJ.Telefono;
                            usuario.Celular = usuarioOBJ.Celular;
                            usuario.FechaNacimiento = usuarioOBJ.FechaNacimiento;
                            usuario.CURP = usuarioOBJ.Curp;

                            usuario.Rol = new ML.Rol();

                            usuario.Rol.IdRol = usuarioOBJ.IdRol;
                            usuario.Rol.Nombre = usuarioOBJ.NombreRol;

                            resultGetAllUsers.Objects.Add(usuario);
                        }

                        resultGetAllUsers.Correct = true;

                    }
                    else
                    {
                        resultGetAllUsers.ErrorMessage = "No se obtuvieron los usuarios";
                    }
                }

            }
            catch (Exception ex)
            {
                resultGetAllUsers.Correct = false;
                resultGetAllUsers.ErrorMessage = ex.Message;
                resultGetAllUsers.Ex = ex;
            }


            return resultGetAllUsers;
        }//GetAllLINQ

        public static ML.Result GetByIdLINQ(int IdUsuario)
        {
            ML.Result resultGetByIdUser = new ML.Result();

            try
            {
                using (DL.MrodriguezProgramacionNcapasContext context = new DL.MrodriguezProgramacionNcapasContext())
                {
                    var queryResult = (from usuarioDB in context.Usuarios
                                       join rolDB in context.Rols on usuarioDB.IdRol equals rolDB.IdRol
                                       where usuarioDB.IdUsuario == IdUsuario
                                       select usuarioDB).SingleOrDefault();

                    if (queryResult != null)
                    {
                        ML.Usuario usuario = new ML.Usuario();

                        usuario.IdUsuario = queryResult.IdUsuario;

                        usuario.UserName = queryResult.UserName;
                        usuario.Nombre = queryResult.Nombre;
                        usuario.ApellidoPaterno = queryResult.ApellidoPaterno;
                        usuario.ApellidoMaterno = queryResult.ApellidoMaterno;
                        usuario.Email = queryResult.Email;
                        usuario.Passwrd = queryResult.Passwrd;
                        usuario.Sexo = queryResult.Sexo;
                        usuario.Telefono = queryResult.Telefono;
                        usuario.Celular = queryResult.Celular;
                        usuario.FechaNacimiento = queryResult.FechaNacimiento;
                        usuario.CURP = queryResult.Curp;

                        usuario.Rol = new ML.Rol();
                        usuario.Rol.IdRol = queryResult.IdRol.Value;

                        resultGetByIdUser.Correct = true;

                        resultGetByIdUser.Object = usuario;

                    }
                    else
                    {
                        resultGetByIdUser.Correct = false;
                    }

                }


            }
            catch (Exception ex)
            {
                resultGetByIdUser.ErrorMessage = ex.Message;
                resultGetByIdUser.Ex = ex;
                resultGetByIdUser.Correct = false;
            }

            return resultGetByIdUser;
        }

        public static ML.Result AddLINQ(ML.Usuario usuario)
        {
            ML.Result resultAddUser = new ML.Result();

            try
            {
                using (DL.MrodriguezProgramacionNcapasContext context = new DL.MrodriguezProgramacionNcapasContext())
                {
                    DL.Usuario usuarioDL = new DL.Usuario();

                    usuarioDL.UserName = usuario.UserName;
                    usuarioDL.Nombre = usuario.Nombre;
                    usuarioDL.ApellidoPaterno = usuario.ApellidoPaterno;
                    usuarioDL.ApellidoMaterno = usuario.ApellidoMaterno;
                    usuarioDL.Email = usuario.Email;
                    usuarioDL.Passwrd = usuario.Passwrd;
                    usuarioDL.Sexo = usuario.Sexo;
                    usuarioDL.Telefono = usuario.Telefono;
                    usuarioDL.Celular = usuario.Celular;
                    usuarioDL.FechaNacimiento = usuario.FechaNacimiento;
                    usuarioDL.Curp = usuario.CURP;
                    usuarioDL.IdRol = usuario.Rol.IdRol;

                    context.Usuarios.Add(usuarioDL);

                    int affectedRows = context.SaveChanges();

                    if (affectedRows > 0)
                    {
                        resultAddUser.Correct = true;
                    }
                    else
                    {
                        resultAddUser.Correct = false;
                    }
                }


            }
            catch (Exception ex)
            {
                resultAddUser.Correct = false;
                resultAddUser.ErrorMessage = ex.Message;

            }

            return resultAddUser;
        }//AddLINQ User

        public static ML.Result UpdateLINQ(ML.Usuario usuario)
        {
            ML.Result resultUpdateUser = new ML.Result();

            try
            {
                using (DL.MrodriguezProgramacionNcapasContext context = new DL.MrodriguezProgramacionNcapasContext())
                {
                    var queryResult = (from usuarioDB in context.Usuarios
                                       where usuarioDB.IdUsuario == usuario.IdUsuario
                                       select usuarioDB).SingleOrDefault();

                    if (queryResult != null)
                    {
                        queryResult.UserName = usuario.UserName;
                        queryResult.Nombre = usuario.Nombre;
                        queryResult.ApellidoPaterno = usuario.ApellidoPaterno;
                        queryResult.ApellidoMaterno = usuario.ApellidoMaterno;
                        queryResult.Email = usuario.Email;
                        queryResult.Passwrd = usuario.Passwrd;
                        queryResult.Sexo = usuario.Sexo;
                        queryResult.Telefono = usuario.Telefono;
                        queryResult.Celular = usuario.Celular;
                        queryResult.FechaNacimiento = usuario.FechaNacimiento;
                        queryResult.Curp = usuario.CURP;
                        queryResult.IdRol = usuario.Rol.IdRol;

                        int affectedRows = context.SaveChanges();

                        if (affectedRows > 0)
                        {
                            resultUpdateUser.Correct = true;
                        }
                        else
                        {
                            resultUpdateUser.Correct = false;
                        }

                    }
                    else
                    {
                        resultUpdateUser.ErrorMessage = $"No se actualizo el usuario  {usuario.UserName}"; //Interpolacion de cadenas
                    }
                }

            }//try
            catch (Exception ex)
            {
                resultUpdateUser.Correct = false;
                resultUpdateUser.ErrorMessage = ex.Message;
                resultUpdateUser.Ex = ex;
            }

            return resultUpdateUser;
        }//UpdateLINQ User

        public static ML.Result DeleteLINQ(int IdUsuario)
        {
            ML.Result resultDeleteUser = new ML.Result();

            try
            {
                using (DL.MrodriguezProgramacionNcapasContext context = new DL.MrodriguezProgramacionNcapasContext())
                {
                    var queryResult = (from usuarioDB in context.Usuarios
                                       where usuarioDB.IdUsuario == IdUsuario
                                       select usuarioDB).SingleOrDefault();


                    if (queryResult != null)
                    {
                        context.Usuarios.Remove(queryResult);

                        int affectedRows = context.SaveChanges();

                        if (affectedRows > 0)
                        {
                            resultDeleteUser.Correct = true;
                        }
                        else
                        {
                            resultDeleteUser.Correct = false;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                resultDeleteUser.Correct = false;
                resultDeleteUser.ErrorMessage = ex.Message;
                resultDeleteUser.Ex = ex;
            }

            return resultDeleteUser;
        }//DeleteLINQ User

        #endregion
    }//class
}//namespace
