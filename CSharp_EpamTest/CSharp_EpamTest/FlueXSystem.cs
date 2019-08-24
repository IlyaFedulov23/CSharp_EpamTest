using System;
using System.Collections.Generic;

// Version 1.0 - Ilya.F

namespace CSharp_EpamTest
{
    // EXIT - when you need to exit from main loop
        enum FLUEX_SYSTEMSTATE { EXIT, RUNNING, LOADING, SAVING }

    [Serializable]
    class FlueXSystem
    {
        // Class Constructors
            public FlueXSystem()
            {
                _systemState    = FLUEX_SYSTEMSTATE.RUNNING;
                _systemTask     = new FlueXTaskSystem();
                _systemUser     = new FlueXUserSystem();
                _systemProject  = new FlueXProjectSystem();
            }

        // Class Methods
            public void ShowInfo()
            {
                // Function Attributes
                    int     f_num       = 0;

                // Function Body
                    if(!_systemTask.ShowList()) // If user doesn't have tasks
                    {
                        Console.WriteLine("Task list is empty.");
                        FlueXInput.TextInput("1 - Create / 2 - Load / 3 - Users / 4 - Projects / 5 - Exit", ref f_num, 5);

                        switch(f_num)
                        {
                            case 1: // Creating New Task
                                if(!CreateTask())
                                    return;
                                break;

                            case 2: // Load From File
                                _systemState = FLUEX_SYSTEMSTATE.LOADING;
                                break;

                            case 3: // User List
                                if (!ControlUserList(ref f_num))
                                    return;
                                break;

                            case 4: // Project List
                                if (!ControlProjectList(ref f_num))
                                    return;
                                break;

                            case 5: // Close Program
                                _systemState = FLUEX_SYSTEMSTATE.EXIT;
                                break;
                        }
                    }
                    else // If user has tasks
                    {
                        FlueXInput.TextInput("1 - Create / 2 - Delete / 3 - Load / 4 - Save / 5 - Users / 6 - Projects / 7 - Exit", 
                            ref f_num, 7);
                        switch (f_num)
                        {
                            case 1: // Creating New Task
                                if (!CreateTask())
                                    return;
                                break;

                            case 2: // Delete Task
                                if (!_systemTask.DeleteElement())
                                    return;
                                break;

                            case 3: // Load From File
                                _systemState = FLUEX_SYSTEMSTATE.LOADING;
                                break;

                            case 4: // Save File
                                _systemState = FLUEX_SYSTEMSTATE.SAVING;
                                break;

                            case 5: // User List
                                if (!ControlUserList(ref f_num))
                                    return;
                                break;

                            case 6: // Project List
                                if (!ControlProjectList(ref f_num))
                                    return;
                                break;

                            case 7: // Close Program
                                _systemState = FLUEX_SYSTEMSTATE.EXIT;
                                break;
                        }
                    }
            }

        // Class Methods::Control Processes
            bool ControlUserList(ref int f_num, bool f_choise = false)
            {
                //Function Body 
                    while (true)
                    {
                        if (!_systemUser.ShowList()) // If List is empty
                        {
                            Console.WriteLine("User List is Empty");
                            if (0 == FlueXInput.TextInput("1 - Create", ref f_num, 1, true))
                                return false;
                            if (!_systemUser.AddElement())
                                return false;
                            continue;
                        }
                        else // If List has objects
                        {
                            if (f_choise)
                            {
                                if (0 == FlueXInput.TextInput("1 - Create / 2 - Delete / 3 - User Tasks / 4 - Select", ref f_num, 4, true))
                                    return false;
                            }
                            else
                            {
                                if (0 == FlueXInput.TextInput("1 - Create / 2 - Delete / 3 - User Tasks", ref f_num, 3, true))
                                    return false;
                            }
                            switch (f_num)
                            {
                                case 1: // Create User 
                                    if (!_systemUser.AddElement())
                                        return false;
                                    continue;

                                case 2: // Delete User 
                                    if (!_systemUser.DeleteElement())
                                        return false;
                                    continue;

                                case 3: // Check User Tasks
                                    if (0 == FlueXInput.TextInput("\nSelect User ID", ref f_num, _systemUser._listUser.Count, true, false))
                                        return false;

                                    if (!_systemUser._listUser[f_num - 1].ShowList())
                                    {
                                        Console.Write("ERROR:User doesn't have tasks!\nPress any key to return...");
                                        Console.ReadKey();
                                        return false;
                                    }

                                    Console.Write("Press any key to return...");
                                    Console.ReadKey();
                                    break;

                                case 4: // Select User to Continue
                                    if (0 == FlueXInput.TextInput("\nSelect User ID", ref f_num, _systemUser._listUser.Count, true, false))
                                        return false;
                                    break;
                            }
                        }
                        break;
                    }

                // Successful Return Value
                    return true;
            }

