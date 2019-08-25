using System;

// v1.1 d8/25/2019 

namespace CSharp_EpamTest
{
    /*  CANCEL - when you need to cancel current action 
        SKIP - when you need to skip current action and continue
        YES - for continue without skip */
        enum FLUEX_INPUTVALUE { CANCEL, SKIP, YES }

    static class FlueXInput
    {
        /*  Text Input: 
            Save user input into "f_savedText" variable 
            and return "FLUEX_INPUTVALUE" */
        public static FLUEX_INPUTVALUE TextInput(string f_messageText, ref string f_savedText, 
                bool f_cancelState = false, bool f_skipState = false)
        {
            // Function Body
                while (true)
                {
                    if (f_messageText != null)
                    {
                        Console.Write($"{f_messageText}");
                        if (f_cancelState)
                            Console.Write(" (C - cancel)");
                        if (f_skipState)
                            Console.Write(" (S - skip)");
                        Console.Write(": ");
                    }

                    f_savedText = Console.ReadLine(); 

                    if (f_cancelState)
                    {
                        if (f_savedText.ToLower() == "c")
                            return FLUEX_INPUTVALUE.CANCEL;
                    }
                    if (f_skipState)
                    {
                        if (f_savedText.ToLower() == "s")
                        {
                            f_savedText = null;
                            return FLUEX_INPUTVALUE.SKIP;
                        }
                    }

                    if (f_savedText.Length <= 1)
                        Console.WriteLine("ERROR: Unavailable action!");
                    else
                        return FLUEX_INPUTVALUE.YES;
                }
        }

        /*  Number Input: 
            Save user input into "f_num" variable 
            and return "FLUEX_INPUTVALUE" */
        public static FLUEX_INPUTVALUE TextInput(string f_messageText, ref int f_num, int f_maxValue, 
                bool f_cancelState = false, bool f_skipState = false, int f_minValue = 1)
        {

            // Function Variables
                string f_savedText = null;

            // Function Body
                while (true)
                {
                    if (f_messageText != null)
                    {
                        Console.Write($"{f_messageText}");
                        if (f_cancelState)
                            Console.Write(" (C - cancel)");
                        if (f_skipState)
                            Console.Write(" (S - skip)");
                        Console.Write(": ");
                    }

                    f_savedText = Console.ReadLine();

                    if (f_cancelState)
                    {
                        if (f_savedText.ToLower() == "c")
                            return FLUEX_INPUTVALUE.CANCEL;
                    }
                    if (f_skipState)
                    {
                        if (f_savedText.ToLower() == "s")
                        {
                            f_num = 0;
                            return FLUEX_INPUTVALUE.SKIP;
                        }
                    }

                    if (!Int32.TryParse(f_savedText, out f_num))
                        Console.WriteLine("\nERROR: Unavailable action!");
                    else if (f_num < f_minValue || f_num > f_maxValue)
                        Console.WriteLine("\nERROR: Unavailable action!");
                    else
                        return FLUEX_INPUTVALUE.YES;
                }
        }
    }
}
