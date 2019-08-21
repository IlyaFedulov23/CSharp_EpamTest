using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CSharp_EpamTest
{
    class FlueXFileSystem
    {
        public static bool SaveFile(ref string f_fileName, ref FlueXSystem f_FlueXSystem)
        {
            if (f_fileName == null)
                return false;

            f_fileName += ".DAT";

            BinaryFormatter f_BF = new BinaryFormatter();

            using (FileStream f_FS = new FileStream(f_fileName, FileMode.OpenOrCreate))
            {
                f_BF.Serialize(f_FS, f_FlueXSystem);
        }

            return true;
        }

        public static bool LoadFile(ref string f_fileName, ref FlueXSystem f_FlueXSystem)
        {
            if (f_fileName == null)
                return false;

            BinaryFormatter f_BF = new BinaryFormatter();

            using (FileStream f_FS = new FileStream(f_fileName, FileMode.OpenOrCreate))
            {
                try
                {
                    f_FlueXSystem = (FlueXSystem)f_BF.Deserialize(f_FS);
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("ERROR: Something wrong! Try again.");
                    return false;
                }
            }

            return true;
        }
    }
}
