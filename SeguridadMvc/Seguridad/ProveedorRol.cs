using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Security;
using SeguridadMvc.Models;

namespace SeguridadMvc.Seguridad
{
    public class ProveedorRol:RoleProvider
    {
        private int _cacheTimeoutInMinutes = 30;

        public override void Initialize(string name, NameValueCollection config)
        {
            int val;
            if (!String.IsNullOrEmpty(config["cacheTimeoutInMinutes"]) &&
                Int32.TryParse(config["cacheTimeoutInMinutes"], out val))
            {
                _cacheTimeoutInMinutes = val;
                base.Initialize(name, config);
            }


            base.Initialize(name, config);
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            var db = new SeguridadDemoEntities();

            var ok = db.Usuario.First(o => o.login == username).
                Rol.Any(o => o.nombre == roleName);

            return ok;

        }

        public override string[] GetRolesForUser(string username)
        {
            var db = new SeguridadDemoEntities();

            var ok = db.Usuario.First(o => o.login == username).
                Rol.Select(o => o.nombre).ToArray();

            return ok;
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName { get; set; }
    }
}