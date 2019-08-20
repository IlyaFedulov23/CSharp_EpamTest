using System;
using System.Collections.Generic;

namespace CSharp_EpamTest
{
    enum FLUEX_SYSTEMSTATE { EMPTY, LOADED, LOADING, CREATINGNEW }

    class FlueXSystem
    {
        //Constructor & Destructor
        public FlueXSystem()
        {
            _systemState    = FLUEX_SYSTEMSTATE.EMPTY;
            _systemTask     = new FlueXTaskSystem();
        }

        //Methods
        public void Start() {
            ShowInfo();
        }

        void ShowInfo()
        {
            //Attributes
                string  f_savedText = null;
                int f_number        = 0;

            Console.Clear();
            //Show all the existing tasks
                if (!_systemTask.ShowList())
                {
                    _systemState = FLUEX_SYSTEMSTATE.EMPTY;
                    Console.Write("Task List is empty\n");
                    //Show Available Actions
                        Console.Write("1 - Create New task / 2 - Load From File\n\tSelect: ");
                } else
                {
                    _systemState = FLUEX_SYSTEMSTATE.LOADED;
                    //Show Available Actions
                        Console.Write("1 - Create New task / 2 - Load From File / 3 - Open / 4 - Delete\n\tSelect(q - exit): ");
                }

            //Select A Number
                f_savedText = Console.ReadLine();
                if (f_savedText == "q")
                    /* EXIT CODE */
                    return;
                if(!Int32.TryParse(f_savedText, out f_number))
                {
                    /* HERE IS AN ERROR CODE */
                }

        }

        //Methods::Control Processes
            bool Input(int f_number)
            {
            //Attributes
            string f_savedText = null;

            switch (_systemState)
            {
                case FLUEX_SYSTEMSTATE.EMPTY:
                    if(f_number > 2 || f_number < 1)
                        return false;
                    else
                        switch (f_number)
                        {
                            case 1:
                                if (!_systemUser.ShowList()) {
                                    Console.Write("User List is empty. Do you want to add new (c - cancel)?: ");
                                }
                                break;
                            case 2:

                                break;
                            default:
                                break;
                        }
                    break;

            }
            return true;
            }

        bool TextInput()
        {

        }
        //Attributes
            FLUEX_SYSTEMSTATE   _systemState;

        //Included Systems
            FlueXUserSystem     _systemUser;
            FlueXProjectSystem  _systemProject;
            FlueXTaskSystem     _systemTask;
    }
}
