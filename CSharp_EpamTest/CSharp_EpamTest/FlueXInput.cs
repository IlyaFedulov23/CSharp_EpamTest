using System;

namespace CSharp_EpamTest
{    
    // Three types of returned value
        enum FLUEX_INPUTVALUE { CANCEL, SKIP, YES }

    class FlueXInput
    {
        //Text Input Function
            static public FLUEX_INPUTVALUE TextInput(ref string f_savedText, string f_messageText, 
                bool f_cancelState = false, bool f_skipState = false)
            {
                //Body
                    while (true)
                    {
                        if (f_messageText != null)
                        {
                            Console.Write($"{f_messageText}");
                            if (f_cancelState)
                                Console.Write(" (c - cancel)");
                            if (f_skipState)
                                Console.Write(" (s - skip)");
                            Console.Write(": ");
                        }
                        f_savedText = Console.ReadLine();
                        if (f_cancelState) // Check cancel action
                        {
                            if (f_savedText == "c")
                                return FLUEX_INPUTVALUE.CANCEL;
                        }
                        if (f_skipState)    // Check skip action
                        {
                            if (f_savedText == "s")
                                return FLUEX_INPUTVALUE.SKIP;
                        }

                        if (f_savedText.Length <= 1)
                            Console.WriteLine("\nERROR: Unavailable action!");
                        else
                            return FLUEX_INPUTVALUE.YES;
                    }
            }

        //Number Input
            static public FLUEX_INPUTVALUE TextInput(ref string f_savedText, ref int f_num, int f_maxValue, 
                string f_messageText, bool f_cancelState = false, bool f_skipState = false)
            {
                //Body
                    while (true)
                    {
                        if (f_messageText != null)
                        {
                            Console.Write($"{f_messageText}");
                            if (f_cancelState)
                                Console.Write(" (c - cancel)");
                            if (f_skipState)
                                Console.Write(" (s - skip)");
                            Console.Write(": ");
                        }
                        f_savedText = Console.ReadLine();
                        if (f_cancelState) // Check cancel action
                        {
                            if (f_savedText == "c")
                                return FLUEX_INPUTVALUE.CANCEL;
                        }
                        if (f_skipState)    // Check skip action
                        {
                            if (f_savedText == "s")
                                return FLUEX_INPUTVALUE.SKIP;
                        }

                        if (!Int32.TryParse(f_savedText, out f_num))
                            Console.WriteLine("\nERROR: Unavailable action!");
                        else if (f_num <=0 || f_num > f_maxValue)
                            Console.WriteLine("\nERROR: Unavailable action!");
                        else
                            return FLUEX_INPUTVALUE.YES;
                    }
            }
    }
}
