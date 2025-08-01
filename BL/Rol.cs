using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Rol
    {
        public static ML.Result GetAllRolsLINQ()
        {
            ML.Result resultGetAllRols = new ML.Result();

            using (DL.MrodriguezProgramacionNcapasContext context = new DL.MrodriguezProgramacionNcapasContext())
            {
                try
                {
                    var listRoles = (from rolBD in context.Rols
                                     select rolBD).ToList();

                    if (listRoles.Count > 0)
                    {
                        resultGetAllRols.Objects = new List<object>();

                        foreach (var rolBD in listRoles)
                        {
                            ML.Rol rol = new ML.Rol();

                            rol.IdRol = rolBD.IdRol;  //rolBD. que trae los roles de mi lista asigna el valor a rol.
                            rol.Nombre = rolBD.Nombre;

                            resultGetAllRols.Objects.Add(rol);
                        }

                        resultGetAllRols.Correct = true;
                    }
                }
                catch (Exception ex)
                {
                    resultGetAllRols.Correct = false;
                    resultGetAllRols.ErrorMessage = ex.Message;
                }
            }

            return resultGetAllRols;
        }
    }
}
