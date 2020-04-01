using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepassDB_SYNC
{
    class Analizer
    {
        static public bool Checkup()
        {
            try
            {
                if (Directory.Exists(Properties.Settings.Default.OnServerDBLocation))
                    Logger.Write(Type.DEBUG, "You are connected to the server.");
                else
                    Logger.Write(Type.DEBUG, "You are not connected to the server.");

                var onServerLastModified = File.GetLastWriteTime(Properties.Settings.Default.OnServerDBLocation + "\\" + Properties.Settings.Default.Db_filename);
                var onLocalLastModified = File.GetLastWriteTime(Properties.Settings.Default.OnLocalDBLocation + "\\" + Properties.Settings.Default.Db_filename);

                if (!onServerLastModified.Equals(onLocalLastModified))
                {
                    if(onServerLastModified.CompareTo(onLocalLastModified) < 0)
                    {
                        MakeBackup(Properties.Settings.Default.OnServerDBLocation + "\\" + Properties.Settings.Default.Db_filename);
                        CopieFile(Properties.Settings.Default.OnLocalDBLocation + "\\" + Properties.Settings.Default.Db_filename, Properties.Settings.Default.OnServerDBLocation);
                    }
                    else if (onServerLastModified.CompareTo(onLocalLastModified) > 0)
                    {
                        MakeBackup(Properties.Settings.Default.OnLocalDBLocation + "\\" + Properties.Settings.Default.Db_filename);
                        CopieFile(Properties.Settings.Default.OnServerDBLocation + "\\" + Properties.Settings.Default.Db_filename, Properties.Settings.Default.OnLocalDBLocation);
                    }
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        static void CopieFile(String fileToCopie, String location)
        {
            File.Copy(fileToCopie, location+"\\"+Properties.Settings.Default.Db_filename);
        }

        static void MakeBackup(String pathFile)
        {
            File.Copy(pathFile, Properties.Settings.Default.BakupFolder+"\\"+Properties.Settings.Default.Db_filename+".bak");
            File.Delete(pathFile);
        }
    }
}
