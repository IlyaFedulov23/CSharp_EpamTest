using System;


namespace CSharp_EpamTest
{
    class Program
    {
        static void Main(string[] args)
        {

            FlueXSystem mainSystem = new FlueXSystem();

            while(mainSystem._systemState != FLUEX_SYSTEMSTATE.EXIT)
            {
                mainSystem._systemState = FLUEX_SYSTEMSTATE.RUNNING;
                mainSystem.ShowInfo();
                if (mainSystem._systemState != FLUEX_SYSTEMSTATE.RUNNING)
                {
                    //Attributes
                    string f_fileName = null;
                    switch (mainSystem._systemState)
                    {
                        case FLUEX_SYSTEMSTATE.LOADING:
                            Console.Clear();
                            if (0 == FlueXInput.TextInput("Enter load file name with file extension:", ref f_fileName, true))
                                continue;
                            if (!FlueXFileSystem.LoadFile(ref f_fileName, ref mainSystem))
                                continue;
                            break;
                        case FLUEX_SYSTEMSTATE.SAVING:
                            Console.Clear();
                            if (0 == FlueXInput.TextInput("Enter save file name without file extension:", ref f_fileName, true))
                                continue;
                            if (!FlueXFileSystem.SaveFile(ref f_fileName, ref mainSystem))
                                continue;
                            break;
                    }
                }
            }
        }
    }
}
