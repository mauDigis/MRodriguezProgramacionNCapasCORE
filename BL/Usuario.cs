using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.OleDb;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        #region MÉTODOS CON STORED PROCEDURES
        public static ML.Result GetAllSPFilter(ML.Usuario usuario)
        {
            ML.Result resultGetUserByFilter = new ML.Result();

            try
            {
                using (DL.MrodriguezProgramacionNcapasContext context = new DL.MrodriguezProgramacionNcapasContext())
                {
                    #region Operaciones Ternarias

                    //Inicializo los atributos de mi objeto
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

                    #region Stored Procedure
                    var queryUsersList = context.
                        UsuarioGetAllDTOs.
                        FromSqlInterpolated(
                        $"EXECUTE UsuarioGetAll @Nombre={usuario.Nombre}, @ApellidoPaterno={usuario.ApellidoPaterno}, @ApellidoMaterno={usuario.ApellidoMaterno}, @IdRol={IdRol}")
                        .ToList();
                    #endregion

                    //#region Query Dynamic
                    //var queryUsersList = context.
                    //    UsuarioGetAllDTOs.
                    //    FromSqlInterpolated(
                    //    $"EXECUTE UsuarioGetAllDynamic @Nombre={usuario.Nombre}, @ApellidoPaterno={usuario.ApellidoPaterno}, @ApellidoMaterno={usuario.ApellidoMaterno}, @IdRol={IdRol}")
                    //    .ToList();
                    //#endregion

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

        public static ML.Result GetByIdSP(int IdUsuario)
        {
            ML.Result resultGetByIdUser = new ML.Result();

            try
            {
                using (DL.MrodriguezProgramacionNcapasContext context = new DL.MrodriguezProgramacionNcapasContext())
                {
                    #region Stored Procedure
                    var resultQuery = context.UsuarioGetAllDTOs.
                        FromSqlInterpolated(
                        $"EXECUTE UsuarioGetById @IdUsuario={IdUsuario}").AsEnumerable().SingleOrDefault();
                    #endregion

                    if (resultQuery != null)
                    {
                        ML.Usuario usuario =  new ML.Usuario();

                        usuario.IdUsuario = resultQuery.IdUsuario;
                        usuario.UserName = resultQuery.UserName;
                        usuario.Nombre = resultQuery.UsuarioNombre;
                        usuario.ApellidoPaterno = resultQuery.ApellidoPaterno;
                        usuario.ApellidoMaterno = resultQuery.ApellidoMaterno;
                        usuario.Email = resultQuery.Email;
                        usuario.Passwrd = resultQuery.Passwrd;
                        usuario.Sexo = resultQuery.Sexo;
                        usuario.Telefono = resultQuery.Telefono;
                        usuario.Celular = resultQuery.Celular;
                        usuario.FechaNacimiento = resultQuery.FechaNacimiento;
                        usuario.CURP = resultQuery.CURP;

                        usuario.Rol = new ML.Rol();

                        usuario.Rol.IdRol = resultQuery.IdRol;
                        usuario.Rol.Nombre = resultQuery.RolNombre;

                        resultGetByIdUser.Object = usuario;

                        resultGetByIdUser.Correct = true;

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

        public static ML.Result AddSP(ML.Usuario usuario)
        {
            ML.Result resultAddUser = new ML.Result();

            usuario.Celular = usuario.Celular == null ? "" : usuario.Celular;

            try
            {
                using (DL.MrodriguezProgramacionNcapasContext context = new DL.MrodriguezProgramacionNcapasContext())
                {

                    #region Stored Procedure
                    int queryAddList = context.Database.ExecuteSqlInterpolated($@"
                        EXECUTE UsuarioAdd 
                            @UserName = {usuario.UserName},
                            @Nombre = {usuario.Nombre},
                            @ApellidoPaterno = {usuario.ApellidoPaterno},
                            @ApellidoMaterno = {usuario.ApellidoMaterno},
                            @Email = {usuario.Email},
                            @Passwrd = {usuario.Passwrd},
                            @Sexo = {usuario.Sexo},
                            @Telefono = {usuario.Telefono},
                            @Celular = {usuario.Celular},
                            @FechaNacimiento = {usuario.FechaNacimiento},
                            @Curp = {usuario.CURP},
                            @IdRol = {usuario.Rol.IdRol}
                        ");
                    #endregion

                    if(queryAddList > 0)
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

        public static ML.Result UpdateSP(ML.Usuario usuario)
        {
            ML.Result resultUpdateUser = new ML.Result();

            try
            {
                using (DL.MrodriguezProgramacionNcapasContext context = new DL.MrodriguezProgramacionNcapasContext())
                {
                    #region Stored Procedure
                    int queryUpdateUser = context.Database.ExecuteSqlInterpolated($@"
                        EXECUTE UsuarioUpdate 
                            @IdUsuario = {usuario.IdUsuario},
                            @UserName = {usuario.UserName},
                            @Nombre = {usuario.Nombre},
                            @ApellidoPaterno = {usuario.ApellidoPaterno},
                            @ApellidoMaterno = {usuario.ApellidoMaterno},
                            @Email = {usuario.Email},
                            @Passwrd = {usuario.Passwrd},
                            @Sexo = {usuario.Sexo},
                            @Telefono = {usuario.Telefono},
                            @Celular = {usuario.Celular},
                            @FechaNacimiento = {usuario.FechaNacimiento},
                            @Curp = {usuario.CURP},
                            @IdRol = {usuario.Rol.IdRol}
                        ");
                    #endregion

                    if (queryUpdateUser > 0)
                    {
                        resultUpdateUser.Correct = true;
                    }
                    else
                    {
                        resultUpdateUser.Correct = false;
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

        public static ML.Result DeleteSP(int IdUsuario)
        {
            ML.Result resultDeleteUser = new ML.Result();

            try
            {
                using (DL.MrodriguezProgramacionNcapasContext context = new DL.MrodriguezProgramacionNcapasContext())
                {
                    var queryResult = context.Database.ExecuteSqlInterpolated($"EXECUTE UsuarioDelete @IdUsuario = {IdUsuario}");

                    if (queryResult > 0)
                    {
                        resultDeleteUser.Correct = true;
                    }
                    else
                    {
                        resultDeleteUser.Correct = false;
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

        #region Método de Excel

        //Este metodo me ayuda a leer mi archivo de excel
        public static ML.Result ReadExcelFile(string conectionString)
        {
            ML.Result resultReadExcelFile = new ML.Result();

            try
            {
                using (OleDbConnection context = new OleDbConnection(conectionString)) //Creo mi conexión con OleDb
                {
                    OleDbCommand oleDbCommand = new OleDbCommand(); //Inicializo mi calse OleDbCommand

                    oleDbCommand.Connection = context;
                    oleDbCommand.CommandText = "SELECT * FROM [Sheet1$]"; //Consulto mi archivo

                    context.Open();

                    //crea y configura una instancia de OleDbDataAdapter y oleDbCommand como argumento en su constructor.
                    OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter(oleDbCommand); //

                    DataTable dataTable = new DataTable();

                    oleDbDataAdapter.Fill(dataTable); //Lleno mi DataTable gracias a mi Adapter.

                    if (dataTable.Rows.Count > 0)
                    {
                        resultReadExcelFile.Objects = new List<object>(); //Inicializo mi lista

                        foreach (DataRow row in dataTable.Rows) //Itero por cada fila de mi datatable
                        {
                            // Validar si TODAS las columnas están vacías
                            bool filaVacia = row.ItemArray.All(
                                c => c == null || c == DBNull.Value || string.IsNullOrWhiteSpace(c.ToString())
                            );

                            if (filaVacia)
                                continue; // Salta a la siguiente fila sin procesar

                            ML.Usuario usuario = new ML.Usuario();

                            usuario.UserName = row[0].ToString();
                            usuario.Nombre = row[1].ToString();
                            usuario.ApellidoPaterno = row[2].ToString();
                            usuario.ApellidoMaterno = row[3].ToString();
                            usuario.Email = row[4].ToString();
                            usuario.Passwrd = row[5].ToString();
                            usuario.Sexo = row[6].ToString();
                            usuario.Telefono = row[7].ToString();
                            usuario.Celular = row[8].ToString();
                            usuario.FechaNacimiento = row[9].ToString();
                            usuario.CURP = row[10].ToString();

                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = Convert.ToInt32(row[11].ToString());

                            resultReadExcelFile.Objects.Add(usuario);
                        }
                        resultReadExcelFile.Correct = true;
                    }
                    else
                    {
                        resultReadExcelFile.Correct = false;
                    }

                    //if (fileExtension == ".xls")
                    //    conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Import_FileName + ";" + "Extended Properties='Excel 8.0;HDR=YES;'"

                    //    conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Import_FileName + ";" + "Extended Properties='Excel 12.0 Xml;HDR=YES;'";

                }
            }
            catch (Exception ex)
            {
                resultReadExcelFile.Correct = false;
                resultReadExcelFile.ErrorMessage = ex.Message;
                resultReadExcelFile.Ex = ex;
            }
            return resultReadExcelFile;
        }

        #endregion
    }//class
}//namespace
