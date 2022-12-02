using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Web.Http;

namespace VKCreateLead.Controllers
{
    public class LeadController : ApiController
    {
        public string CreateLeadFromVKForm(VKUserEvent vkEvent)
        {
            try
            {
                if (vkEvent.type == "confirmation" && vkEvent.group_id == 215303511)
                {
                    return "622414a9";
                }

                if (vkEvent.type == "lead_forms_new" && vkEvent.group_id == 215303511)
                {
                    return JsonConvert.SerializeObject(vkEvent);
                }

                return "ok";
            }
            catch (Exception exc)
            {
                return $"Error create Lead {exc}";
            }
        }

        [HttpGet, Route("test")]
        public string test()
        {
            return "test2";
        }
    }

    public class VKUserEvent
    {
        [DataMember]
        public string type { get; set; }
        [DataMember]
        public VKEvent @object { get; set; }
        [DataMember]
        public int group_id { get; set; }
        [DataMember]
        public string secret { get; set; }
    }

    [DataContract]
    public class VKEvent
    {
        [DataMember]
        public int user_id { get; set; }
        [DataMember]
        public int lead_id { get; set; }
        [DataMember]
        public int group_id { get; set; }
        [DataMember]
        public int form_id { get; set; }
        [DataMember]
        public string form_name { get; set; }
        [DataMember]
        public int ad_id { get; set; }
        [DataMember]
        public VKAnswers[] answers { get; set; }
    }

    [DataContract]
    public class VKAnswers
    {
        [DataMember]
        public string key { get; set; }
        [DataMember]
        public string question { get; set; }
        [DataMember]
        public string answer { get; set; }
    }
}
