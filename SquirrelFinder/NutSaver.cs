using Newtonsoft.Json;
using SquirrelFinder.Nuts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace SquirrelFinder
{

    public static class NutSaver
    {
        public static IList<INut> GetNuts(string json)
        {
            var nuts = JsonConvert.DeserializeObject<List<Nut>>(json);

            var output = new List<INut>();
            foreach (var nut in nuts)
            {
                var directory = NutHelper.GetDirectoryFromUrl(nut.Url.ToString());
                if (string.IsNullOrEmpty(directory))
                {
                    output.Add(nut);
                }
                else
                {
                    output.Add(new LocalNut
                    {
                        Url = nut.Url,
                        HasShownMessage = nut.HasShownMessage,
                        LastResponse = nut.LastResponse,
                        State = nut.State,
                        Title = nut.Title
                    });
                }
            }
            return output;
        }

        public static void SaveNuts(IEnumerable<INut> nuts)
        {
            var json = JsonConvert.SerializeObject(nuts);
        }
    }
}
