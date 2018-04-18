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
        #endregion

        private FilesHandler ()
        {
        }

        public void Initialize (string storyBoardPath, string settingsPath)
        {
            this.storyBoardPath = storyBoardPath;
            this.settingsPath = settingsPath;

            CheckFilesIntegrity();
        }


        private void CheckFilesIntegrity()
        {
            MessageBox.Show("Ok");
            MessageBox.Show(storyBoardPath);
            Directory.CreateDirectory(storyBoardPath);
            Directory.CreateDirectory(Path.GetDirectoryName(settingsPath));
        }
    }
}
