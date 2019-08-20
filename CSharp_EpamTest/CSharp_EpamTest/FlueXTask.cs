using System;
using System.Collections.Generic;

namespace CSharp_EpamTest
{
    enum FLUEX_PRIORITITYPE { LOW, MID, HIGH };

    class FlueXTask
    {
        //Constructor & Destructor
            public FlueXTask(ref string f_topic, ref string f_type, FLUEX_PRIORITITYPE f_priorityType,
                ref FlueXUser f_user, ref FlueXProject f_project, int f_id = 0)
            {
                _topic          = f_topic;
                _type           = f_type;
                _priorityType   = f_priorityType;
                _user           = f_user;
                _project        = f_project;
                _id             = f_id;
                _description    = null;
            }
            public FlueXTask(ref string f_topic, ref string f_type, FLUEX_PRIORITITYPE f_priorityType,
                ref FlueXUser f_user, ref FlueXProject f_project, ref string f_description, int f_id = 0) 
                    : this(ref f_topic, ref f_type, f_priorityType, ref f_user, ref f_project, f_id)
            {
                _description = f_description;
            }

        //Methods
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
                    default:
                        Console.Write($"Low");
                        break;
                }
                Console.WriteLine();
                _user.ShowInfo();
                Console.WriteLine($"Description: {_description}\n");
            }

        //Attributes
            public int          _id             { get; set; }
            string              _topic;
            string              _type;
            string              _description;
            FLUEX_PRIORITITYPE  _priorityType;
            public FlueXUser    _user           { get; }
            public FlueXProject _project        { get; }
    }

    class FlueXTaskSystem
    {
        //Constructor & Destructor 
        public FlueXTaskSystem()
        {
            _listTask = new List<FlueXTask>();
            _idCounter = 0;
        }

        //Methods
            public bool ShowList()
            {
                Console.Clear();
                if (_listTask.Count <= 0)
                {
                    return false;
                }
                else
                {
                    for (int i = 0; i < _listTask.Count; i++)
                    {
                        Console.Write($"\t{i + 1}.");
                        _listTask[i].ShowInfo();
                    }
                }
                return true;
            }

            public bool DeleteElement()
            {
            //Attributes
                int f_number = 0;

            //Body
                if (0 == FlueXInput.TextInput("\nID of the deleted task", ref f_number, _listTask.Count, true, false, 1))
                    return false;

                _listTask[f_number - 1]._user.DeleteTaskByID(_listTask[f_number - 1]._id);
                _listTask[f_number - 1]._project.DeleteTaskByID(_listTask[f_number - 1]._id);
                _listTask.RemoveAt(f_number - 1);

            //Successful return value
                return true;
            }


        //Attributes
            public int _idCounter;
            public List<FlueXTask> _listTask { get; }
    }
}
