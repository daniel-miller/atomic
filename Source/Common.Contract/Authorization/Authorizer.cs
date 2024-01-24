﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Contract.Security
{
    public class Authorizer
    {
        private readonly List<Permission> _permissions = new List<Permission>();
        private readonly Guid _root;

        public Authorizer(Guid root)
        {
            _root = root;
        }

        public void Add(Guid function, Guid resource, Guid role)
        {
            if (IsGranted(function, resource, role))
                return;

            var permission = new Permission
            {
                Function = new Function { Identifier = function },
                Resource = new Resource { Identifier = resource },
                Role = new Role { Identifier = role }
            };

            _permissions.Add(permission);
        }

        public bool IsGranted(Guid function, Guid resource, Guid role)
        {
            return _permissions.Any(rule => rule.Function.Identifier == function && rule.Resource.Identifier == resource && rule.Role.Identifier == role);
        }

        public bool IsGranted(Guid function, Guid resource, IEnumerable<Guid> roles)
        {
            if (IsRoot(roles))
                return true;

            if (!_permissions.Any(rule => rule.Resource.Identifier == resource && rule.Function.Identifier == function))
                return false;

            var grants = _permissions
                .Where(rule => rule.Resource.Identifier == resource && rule.Function.Identifier == function)
                .Select(rule => rule.Role.Identifier);

            return roles.Intersect(grants).Any();
        }

        private bool IsRoot(IEnumerable<Guid> roles)
        {
            return roles.Any(role => role == _root);
        }
    }
}