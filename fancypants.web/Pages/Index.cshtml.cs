using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using fancypants.web.Model;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

namespace fancypants.web.Pages
{
    public class IndexModel : PageModel
    {
        public List<Photo> Images { get; set; }
        public Photo_Manifest Manifest { get; set; }
        public int SelectedSol { get; set; }
        private HttpClient _client;
        private IConfiguration _config;

        public IndexModel(IConfiguration config)
        {
            _config = config;
            _client = new HttpClient();
            Images = new List<Photo>();
        }

        public async Task<IActionResult> OnGet()
        {
            var apiKey = _config["API_KEY"];

            var manifestString = await _client.GetStringAsync($"https://api.nasa.gov/mars-photos/api/v1/manifests/curiosity?api_key={apiKey}");
            var m = JsonConvert.DeserializeObject<MissionManifest>(manifestString);
            Manifest = m.photo_manifest;

            do
            {
                SelectedSol = new Random().Next(Manifest.max_sol);
            }
            while (!Manifest.photos.Any(x => x.sol == SelectedSol));

            var images = await _client.GetStringAsync($"https://api.nasa.gov/mars-photos/api/v1/rovers/curiosity/photos?sol={SelectedSol}&api_key={apiKey}");
            var ir = JsonConvert.DeserializeObject<ImageRequest>(images);

            Images.AddRange(ir.photos);

            return Page();
        }
    }
}
