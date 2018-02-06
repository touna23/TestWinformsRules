using System.Configuration;

namespace KieForms.Configurations
{
    public class Configuration : ConfigurationSection
    {
        public static Configuration GetConfiguration()
        {
            Configuration configuration =
                ConfigurationManager.GetSection("KieServer") as Configuration;

            if (configuration != null)
                return configuration;

            return new Configuration();
        }

        [ConfigurationProperty("HostUrl", IsRequired = false)]
        public string HostUrl
        {
            get
            {
                return this["HostUrl"] as string;
            }
        }

        [ConfigurationProperty("AuthUserName", IsRequired = false)]
        public string AuthUserName
        {
            get
            {
                return this["AuthUserName"] as string;
            }
        }

        [ConfigurationProperty("AuthPassword", IsRequired = false)]
        public string AuthPassword
        {
            get
            {
                return this["AuthPassword"] as string;
            }
        }

        [ConfigurationProperty("LookUp", IsRequired = false)]
        public string LookUp
        {
            get
            {
                return this["LookUp"] as string;
            }
        }

        [ConfigurationProperty("ContainerName1", IsRequired = false)]
        public string ContainerName1
        {
            get
            {
                return this["ContainerName1"] as string;
            }
        }

        [ConfigurationProperty("ContainerName2", IsRequired = false)]
        public string ContainerName2
        {
            get
            {
                return this["ContainerName2"] as string;
            }
        }


    }
}