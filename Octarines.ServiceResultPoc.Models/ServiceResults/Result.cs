using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octarines.ServiceResultPoc.Models.ServiceResults
{
    public abstract class Result<T>
    {
        public abstract ResultType ResultType { get; }
        public virtual IEnumerable<string> Errors => new List<string>();
        public virtual T Data => default(T);

        public bool HasErrors => Errors.Any();
    }
}
