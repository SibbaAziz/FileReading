using System;
using System.Collections.Generic;
using System.Linq;

namespace FileReading.Security
{
    public enum Role
    {
        Admin,
        User
    }

    public class RoleBasedSecurity : ISecurity
    {
        private List<string> _accessibleFiles = new List<string>()
        {
            "Test.xml"
        };
        private Role _role; 
        public RoleBasedSecurity(Role role)
        {
            _role = role;
        }

        public RoleBasedSecurity(Role role, IEnumerable<string> accessibleFiles)
        {
            _role = role;
            _accessibleFiles = accessibleFiles?.ToList();
        }

        public bool CanRead(string path)
        {
            if (_role == Role.Admin)
                return true;

            if(_role == Role.User)
            {
                if (string.IsNullOrEmpty(path) || _accessibleFiles == null)
                    return false;
                var fileName = path.Split('/').LastOrDefault();

                return (_accessibleFiles.Contains(fileName)) ;
            }
            return false;
        }

        public bool CanWrite(string path)
        {
            throw new NotImplementedException();
        }


    }
}
