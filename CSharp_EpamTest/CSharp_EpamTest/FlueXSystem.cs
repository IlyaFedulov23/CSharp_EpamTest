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
            int f_num = 0;
            string f_text = null;
            FLUEX_INPUTVALUE f_inputValue = FLUEX_INPUTVALUE.SKIP;

            if(!_systemTask.ShowList())
            {
                Console.WriteLine("Task list is empty.");
                f_inputValue = FlueXInput.TextInput("1 - Create New Task / 2 - Load / 3 - Exit", ref f_num, 3, false, false);
                
            }
        }

        //Methods::Control Processes
            

        //Attributes
            FLUEX_SYSTEMSTATE   _systemState;

            //Included Systems
                FlueXUserSystem     _systemUser;
                FlueXProjectSystem  _systemProject;
                FlueXTaskSystem     _systemTask;
    }
}
