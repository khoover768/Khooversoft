﻿using Khooversoft.Toolbox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khooversoft.Services
{
    public class PrincipalId : StringType
    {
        public PrincipalId(string value)
            : base(value, 100)
        {
        }

        /// <summary>
        /// Implicit conversion to string
        /// </summary>
        /// <param name="source">source reference</param>
        public static implicit operator string(PrincipalId source)
        {
            return source?.Value;
        }

        public override string ToString()
        {
            return Value;
        }

        public override bool IsValueValid()
        {
            if (!base.IsValueValid())
            {
                return false;
            }

            return Value.IndexOf('/') == -1 &&
                Value.IndexOf('\\') == -1;
        }
    }
}
