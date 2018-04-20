using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VPackage.Files;
using VPackage.Json;
using System.Windows;
using DmxController.Common.Json;

namespace DmxController.Common.Files
{
    public class FilesHandler
    {
        #region Singleton
        private static FilesHandler current;
        public static FilesHandler Current { get { if (current == null) current = new FilesHandler(); return current; } }
        #endregion


        #region Fields
        private string storyBoardPath;
        private string settingsPath;

        private JsonHandler.ConfigurationPacket currentConfiguration;
        private event Action ConfigurationChanged;
        #endregion

        private FilesHandler ()
        {
        }

        private void OnConfigurationChanged ()
        {
            if (ConfigurationChanged != null) ConfigurationChanged();
        }

        public void Initialize (string storyBoardPath, string settingsPath)
        {
            this.storyBoardPath = storyBoardPath;
            this.settingsPath = settingsPath;

            CheckFilesIntegrity();
        }

        private void CheckFilesIntegrity()
        {
            Directory.CreateDirectory(storyBoardPath);
            Directory.CreateDirectory(Path.GetDirectoryName(settingsPath));

            if (!File.Exists(settingsPath))
            {
                FileManager.Write(settingsPath, JsonHandler.ConstructConfigurationPacket(new JsonHandler.ConfigurationPacket()));
            }
        }

        public JsonHandler.ConfigurationPacket GetConfiguration ()
        {
            if (currentConfiguration == null)
            {
                string s = FileManager.Read(settingsPath);
                currentConfiguration = JSONSerializer.Deserialize<JsonHandler.ConfigurationPacket>(s);
            }

            return currentConfiguration;
        }

        public void ChangeConfiguration (JsonHandler.ConfigurationPacket conf)
        {
            FileManager.Write(settingsPath, JSONSerializer.Serialize<JsonHandler.ConfigurationPacket>(conf), FileManager.WriteOptions.CreateDirectory);
            OnConfigurationChanged();
        }
    }
}
