using Newtonsoft.Json;
using SquirrelFinder.Nuts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace SquirrelFinder
{
    public class NutBox
    {
        public NutBox() { }

        public NutBox(IEnumerable<INut> nuts)
        {
            Nuts = new List<Nut>();
            SitefinityNuts = new List<SitefinityNut>();
            LocalNuts = new List<LocalNut>();
            LocalSitefinityNuts = new List<LocalSitefinityNut>();

            foreach (var nut in nuts)
            {
                if (nut is LocalSitefinityNut)
                    LocalSitefinityNuts.Add(nut as LocalSitefinityNut);
                else if (nut is LocalNut)
                    LocalNuts.Add(nut as LocalNut);
                else if (nut is SitefinityNut)
                    SitefinityNuts.Add(nut as SitefinityNut);
                else if (nut is Nut)
                    Nuts.Add(nut as Nut);
                else
                    continue;
            }
        }

        public List<Nut> Nuts { get; set; }
        public List<SitefinityNut> SitefinityNuts { get; set; }
        public List<LocalNut> LocalNuts { get; set; }
        public List<LocalSitefinityNut> LocalSitefinityNuts { get; set; }

    }

    public static class NutSaver
    {
        public static NutBox GetNuts(string filePath = "nutbox.json")
        {
            var serializedData = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<NutBox>(serializedData);
        }

        public static void SaveNuts(IEnumerable<INut> nuts, string filePath = "nutbox.json")
        {
            var serializedNutBox = JsonConvert.SerializeObject(new NutBox(nuts));
            File.Delete(filePath);
            File.AppendAllText(filePath, serializedNutBox);
        }
    }
}
