using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VPackage.Files;
using VPackage.Json;

namespace DmxController.Common.Configuration
{
    public class ConfigurationHandler
    {
        private string configurationPath;
        private Configuration currentConfiguration;

        public ConfigurationHandler (string configurationPath)
        {
            this.ConfigurationPath = configurationPath;
        }

        public string ConfigurationPath
        {
            get
            {
                return configurationPath;
            }

            set
            {
                configurationPath = value;
            }
        }

        public Configuration CurrentConfiguration
        {
            get
            {
                return new Configuration(currentConfiguration);
            }

            set
            {
                currentConfiguration = value;
            }
        }

        public void WriteConfiguration ()
        {
            string json = JSONSerializer.Serialize<Configuration>(CurrentConfiguration);
            FileManager.Write(ConfigurationPath, json, FileManager.WriteOptions.CreateDirectory);
        }

        public void SearchConfiguration ()
        {
            string file = FileManager.Read(ConfigurationPath);
            CurrentConfiguration = JSONSerializer.Deserialize<Configuration>(file);
        }
    }
}
