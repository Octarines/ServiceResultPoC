﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octarines.ServiceResultPoc.Models.ServiceResults
{
    public class UnauthorizedResult<T> : Result<T>
    {
        public override ResultType ResultType => ResultType.Unauthorized;

        public override IEnumerable<string> Errors => new List<string> { "The input was invalid." };

        public override T Data => default(T);

        public UnauthorizedResult() { }
    }
}