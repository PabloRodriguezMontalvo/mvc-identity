using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using SeguridadMvc.Models;

namespace SeguridadMvc.Seguridad
{
    public class UsuarioProveedorIdentidad:MembershipUser
    {
        public String Nombre { get; set; }
        public String Apellidos { get; set; }
        public int IdUsuario { get; set; }
        public String[] Roles { get; set; }
        public UsuarioProveedorIdentidad(Usuario usuario)
        {
            Nombre = usuario.nombre;
            Apellidos = usuario.apellido;
            IdUsuario = usuario.id;
            Roles = usuario.Rol.Select(o => o.nombre).ToArray();
        }
    }
}