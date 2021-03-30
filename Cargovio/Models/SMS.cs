using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Cargovio.Models
{
    public class SMS
    {
      
            public bool Send(string ContactNo, string MessageBody)
            {
                string key = "q5hv8s6rmk9oc1l";
                string secret = "u2lq03jx65kv6oo";
                string to = "91" + ContactNo;
                string messages = MessageBody;

                string sURL;


                sURL = "https://www.thetexting.com/rest/sms/json/message/send?api_key=" + key + "&api_secret=" + secret + "&to=" + to + "&text=" + messages;
                using (WebClient client = new WebClient())
                {

                    string s = client.DownloadString(sURL);

                    var responseObject = Newtonsoft.Json.JsonConvert.DeserializeObject(s);
                    string n = responseObject.ToString();
                    return true;

            }
            
        }
       
        abstract class RootObject
        {
            public WebResponse Response { get; set; }
            public string ErrorMessage { get; set; }
            public int Status { get; set; }
        }
    }
}