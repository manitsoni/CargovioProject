using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class SharedCode
    {
        public static T JsonCast<T>(this Object myobj)
        {
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(myobj,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                    NullValueHandling = NullValueHandling.Ignore
                }));
        }
    }
}
