using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Experia.Framework
{
    public class FileIO
    {
        public static FileIO Instance { get { return Experia.Framework.Generics.Singleton<FileIO>.Instance; } }
        protected FileIO()
        {

        }

        public void CreateHardwareProfile()
        {
            string directory = @"Configs";
            string path = @"Configs\\HardwareProfile.conf";

            //Check to see if the Tree structure has been setup
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            //Verify that our files were even created and honor user changes
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("[Machine Name]" + Environment.NewLine + Environment.MachineName);
                    sw.WriteLine("[Machine User Name]" + Environment.NewLine + Environment.UserName);
                    sw.WriteLine("[OS Version]" + Environment.NewLine + Environment.OSVersion);
                    sw.WriteLine("[OS 64-bit]" + Environment.NewLine + Environment.Is64BitOperatingSystem);
                    sw.WriteLine("[Processor Count]" + Environment.NewLine + Environment.ProcessorCount);
                    sw.WriteLine("[RAM] " + Environment.NewLine + ((new Microsoft.VisualBasic.Devices.ComputerInfo().TotalPhysicalMemory / 1048576) + 1) + "MB");
                    sw.WriteLine("[Graphics Card]" + Environment.NewLine + GraphicsManager.Instance.Device.Adapter.Description);
                    sw.WriteLine("[Native Resolution]" + Environment.NewLine + GraphicsManager.Instance.Device.DisplayMode.Width + "x" + GraphicsManager.Instance.Device.DisplayMode.Height);
                    sw.WriteLine("[Landscape Orientation]" + Environment.NewLine + GraphicsManager.Instance.Device.Adapter.IsWideScreen);
                    sw.WriteLine("[Aspect Ratio]" + Environment.NewLine + GraphicsManager.Instance.Device.DisplayMode.AspectRatio);
                }
            }
            else if(File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("[Machine Name]" + Environment.NewLine + Environment.MachineName);
                    sw.WriteLine("[Machine User Name]" + Environment.NewLine + Environment.UserName);
                    sw.WriteLine("[OS Version]" + Environment.NewLine + Environment.OSVersion);
                    sw.WriteLine("[OS 64-bit]" + Environment.NewLine + Environment.Is64BitOperatingSystem);
                    sw.WriteLine("[Processor Count]" + Environment.NewLine + Environment.ProcessorCount);
                    sw.WriteLine("[RAM] " + Environment.NewLine + ((new Microsoft.VisualBasic.Devices.ComputerInfo().TotalPhysicalMemory / 1048576) + 1) + "MB");
                    sw.WriteLine("[Graphics Card]" + Environment.NewLine + GraphicsManager.Instance.Device.Adapter.Description);
                    sw.WriteLine("[Native Resolution]" + Environment.NewLine + GraphicsManager.Instance.Device.DisplayMode.Width + "x" + GraphicsManager.Instance.Device.DisplayMode.Height);
                    sw.WriteLine("[Landscape Orientation]" + Environment.NewLine + GraphicsManager.Instance.Device.Adapter.IsWideScreen);
                    sw.WriteLine("[Aspect Ratio]" + Environment.NewLine + GraphicsManager.Instance.Device.DisplayMode.AspectRatio);
                }
            }
        }

        public void CreateUserSettings()
        {

        }
        public void LoadUserSettings()
        {

        }

    }
}
