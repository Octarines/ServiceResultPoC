using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octarines.ServiceResultPoc.Models.ServiceResults
{
    public class SuccessResult<T> : Result<T>
    {
        private readonly T _data;

        public override ResultType ResultType => ResultType.Success;

        public override T Data => _data;

        public SuccessResult(T data = default)
        {
            _data = data;
        }        
    }
}
