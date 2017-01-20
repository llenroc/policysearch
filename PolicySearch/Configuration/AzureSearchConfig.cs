using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace PolicySearch.Configuration
{
    public class AzureSearchConfig : ConfigurationSection
    {
        [ConfigurationProperty("serviceName", IsRequired = true)]
        public string ServiceName
        {
            get
            {
                return (string)this["serviceName"];
            }
            set
            {
                this["serviceName"] = value;
            }
        }

        [ConfigurationProperty("apiKey", IsRequired = true)]
        public string APIKey
        {
            get
            {
                return (string)this["apiKey"];
            }
            set
            {
                this["apiKey"] = value;
            }
        }

        [ConfigurationProperty("indexName", IsRequired = true)]
        public string IndexName
        {
            get
            {
                return (string)this["indexName"];
            }
            set
            {
                this["indexName"] = value;
            }
        }
    }
}