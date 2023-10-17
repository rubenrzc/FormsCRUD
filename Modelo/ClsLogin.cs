using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ClsLogin
    {
        public static int IniciarSesion( int id)
        {
            int usuarioId = 0;
            EntidadesDataContext context = new EntidadesDataContext();
            var query = context.Usuarios.Where(u=>u.Id_Usuario == id).Select(u=>u);
            var query1 = from p in context.Usuarios where p.Id_Usuario==id select p;

            if(query.Count() > 0) {
                usuarioId = query.First().Id_Usuario;
            }
            return usuarioId;
        }
    }
}
