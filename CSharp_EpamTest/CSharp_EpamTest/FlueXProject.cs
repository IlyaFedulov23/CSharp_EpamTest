using System;
using System.Collections.Generic;

namespace CSharp_EpamTest
{
    class FlueXProject
    {
        //Constructor & Destructor 
            public FlueXProject(ref string f_name)
            {
                _name = f_name;
            }

        //Methods
            public void ShowInfo()
            {
                Console.Write($"{_name}");
                Console.Write("\n\n");
            }

        //Attributes
            public string _name { get; set; }
    }

    class FlueXProjectSystem
    {
        //Constructor & Destructor
            public FlueXProjectSystem()
            {
                _listProject = new List<FlueXProject>();
            }

        //Methods
            public bool ShowList()
            {
                Console.Clear();
                if (_listProject.Count <= 0)
                {
                    return false;
                } else
                {
                    for(int i = 0; i < _listProject.Count; i++)
                    {
                        Console.Write($"{i + 1}.");
                        _listProject[i].ShowInfo();
                    }
                }
             
                return true;
            }

        public bool AddElement()
        {
            //Attributes
                string f_name = null;

            //Body
                Console.Clear();
                Console.WriteLine("\tAdding new project");

            if (0 == FlueXInput.TextInput("Project name", ref f_name, true))
                return false;

            _listProject.Add(new FlueXProject(ref f_name));

            return true;
        }

        public bool DeleteElement()
        {
            //Attributes
            int f_number = 0;

            //Body
            if(0 == FlueXInput.TextInput("\nID of the deleted project", ref f_number, _listProject.Count, true, false, 1))
                return false;

            _listProject.RemoveAt(f_number - 1);

            //Successful return value
                return true;
        }

        //Attributes
            public List<FlueXProject> _listProject { get; }
    }
}