        bool ControlProjectList(ref int f_num, bool f_choise = false)
        {
            while (true)
            {
                if (!_systemProject.ShowList()) // If List is empty
                {
                    Console.WriteLine("Project List is Empty");
                    if (0 == FlueXInput.TextInput("1 - Create", ref f_num, 1, true))
                        return false;
                    if (!_systemProject.AddElement())
                        return false;
                    continue;
                }
                else // If List has projects
                {
                    if (f_choise)
                    {
                        if (0 == FlueXInput.TextInput("1 - Create / 2 - Delete / 3 - Select", ref f_num, 3, true))
                            return false;
                    }
                    else
                    {
                        if (0 == FlueXInput.TextInput("1 - Create / 2 - Delete", ref f_num, 3, true))
                            return false;
                    }
                    switch (f_num)
                    {
                        case 1:
                            if (!_systemProject.AddElement())
                                return false;
                            continue;

                        case 2:
                            if (!_systemProject.DeleteElement())
                                return false;
                            continue;

                        case 3:
                            if (0 == FlueXInput.TextInput("\nSelect Project ID", ref f_num, _systemUser._listUser.Count, true, false))
                                return false;
                            break;
                    }
                }
                break;
            }

            // Successful Return Value
                return true;
        }

        // Class Methods::Create
            bool CreateTask()
            {
                // Function Variables
                    int f_num               = 0;
                    FlueXProject f_project  = null;
                    FlueXUser f_user        = null;
                    string f_topic          = null;
                    string f_type           = null;
                    string f_description    = null;
                    FLUEX_PRIORITITYPE f_priorType = FLUEX_PRIORITITYPE.LOW;

                // Variables Defenition
                    if (!ControlUserList(ref f_num, true))
                        return false;
                    f_user = _systemUser._listUser[f_num - 1];

                    if (!ControlProjectList(ref f_num, true))
                        return false;
                    f_project = _systemProject._listProject[f_num - 1];

                    Console.Clear();
                    if (0 == FlueXInput.TextInput("Topic", ref f_topic, true))
                        return false;

                    Console.Clear();
                    if (0 == FlueXInput.TextInput("Type", ref f_type, true))
                        return false;

                    Console.Clear();
                    if (0 == FlueXInput.TextInput("Prioriti (1-3)", ref f_num, 3, true, false, 1))
                        return false;
                    f_priorType = (FLUEX_PRIORITITYPE)f_num - 1;

                    Console.Clear();
                    if (0 == FlueXInput.TextInput("Description", ref f_description, true))
                        return false;

                    // Create New Object
                        _systemTask._listTask.Add(new FlueXTask(ref f_topic, ref f_type, f_priorType,
                            ref f_user, ref f_project, ref f_description));
                        // Set Personal ID
                            _systemTask._listTask[_systemTask._listTask.Count - 1]._id = _systemTask._idCounter++;

                // Add Pointers
                    f_user._listTask.Add(_systemTask._listTask[_systemTask._listTask.Count - 1]);
                    f_project._listTask.Add(_systemTask._listTask[_systemTask._listTask.Count - 1]);

                // Successful Return Value
                    return true;
            }

        // Class Variables
            public FLUEX_SYSTEMSTATE   _systemState;

            // Included Systems
                FlueXUserSystem     _systemUser;
                FlueXProjectSystem  _systemProject;
                FlueXTaskSystem     _systemTask;
    }
}