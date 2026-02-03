    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common
{
    public class PageResult<T>
    {
        public List<T> Data { get; set; } = new List<T>();
        public int Count { get; set; }
    }
}
