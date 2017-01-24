using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace PolicySearch.Configuration
{
    public class LuisConfig : ConfigurationSection
    {
        [ConfigurationProperty("appId", IsRequired = true)]
        public string AppId
        {
            get
            {
                return (string)this["appId"];
            }
            set
            {
                this["appId"] = value;
            }
        }

        [ConfigurationProperty("subscriptionKey", IsRequired = true)]
        public string SubscriptionKey
        {
            get
            {
                return (string)this["subscriptionKey"];
            }
            set
            {
                this["subscriptionKey"] = value;
            }
        }
    }
}