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
using DmxController.StoryBoards;
using DmxController.Common.Configurations;

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
        private Configuration currentConfiguration;
        public event Action ConfigurationChanged;


        public Configuration CurrentConfiguration
        {
            get
            {
                return currentConfiguration;
            }
        }
        #endregion

        private FilesHandler ()
        {
        }

        private void OnConfigurationChanged ()
        {
            ConfigurationChanged?.Invoke();
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
                FileManager.Write(settingsPath, JsonHandler.ConstructConfigurationPacket(new Configuration()
                {
                    Hostname = "127.0.0.1",
                    LightAddress = 1,
                    ReceivePort = 5000,
                    SendPort = 15000,
                    TargetType = ViewModels.TargetTypeEnum.Projecteur
                }));
            }
        }
        
        public void SaveConfiguration (Configuration configuration)
        {
            string json = JsonHandler.ConstructConfigurationPacket(configuration);
            FileManager.Write(settingsPath, json, FileManager.WriteOptions.CreateDirectory);
            if (configuration.Hostname != CurrentConfiguration.Hostname || configuration.ReceivePort != CurrentConfiguration.ReceivePort || configuration.SendPort != CurrentConfiguration.SendPort)
                OnConfigurationChanged();
            currentConfiguration = new Configuration(configuration);
        }

        public Configuration OpenConfiguration ()
        {
            string json = FileManager.Read(settingsPath);

            Configuration c = JsonHandler.ParseConfigurationPacket(json);
            currentConfiguration = c;
            return c;
        }

        public void SaveStoryBoard(string storyBoardPath, StoryBoardElement[] storyBoardElements)
        {
            string json = JsonHandler.ConstructStoryBoardSave(storyBoardPath, storyBoardElements);
            FileManager.Write(storyBoardPath, json, FileManager.WriteOptions.CreateDirectory);
        }

        public JsonHandler.StoryBaordSave OpenStoryBoard(string fileName)
        {
            string json = FileManager.Read(fileName);
            return JsonHandler.ParseStoryBoard(json);
        }
    }
}
