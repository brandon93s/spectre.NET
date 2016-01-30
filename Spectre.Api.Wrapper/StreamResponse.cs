using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spectre.Api.Wrapper
{
    public class StreamResponse : Response
    {
        public Stream Result { get; set; }
    }
}
