using System;

namespace CSharp_EpamTest
{
    enum PRIORITI_TYPE { P_LOW, P_MID, P_HIGH };

    class FlueXTask
    {
        //Constructor & Destructor
            public FlueXTask(ref string f_topic, ref string f_type, PRIORITI_TYPE f_priorityType,
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
            public FlueXTask(ref string f_topic, ref string f_type, PRIORITI_TYPE f_priorityType,
                ref FlueXUser f_user, ref FlueXProject f_project, ref string f_description, int f_id = 0) 
                    : this(ref f_topic, ref f_type, f_priorityType, ref f_user, ref f_project, f_id)
            {
                _description = f_description;
            }

        //Methods
        public void ShowInfo()
            {
                Console.WriteLine($"{_id}.{_project._name}");

                //If user has patronymic
                if (_user._patronymic.Length >= 1)
                {
                    Console.WriteLine($"\tИсполнитель: {_user._name} {_user._surname} {_user._patronymic}");
                } else
                {
                    Console.WriteLine($"\tИсполнитель: {_user._name} {_user._surname}");
                }

                Console.WriteLine($"\t{_topic} / {_type} / {_priorityType}");

                //if task has description
                if (_description.Length >= 1)
                {
                    Console.WriteLine($"\nОписание:\t{_description}");
                }
            }

    //Attributes
            int             _id;
            string          _topic;
            string          _type;
            string          _description;
            PRIORITI_TYPE   _priorityType;
            FlueXUser       _user;
            FlueXProject    _project;
    }
}
