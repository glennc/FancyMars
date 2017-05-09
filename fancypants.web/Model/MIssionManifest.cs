using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fancypants.web.Model
{

    public class MissionManifest
    {
        public Photo_Manifest photo_manifest { get; set; }
    }

    public class Photo_Manifest
    {
        public string name { get; set; }
        public string landing_date { get; set; }
        public string launch_date { get; set; }
        public string status { get; set; }
        public int max_sol { get; set; }
        public string max_date { get; set; }
        public int total_photos { get; set; }
        public PhotoSummary[] photos { get; set; }
    }

    public class PhotoSummary
    {
        public int sol { get; set; }
        public int total_photos { get; set; }
        public string[] cameras { get; set; }
    }

}
