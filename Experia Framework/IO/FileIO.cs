using System;
using System.IO;
using System.Net;
using System.Xml;
using System.Text;
using System.Management;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Microsoft.VisualBasic.Devices;
using Microsoft.Xna.Framework.Graphics;

namespace Experia.Framework
{
    public class FileIO
    {
        public static FileIO Instance { get { return Experia.Framework.Generics.Singleton<FileIO>.Instance; } }
        protected enum ExperiaDirectories { Configs, Game, Logs, Assets }
        protected enum ExperiaFiles { HardwareProfile, UserSettings, EngineSettings }
        protected Dictionary<ExperiaDirectories, string> m_Directories;
        protected Dictionary<ExperiaFiles, string> m_Paths;
        protected FileIO()
        {
            m_Directories = new Dictionary<ExperiaDirectories, string>();
            m_Paths = new Dictionary<ExperiaFiles, string>();

            m_Directories.Add(ExperiaDirectories.Configs, @"Configs\");
            m_Paths.Add(ExperiaFiles.HardwareProfile, m_Directories[ExperiaDirectories.Configs] + "HardwareProfile.xml");
            m_Paths.Add(ExperiaFiles.UserSettings, m_Directories[ExperiaDirectories.Configs] + "UserSettings.xml");
        }

        public void XmlWriteElement(XmlWriter writer, string tag, string value)
        {
            writer.WriteStartElement(tag);
            writer.WriteString(value);
            writer.WriteEndElement();
        }

        #region XmlWriteAttributeElement
        public void XmlWriteAttributeElement(XmlWriter writer, string tag, string attributeTag, string attributeValue)
        {
            if (writer != null)
            {
                writer.WriteStartElement(tag);
                writer.WriteAttributeString(attributeTag, attributeValue);
            }
            else
            {
                throw new ArgumentNullException(writer.GetType().Name, "Writer is Null, please generate one using XmlWriter.Create().");
            }
        }

        /// <summary>
        /// Writes an XML Element with Attributes using a Dictionary of items.
        /// </summary>
        /// <param name="writer">Writer that has the assigned file location</param>
        /// <param name="tag">Xml Open Tag</param>
        /// <param name="attributePool">Dictionary of your attributes ["Key" Being your attirbute name and "Value" being it's value]</param>
        public void XmlWriteAttributeElement(XmlWriter writer, string tag, Dictionary<string, string> attributePool)
        {
            if (writer != null)
            {
                writer.WriteStartElement(tag);
                foreach (KeyValuePair<string, string> kvp in attributePool)
                {
                    writer.WriteAttributeString(kvp.Key, kvp.Value);
                }
                writer.WriteEndElement();
            }
            else
            {
                throw new ArgumentNullException(writer.GetType().Name, "Writer is Null, please generate one using XmlWriter.Create().");
            }
        }

        /// <summary>
        /// Writes an XML Element with Attributes using a Dictionary of items.
        /// </summary>
        /// <param name="writer">Writer that has the assigned file location</param>
        /// <param name="tag">Xml Open Tag</param>
        /// <param name="attributePool">Dictionary of your attributes ["Key" Being your attirbute name and "Value" being it's value]</param>
        public void XmlWriteAttributeElement(XmlWriter writer, string tag, Dictionary<string, string> attributePool, bool writeEndElement)
        {
            if (writer != null)
            {
                writer.WriteStartElement(tag);
                foreach (KeyValuePair<string, string> kvp in attributePool)
                {
                    writer.WriteAttributeString(kvp.Key, kvp.Value);
                }
                if (writeEndElement)
                {
                    writer.WriteEndElement();
                }
            }
            else
            {
                throw new ArgumentNullException(writer.GetType().Name, "Writer is Null, please generate one using XmlWriter.Create().");
            }
        }

        public void XmlWriteAttributeElement(XmlWriter writer, string tag, string attributeTag, string attributeValue, string descriptionValue)
        {
            if (writer != null)
            {
                writer.WriteStartElement(tag);
                writer.WriteAttributeString(attributeTag, attributeValue);
                writer.WriteString(descriptionValue);
                writer.WriteEndElement();
            }
            else
            {
                throw new ArgumentNullException(writer.GetType().Name, "Writer is Null, please generate one using XmlWriter.Create().");
            }
        }
        /// <summary>
        /// Writes an XML Element with Attributes using a Dictionary of items.
        /// </summary>
        /// <param name="writer">Writer that has the assigned file location</param>
        /// <param name="tag">Xml Open Tag</param>
        /// <param name="attributePool">Dictionary of your attributes ["Key" Being your attirbute name and "Value" being it's value]</param>
        /// <param name="descriptionValue">Element Description Value</param>
        public void XmlWriteAttributeElement(XmlWriter writer, string tag, Dictionary<string, string> attributePool, string descriptionValue)
        {
            if (writer != null)
            {
                writer.WriteStartElement(tag);
                foreach (KeyValuePair<string, string> kvp in attributePool)
                {
                    writer.WriteAttributeString(kvp.Key, kvp.Value);
                }
                writer.WriteString(descriptionValue);
                writer.WriteEndElement();
            }
            else
            {
                throw new ArgumentNullException(writer.GetType().Name, "Writer is Null, please generate one using XmlWriter.Create().");
            }
        }
        #endregion

        public void XmlClose(XmlWriter writer)
        {
            writer.WriteEndDocument();
            writer.Close();
            writer.Flush();
        }
        /// <summary>Generates an XML containing user hardware information.</summary>
        /// <param name="graphics">GraphicsDevice so that we can easily probe for the GPU</param>
        public void CreateHardwareProfile(GraphicsDevice graphics)
        {
            //Check to see if the Tree structure has been setup
            if (!Directory.Exists(m_Directories[ExperiaDirectories.Configs]))
            {
                Directory.CreateDirectory(m_Directories[ExperiaDirectories.Configs]);
            }

            XmlWriterSettings settings = new XmlWriterSettings { Encoding = Encoding.UTF8, Indent = true };

            //This takes a bit so lets makesure we even need to create this doc
            //if (!File.Exists(m_Paths[ExperiaFiles.HardwareProfile]))
            if(true)
            {
                XmlWriter writer = XmlWriter.Create(m_Paths[ExperiaFiles.HardwareProfile], settings);

                //OS Info
                XmlWriteAttributeElement(writer, "Machine", "HWGUID", ExperiaHelper.Instance.HardwareGuidGen(graphics).ToString());
                XmlWriteAttributeElement(writer, "OS", "Is64Bit", Environment.Is64BitOperatingSystem.ToString(), Environment.OSVersion.ToString()); 
                
                //Processor Write
                ManagementObject processorObject = new ManagementObject("Win32_Processor.DeviceID='CPU0'");
                Dictionary<string, string> processorInfo = new Dictionary<string, string>();
                processorInfo.Add("Count", Environment.ProcessorCount.ToString());
                processorInfo.Add("Clock", processorObject["CurrentClockSpeed"].ToString());
                processorInfo.Add("MaxClock", processorObject["MaxClockSpeed"].ToString());
                processorInfo.Add("L2", processorObject["L2CacheSize"].ToString());
                processorInfo.Add("L3", processorObject["L3CacheSize"].ToString());
                XmlWriteAttributeElement(writer, "Processor", processorInfo, processorObject["Name"].ToString());
                processorObject.Dispose();

                //Memory Info
                XmlWriteAttributeElement(writer, "RAM", "Bytes", new ComputerInfo().TotalPhysicalMemory.ToString());
                writer.WriteEndElement();
                
                //Network Info
                Dictionary<string, string> networkInfo = new Dictionary<string, string>();
                networkInfo.Add("ComputerName", Environment.MachineName);
                networkInfo.Add("UserName", Environment.UserName);
                XmlWriteAttributeElement(writer, "Network", networkInfo, false);
                networkInfo.Clear();
                //Network Adapter Info
                for(int i = 0; i < NetworkInterface.GetAllNetworkInterfaces().Length; i++)
                {
                    if (NetworkInterface.GetAllNetworkInterfaces()[i].OperationalStatus == OperationalStatus.Up)
                    {
                        networkInfo.Add("Name", NetworkInterface.GetAllNetworkInterfaces()[i].Description);
                        networkInfo.Add("Speed", NetworkInterface.GetAllNetworkInterfaces()[i].Speed.ToString());
                        networkInfo.Add("MAC", NetworkInterface.GetAllNetworkInterfaces()[i].GetPhysicalAddress().ToString());
                        XmlWriteAttributeElement(writer, "Adapter", networkInfo, false);
                        writer.WriteEndElement();
                        networkInfo.Clear();
                    }
                }
                writer.WriteEndElement();

                //Gpu Info
                Dictionary<string, string> gpuAttributes = new Dictionary<string, string>();
                gpuAttributes.Add("ID", graphics.Adapter.DeviceId.ToString());
                gpuAttributes.Add("VendorID", graphics.Adapter.VendorId.ToString());
                gpuAttributes.Add("SystemID", graphics.Adapter.SubSystemId.ToString());
                gpuAttributes.Add("Revision", graphics.Adapter.Revision.ToString());
                gpuAttributes.Add("HiDefCapable", graphics.Adapter.IsProfileSupported(GraphicsProfile.HiDef).ToString());
                XmlWriteAttributeElement(writer, "GPU", gpuAttributes, graphics.Adapter.Description);
                //Gpu Desktop Res
                Dictionary<string, string> gpuDesktopRes = new Dictionary<string, string>();
                gpuDesktopRes.Add("X", graphics.Adapter.CurrentDisplayMode.Width.ToString());
                gpuDesktopRes.Add("Y", graphics.Adapter.CurrentDisplayMode.Height.ToString());
                XmlWriteAttributeElement(writer, "DesktopResolution", gpuDesktopRes);

                //Close out the file
                XmlClose(writer);
                writer = null;
            }

            settings = null;
        }

        public void CreateUserSettings()
        {
            XmlWriterSettings settings = new XmlWriterSettings { Encoding = Encoding.UTF8, Indent = true };

            //XmlWriter writer = XmlWriter.Create(m_Paths[ExperiaFiles.UserSettings], settings);
        }
        public void LoadUserSettings()
        {

        }

    }
}
