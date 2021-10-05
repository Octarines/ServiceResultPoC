using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octarines.ServiceResultPoc.Models.ServiceResults
{
    public enum ResultType
    {
        Success,
        NotFound,
        Unauthorized,
        Invalid,
        Unexpected
    }
}
