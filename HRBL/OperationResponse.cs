using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRBL
{
    /// <summary>
    ///All Service calls return  OperationResponse providing info including
    ///Is call Success ,if error error message payload or list of provided - Type instances.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class OperationResponse<T>
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public long Id { get; set; }
        public object obj { get; set; }
        public T Item { get; set; }
        public List<T> Items { get; set; }
    }
}
