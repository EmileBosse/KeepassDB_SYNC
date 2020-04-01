using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepassDB_SYNC
{
    public enum Type { DEBUG, INFO, ERROR }

    public class Logger
    {
        static public void Write(Type t, String m)
        {
            try
            {
                String fileName = GetFileName(t);
                String message = GetMessage(m);

                using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(Properties.Settings.Default.logFolder+"\\"+fileName, true))
                {
                    file.WriteLine(message);
                }
            }
            catch (Exception){}
        }

        static String GetMessage(String m)
        {
            return "["+ DateTimeOffset.Now.ToString()+"] -> "+m;
        }

        static String GetFileName(Type type)
        {
            switch (type)
            {
                case Type.DEBUG:
                    return "DEBUG_" + DateTimeOffset.Now.Date.ToString().Split()[0]+".log";

                case Type.ERROR:
                    return "ERROR_" + DateTimeOffset.Now.Date.ToString().Split()[0] + ".log";

                case Type.INFO:
                    return "INFO_" + DateTimeOffset.Now.Date.ToString().Split()[0] + ".log";

                default:
                    throw new Exception("This is not a valid type.");
            }
        }
    }
}
