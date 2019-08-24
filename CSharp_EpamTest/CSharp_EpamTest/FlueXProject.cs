using System;
using System.Collections.Generic;

namespace CSharp_EpamTest
{
    [Serializable]
    class FlueXProject
    {
        // Class Constructors
            public FlueXProject(ref string f_name)
            {
                _name = f_name;
                _listTask = new List<FlueXTask>();
            }

        // Class Methods
            public void ShowInfo()
            {
                Console.Write($"{_name}");
                Console.Write("\n\n");
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
            public string _name                 { get; set; }
            public List<FlueXTask> _listTask    { get; }
    }

    [Serializable]
    class FlueXProjectSystem
    {
        // Class Constructors
            public FlueXProjectSystem()
            {
                _listProject = new List<FlueXProject>();
            }

        // Class Methods
            public bool ShowList()
            {
                Console.Clear();
                if (_listProject.Count <= 0)
                {
                    return false;
                }
                else
                {
                    int f_counter = 0;
                    foreach (FlueXProject ft_project in _listProject)
                    {
                        Console.Write($"{f_counter + 1}.");
                        ft_project.ShowInfo();
                        f_counter++;
                    }
                    return true;
                }
            }

            public bool AddElement()
            {
                // Function Variables
                    string f_name = null;

                // Function Body
                    Console.Clear();
                    Console.WriteLine("\tAdding new project");

                    if (0 == FlueXInput.TextInput("Project name", ref f_name, true))
                        return false;

                    _listProject.Add(new FlueXProject(ref f_name));

                // Successful Return Value
                    return true;
            }

            public bool DeleteElement()
            {
                // Function Variables
                    int f_number = 0;

                // Function Body
                    while (true)
                    {
                        if (0 == FlueXInput.TextInput("\nID of the deleted project", ref f_number, _listProject.Count, true, false, 1))
                            return false;
                        else if (_listProject[f_number - 1]._listTask.Count > 0)
                        {
                            Console.WriteLine("ERROR: This project has tasks!");
                            continue;
                        }
                        _listProject.RemoveAt(f_number - 1);
                        break;
                    }

                // Successful return value
                    return true;
            }

        // Class Variables
            public List<FlueXProject> _listProject { get; }
    }
}
