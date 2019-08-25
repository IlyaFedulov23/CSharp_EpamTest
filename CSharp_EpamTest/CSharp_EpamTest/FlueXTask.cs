using System;
using System.Collections.Generic;

// v1.1 d8/25/2019 

namespace CSharp_EpamTest
{
    enum FLUEX_PRIORITITYPE { LOW, MID, HIGH };

    [Serializable]
    class FlueXTask
    {
        // Class Constructors
            public FlueXTask(ref string f_topic, ref string f_type, FLUEX_PRIORITITYPE f_priorityType,
                ref FlueXUser f_user, ref FlueXProject f_project, ref string f_description, int f_id = 0)
            {
                _topic          = f_topic;
                _type           = f_type;
                _priorityType   = f_priorityType;
                _user           = f_user;
                _project        = f_project;
                _id             = f_id;
                _description    = f_description;
            }

        // Class Methods
            public void ShowInfo()
            {
                Console.Write($"{_project._name}\nTopic: {_topic}\nType: {_type}\nPriority: ");
                switch (_priorityType)
                {
                    case FLUEX_PRIORITITYPE.LOW:
                        Console.Write($"Low");
                        break;

                    case FLUEX_PRIORITITYPE.MID:
                        Console.Write($"Mid");
                        break;

                    case FLUEX_PRIORITITYPE.HIGH:
                        Console.Write($"High");
                        break;
                }
                Console.WriteLine();
                _user.ShowInfo();
                Console.WriteLine($"Description: {_description}\n");
            }

        // Class Variables
            public int  _id                 { get; set; }
            string      _topic;
            string      _type;
            string      _description;
            FLUEX_PRIORITITYPE  _priorityType;
            public FlueXUser    _user       { get; }
            public FlueXProject _project    { get; }
    }

    [Serializable]
    class FlueXTaskSystem
    {
        // Class Constructors
            public FlueXTaskSystem()
            {
                _listTask = new List<FlueXTask>();
            }

        // Class Methods
            public bool ShowList()
            {
                Console.Clear();
                if (_listTask.Count <= 0)
                {
                    return false;
                }
                else
                {
                    int f_counter = 0;
                    foreach (FlueXTask ft_task in _listTask)
                    {

                        Console.Write($"\t{f_counter + 1}.");
                        ft_task.ShowInfo();
                        f_counter++;
                    }
                }
                return true;
            }

            public bool DeleteElement()
            {
                // Function Variables 
                    int f_number = 0;

                // Function Body
                    if (0 == FlueXInput.TextInput("\nID of the deleted task", ref f_number, _listTask.Count, true, false, 1))
                        return false;

                    _listTask[f_number - 1]._user.DeleteTaskByID(_listTask[f_number - 1]._id);
                    _listTask[f_number - 1]._project.DeleteTaskByID(_listTask[f_number - 1]._id);
                    _listTask.RemoveAt(f_number - 1);

                // Successful Return Value
                    return true;
            }

        // Class Variables
            public int _idCounter;
            public List<FlueXTask> _listTask { get; }
    }

    [Serializable]
    class FlueXTaskAddition
    {
        // Class Constructor
            public FlueXTaskAddition()
            {
                _listTask = new List<FlueXTask>();
            }

        // Class Methods
            public bool ShowList()
            {
                Console.Clear();
                if (_listTask.Count <= 0)
                {
                    return false;
                }
                else
                {
                    int f_counter = 0;
                    foreach (FlueXTask ft_task in _listTask)
                    {
                        Console.Write($"\t{f_counter + 1}.");
                        ft_task.ShowInfo();
                        f_counter++;
                    }
                }
                return true;
            }

            public void DeleteTaskByID(int f_id)
            {
                int f_counter = 0;
                foreach (FlueXTask ft_task in _listTask)
                {
                    if (ft_task._id == f_id)
                    {
                        _listTask.RemoveAt(f_counter);
                        return;
                    }
                    f_counter++;
                }
            }

        // Class Variables
            public List<FlueXTask> _listTask { get; }
    }
}
