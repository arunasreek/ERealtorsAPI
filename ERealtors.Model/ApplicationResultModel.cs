using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERealtors.Model
{
    public class ApplicationResultModel
    {
        public bool Success { get; set; }
        public string Error { get; set; }
        public object Result { get; set; }
    }
}
