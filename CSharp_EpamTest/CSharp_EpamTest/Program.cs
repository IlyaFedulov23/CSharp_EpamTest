﻿using System;

// Version 1.0 - Ilya.F

namespace CSharp_EpamTest
{
    static class Program
    {
        static void Main(string[] args)
        {
            // Function Variables 
                FlueXSystem mainSystem = new FlueXSystem();

            // Function Body
                while(mainSystem._systemState != FLUEX_SYSTEMSTATE.EXIT)
                {
                    mainSystem._systemState = FLUEX_SYSTEMSTATE.RUNNING;
                    mainSystem.ShowInfo();

                    if (mainSystem._systemState != FLUEX_SYSTEMSTATE.RUNNING)
                    {
                        // Function Temp Variables 
                            string f_fileName = null;

                        // Check System State
                            switch (mainSystem._systemState)
                            {
                                case FLUEX_SYSTEMSTATE.LOADING: // Load File
                                    Console.Clear();
                                    if (0 == FlueXInput.TextInput("Enter load file name without file extension:", 
                                            ref f_fileName, true))
                                        continue;
                                    if (!FlueXFileSystem.LoadFile(ref f_fileName, ref mainSystem))
                                        continue;
                                    break;

                                case FLUEX_SYSTEMSTATE.SAVING: // Save File
                                    Console.Clear();
                                    if (0 == FlueXInput.TextInput("Enter save file name without file extension:", 
                                            ref f_fileName, true))
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
