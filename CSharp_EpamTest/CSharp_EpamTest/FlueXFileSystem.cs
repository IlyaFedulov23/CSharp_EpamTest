using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CSharp_EpamTest
{
    static class FlueXFileSystem
    {
        // Save FlueXSystem object
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

        // Load FlueXSystem object
            public static bool LoadFile(ref string f_fileName, ref FlueXSystem f_FlueXSystem)
            {
                if (f_fileName == null)
                    return false;

                f_fileName += ".DAT";

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
                        Console.WriteLine("ERROR: File doesn't exist!\nPress any key to continue...");
                        Console.ReadKey();
                        return false;
                    }
                }

                return true;
            }
    }
}
