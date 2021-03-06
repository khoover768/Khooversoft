﻿using Khooversoft.Actor;
using Khooversoft.Security;
using Khooversoft.Toolbox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khooversoft.Services
{
    public static class ActorKeyExtensions
    {
        public static ActorKey CreateActorKey(this LocalCertificateKey self)
        {
            return new ActorKey(self.ToString());
        }

        public static ActorKey CreateActorKey(this IdentityPrincipal self)
        {
            return new ActorKey(self.PrincipalId);
        }

        public static ActorKey CreateActorKey(this TokenKey self)
        {
            return new ActorKey(self.Value);
        }
    }
}
