using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ClsUsuario
    {
        public static Usuarios BuscarUsuariosById(int id)
        {
            Usuarios usuario = new Usuarios();

            EntidadesDataContext context = new EntidadesDataContext();
            var query = context.Usuarios.Where(u => u.Id_Usuario == id).Select(u => u);

            if (query.Count() > 0)
            {
                usuario = query.First();
            }
            return usuario;
        }

        public static object BuscarUsuarios()
        {

            EntidadesDataContext context = new EntidadesDataContext();
            var usuarios = from u in context.Usuarios
                           join c in context.Ciudades
                           on u.Ciudad equals c.Id
                           orderby u.Nombre ascending
                           select new
                           {
                               Id = u.Id_Usuario,
                               Nombre = u.Nombre,
                               Edad = u.Edad,
                               Correo = u.Correo,
                               Ciudad = c.Nombre
                           };

            return usuarios;
        }
        public static bool AddUsuario(Usuarios usu)
        {
            EntidadesDataContext context = new EntidadesDataContext();
            context.Usuarios.InsertOnSubmit(usu);
            try
            {
                context.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                context.SubmitChanges();
                return false;
            }
        }

        public static bool UpdateUsuario(Usuarios usu)
        {
            EntidadesDataContext context = new EntidadesDataContext();
            var query = context.Usuarios.Where(u => u.Id_Usuario == usu.Id_Usuario).Select(u => u).FirstOrDefault();
            query.Nombre = usu.Nombre;
            query.Edad = usu.Edad;
            query.Correo = usu.Correo;
            query.Ciudad = usu.Ciudad;
            query.Fecha_Nacimiento = usu.Fecha_Nacimiento;
            try
            {
                context.SubmitChanges();
                return true;
            } catch (Exception ex)
            {
                context.SubmitChanges();
                return false;
            }
        }

        public static bool RemoveUsuario(int sID)
        {
            EntidadesDataContext context = new EntidadesDataContext();
            try
            {
                var query = context.Usuarios.Where(u=>u.Id_Usuario==sID).Select(u=>u);

                context.Usuarios.DeleteAllOnSubmit(query);
                context.SubmitChanges();
                return true;
            }catch (Exception ex)
            {
                context.SubmitChanges();
                return false;
            }
            
        }
    }
}
