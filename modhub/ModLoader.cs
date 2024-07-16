using System;
using System.IO;
using System.Windows.Forms;

namespace modhub
{

    public static class ModLoader
    {
        public static string[] GetMods()
        {
            string modsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "mods");

            if (Directory.Exists(modsDirectory))
            {
                string[] subDirectories = Directory.GetDirectories(modsDirectory);
                if (subDirectories.Length > 0)
                {
                    string[] folderNames = new string[subDirectories.Length];
                    for (int i = 0; i < subDirectories.Length; i++)
                    {
                        folderNames[i] = Path.GetFileName(subDirectories[i]);
                    }
                    return folderNames;
                }
            }

            return new string[0]; // 返回空数组
        }
    }
}