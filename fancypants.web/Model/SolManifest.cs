using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fancypants.web.Model
{
    public class SolManifest
    {
        public int sol { get; set; }
        public int total_photos { get; set; }
        public string[] cameras { get; set; }
    }
}
