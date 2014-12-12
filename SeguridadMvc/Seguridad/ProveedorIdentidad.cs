using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;

namespace SeguridadMvc.Seguridad
{
    public class ProveedorIdentidad:IIdentity
    {
        public string Name {
            get { return String.Format("{0} {1}", Nombre, Apellidos); }
             }
        public string AuthenticationType {
            get { return Identity.AuthenticationType; } 
        }
        public bool IsAuthenticated {
            get { return Identity.IsAuthenticated; }
        }
        public IIdentity Identity { get; set; }
        public String Nombre { get; set; }
        public String Apellidos { get; set; }
        public int IdUsuario { get; set; }
        public String[] Roles { get; set; }


        public ProveedorIdentidad(IIdentity identity)
        {
            Identity = identity;
            var usuario = 
                (UsuarioProveedorIdentidad)Membership.GetUser(identity.Name,false);

            Nombre = usuario.Nombre;
            Apellidos = usuario.Apellidos;
            IdUsuario = usuario.IdUsuario;
            Roles = usuario.Roles;
        }


    }
}